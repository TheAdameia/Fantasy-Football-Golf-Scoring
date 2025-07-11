using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using FantasyGolfball.Data;
using FantasyGolfball.Services;
using FantasyGolfball.Models.Events;
using FantasyGolfball.Models.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opts =>
{
    opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddCors(options => {
    options.AddPolicy("AllowFrontend",
    policy =>
    {
        policy.WithOrigins(
                "http://localhost:5173",
                "https://fantasygolfball.org")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

builder.Services.AddSingleton<IDraftService, DraftService>(); // registers IDraftService and its implementation, Singleton instead of scopes means there will only be one persistent instance across the app's runtime
builder.Services.AddScoped<FantasyGolfballDbContext>();

builder.Services.AddSingleton<IMatchupService, MatchupService>();
builder.Services.AddSingleton<IEventBus, EventBus>();
builder.Services.AddHostedService<WeekAdvancementService>(); // cronjob to see when currentWeek changes
builder.Services.AddSingleton<WeekAdvancementListenerService>(); // listens for week change
builder.Services.AddSingleton<TradeEffectuationService>(); // checks for trades after WALS calculations
builder.Services.AddSingleton<ScoreRevealService>(); // handles score reveal for matchups

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.Cookie.Name = "FantasyGolfballLoginCookie";
        options.Cookie.SameSite = SameSiteMode.Strict;
        options.Cookie.HttpOnly = true; //The cookie cannot be accessed through JS (protects against XSS)
        options.Cookie.MaxAge = new TimeSpan(7, 0, 0, 0); // cookie expires in a week regardless of activity
        options.SlidingExpiration = true; // extend the cookie lifetime with activity up to 7 days.
        options.ExpireTimeSpan = new TimeSpan(24, 0, 0); // Cookie will expire in 24 hours without activity
        options.Events.OnRedirectToLogin = (context) =>
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        };
        options.Events.OnRedirectToAccessDenied = (context) =>
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            return Task.CompletedTask;
        };
    });

builder.Services.AddIdentityCore<IdentityUser>(config =>
            {
                config.Password.RequireDigit = false;
                config.Password.RequiredLength = 3;
                config.Password.RequireLowercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                config.User.RequireUniqueEmail = true;
            })
    .AddRoles<IdentityRole>()  //add the role service.  
    .AddEntityFrameworkStores<FantasyGolfballDbContext>();


// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<FantasyGolfballDbContext>(builder.Configuration["FantasyGolfballDbConnectionString"]);


var app = builder.Build();

app.UseCors("AllowFrontend");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

 // app.UseHttpsRedirection(); // commented out for server config
// these two calls are required to add auth to the pipeline for a request
app.UseAuthentication();
app.UseAuthorization();

// Creating a SignalR hub for draft chat
app.MapHub<ChatHub>("/chathub");
// Creating a SignalR hub for draft services
app.MapHub<LiveDraftHub>("/draftHub");
// SignalR hub for score reveal
app.MapHub<ScoreRevealHub>("/scorerevealhub");

// forcing services to initialize when the app starts to run
var matchupService = app.Services.GetRequiredService<IMatchupService>();
var weekListenerService = app.Services.GetRequiredService<WeekAdvancementListenerService>();
var tradeEffectuationService = app.Services.GetRequiredService<TradeEffectuationService>();
var scoreRevealService = app.Services.GetRequiredService<ScoreRevealService>();

// cleanup initializer
ScoreRevealCache.StartCleanup(TimeSpan.FromHours(2));


app.MapControllers();

app.Run();

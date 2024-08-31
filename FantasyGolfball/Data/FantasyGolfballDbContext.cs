using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FantasyGolfball.Models;
using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Data;
public class FantasyGolfballDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<Bike> Bikes { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }

    public FantasyGolfballDbContext(DbContextOptions<FantasyGolfballDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Administrator",
            Email = "admina@strator.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Admina",
            LastName = "Strator",
            Address = "101 Main Street",
        });
        // left this in here as an example for myself
        modelBuilder.Entity<Bike>().HasData(new Bike[]
        {
            new Bike
            {
                Id = 1,
                Brand = "Schwinn",
                Color = "Blue",
                OwnerId = 1,
                BikeTypeId = 1
            },
            new Bike
            {
                Id = 2,
                Brand = "Huffy",
                Color = "Red",
                OwnerId = 1,
                BikeTypeId = 3
            },
            new Bike
            {
                Id = 3,
                Brand = "Cannondale",
                Color = "Purple",
                OwnerId = 2,
                BikeTypeId = 2
            },
            new Bike
            {
                Id = 4,
                Brand = "Giant",
                Color = "Green",
                OwnerId = 3,
                BikeTypeId = 1
            },
        });
    }
}
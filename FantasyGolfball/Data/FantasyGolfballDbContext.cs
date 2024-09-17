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
        });
        modelBuilder.Entity<Position>().HasData(new Position[]
        {
            new Position
            {
                PositionId = 1,
                PositionShort = "QB",
                PositionLong = "Quarterback"
            },
            new Position
            {
                PositionId = 2,
                PositionShort = "WR",
                PositionLong = "Wide Receiver"
            },
            new Position
            {
                PositionId = 3,
                PositionShort = "RB",
                PositionLong = "Running Back"
            },
            new Position
            {
                PositionId = 4,
                PositionShort = "TE",
                PositionLong = "Tight End"
            },
            new Position
            {
                PositionId = 5,
                PositionShort = "K",
                PositionLong = "Kicker"
            },
            new Position
            {
                PositionId = 6,
                PositionShort = "DEF",
                PositionLong = "Defense"
            }
        });
        modelBuilder.Entity<Status>().HasData(new Status[
            new Status
            {
                StatusId = 1,
                StatusType = "Green",
                ViableToPlay = true,
                RequiresBackup = false
            },
            new Status
            {
                StatusId = 2,
                StatusType = "IR",
                ViableToPlay = false,
                RequiresBackup = true
            },
            new Status
            {
                StatusId = 3,
                StatusType = "O",
                ViableToPlay = false,
                RequiresBackup = true
            },
            new Status
            {
                StatusId = 4,
                StatusType = "Q",
                ViableToPlay = true,
                RequiresBackup = true
            },
            new Status
            {
                StatusId = 5,
                StatusType = "D",
                ViableToPlay = true,
                RequiresBackup = true
            },
            new Status
            {
                StatusId = 6,
                StatusType = "SSPD",
                ViableToPlay = false,
                RequiresBackup = true
            }
        ]);
        modelBuilder.Entity<Player>().HasData(new Player[]
        {
            new Player
            {
                PlayerId = 1,
                PlayerFirstName = "Bob",
                PlayerLastName = "McCarthy",
                PositionId = "QB",
            }
        });
        modelBuilder.Entity<Scoring>().HasData(new Scoring[]
        {
            new Scoring
            {
                ScoringId = 1,
                PlayerId = 1,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 5.1F
            }
        })
    }
}
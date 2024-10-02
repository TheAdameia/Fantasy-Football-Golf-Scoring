using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FantasyGolfball.Models;
using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Data;
public class FantasyGolfballDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<League> Leagues { get; set; }
    public DbSet<Matchup> Matchups { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Roster> Rosters { get; set; }
    public DbSet<RosterPlayer> RosterPlayers { get; set; }
    public DbSet<Scoring> Scorings { get; set; }
    public DbSet<Status> Statuses { get; set; }
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
        modelBuilder.Entity<Status>().HasData(new Status[]
        {
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
        });
        modelBuilder.Entity<Player>().HasData(new Player[]
        {
            // Ton of fabricated data for testing purposes
            // Quarterbacks
            new Player
            {
                PlayerId = 1,
                PlayerFirstName = "Jake",
                PlayerLastName = "Mason",
                PositionId = 1,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 2,
                PlayerFirstName = "Evan",
                PlayerLastName = "Carter",
                PositionId = 1,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 3,
                PlayerFirstName = "Derek",
                PlayerLastName = "Henderson",
                PositionId = 1,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 4,
                PlayerFirstName = "Marcus",
                PlayerLastName = "Wells",
                PositionId = 1,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 5,
                PlayerFirstName = "Tyler",
                PlayerLastName = "Nash",
                PositionId = 1,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 6,
                PlayerFirstName = "Brad",
                PlayerLastName = "McKinney",
                PositionId = 1,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 7,
                PlayerFirstName = "Chris",
                PlayerLastName = "Johnson",
                PositionId = 1,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 8,
                PlayerFirstName = "Brandon",
                PlayerLastName = "Richards",
                PositionId = 1,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 9,
                PlayerFirstName = "Kyle",
                PlayerLastName = "Foster",
                PositionId = 1,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 10,
                PlayerFirstName = "Matt",
                PlayerLastName = "Griffin",
                PositionId = 1,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 11,
                PlayerFirstName = "Trevor",
                PlayerLastName = "Burns",
                PositionId = 1,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 12,
                PlayerFirstName = "Grant",
                PlayerLastName = "Hunter",
                PositionId = 1,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 13,
                PlayerFirstName = "Dylan",
                PlayerLastName = "Reed",
                PositionId = 1,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 14,
                PlayerFirstName = "Nick",
                PlayerLastName = "Evans",
                PositionId = 1,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 15,
                PlayerFirstName = "Scott",
                PlayerLastName = "Bailey",
                PositionId = 1,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 16,
                PlayerFirstName = "Troy",
                PlayerLastName = "Farmer",
                PositionId = 1,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 17,
                PlayerFirstName = "Zach",
                PlayerLastName = "Lowe",
                PositionId = 1,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 18,
                PlayerFirstName = "Hunter",
                PlayerLastName = "Murphy",
                PositionId = 1,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 19,
                PlayerFirstName = "Austin",
                PlayerLastName = "Patterson",
                PositionId = 1,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 20,
                PlayerFirstName = "Caleb",
                PlayerLastName = "Harrison",
                PositionId = 1,
                StatusId = 1,
            },

            // Tight Ends
            new Player
            {
                PlayerId = 21,
                PlayerFirstName = "Ryan",
                PlayerLastName = "Fitzgerald",
                PositionId = 4,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 22,
                PlayerFirstName = "Mason",
                PlayerLastName = "Scott",
                PositionId = 4,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 23,
                PlayerFirstName = "Jordan",
                PlayerLastName = "Brooks",
                PositionId = 4,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 24,
                PlayerFirstName = "Jason",
                PlayerLastName = "Douglas",
                PositionId = 4,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 25,
                PlayerFirstName = "Alex",
                PlayerLastName = "Cooper",
                PositionId = 4,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 26,
                PlayerFirstName = "Chase",
                PlayerLastName = "Garrett",
                PositionId = 4,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 27,
                PlayerFirstName = "Cody",
                PlayerLastName = "Thompson",
                PositionId = 4,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 28,
                PlayerFirstName = "Landon",
                PlayerLastName = "Pearson",
                PositionId = 4,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 29,
                PlayerFirstName = "Jared",
                PlayerLastName = "Dunn",
                PositionId = 4,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 30,
                PlayerFirstName = "Drew",
                PlayerLastName = "Cross",
                PositionId = 4,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 31,
                PlayerFirstName = "Colin",
                PlayerLastName = "Shelby",
                PositionId = 4,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 32,
                PlayerFirstName = "Garrett",
                PlayerLastName = "Coleman",
                PositionId = 4,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 33,
                PlayerFirstName = "Bryce",
                PlayerLastName = "Fowler",
                PositionId = 4,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 34,
                PlayerFirstName = "Clay",
                PlayerLastName = "Sanders",
                PositionId = 4,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 35,
                PlayerFirstName = "Isaac",
                PlayerLastName = "McLean",
                PositionId = 4,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 36,
                PlayerFirstName = "Cole",
                PlayerLastName = "Washington",
                PositionId = 4,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 37,
                PlayerFirstName = "Blake",
                PlayerLastName = "Morris",
                PositionId = 4,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 38,
                PlayerFirstName = "Nate",
                PlayerLastName = "Bryant",
                PositionId = 4,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 39,
                PlayerFirstName = "Jesse",
                PlayerLastName = "Holmes",
                PositionId = 4,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 40,
                PlayerFirstName = "Connor",
                PlayerLastName = "Davis",
                PositionId = 4,
                StatusId = 1,
            },

            // Kickers
            new Player
            {
                PlayerId = 41,
                PlayerFirstName = "Lucas",
                PlayerLastName = "Smith",
                PositionId = 5,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 42,
                PlayerFirstName = "Noah",
                PlayerLastName = "Johnson",
                PositionId = 5,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 43,
                PlayerFirstName = "Ethan",
                PlayerLastName = "Williams",
                PositionId = 5,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 44,
                PlayerFirstName = "Logan",
                PlayerLastName = "Jones",
                PositionId = 5,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 45,
                PlayerFirstName = "Mason",
                PlayerLastName = "Brown",
                PositionId = 5,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 46,
                PlayerFirstName = "Oliver",
                PlayerLastName = "Davis",
                PositionId = 5,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 47,
                PlayerFirstName = "Liam",
                PlayerLastName = "Miller",
                PositionId = 5,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 48,
                PlayerFirstName = "Jacob",
                PlayerLastName = "Wilson",
                PositionId = 5,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 49,
                PlayerFirstName = "James",
                PlayerLastName = "Moore",
                PositionId = 5,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 50,
                PlayerFirstName = "Benjamin",
                PlayerLastName = "Taylor",
                PositionId = 5,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 51,
                PlayerFirstName = "Henry",
                PlayerLastName = "Anderson",
                PositionId = 5,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 52,
                PlayerFirstName = "Owen",
                PlayerLastName = "Thomas",
                PositionId = 5,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 53,
                PlayerFirstName = "William",
                PlayerLastName = "Jackson",
                PositionId = 5,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 54,
                PlayerFirstName = "Elijah",
                PlayerLastName = "White",
                PositionId = 5,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 55,
                PlayerFirstName = "Jackson",
                PlayerLastName = "Harris",
                PositionId = 5,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 56,
                PlayerFirstName = "Gabriel",
                PlayerLastName = "Clark",
                PositionId = 5,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 57,
                PlayerFirstName = "Sebastian",
                PlayerLastName = "Rodriguez",
                PositionId = 5,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 58,
                PlayerFirstName = "Daniel",
                PlayerLastName = "Lewis",
                PositionId = 5,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 59,
                PlayerFirstName = "Nathan",
                PlayerLastName = "Walker",
                PositionId = 5,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 60,
                PlayerFirstName = "Ethan",
                PlayerLastName = "Adams",
                PositionId = 5,
                StatusId = 1,
            },

            // Wide Receivers
            new Player
            {
                PlayerId = 61,
                PlayerFirstName = "Aiden",
                PlayerLastName = "Miller",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 62,
                PlayerFirstName = "Liam",
                PlayerLastName = "Brown",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 63,
                PlayerFirstName = "Alexander",
                PlayerLastName = "Jones",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 64,
                PlayerFirstName = "Joseph",
                PlayerLastName = "Garcia",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 65,
                PlayerFirstName = "Samuel",
                PlayerLastName = "Martinez",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 66,
                PlayerFirstName = "Matthew",
                PlayerLastName = "Hernandez",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 67,
                PlayerFirstName = "David",
                PlayerLastName = "Lopez",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 68,
                PlayerFirstName = "Andrew",
                PlayerLastName = "Gonzalez",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 69,
                PlayerFirstName = "Joshua",
                PlayerLastName = "Wilson",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 70,
                PlayerFirstName = "Christopher",
                PlayerLastName = "Perez",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 71,
                PlayerFirstName = "Thomas",
                PlayerLastName = "Taylor",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 72,
                PlayerFirstName = "John",
                PlayerLastName = "Anderson",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 73,
                PlayerFirstName = "James",
                PlayerLastName = "Thomas",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 74,
                PlayerFirstName = "Brian",
                PlayerLastName = "Jackson",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 75,
                PlayerFirstName = "Nicholas",
                PlayerLastName = "White",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 76,
                PlayerFirstName = "Justin",
                PlayerLastName = "Harris",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 77,
                PlayerFirstName = "Aaron",
                PlayerLastName = "Clark",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 78,
                PlayerFirstName = "Zachary",
                PlayerLastName = "Lewis",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 79,
                PlayerFirstName = "Paul",
                PlayerLastName = "Walker",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 80,
                PlayerFirstName = "Eric",
                PlayerLastName = "Young",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 81,
                PlayerFirstName = "Sean",
                PlayerLastName = "King",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 82,
                PlayerFirstName = "Ray",
                PlayerLastName = "Scott",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 83,
                PlayerFirstName = "Derek",
                PlayerLastName = "Adams",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 84,
                PlayerFirstName = "Kevin",
                PlayerLastName = "Baker",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 85,
                PlayerFirstName = "Tony",
                PlayerLastName = "Collins",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 86,
                PlayerFirstName = "Cameron",
                PlayerLastName = "Cox",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 87,
                PlayerFirstName = "Adam",
                PlayerLastName = "Stewart",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 88,
                PlayerFirstName = "Kyle",
                PlayerLastName = "Turner",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 89,
                PlayerFirstName = "Greg",
                PlayerLastName = "Hughes",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 90,
                PlayerFirstName = "Mike",
                PlayerLastName = "Ramirez",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 91,
                PlayerFirstName = "Patrick",
                PlayerLastName = "Ross",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 92,
                PlayerFirstName = "Alex",
                PlayerLastName = "Powell",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 93,
                PlayerFirstName = "Steven",
                PlayerLastName = "Griffin",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 94,
                PlayerFirstName = "Bill",
                PlayerLastName = "Brooks",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 95,
                PlayerFirstName = "Daniel",
                PlayerLastName = "Kelly",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 96,
                PlayerFirstName = "Rob",
                PlayerLastName = "Foster",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 97,
                PlayerFirstName = "Jeff",
                PlayerLastName = "Reed",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 98,
                PlayerFirstName = "Phil",
                PlayerLastName = "Patterson",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 99,
                PlayerFirstName = "Larry",
                PlayerLastName = "Burns",
                PositionId = 2,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 100,
                PlayerFirstName = "Jackson",
                PlayerLastName = "Wilson",
                PositionId = 2,
                StatusId = 1,
            },

            // Running Backs
            new Player
            {
                PlayerId = 101,
                PlayerFirstName = "Owen",
                PlayerLastName = "Taylor",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 102,
                PlayerFirstName = "Logan",
                PlayerLastName = "Lee",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 103,
                PlayerFirstName = "Dylan",
                PlayerLastName = "Perez",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 104,
                PlayerFirstName = "Aiden",
                PlayerLastName = "Gonzalez",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 105,
                PlayerFirstName = "Elijah",
                PlayerLastName = "Mitchell",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 106,
                PlayerFirstName = "Henry",
                PlayerLastName = "Carter",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 107,
                PlayerFirstName = "Ethan",
                PlayerLastName = "Torres",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 108,
                PlayerFirstName = "Alexander",
                PlayerLastName = "Evans",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 109,
                PlayerFirstName = "Logan",
                PlayerLastName = "Edwards",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 110,
                PlayerFirstName = "Jackson",
                PlayerLastName = "Collins",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 111,
                PlayerFirstName = "Landon",
                PlayerLastName = "Morris",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 112,
                PlayerFirstName = "Bryson",
                PlayerLastName = "Murphy",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 113,
                PlayerFirstName = "Parker",
                PlayerLastName = "Powell",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 114,
                PlayerFirstName = "Jameson",
                PlayerLastName = "Sullivan",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 115,
                PlayerFirstName = "Bentley",
                PlayerLastName = "Bryant",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 116,
                PlayerFirstName = "Carson",
                PlayerLastName = "Newton",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 117,
                PlayerFirstName = "Braxton",
                PlayerLastName = "Lambert",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 118,
                PlayerFirstName = "Tucker",
                PlayerLastName = "Cruz",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 119,
                PlayerFirstName = "Zane",
                PlayerLastName = "Owen",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 120,
                PlayerFirstName = "Rowan",
                PlayerLastName = "Knight",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 121,
                PlayerFirstName = "Harrison",
                PlayerLastName = "Lane",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 122,
                PlayerFirstName = "Weston",
                PlayerLastName = "Hicks",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 123,
                PlayerFirstName = "Finley",
                PlayerLastName = "Abbott",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 124,
                PlayerFirstName = "Sullivan",
                PlayerLastName = "Reeves",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 125,
                PlayerFirstName = "Reid",
                PlayerLastName = "Jenkins",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 126,
                PlayerFirstName = "Archer",
                PlayerLastName = "Gibson",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 127,
                PlayerFirstName = "Rhys",
                PlayerLastName = "Parks",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 128,
                PlayerFirstName = "Knox",
                PlayerLastName = "Greene",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 129,
                PlayerFirstName = "Brody",
                PlayerLastName = "Austin",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 130,
                PlayerFirstName = "Cade",
                PlayerLastName = "Wells",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 131,
                PlayerFirstName = "Theo",
                PlayerLastName = "Wagner",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 132,
                PlayerFirstName = "Sterling",
                PlayerLastName = "Rice",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 133,
                PlayerFirstName = "Jude",
                PlayerLastName = "Hayes",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 134,
                PlayerFirstName = "Crosby",
                PlayerLastName = "Houston",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 135,
                PlayerFirstName = "Porter",
                PlayerLastName = "Hale",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 136,
                PlayerFirstName = "Beckham",
                PlayerLastName = "Wallace",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 137,
                PlayerFirstName = "Judah",
                PlayerLastName = "Leonard",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 138,
                PlayerFirstName = "Griffin",
                PlayerLastName = "Todd",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 139,
                PlayerFirstName = "Phoenix",
                PlayerLastName = "Webb",
                PositionId = 3,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 140,
                PlayerFirstName = "Dawson",
                PlayerLastName = "Sanders",
                PositionId = 3,
                StatusId = 1,
            },

            // Defense
            new Player
            {
                PlayerId = 141,
                PlayerFirstName = "Denver",
                PlayerLastName = "Thunderbirds",
                PositionId = 6,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 142,
                PlayerFirstName = "Atlanta",
                PlayerLastName = "Vipers",
                PositionId = 6,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 143,
                PlayerFirstName = "Houston",
                PlayerLastName = "Ironhounds",
                PositionId = 6,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 144,
                PlayerFirstName = "Chicago",
                PlayerLastName = "Stallions",
                PositionId = 6,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 145,
                PlayerFirstName = "Seattle",
                PlayerLastName = "Warhawks",
                PositionId = 6,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 146,
                PlayerFirstName = "Orlando",
                PlayerLastName = "Cyclones",
                PositionId = 6,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 147,
                PlayerFirstName = "Nashville",
                PlayerLastName = "Guardians",
                PositionId = 6,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 148,
                PlayerFirstName = "Portland",
                PlayerLastName = "Lumberjacks",
                PositionId = 6,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 149,
                PlayerFirstName = "Las Vegas",
                PlayerLastName = "Outlaws",
                PositionId = 6,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 150,
                PlayerFirstName = "Kansas City",
                PlayerLastName = "Redtails",
                PositionId = 6,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 151,
                PlayerFirstName = "Phoenix",
                PlayerLastName = "Firestorm",
                PositionId = 6,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 152,
                PlayerFirstName = "Brooklyn",
                PlayerLastName = "Sentinels",
                PositionId = 6,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 153,
                PlayerFirstName = "Miami",
                PlayerLastName = "Hurricanes",
                PositionId = 6,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 154,
                PlayerFirstName = "San Diego",
                PlayerLastName = "Tritons",
                PositionId = 6,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 155,
                PlayerFirstName = "Detroit",
                PlayerLastName = "Phantoms",
                PositionId = 6,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 156,
                PlayerFirstName = "Carolina",
                PlayerLastName = "Cobras",
                PositionId = 6,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 157,
                PlayerFirstName = "New Jersey",
                PlayerLastName = "Rampage",
                PositionId = 6,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 158,
                PlayerFirstName = "St. Louis",
                PlayerLastName = "Renegades",
                PositionId = 6,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 159,
                PlayerFirstName = "Oklahoma City",
                PlayerLastName = "Mustangs",
                PositionId = 6,
                StatusId = 1,
            },
            new Player
            {
                PlayerId = 160,
                PlayerFirstName = "Cincinnati",
                PlayerLastName = "Scorpions",
                PositionId = 6,
                StatusId = 1,
            },

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
            },

            new Scoring
            {
                ScoringId = 2,
                PlayerId = 1,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 5.5F
            },

            new Scoring
            {
                ScoringId = 3,
                PlayerId = 1,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 5.7F
            },

            new Scoring
            {
                ScoringId = 4,
                PlayerId = 1,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 1.4F
            },

            new Scoring
            {
                ScoringId = 5,
                PlayerId = 2,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -4.3F
            },

            new Scoring
            {
                ScoringId = 6,
                PlayerId = 2,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 16.8F
            },

            new Scoring
            {
                ScoringId = 7,
                PlayerId = 2,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 10.8F
            },

            new Scoring
            {
                ScoringId = 8,
                PlayerId = 2,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 4.3F
            },

            new Scoring
            {
                ScoringId = 9,
                PlayerId = 3,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 10.0F
            },

            new Scoring
            {
                ScoringId = 10,
                PlayerId = 3,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 0.2F
            },

            new Scoring
            {
                ScoringId = 11,
                PlayerId = 3,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -0.2F
            },

            new Scoring
            {
                ScoringId = 12,
                PlayerId = 3,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -1.1F
            },

            new Scoring
            {
                ScoringId = 13,
                PlayerId = 4,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 18.7F
            },

            new Scoring
            {
                ScoringId = 14,
                PlayerId = 4,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 2.7F
            },

            new Scoring
            {
                ScoringId = 15,
                PlayerId = 4,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 18.2F
            },

            new Scoring
            {
                ScoringId = 16,
                PlayerId = 4,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 2.3F
            },

            new Scoring
            {
                ScoringId = 17,
                PlayerId = 5,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 15.5F
            },

            new Scoring
            {
                ScoringId = 18,
                PlayerId = 5,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 6.2F
            },

            new Scoring
            {
                ScoringId = 19,
                PlayerId = 5,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 9.6F
            },

            new Scoring
            {
                ScoringId = 20,
                PlayerId = 5,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -4.7F
            },

            new Scoring
            {
                ScoringId = 21,
                PlayerId = 6,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 2.9F
            },

            new Scoring
            {
                ScoringId = 22,
                PlayerId = 6,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 1.4F
            },

            new Scoring
            {
                ScoringId = 23,
                PlayerId = 6,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 0.1F
            },

            new Scoring
            {
                ScoringId = 24,
                PlayerId = 6,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 0.2F
            },

            new Scoring
            {
                ScoringId = 25,
                PlayerId = 7,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -3.1F
            },

            new Scoring
            {
                ScoringId = 26,
                PlayerId = 7,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 15.0F
            },

            new Scoring
            {
                ScoringId = 27,
                PlayerId = 7,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -2.4F
            },

            new Scoring
            {
                ScoringId = 28,
                PlayerId = 7,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 7.6F
            },

            new Scoring
            {
                ScoringId = 29,
                PlayerId = 8,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 12.8F
            },

            new Scoring
            {
                ScoringId = 30,
                PlayerId = 8,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 14.0F
            },

            new Scoring
            {
                ScoringId = 31,
                PlayerId = 8,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 16.1F
            },

            new Scoring
            {
                ScoringId = 32,
                PlayerId = 8,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 7.8F
            },

            new Scoring
            {
                ScoringId = 33,
                PlayerId = 9,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 17.9F
            },

            new Scoring
            {
                ScoringId = 34,
                PlayerId = 9,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 2.2F
            },

            new Scoring
            {
                ScoringId = 35,
                PlayerId = 9,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -4.5F
            },

            new Scoring
            {
                ScoringId = 36,
                PlayerId = 9,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -3.3F
            },

            new Scoring
            {
                ScoringId = 37,
                PlayerId = 10,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 20.0F
            },

            new Scoring
            {
                ScoringId = 38,
                PlayerId = 10,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -2.7F
            },

            new Scoring
            {
                ScoringId = 39,
                PlayerId = 10,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 17.2F
            },

            new Scoring
            {
                ScoringId = 40,
                PlayerId = 10,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 18.2F
            },

            new Scoring
            {
                ScoringId = 41,
                PlayerId = 11,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 10.8F
            },

            new Scoring
            {
                ScoringId = 42,
                PlayerId = 11,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 3.9F
            },

            new Scoring
            {
                ScoringId = 43,
                PlayerId = 11,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -2.6F
            },

            new Scoring
            {
                ScoringId = 44,
                PlayerId = 11,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 18.9F
            },

            new Scoring
            {
                ScoringId = 45,
                PlayerId = 12,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 12.3F
            },

            new Scoring
            {
                ScoringId = 46,
                PlayerId = 12,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 17.0F
            },

            new Scoring
            {
                ScoringId = 47,
                PlayerId = 12,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 4.5F
            },

            new Scoring
            {
                ScoringId = 48,
                PlayerId = 12,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -4.0F
            },

            new Scoring
            {
                ScoringId = 49,
                PlayerId = 13,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -4.7F
            },

            new Scoring
            {
                ScoringId = 50,
                PlayerId = 13,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -1.2F
            },

            new Scoring
            {
                ScoringId = 51,
                PlayerId = 13,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 9.3F
            },

            new Scoring
            {
                ScoringId = 52,
                PlayerId = 13,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 16.1F
            },

            new Scoring
            {
                ScoringId = 53,
                PlayerId = 14,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 0.4F
            },

            new Scoring
            {
                ScoringId = 54,
                PlayerId = 14,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 4.9F
            },

            new Scoring
            {
                ScoringId = 55,
                PlayerId = 14,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -4.8F
            },

            new Scoring
            {
                ScoringId = 56,
                PlayerId = 14,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 3.6F
            },

            new Scoring
            {
                ScoringId = 57,
                PlayerId = 15,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 12.6F
            },

            new Scoring
            {
                ScoringId = 58,
                PlayerId = 15,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -2.6F
            },

            new Scoring
            {
                ScoringId = 59,
                PlayerId = 15,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 2.7F
            },

            new Scoring
            {
                ScoringId = 60,
                PlayerId = 15,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 4.9F
            },

            new Scoring
            {
                ScoringId = 61,
                PlayerId = 16,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 13.7F
            },

            new Scoring
            {
                ScoringId = 62,
                PlayerId = 16,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -2.2F
            },

            new Scoring
            {
                ScoringId = 63,
                PlayerId = 16,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 9.8F
            },

            new Scoring
            {
                ScoringId = 64,
                PlayerId = 16,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 9.8F
            },

            new Scoring
            {
                ScoringId = 65,
                PlayerId = 17,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 19.5F
            },

            new Scoring
            {
                ScoringId = 66,
                PlayerId = 17,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 6.6F
            },

            new Scoring
            {
                ScoringId = 67,
                PlayerId = 17,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 16.6F
            },

            new Scoring
            {
                ScoringId = 68,
                PlayerId = 17,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 8.3F
            },

            new Scoring
            {
                ScoringId = 69,
                PlayerId = 18,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -4.5F
            },

            new Scoring
            {
                ScoringId = 70,
                PlayerId = 18,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 9.9F
            },

            new Scoring
            {
                ScoringId = 71,
                PlayerId = 18,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 18.4F
            },

            new Scoring
            {
                ScoringId = 72,
                PlayerId = 18,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -4.6F
            },

            new Scoring
            {
                ScoringId = 73,
                PlayerId = 19,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -4.8F
            },

            new Scoring
            {
                ScoringId = 74,
                PlayerId = 19,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 1.8F
            },

            new Scoring
            {
                ScoringId = 75,
                PlayerId = 19,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 7.9F
            },

            new Scoring
            {
                ScoringId = 76,
                PlayerId = 19,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 12.4F
            },

            new Scoring
            {
                ScoringId = 77,
                PlayerId = 20,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 10.4F
            },

            new Scoring
            {
                ScoringId = 78,
                PlayerId = 20,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -3.6F
            },

            new Scoring
            {
                ScoringId = 79,
                PlayerId = 20,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 0.1F
            },

            new Scoring
            {
                ScoringId = 80,
                PlayerId = 20,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -1.8F
            },

            new Scoring
            {
                ScoringId = 81,
                PlayerId = 21,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 1.5F
            },

            new Scoring
            {
                ScoringId = 82,
                PlayerId = 21,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 2.4F
            },

            new Scoring
            {
                ScoringId = 83,
                PlayerId = 21,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 15.2F
            },

            new Scoring
            {
                ScoringId = 84,
                PlayerId = 21,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 6.3F
            },

            new Scoring
            {
                ScoringId = 85,
                PlayerId = 22,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 8.8F
            },

            new Scoring
            {
                ScoringId = 86,
                PlayerId = 22,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 5.9F
            },

            new Scoring
            {
                ScoringId = 87,
                PlayerId = 22,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 12.8F
            },

            new Scoring
            {
                ScoringId = 88,
                PlayerId = 22,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 14.3F
            },

            new Scoring
            {
                ScoringId = 89,
                PlayerId = 23,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 1.4F
            },

            new Scoring
            {
                ScoringId = 90,
                PlayerId = 23,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 10.2F
            },

            new Scoring
            {
                ScoringId = 91,
                PlayerId = 23,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 4.1F
            },

            new Scoring
            {
                ScoringId = 92,
                PlayerId = 23,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 8.8F
            },

            new Scoring
            {
                ScoringId = 93,
                PlayerId = 24,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 12.8F
            },

            new Scoring
            {
                ScoringId = 94,
                PlayerId = 24,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 6.1F
            },

            new Scoring
            {
                ScoringId = 95,
                PlayerId = 24,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 10.6F
            },

            new Scoring
            {
                ScoringId = 96,
                PlayerId = 24,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -4.9F
            },

            new Scoring
            {
                ScoringId = 97,
                PlayerId = 25,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 11.2F
            },

            new Scoring
            {
                ScoringId = 98,
                PlayerId = 25,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -2.7F
            },

            new Scoring
            {
                ScoringId = 99,
                PlayerId = 25,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -3.2F
            },

            new Scoring
            {
                ScoringId = 100,
                PlayerId = 25,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 15.9F
            },

            new Scoring
            {
                ScoringId = 101,
                PlayerId = 26,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 13.1F
            },

            new Scoring
            {
                ScoringId = 102,
                PlayerId = 26,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 5.6F
            },

            new Scoring
            {
                ScoringId = 103,
                PlayerId = 26,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 7.2F
            },

            new Scoring
            {
                ScoringId = 104,
                PlayerId = 26,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 19.7F
            },

            new Scoring
            {
                ScoringId = 105,
                PlayerId = 27,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 12.9F
            },

            new Scoring
            {
                ScoringId = 106,
                PlayerId = 27,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -3.0F
            },

            new Scoring
            {
                ScoringId = 107,
                PlayerId = 27,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 10.6F
            },

            new Scoring
            {
                ScoringId = 108,
                PlayerId = 27,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 12.8F
            },

            new Scoring
            {
                ScoringId = 109,
                PlayerId = 28,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -1.6F
            },

            new Scoring
            {
                ScoringId = 110,
                PlayerId = 28,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 11.0F
            },

            new Scoring
            {
                ScoringId = 111,
                PlayerId = 28,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -2.6F
            },

            new Scoring
            {
                ScoringId = 112,
                PlayerId = 28,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 17.5F
            },

            new Scoring
            {
                ScoringId = 113,
                PlayerId = 29,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 3.2F
            },

            new Scoring
            {
                ScoringId = 114,
                PlayerId = 29,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 17.2F
            },

            new Scoring
            {
                ScoringId = 115,
                PlayerId = 29,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 9.9F
            },

            new Scoring
            {
                ScoringId = 116,
                PlayerId = 29,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 18.3F
            },

            new Scoring
            {
                ScoringId = 117,
                PlayerId = 30,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 18.6F
            },

            new Scoring
            {
                ScoringId = 118,
                PlayerId = 30,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -1.6F
            },

            new Scoring
            {
                ScoringId = 119,
                PlayerId = 30,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 17.0F
            },

            new Scoring
            {
                ScoringId = 120,
                PlayerId = 30,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 16.1F
            },

            new Scoring
            {
                ScoringId = 121,
                PlayerId = 31,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 13.6F
            },

            new Scoring
            {
                ScoringId = 122,
                PlayerId = 31,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -2.8F
            },

            new Scoring
            {
                ScoringId = 123,
                PlayerId = 31,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 0.5F
            },

            new Scoring
            {
                ScoringId = 124,
                PlayerId = 31,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -3.9F
            },

            new Scoring
            {
                ScoringId = 125,
                PlayerId = 32,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -1.8F
            },

            new Scoring
            {
                ScoringId = 126,
                PlayerId = 32,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -2.5F
            },

            new Scoring
            {
                ScoringId = 127,
                PlayerId = 32,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -3.6F
            },

            new Scoring
            {
                ScoringId = 128,
                PlayerId = 32,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 14.6F
            },

            new Scoring
            {
                ScoringId = 129,
                PlayerId = 33,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 4.6F
            },

            new Scoring
            {
                ScoringId = 130,
                PlayerId = 33,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 11.8F
            },

            new Scoring
            {
                ScoringId = 131,
                PlayerId = 33,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -0.9F
            },

            new Scoring
            {
                ScoringId = 132,
                PlayerId = 33,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 9.4F
            },

            new Scoring
            {
                ScoringId = 133,
                PlayerId = 34,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 2.6F
            },

            new Scoring
            {
                ScoringId = 134,
                PlayerId = 34,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 6.0F
            },

            new Scoring
            {
                ScoringId = 135,
                PlayerId = 34,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -3.9F
            },

            new Scoring
            {
                ScoringId = 136,
                PlayerId = 34,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -2.3F
            },

            new Scoring
            {
                ScoringId = 137,
                PlayerId = 35,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 11.8F
            },

            new Scoring
            {
                ScoringId = 138,
                PlayerId = 35,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 7.9F
            },

            new Scoring
            {
                ScoringId = 139,
                PlayerId = 35,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 17.1F
            },

            new Scoring
            {
                ScoringId = 140,
                PlayerId = 35,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 5.7F
            },

            new Scoring
            {
                ScoringId = 141,
                PlayerId = 36,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 14.3F
            },

            new Scoring
            {
                ScoringId = 142,
                PlayerId = 36,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 3.1F
            },

            new Scoring
            {
                ScoringId = 143,
                PlayerId = 36,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -1.2F
            },

            new Scoring
            {
                ScoringId = 144,
                PlayerId = 36,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 13.2F
            },

            new Scoring
            {
                ScoringId = 145,
                PlayerId = 37,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 12.0F
            },

            new Scoring
            {
                ScoringId = 146,
                PlayerId = 37,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 9.6F
            },

            new Scoring
            {
                ScoringId = 147,
                PlayerId = 37,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 17.3F
            },

            new Scoring
            {
                ScoringId = 148,
                PlayerId = 37,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 19.1F
            },

            new Scoring
            {
                ScoringId = 149,
                PlayerId = 38,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -1.4F
            },

            new Scoring
            {
                ScoringId = 150,
                PlayerId = 38,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 12.4F
            },

            new Scoring
            {
                ScoringId = 151,
                PlayerId = 38,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 6.1F
            },

            new Scoring
            {
                ScoringId = 152,
                PlayerId = 38,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 3.3F
            },

            new Scoring
            {
                ScoringId = 153,
                PlayerId = 39,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 18.3F
            },

            new Scoring
            {
                ScoringId = 154,
                PlayerId = 39,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 19.3F
            },

            new Scoring
            {
                ScoringId = 155,
                PlayerId = 39,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -1.8F
            },

            new Scoring
            {
                ScoringId = 156,
                PlayerId = 39,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 18.6F
            },

            new Scoring
            {
                ScoringId = 157,
                PlayerId = 40,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 5.5F
            },

            new Scoring
            {
                ScoringId = 158,
                PlayerId = 40,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 9.1F
            },

            new Scoring
            {
                ScoringId = 159,
                PlayerId = 40,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 15.2F
            },

            new Scoring
            {
                ScoringId = 160,
                PlayerId = 40,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 18.6F
            },

            new Scoring
            {
                ScoringId = 161,
                PlayerId = 41,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 8.1F
            },

            new Scoring
            {
                ScoringId = 162,
                PlayerId = 41,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 14.3F
            },

            new Scoring
            {
                ScoringId = 163,
                PlayerId = 41,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 15.4F
            },

            new Scoring
            {
                ScoringId = 164,
                PlayerId = 41,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 16.8F
            },

            new Scoring
            {
                ScoringId = 165,
                PlayerId = 42,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 3.5F
            },

            new Scoring
            {
                ScoringId = 166,
                PlayerId = 42,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 16.5F
            },

            new Scoring
            {
                ScoringId = 167,
                PlayerId = 42,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 19.4F
            },

            new Scoring
            {
                ScoringId = 168,
                PlayerId = 42,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 4.2F
            },

            new Scoring
            {
                ScoringId = 169,
                PlayerId = 43,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 2.8F
            },

            new Scoring
            {
                ScoringId = 170,
                PlayerId = 43,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 12.0F
            },

            new Scoring
            {
                ScoringId = 171,
                PlayerId = 43,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 2.5F
            },

            new Scoring
            {
                ScoringId = 172,
                PlayerId = 43,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -1.9F
            },

            new Scoring
            {
                ScoringId = 173,
                PlayerId = 44,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -0.5F
            },

            new Scoring
            {
                ScoringId = 174,
                PlayerId = 44,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 4.0F
            },

            new Scoring
            {
                ScoringId = 175,
                PlayerId = 44,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 3.8F
            },

            new Scoring
            {
                ScoringId = 176,
                PlayerId = 44,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 13.0F
            },

            new Scoring
            {
                ScoringId = 177,
                PlayerId = 45,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 13.2F
            },

            new Scoring
            {
                ScoringId = 178,
                PlayerId = 45,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 14.1F
            },

            new Scoring
            {
                ScoringId = 179,
                PlayerId = 45,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 16.6F
            },

            new Scoring
            {
                ScoringId = 180,
                PlayerId = 45,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 14.1F
            },

            new Scoring
            {
                ScoringId = 181,
                PlayerId = 46,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 2.9F
            },

            new Scoring
            {
                ScoringId = 182,
                PlayerId = 46,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 10.9F
            },

            new Scoring
            {
                ScoringId = 183,
                PlayerId = 46,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 14.8F
            },

            new Scoring
            {
                ScoringId = 184,
                PlayerId = 46,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 15.4F
            },

            new Scoring
            {
                ScoringId = 185,
                PlayerId = 47,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 13.9F
            },

            new Scoring
            {
                ScoringId = 186,
                PlayerId = 47,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 14.5F
            },

            new Scoring
            {
                ScoringId = 187,
                PlayerId = 47,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -0.3F
            },

            new Scoring
            {
                ScoringId = 188,
                PlayerId = 47,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -1.0F
            },

            new Scoring
            {
                ScoringId = 189,
                PlayerId = 48,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 2.8F
            },

            new Scoring
            {
                ScoringId = 190,
                PlayerId = 48,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 3.9F
            },

            new Scoring
            {
                ScoringId = 191,
                PlayerId = 48,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 2.3F
            },

            new Scoring
            {
                ScoringId = 192,
                PlayerId = 48,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 11.0F
            },

            new Scoring
            {
                ScoringId = 193,
                PlayerId = 49,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -1.7F
            },

            new Scoring
            {
                ScoringId = 194,
                PlayerId = 49,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 7.1F
            },

            new Scoring
            {
                ScoringId = 195,
                PlayerId = 49,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 11.0F
            },

            new Scoring
            {
                ScoringId = 196,
                PlayerId = 49,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 12.5F
            },

            new Scoring
            {
                ScoringId = 197,
                PlayerId = 50,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 8.9F
            },

            new Scoring
            {
                ScoringId = 198,
                PlayerId = 50,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 3.4F
            },

            new Scoring
            {
                ScoringId = 199,
                PlayerId = 50,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 4.9F
            },

            new Scoring
            {
                ScoringId = 200,
                PlayerId = 50,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 19.6F
            },

            new Scoring
            {
                ScoringId = 201,
                PlayerId = 51,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 13.1F
            },

            new Scoring
            {
                ScoringId = 202,
                PlayerId = 51,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -2.2F
            },

            new Scoring
            {
                ScoringId = 203,
                PlayerId = 51,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 12.7F
            },

            new Scoring
            {
                ScoringId = 204,
                PlayerId = 51,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 18.4F
            },

            new Scoring
            {
                ScoringId = 205,
                PlayerId = 52,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 18.2F
            },

            new Scoring
            {
                ScoringId = 206,
                PlayerId = 52,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -0.6F
            },

            new Scoring
            {
                ScoringId = 207,
                PlayerId = 52,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 3.6F
            },

            new Scoring
            {
                ScoringId = 208,
                PlayerId = 52,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 15.7F
            },

            new Scoring
            {
                ScoringId = 209,
                PlayerId = 53,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -2.3F
            },

            new Scoring
            {
                ScoringId = 210,
                PlayerId = 53,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 1.2F
            },

            new Scoring
            {
                ScoringId = 211,
                PlayerId = 53,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 19.1F
            },

            new Scoring
            {
                ScoringId = 212,
                PlayerId = 53,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 7.7F
            },

            new Scoring
            {
                ScoringId = 213,
                PlayerId = 54,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 0.6F
            },

            new Scoring
            {
                ScoringId = 214,
                PlayerId = 54,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 0.9F
            },

            new Scoring
            {
                ScoringId = 215,
                PlayerId = 54,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 1.5F
            },

            new Scoring
            {
                ScoringId = 216,
                PlayerId = 54,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -2.4F
            },

            new Scoring
            {
                ScoringId = 217,
                PlayerId = 55,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 0.7F
            },

            new Scoring
            {
                ScoringId = 218,
                PlayerId = 55,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -3.3F
            },

            new Scoring
            {
                ScoringId = 219,
                PlayerId = 55,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 3.3F
            },

            new Scoring
            {
                ScoringId = 220,
                PlayerId = 55,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 14.4F
            },

            new Scoring
            {
                ScoringId = 221,
                PlayerId = 56,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -4.1F
            },

            new Scoring
            {
                ScoringId = 222,
                PlayerId = 56,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 14.6F
            },

            new Scoring
            {
                ScoringId = 223,
                PlayerId = 56,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 18.4F
            },

            new Scoring
            {
                ScoringId = 224,
                PlayerId = 56,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -3.5F
            },

            new Scoring
            {
                ScoringId = 225,
                PlayerId = 57,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 15.0F
            },

            new Scoring
            {
                ScoringId = 226,
                PlayerId = 57,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 7.2F
            },

            new Scoring
            {
                ScoringId = 227,
                PlayerId = 57,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -3.5F
            },

            new Scoring
            {
                ScoringId = 228,
                PlayerId = 57,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 17.0F
            },

            new Scoring
            {
                ScoringId = 229,
                PlayerId = 58,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 17.0F
            },

            new Scoring
            {
                ScoringId = 230,
                PlayerId = 58,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 13.0F
            },

            new Scoring
            {
                ScoringId = 231,
                PlayerId = 58,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 14.4F
            },

            new Scoring
            {
                ScoringId = 232,
                PlayerId = 58,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -0.2F
            },

            new Scoring
            {
                ScoringId = 233,
                PlayerId = 59,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 17.3F
            },

            new Scoring
            {
                ScoringId = 234,
                PlayerId = 59,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 16.3F
            },

            new Scoring
            {
                ScoringId = 235,
                PlayerId = 59,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -0.2F
            },

            new Scoring
            {
                ScoringId = 236,
                PlayerId = 59,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 16.6F
            },

            new Scoring
            {
                ScoringId = 237,
                PlayerId = 60,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 15.4F
            },

            new Scoring
            {
                ScoringId = 238,
                PlayerId = 60,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 17.0F
            },

            new Scoring
            {
                ScoringId = 239,
                PlayerId = 60,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 6.0F
            },

            new Scoring
            {
                ScoringId = 240,
                PlayerId = 60,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 2.8F
            },

            new Scoring
            {
                ScoringId = 241,
                PlayerId = 61,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -0.1F
            },

            new Scoring
            {
                ScoringId = 242,
                PlayerId = 61,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 9.1F
            },

            new Scoring
            {
                ScoringId = 243,
                PlayerId = 61,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 4.7F
            },

            new Scoring
            {
                ScoringId = 244,
                PlayerId = 61,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 15.5F
            },

            new Scoring
            {
                ScoringId = 245,
                PlayerId = 62,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 17.8F
            },

            new Scoring
            {
                ScoringId = 246,
                PlayerId = 62,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 14.1F
            },

            new Scoring
            {
                ScoringId = 247,
                PlayerId = 62,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 17.0F
            },

            new Scoring
            {
                ScoringId = 248,
                PlayerId = 62,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -0.4F
            },

            new Scoring
            {
                ScoringId = 249,
                PlayerId = 63,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 7.0F
            },

            new Scoring
            {
                ScoringId = 250,
                PlayerId = 63,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 15.7F
            },

            new Scoring
            {
                ScoringId = 251,
                PlayerId = 63,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 15.2F
            },

            new Scoring
            {
                ScoringId = 252,
                PlayerId = 63,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 5.3F
            },

            new Scoring
            {
                ScoringId = 253,
                PlayerId = 64,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 4.7F
            },

            new Scoring
            {
                ScoringId = 254,
                PlayerId = 64,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 19.5F
            },

            new Scoring
            {
                ScoringId = 255,
                PlayerId = 64,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 9.1F
            },

            new Scoring
            {
                ScoringId = 256,
                PlayerId = 64,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 6.9F
            },

            new Scoring
            {
                ScoringId = 257,
                PlayerId = 65,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 10.1F
            },

            new Scoring
            {
                ScoringId = 258,
                PlayerId = 65,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -4.3F
            },

            new Scoring
            {
                ScoringId = 259,
                PlayerId = 65,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -0.9F
            },

            new Scoring
            {
                ScoringId = 260,
                PlayerId = 65,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 10.7F
            },

            new Scoring
            {
                ScoringId = 261,
                PlayerId = 66,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 10.8F
            },

            new Scoring
            {
                ScoringId = 262,
                PlayerId = 66,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -0.7F
            },

            new Scoring
            {
                ScoringId = 263,
                PlayerId = 66,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 6.2F
            },

            new Scoring
            {
                ScoringId = 264,
                PlayerId = 66,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 15.1F
            },

            new Scoring
            {
                ScoringId = 265,
                PlayerId = 67,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 8.3F
            },

            new Scoring
            {
                ScoringId = 266,
                PlayerId = 67,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 7.0F
            },

            new Scoring
            {
                ScoringId = 267,
                PlayerId = 67,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 19.2F
            },

            new Scoring
            {
                ScoringId = 268,
                PlayerId = 67,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 15.3F
            },

            new Scoring
            {
                ScoringId = 269,
                PlayerId = 68,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -3.0F
            },

            new Scoring
            {
                ScoringId = 270,
                PlayerId = 68,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 15.0F
            },

            new Scoring
            {
                ScoringId = 271,
                PlayerId = 68,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 3.0F
            },

            new Scoring
            {
                ScoringId = 272,
                PlayerId = 68,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 6.5F
            },

            new Scoring
            {
                ScoringId = 273,
                PlayerId = 69,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 17.1F
            },

            new Scoring
            {
                ScoringId = 274,
                PlayerId = 69,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -4.9F
            },

            new Scoring
            {
                ScoringId = 275,
                PlayerId = 69,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 8.0F
            },

            new Scoring
            {
                ScoringId = 276,
                PlayerId = 69,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 17.0F
            },

            new Scoring
            {
                ScoringId = 277,
                PlayerId = 70,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 10.5F
            },

            new Scoring
            {
                ScoringId = 278,
                PlayerId = 70,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 12.4F
            },

            new Scoring
            {
                ScoringId = 279,
                PlayerId = 70,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 14.4F
            },

            new Scoring
            {
                ScoringId = 280,
                PlayerId = 70,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 9.9F
            },

            new Scoring
            {
                ScoringId = 281,
                PlayerId = 71,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 4.0F
            },

            new Scoring
            {
                ScoringId = 282,
                PlayerId = 71,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 0.5F
            },

            new Scoring
            {
                ScoringId = 283,
                PlayerId = 71,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 9.7F
            },

            new Scoring
            {
                ScoringId = 284,
                PlayerId = 71,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 10.8F
            },

            new Scoring
            {
                ScoringId = 285,
                PlayerId = 72,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 10.9F
            },

            new Scoring
            {
                ScoringId = 286,
                PlayerId = 72,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -3.2F
            },

            new Scoring
            {
                ScoringId = 287,
                PlayerId = 72,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -3.7F
            },

            new Scoring
            {
                ScoringId = 288,
                PlayerId = 72,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 19.5F
            },

            new Scoring
            {
                ScoringId = 289,
                PlayerId = 73,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 14.1F
            },

            new Scoring
            {
                ScoringId = 290,
                PlayerId = 73,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 9.3F
            },

            new Scoring
            {
                ScoringId = 291,
                PlayerId = 73,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 1.1F
            },

            new Scoring
            {
                ScoringId = 292,
                PlayerId = 73,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 10.7F
            },

            new Scoring
            {
                ScoringId = 293,
                PlayerId = 74,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 3.8F
            },

            new Scoring
            {
                ScoringId = 294,
                PlayerId = 74,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 17.5F
            },

            new Scoring
            {
                ScoringId = 295,
                PlayerId = 74,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 15.5F
            },

            new Scoring
            {
                ScoringId = 296,
                PlayerId = 74,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 5.1F
            },

            new Scoring
            {
                ScoringId = 297,
                PlayerId = 75,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 4.4F
            },

            new Scoring
            {
                ScoringId = 298,
                PlayerId = 75,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -1.7F
            },

            new Scoring
            {
                ScoringId = 299,
                PlayerId = 75,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 7.3F
            },

            new Scoring
            {
                ScoringId = 300,
                PlayerId = 75,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 16.0F
            },

            new Scoring
            {
                ScoringId = 301,
                PlayerId = 76,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 10.3F
            },

            new Scoring
            {
                ScoringId = 302,
                PlayerId = 76,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -1.3F
            },

            new Scoring
            {
                ScoringId = 303,
                PlayerId = 76,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 16.8F
            },

            new Scoring
            {
                ScoringId = 304,
                PlayerId = 76,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 4.6F
            },

            new Scoring
            {
                ScoringId = 305,
                PlayerId = 77,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -0.6F
            },

            new Scoring
            {
                ScoringId = 306,
                PlayerId = 77,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 4.5F
            },

            new Scoring
            {
                ScoringId = 307,
                PlayerId = 77,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 19.7F
            },

            new Scoring
            {
                ScoringId = 308,
                PlayerId = 77,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 17.7F
            },

            new Scoring
            {
                ScoringId = 309,
                PlayerId = 78,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 18.9F
            },

            new Scoring
            {
                ScoringId = 310,
                PlayerId = 78,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 19.2F
            },

            new Scoring
            {
                ScoringId = 311,
                PlayerId = 78,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 4.1F
            },

            new Scoring
            {
                ScoringId = 312,
                PlayerId = 78,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 5.4F
            },

            new Scoring
            {
                ScoringId = 313,
                PlayerId = 79,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 12.0F
            },

            new Scoring
            {
                ScoringId = 314,
                PlayerId = 79,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 18.9F
            },

            new Scoring
            {
                ScoringId = 315,
                PlayerId = 79,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 12.3F
            },

            new Scoring
            {
                ScoringId = 316,
                PlayerId = 79,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 0.3F
            },

            new Scoring
            {
                ScoringId = 317,
                PlayerId = 80,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -2.2F
            },

            new Scoring
            {
                ScoringId = 318,
                PlayerId = 80,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -1.2F
            },

            new Scoring
            {
                ScoringId = 319,
                PlayerId = 80,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 15.9F
            },

            new Scoring
            {
                ScoringId = 320,
                PlayerId = 80,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 14.0F
            },

            new Scoring
            {
                ScoringId = 321,
                PlayerId = 81,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 19.9F
            },

            new Scoring
            {
                ScoringId = 322,
                PlayerId = 81,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -5.0F
            },

            new Scoring
            {
                ScoringId = 323,
                PlayerId = 81,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 13.5F
            },

            new Scoring
            {
                ScoringId = 324,
                PlayerId = 81,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 0.8F
            },

            new Scoring
            {
                ScoringId = 325,
                PlayerId = 82,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 8.0F
            },

            new Scoring
            {
                ScoringId = 326,
                PlayerId = 82,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 1.1F
            },

            new Scoring
            {
                ScoringId = 327,
                PlayerId = 82,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 10.3F
            },

            new Scoring
            {
                ScoringId = 328,
                PlayerId = 82,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 3.6F
            },

            new Scoring
            {
                ScoringId = 329,
                PlayerId = 83,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 19.7F
            },

            new Scoring
            {
                ScoringId = 330,
                PlayerId = 83,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 2.8F
            },

            new Scoring
            {
                ScoringId = 331,
                PlayerId = 83,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 13.7F
            },

            new Scoring
            {
                ScoringId = 332,
                PlayerId = 83,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 15.5F
            },

            new Scoring
            {
                ScoringId = 333,
                PlayerId = 84,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -3.8F
            },

            new Scoring
            {
                ScoringId = 334,
                PlayerId = 84,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 11.9F
            },

            new Scoring
            {
                ScoringId = 335,
                PlayerId = 84,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 1.2F
            },

            new Scoring
            {
                ScoringId = 336,
                PlayerId = 84,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -4.8F
            },

            new Scoring
            {
                ScoringId = 337,
                PlayerId = 85,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 5.9F
            },

            new Scoring
            {
                ScoringId = 338,
                PlayerId = 85,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 15.9F
            },

            new Scoring
            {
                ScoringId = 339,
                PlayerId = 85,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 15.9F
            },

            new Scoring
            {
                ScoringId = 340,
                PlayerId = 85,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 18.1F
            },

            new Scoring
            {
                ScoringId = 341,
                PlayerId = 86,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 17.2F
            },

            new Scoring
            {
                ScoringId = 342,
                PlayerId = 86,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 11.8F
            },

            new Scoring
            {
                ScoringId = 343,
                PlayerId = 86,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 4.2F
            },

            new Scoring
            {
                ScoringId = 344,
                PlayerId = 86,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 12.9F
            },

            new Scoring
            {
                ScoringId = 345,
                PlayerId = 87,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 11.6F
            },

            new Scoring
            {
                ScoringId = 346,
                PlayerId = 87,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 15.3F
            },

            new Scoring
            {
                ScoringId = 347,
                PlayerId = 87,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 14.9F
            },

            new Scoring
            {
                ScoringId = 348,
                PlayerId = 87,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 3.8F
            },

            new Scoring
            {
                ScoringId = 349,
                PlayerId = 88,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 7.2F
            },

            new Scoring
            {
                ScoringId = 350,
                PlayerId = 88,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 11.3F
            },

            new Scoring
            {
                ScoringId = 351,
                PlayerId = 88,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 14.3F
            },

            new Scoring
            {
                ScoringId = 352,
                PlayerId = 88,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 18.7F
            },

            new Scoring
            {
                ScoringId = 353,
                PlayerId = 89,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -4.9F
            },

            new Scoring
            {
                ScoringId = 354,
                PlayerId = 89,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 4.3F
            },

            new Scoring
            {
                ScoringId = 355,
                PlayerId = 89,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -1.7F
            },

            new Scoring
            {
                ScoringId = 356,
                PlayerId = 89,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -4.2F
            },

            new Scoring
            {
                ScoringId = 357,
                PlayerId = 90,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 1.8F
            },

            new Scoring
            {
                ScoringId = 358,
                PlayerId = 90,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 3.0F
            },

            new Scoring
            {
                ScoringId = 359,
                PlayerId = 90,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 13.0F
            },

            new Scoring
            {
                ScoringId = 360,
                PlayerId = 90,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 11.3F
            },

            new Scoring
            {
                ScoringId = 361,
                PlayerId = 91,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 11.5F
            },

            new Scoring
            {
                ScoringId = 362,
                PlayerId = 91,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 1.0F
            },

            new Scoring
            {
                ScoringId = 363,
                PlayerId = 91,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 18.1F
            },

            new Scoring
            {
                ScoringId = 364,
                PlayerId = 91,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 15.8F
            },

            new Scoring
            {
                ScoringId = 365,
                PlayerId = 92,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 7.7F
            },

            new Scoring
            {
                ScoringId = 366,
                PlayerId = 92,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 6.9F
            },

            new Scoring
            {
                ScoringId = 367,
                PlayerId = 92,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 11.7F
            },

            new Scoring
            {
                ScoringId = 368,
                PlayerId = 92,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -2.6F
            },

            new Scoring
            {
                ScoringId = 369,
                PlayerId = 93,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 5.1F
            },

            new Scoring
            {
                ScoringId = 370,
                PlayerId = 93,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 13.9F
            },

            new Scoring
            {
                ScoringId = 371,
                PlayerId = 93,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 14.3F
            },

            new Scoring
            {
                ScoringId = 372,
                PlayerId = 93,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 11.7F
            },

            new Scoring
            {
                ScoringId = 373,
                PlayerId = 94,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 15.8F
            },

            new Scoring
            {
                ScoringId = 374,
                PlayerId = 94,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -5.0F
            },

            new Scoring
            {
                ScoringId = 375,
                PlayerId = 94,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 14.3F
            },

            new Scoring
            {
                ScoringId = 376,
                PlayerId = 94,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 14.4F
            },

            new Scoring
            {
                ScoringId = 377,
                PlayerId = 95,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 10.7F
            },

            new Scoring
            {
                ScoringId = 378,
                PlayerId = 95,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -2.6F
            },

            new Scoring
            {
                ScoringId = 379,
                PlayerId = 95,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 2.4F
            },

            new Scoring
            {
                ScoringId = 380,
                PlayerId = 95,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 14.8F
            },

            new Scoring
            {
                ScoringId = 381,
                PlayerId = 96,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 18.2F
            },

            new Scoring
            {
                ScoringId = 382,
                PlayerId = 96,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 17.7F
            },

            new Scoring
            {
                ScoringId = 383,
                PlayerId = 96,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 13.7F
            },

            new Scoring
            {
                ScoringId = 384,
                PlayerId = 96,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 3.6F
            },

            new Scoring
            {
                ScoringId = 385,
                PlayerId = 97,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 10.6F
            },

            new Scoring
            {
                ScoringId = 386,
                PlayerId = 97,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 13.3F
            },

            new Scoring
            {
                ScoringId = 387,
                PlayerId = 97,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 5.6F
            },

            new Scoring
            {
                ScoringId = 388,
                PlayerId = 97,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 18.0F
            },

            new Scoring
            {
                ScoringId = 389,
                PlayerId = 98,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 6.6F
            },

            new Scoring
            {
                ScoringId = 390,
                PlayerId = 98,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 17.1F
            },

            new Scoring
            {
                ScoringId = 391,
                PlayerId = 98,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -3.9F
            },

            new Scoring
            {
                ScoringId = 392,
                PlayerId = 98,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -2.8F
            },

            new Scoring
            {
                ScoringId = 393,
                PlayerId = 99,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -0.3F
            },

            new Scoring
            {
                ScoringId = 394,
                PlayerId = 99,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 16.8F
            },

            new Scoring
            {
                ScoringId = 395,
                PlayerId = 99,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -4.8F
            },

            new Scoring
            {
                ScoringId = 396,
                PlayerId = 99,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 9.6F
            },

            new Scoring
            {
                ScoringId = 397,
                PlayerId = 100,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 13.4F
            },

            new Scoring
            {
                ScoringId = 398,
                PlayerId = 100,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 8.3F
            },

            new Scoring
            {
                ScoringId = 399,
                PlayerId = 100,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -0.1F
            },

            new Scoring
            {
                ScoringId = 400,
                PlayerId = 100,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -4.1F
            },

            new Scoring
            {
                ScoringId = 401,
                PlayerId = 101,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -3.8F
            },

            new Scoring
            {
                ScoringId = 402,
                PlayerId = 101,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -2.8F
            },

            new Scoring
            {
                ScoringId = 403,
                PlayerId = 101,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 4.3F
            },

            new Scoring
            {
                ScoringId = 404,
                PlayerId = 101,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 7.5F
            },

            new Scoring
            {
                ScoringId = 405,
                PlayerId = 102,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 16.0F
            },

            new Scoring
            {
                ScoringId = 406,
                PlayerId = 102,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 2.8F
            },

            new Scoring
            {
                ScoringId = 407,
                PlayerId = 102,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 10.6F
            },

            new Scoring
            {
                ScoringId = 408,
                PlayerId = 102,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 8.2F
            },

            new Scoring
            {
                ScoringId = 409,
                PlayerId = 103,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 18.7F
            },

            new Scoring
            {
                ScoringId = 410,
                PlayerId = 103,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 7.5F
            },

            new Scoring
            {
                ScoringId = 411,
                PlayerId = 103,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -1.2F
            },

            new Scoring
            {
                ScoringId = 412,
                PlayerId = 103,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 3.6F
            },

            new Scoring
            {
                ScoringId = 413,
                PlayerId = 104,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 19.6F
            },

            new Scoring
            {
                ScoringId = 414,
                PlayerId = 104,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -1.8F
            },

            new Scoring
            {
                ScoringId = 415,
                PlayerId = 104,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 4.3F
            },

            new Scoring
            {
                ScoringId = 416,
                PlayerId = 104,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 16.9F
            },

            new Scoring
            {
                ScoringId = 417,
                PlayerId = 105,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -2.2F
            },

            new Scoring
            {
                ScoringId = 418,
                PlayerId = 105,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 11.4F
            },

            new Scoring
            {
                ScoringId = 419,
                PlayerId = 105,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 14.6F
            },

            new Scoring
            {
                ScoringId = 420,
                PlayerId = 105,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 15.4F
            },

            new Scoring
            {
                ScoringId = 421,
                PlayerId = 106,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 4.3F
            },

            new Scoring
            {
                ScoringId = 422,
                PlayerId = 106,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -2.5F
            },

            new Scoring
            {
                ScoringId = 423,
                PlayerId = 106,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 13.8F
            },

            new Scoring
            {
                ScoringId = 424,
                PlayerId = 106,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 0.4F
            },

            new Scoring
            {
                ScoringId = 425,
                PlayerId = 107,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 13.5F
            },

            new Scoring
            {
                ScoringId = 426,
                PlayerId = 107,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 7.7F
            },

            new Scoring
            {
                ScoringId = 427,
                PlayerId = 107,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 2.7F
            },

            new Scoring
            {
                ScoringId = 428,
                PlayerId = 107,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 5.0F
            },

            new Scoring
            {
                ScoringId = 429,
                PlayerId = 108,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 0.9F
            },

            new Scoring
            {
                ScoringId = 430,
                PlayerId = 108,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 1.8F
            },

            new Scoring
            {
                ScoringId = 431,
                PlayerId = 108,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 8.8F
            },

            new Scoring
            {
                ScoringId = 432,
                PlayerId = 108,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 15.8F
            },

            new Scoring
            {
                ScoringId = 433,
                PlayerId = 109,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -1.6F
            },

            new Scoring
            {
                ScoringId = 434,
                PlayerId = 109,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 2.4F
            },

            new Scoring
            {
                ScoringId = 435,
                PlayerId = 109,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 15.7F
            },

            new Scoring
            {
                ScoringId = 436,
                PlayerId = 109,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -4.3F
            },

            new Scoring
            {
                ScoringId = 437,
                PlayerId = 110,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 13.2F
            },

            new Scoring
            {
                ScoringId = 438,
                PlayerId = 110,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 15.7F
            },

            new Scoring
            {
                ScoringId = 439,
                PlayerId = 110,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 13.9F
            },

            new Scoring
            {
                ScoringId = 440,
                PlayerId = 110,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 18.2F
            },

            new Scoring
            {
                ScoringId = 441,
                PlayerId = 111,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 5.8F
            },

            new Scoring
            {
                ScoringId = 442,
                PlayerId = 111,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 16.8F
            },

            new Scoring
            {
                ScoringId = 443,
                PlayerId = 111,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 9.5F
            },

            new Scoring
            {
                ScoringId = 444,
                PlayerId = 111,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 0.5F
            },

            new Scoring
            {
                ScoringId = 445,
                PlayerId = 112,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 16.8F
            },

            new Scoring
            {
                ScoringId = 446,
                PlayerId = 112,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 8.1F
            },

            new Scoring
            {
                ScoringId = 447,
                PlayerId = 112,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 5.7F
            },

            new Scoring
            {
                ScoringId = 448,
                PlayerId = 112,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 0.9F
            },

            new Scoring
            {
                ScoringId = 449,
                PlayerId = 113,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 6.6F
            },

            new Scoring
            {
                ScoringId = 450,
                PlayerId = 113,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 4.8F
            },

            new Scoring
            {
                ScoringId = 451,
                PlayerId = 113,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -3.8F
            },

            new Scoring
            {
                ScoringId = 452,
                PlayerId = 113,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 18.7F
            },

            new Scoring
            {
                ScoringId = 453,
                PlayerId = 114,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -1.3F
            },

            new Scoring
            {
                ScoringId = 454,
                PlayerId = 114,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 0.3F
            },

            new Scoring
            {
                ScoringId = 455,
                PlayerId = 114,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 2.9F
            },

            new Scoring
            {
                ScoringId = 456,
                PlayerId = 114,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 1.9F
            },

            new Scoring
            {
                ScoringId = 457,
                PlayerId = 115,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 18.7F
            },

            new Scoring
            {
                ScoringId = 458,
                PlayerId = 115,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 4.7F
            },

            new Scoring
            {
                ScoringId = 459,
                PlayerId = 115,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 16.5F
            },

            new Scoring
            {
                ScoringId = 460,
                PlayerId = 115,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 8.1F
            },

            new Scoring
            {
                ScoringId = 461,
                PlayerId = 116,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 4.0F
            },

            new Scoring
            {
                ScoringId = 462,
                PlayerId = 116,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -1.6F
            },

            new Scoring
            {
                ScoringId = 463,
                PlayerId = 116,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 10.5F
            },

            new Scoring
            {
                ScoringId = 464,
                PlayerId = 116,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 18.6F
            },

            new Scoring
            {
                ScoringId = 465,
                PlayerId = 117,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 16.3F
            },

            new Scoring
            {
                ScoringId = 466,
                PlayerId = 117,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 3.5F
            },

            new Scoring
            {
                ScoringId = 467,
                PlayerId = 117,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 0.9F
            },

            new Scoring
            {
                ScoringId = 468,
                PlayerId = 117,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -3.4F
            },

            new Scoring
            {
                ScoringId = 469,
                PlayerId = 118,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 19.4F
            },

            new Scoring
            {
                ScoringId = 470,
                PlayerId = 118,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 13.6F
            },

            new Scoring
            {
                ScoringId = 471,
                PlayerId = 118,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 19.6F
            },

            new Scoring
            {
                ScoringId = 472,
                PlayerId = 118,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 12.9F
            },

            new Scoring
            {
                ScoringId = 473,
                PlayerId = 119,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 9.2F
            },

            new Scoring
            {
                ScoringId = 474,
                PlayerId = 119,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 19.8F
            },

            new Scoring
            {
                ScoringId = 475,
                PlayerId = 119,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 3.2F
            },

            new Scoring
            {
                ScoringId = 476,
                PlayerId = 119,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -2.2F
            },

            new Scoring
            {
                ScoringId = 477,
                PlayerId = 120,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 10.6F
            },

            new Scoring
            {
                ScoringId = 478,
                PlayerId = 120,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 10.6F
            },

            new Scoring
            {
                ScoringId = 479,
                PlayerId = 120,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 6.3F
            },

            new Scoring
            {
                ScoringId = 480,
                PlayerId = 120,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -4.1F
            },

            new Scoring
            {
                ScoringId = 481,
                PlayerId = 121,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -3.0F
            },

            new Scoring
            {
                ScoringId = 482,
                PlayerId = 121,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 1.8F
            },

            new Scoring
            {
                ScoringId = 483,
                PlayerId = 121,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 19.8F
            },

            new Scoring
            {
                ScoringId = 484,
                PlayerId = 121,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 15.8F
            },

            new Scoring
            {
                ScoringId = 485,
                PlayerId = 122,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 9.5F
            },

            new Scoring
            {
                ScoringId = 486,
                PlayerId = 122,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 4.3F
            },

            new Scoring
            {
                ScoringId = 487,
                PlayerId = 122,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -2.7F
            },

            new Scoring
            {
                ScoringId = 488,
                PlayerId = 122,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 8.7F
            },

            new Scoring
            {
                ScoringId = 489,
                PlayerId = 123,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -4.6F
            },

            new Scoring
            {
                ScoringId = 490,
                PlayerId = 123,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 15.0F
            },

            new Scoring
            {
                ScoringId = 491,
                PlayerId = 123,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 14.0F
            },

            new Scoring
            {
                ScoringId = 492,
                PlayerId = 123,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 9.2F
            },

            new Scoring
            {
                ScoringId = 493,
                PlayerId = 124,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 8.2F
            },

            new Scoring
            {
                ScoringId = 494,
                PlayerId = 124,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 2.1F
            },

            new Scoring
            {
                ScoringId = 495,
                PlayerId = 124,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 5.6F
            },

            new Scoring
            {
                ScoringId = 496,
                PlayerId = 124,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 16.0F
            },

            new Scoring
            {
                ScoringId = 497,
                PlayerId = 125,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 13.9F
            },

            new Scoring
            {
                ScoringId = 498,
                PlayerId = 125,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 15.9F
            },

            new Scoring
            {
                ScoringId = 499,
                PlayerId = 125,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -0.4F
            },

            new Scoring
            {
                ScoringId = 500,
                PlayerId = 125,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 8.2F
            },

            new Scoring
            {
                ScoringId = 501,
                PlayerId = 126,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -0.8F
            },

            new Scoring
            {
                ScoringId = 502,
                PlayerId = 126,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -2.0F
            },

            new Scoring
            {
                ScoringId = 503,
                PlayerId = 126,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -4.5F
            },

            new Scoring
            {
                ScoringId = 504,
                PlayerId = 126,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 1.7F
            },

            new Scoring
            {
                ScoringId = 505,
                PlayerId = 127,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 20.0F
            },

            new Scoring
            {
                ScoringId = 506,
                PlayerId = 127,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 4.0F
            },

            new Scoring
            {
                ScoringId = 507,
                PlayerId = 127,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -1.6F
            },

            new Scoring
            {
                ScoringId = 508,
                PlayerId = 127,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -1.0F
            },

            new Scoring
            {
                ScoringId = 509,
                PlayerId = 128,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 3.9F
            },

            new Scoring
            {
                ScoringId = 510,
                PlayerId = 128,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 5.0F
            },

            new Scoring
            {
                ScoringId = 511,
                PlayerId = 128,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -3.4F
            },

            new Scoring
            {
                ScoringId = 512,
                PlayerId = 128,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 0.0F
            },

            new Scoring
            {
                ScoringId = 513,
                PlayerId = 129,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -5.0F
            },

            new Scoring
            {
                ScoringId = 514,
                PlayerId = 129,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 3.8F
            },

            new Scoring
            {
                ScoringId = 515,
                PlayerId = 129,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 18.8F
            },

            new Scoring
            {
                ScoringId = 516,
                PlayerId = 129,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 7.7F
            },

            new Scoring
            {
                ScoringId = 517,
                PlayerId = 130,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 11.1F
            },

            new Scoring
            {
                ScoringId = 518,
                PlayerId = 130,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 2.8F
            },

            new Scoring
            {
                ScoringId = 519,
                PlayerId = 130,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 8.6F
            },

            new Scoring
            {
                ScoringId = 520,
                PlayerId = 130,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 19.7F
            },

            new Scoring
            {
                ScoringId = 521,
                PlayerId = 131,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 3.0F
            },

            new Scoring
            {
                ScoringId = 522,
                PlayerId = 131,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 9.4F
            },

            new Scoring
            {
                ScoringId = 523,
                PlayerId = 131,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 4.8F
            },

            new Scoring
            {
                ScoringId = 524,
                PlayerId = 131,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 15.5F
            },

            new Scoring
            {
                ScoringId = 525,
                PlayerId = 132,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 11.9F
            },

            new Scoring
            {
                ScoringId = 526,
                PlayerId = 132,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 9.2F
            },

            new Scoring
            {
                ScoringId = 527,
                PlayerId = 132,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 12.5F
            },

            new Scoring
            {
                ScoringId = 528,
                PlayerId = 132,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 6.0F
            },

            new Scoring
            {
                ScoringId = 529,
                PlayerId = 133,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 10.7F
            },

            new Scoring
            {
                ScoringId = 530,
                PlayerId = 133,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 14.9F
            },

            new Scoring
            {
                ScoringId = 531,
                PlayerId = 133,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 14.2F
            },

            new Scoring
            {
                ScoringId = 532,
                PlayerId = 133,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 15.7F
            },

            new Scoring
            {
                ScoringId = 533,
                PlayerId = 134,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 10.0F
            },

            new Scoring
            {
                ScoringId = 534,
                PlayerId = 134,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 0.8F
            },

            new Scoring
            {
                ScoringId = 535,
                PlayerId = 134,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 5.6F
            },

            new Scoring
            {
                ScoringId = 536,
                PlayerId = 134,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 10.8F
            },

            new Scoring
            {
                ScoringId = 537,
                PlayerId = 135,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 11.6F
            },

            new Scoring
            {
                ScoringId = 538,
                PlayerId = 135,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -4.8F
            },

            new Scoring
            {
                ScoringId = 539,
                PlayerId = 135,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 5.3F
            },

            new Scoring
            {
                ScoringId = 540,
                PlayerId = 135,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 2.2F
            },

            new Scoring
            {
                ScoringId = 541,
                PlayerId = 136,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 12.7F
            },

            new Scoring
            {
                ScoringId = 542,
                PlayerId = 136,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -2.0F
            },

            new Scoring
            {
                ScoringId = 543,
                PlayerId = 136,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 15.4F
            },

            new Scoring
            {
                ScoringId = 544,
                PlayerId = 136,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 14.8F
            },

            new Scoring
            {
                ScoringId = 545,
                PlayerId = 137,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 12.9F
            },

            new Scoring
            {
                ScoringId = 546,
                PlayerId = 137,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 18.4F
            },

            new Scoring
            {
                ScoringId = 547,
                PlayerId = 137,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -4.6F
            },

            new Scoring
            {
                ScoringId = 548,
                PlayerId = 137,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 12.1F
            },

            new Scoring
            {
                ScoringId = 549,
                PlayerId = 138,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 6.1F
            },

            new Scoring
            {
                ScoringId = 550,
                PlayerId = 138,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -1.4F
            },

            new Scoring
            {
                ScoringId = 551,
                PlayerId = 138,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -1.4F
            },

            new Scoring
            {
                ScoringId = 552,
                PlayerId = 138,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 9.9F
            },

            new Scoring
            {
                ScoringId = 553,
                PlayerId = 139,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 7.6F
            },

            new Scoring
            {
                ScoringId = 554,
                PlayerId = 139,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 7.0F
            },

            new Scoring
            {
                ScoringId = 555,
                PlayerId = 139,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 0.8F
            },

            new Scoring
            {
                ScoringId = 556,
                PlayerId = 139,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 13.6F
            },

            new Scoring
            {
                ScoringId = 557,
                PlayerId = 140,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 8.2F
            },

            new Scoring
            {
                ScoringId = 558,
                PlayerId = 140,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 18.9F
            },

            new Scoring
            {
                ScoringId = 559,
                PlayerId = 140,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 11.8F
            },

            new Scoring
            {
                ScoringId = 560,
                PlayerId = 140,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 11.2F
            },

            new Scoring
            {
                ScoringId = 561,
                PlayerId = 141,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 11.8F
            },

            new Scoring
            {
                ScoringId = 562,
                PlayerId = 141,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -2.5F
            },

            new Scoring
            {
                ScoringId = 563,
                PlayerId = 141,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 5.0F
            },

            new Scoring
            {
                ScoringId = 564,
                PlayerId = 141,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 11.9F
            },

            new Scoring
            {
                ScoringId = 565,
                PlayerId = 142,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 11.8F
            },

            new Scoring
            {
                ScoringId = 566,
                PlayerId = 142,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 11.9F
            },

            new Scoring
            {
                ScoringId = 567,
                PlayerId = 142,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 9.7F
            },

            new Scoring
            {
                ScoringId = 568,
                PlayerId = 142,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 9.8F
            },

            new Scoring
            {
                ScoringId = 569,
                PlayerId = 143,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -4.3F
            },

            new Scoring
            {
                ScoringId = 570,
                PlayerId = 143,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 4.4F
            },

            new Scoring
            {
                ScoringId = 571,
                PlayerId = 143,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 11.1F
            },

            new Scoring
            {
                ScoringId = 572,
                PlayerId = 143,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 6.6F
            },

            new Scoring
            {
                ScoringId = 573,
                PlayerId = 144,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 14.1F
            },

            new Scoring
            {
                ScoringId = 574,
                PlayerId = 144,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 13.2F
            },

            new Scoring
            {
                ScoringId = 575,
                PlayerId = 144,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 14.3F
            },

            new Scoring
            {
                ScoringId = 576,
                PlayerId = 144,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -4.0F
            },

            new Scoring
            {
                ScoringId = 577,
                PlayerId = 145,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 7.7F
            },

            new Scoring
            {
                ScoringId = 578,
                PlayerId = 145,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 8.0F
            },

            new Scoring
            {
                ScoringId = 579,
                PlayerId = 145,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 4.0F
            },

            new Scoring
            {
                ScoringId = 580,
                PlayerId = 145,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -4.4F
            },

            new Scoring
            {
                ScoringId = 581,
                PlayerId = 146,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 17.9F
            },

            new Scoring
            {
                ScoringId = 582,
                PlayerId = 146,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -2.5F
            },

            new Scoring
            {
                ScoringId = 583,
                PlayerId = 146,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 16.9F
            },

            new Scoring
            {
                ScoringId = 584,
                PlayerId = 146,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 5.8F
            },

            new Scoring
            {
                ScoringId = 585,
                PlayerId = 147,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 6.2F
            },

            new Scoring
            {
                ScoringId = 586,
                PlayerId = 147,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -4.6F
            },

            new Scoring
            {
                ScoringId = 587,
                PlayerId = 147,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 11.9F
            },

            new Scoring
            {
                ScoringId = 588,
                PlayerId = 147,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 0.9F
            },

            new Scoring
            {
                ScoringId = 589,
                PlayerId = 148,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 18.9F
            },

            new Scoring
            {
                ScoringId = 590,
                PlayerId = 148,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -3.7F
            },

            new Scoring
            {
                ScoringId = 591,
                PlayerId = 148,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 12.5F
            },

            new Scoring
            {
                ScoringId = 592,
                PlayerId = 148,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -2.3F
            },

            new Scoring
            {
                ScoringId = 593,
                PlayerId = 149,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 18.6F
            },

            new Scoring
            {
                ScoringId = 594,
                PlayerId = 149,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -4.4F
            },

            new Scoring
            {
                ScoringId = 595,
                PlayerId = 149,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 5.0F
            },

            new Scoring
            {
                ScoringId = 596,
                PlayerId = 149,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 2.6F
            },

            new Scoring
            {
                ScoringId = 597,
                PlayerId = 150,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 9.5F
            },

            new Scoring
            {
                ScoringId = 598,
                PlayerId = 150,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 5.9F
            },

            new Scoring
            {
                ScoringId = 599,
                PlayerId = 150,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 11.5F
            },

            new Scoring
            {
                ScoringId = 600,
                PlayerId = 150,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 8.6F
            },

            new Scoring
            {
                ScoringId = 601,
                PlayerId = 151,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 6.8F
            },

            new Scoring
            {
                ScoringId = 602,
                PlayerId = 151,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 11.5F
            },

            new Scoring
            {
                ScoringId = 603,
                PlayerId = 151,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 19.9F
            },

            new Scoring
            {
                ScoringId = 604,
                PlayerId = 151,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 16.4F
            },

            new Scoring
            {
                ScoringId = 605,
                PlayerId = 152,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 7.8F
            },

            new Scoring
            {
                ScoringId = 606,
                PlayerId = 152,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = -2.8F
            },

            new Scoring
            {
                ScoringId = 607,
                PlayerId = 152,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 16.8F
            },

            new Scoring
            {
                ScoringId = 608,
                PlayerId = 152,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 2.3F
            },

            new Scoring
            {
                ScoringId = 609,
                PlayerId = 153,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -1.6F
            },

            new Scoring
            {
                ScoringId = 610,
                PlayerId = 153,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 19.5F
            },

            new Scoring
            {
                ScoringId = 611,
                PlayerId = 153,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -1.7F
            },

            new Scoring
            {
                ScoringId = 612,
                PlayerId = 153,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 6.8F
            },

            new Scoring
            {
                ScoringId = 613,
                PlayerId = 154,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 2.3F
            },

            new Scoring
            {
                ScoringId = 614,
                PlayerId = 154,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 12.4F
            },

            new Scoring
            {
                ScoringId = 615,
                PlayerId = 154,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -4.7F
            },

            new Scoring
            {
                ScoringId = 616,
                PlayerId = 154,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 15.2F
            },

            new Scoring
            {
                ScoringId = 617,
                PlayerId = 155,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -2.5F
            },

            new Scoring
            {
                ScoringId = 618,
                PlayerId = 155,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 11.7F
            },

            new Scoring
            {
                ScoringId = 619,
                PlayerId = 155,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -0.9F
            },

            new Scoring
            {
                ScoringId = 620,
                PlayerId = 155,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 4.1F
            },

            new Scoring
            {
                ScoringId = 621,
                PlayerId = 156,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 4.8F
            },

            new Scoring
            {
                ScoringId = 622,
                PlayerId = 156,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 18.5F
            },

            new Scoring
            {
                ScoringId = 623,
                PlayerId = 156,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 6.6F
            },

            new Scoring
            {
                ScoringId = 624,
                PlayerId = 156,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 9.2F
            },

            new Scoring
            {
                ScoringId = 625,
                PlayerId = 157,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 5.2F
            },

            new Scoring
            {
                ScoringId = 626,
                PlayerId = 157,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 17.0F
            },

            new Scoring
            {
                ScoringId = 627,
                PlayerId = 157,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 6.2F
            },

            new Scoring
            {
                ScoringId = 628,
                PlayerId = 157,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 7.3F
            },

            new Scoring
            {
                ScoringId = 629,
                PlayerId = 158,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 13.8F
            },

            new Scoring
            {
                ScoringId = 630,
                PlayerId = 158,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 1.9F
            },

            new Scoring
            {
                ScoringId = 631,
                PlayerId = 158,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 17.5F
            },

            new Scoring
            {
                ScoringId = 632,
                PlayerId = 158,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 7.9F
            },

            new Scoring
            {
                ScoringId = 633,
                PlayerId = 159,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = 11.9F
            },

            new Scoring
            {
                ScoringId = 634,
                PlayerId = 159,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 11.3F
            },

            new Scoring
            {
                ScoringId = 635,
                PlayerId = 159,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = -4.6F
            },

            new Scoring
            {
                ScoringId = 636,
                PlayerId = 159,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = -4.2F
            },

            new Scoring
            {
                ScoringId = 637,
                PlayerId = 160,
                SeasonYear = 2024,
                SeasonWeek = 1,
                Points = -5.0F
            },

            new Scoring
            {
                ScoringId = 638,
                PlayerId = 160,
                SeasonYear = 2024,
                SeasonWeek = 2,
                Points = 11.0F
            },

            new Scoring
            {
                ScoringId = 639,
                PlayerId = 160,
                SeasonYear = 2024,
                SeasonWeek = 3,
                Points = 3.8F
            },

            new Scoring
            {
                ScoringId = 640,
                PlayerId = 160,
                SeasonYear = 2024,
                SeasonWeek = 4,
                Points = 12.1F
            },
        });
    }
}
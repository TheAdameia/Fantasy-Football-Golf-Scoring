using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FantasyGolfball.Controllers;
using FantasyGolfball.Models.DTOs;
using FantasyGolfball.Data;
using Microsoft.AspNetCore.Identity;

public class RosterPlayerControllerTests
{
    [Fact]
    public void Post_ValidRosterPlayer_ReturnsOkResult()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<FantasyGolfballDbContext>()
            .UseInMemoryDatabase("TestDb")  // Use In-Memory Database for testing
            .Options;

        // Create a mock IConfiguration object
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                { "AdminPassword", "TestPassword" }  // Mock value for AdminPassword
            })
            .Build();

        using (var context = new FantasyGolfballDbContext(options, config))
        {
            // Add test user directly without password hash
            var user = new IdentityUser
            {
                Id = "test-user-id",
                UserName = "testuser",
                Email = "testuser@example.com"
            };

            var role = new IdentityRole { Id = "role-id", Name = "Admin" };

            context.Users.Add(user);
            context.Roles.Add(role);
            context.UserRoles.Add(new IdentityUserRole<string> { UserId = user.Id, RoleId = role.Id });

            context.SaveChanges();

            var controller = new RosterPlayerController(context);

            var rosterPlayerDTO = new RosterPlayerPOSTDTO
            {
                PlayerId = 1,
                RosterId = 1
            };

            // Act
            var result = controller.Post(rosterPlayerDTO);

            // Assert
            var createdPlayer = context.RosterPlayers.FirstOrDefault(rp => rp.PlayerId == 1 && rp.RosterId == 1);
            Assert.NotNull(createdPlayer); // Ensure the player was added to the DB
            Assert.IsType<OkResult>(result); // Ensure the response is 200 OK
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfHandicapMobile.MockAPI.Controllers
{
    using System.Threading;
    using HandicapMobile.MockAPI.Database;
    using HandicapMobile.MockAPI.Database.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly Func<MockDatabaseDbContext> MockDatabaseDbContextResolver;

        public PlayerController(Func<MockDatabaseDbContext> mockDatabaseDbContextResolver)
        {
            this.MockDatabaseDbContextResolver = mockDatabaseDbContextResolver;
        }

        [HttpPost]
        public async Task<IActionResult> PostPlayer([FromBody] RegisterPlayerRequest request,
                                                    CancellationToken cancellationToken)
        {
            // create a player
            Player player = new Player
                            {
                                PlayerId = Guid.NewGuid(),
                                LastName = request.LastName,
                                FirstName = request.FirstName,
                                DateOfBirth = request.DateOfBirth,
                                EmailAddress = request.EmailAddress,
                                ExactHandicap = request.ExactHandicap,
                                Gender = request.Gender,
                                MiddleName = request.MiddleName
                            };

            // create a user
            RegisteredUser user = new RegisteredUser
                                  {
                                      EmailAddress = request.EmailAddress,
                                      Password = "123456",
                                      UserId = Guid.NewGuid()
                                  };

            // Add to mock database
            using(MockDatabaseDbContext context = this.MockDatabaseDbContextResolver())
            {
                context.RegisteredUsers.Add(user);
                context.Players.Add(player);

                await context.SaveChangesAsync(cancellationToken);
            }

            return this.Ok(new RegisterPlayerResponse
                           {
                               PlayerId = player.PlayerId
                           });
        }
    }

    public class RegisterPlayerRequest
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public String FirstName { get; set; }

        /// <summary>
        /// Gets or sets the name of the middle.
        /// </summary>
        /// <value>
        /// The name of the middle.
        /// </value>
        public String MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public String LastName { get; set; }

        /// <summary>
        /// Gets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        public String Gender { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>
        /// The date of birth.
        /// </value>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets the exact handicap.
        /// </summary>
        /// <value>
        /// The exact handicap.
        /// </value>
        public Decimal ExactHandicap { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        public String EmailAddress { get; set; }
    }

    public class RegisterPlayerResponse
    {
        /// <summary>
        /// Gets or sets the player identifier.
        /// </summary>
        /// <value>
        /// The player identifier.
        /// </value>
        public Guid PlayerId { get; set; }
    }
}

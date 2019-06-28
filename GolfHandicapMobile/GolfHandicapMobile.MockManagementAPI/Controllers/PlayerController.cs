using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfHandicapMobile.MockAPI.Controllers
{
    using System.Threading;
    using DataTransferObjects;
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

        [HttpGet]
        public async Task<IActionResult> GetPlayer()
        {
            var gimp = this.Request.Headers.ToList();
            var authHeader = gimp.Where(x => x.Key == "Authorization").Select(x => x.Value).SingleOrDefault().SingleOrDefault();

            if (authHeader == null)
            {
                return this.Unauthorized();
            }

            // Parse the token
            String[] tokenValues = authHeader.Split('|');

            // Get the player id
            Guid playerId = Guid.Parse(tokenValues[2]);

            using(MockDatabaseDbContext context = this.MockDatabaseDbContextResolver())
            {
                // Find the player
                Player player = context.Players.Where(p => p.PlayerId == playerId).SingleOrDefault();

                if (player == null)
                {
                    return this.NotFound();
                }
                else
                {
                    return this.Ok(new GetPlayerDetailsResponse
                                   {
                                       DateOfBirth = player.DateOfBirth,
                                       FirstName = player.FirstName,
                                       EmailAddress = player.EmailAddress,
                                       LastName = player.LastName,
                                       ExactHandicap = player.ExactHandicap,
                                       Gender = player.Gender,
                                       FullName = $"{player.FirstName} {player.LastName}",
                                       HasBeenRegistered = true,
                                       PlayingHandicap = this.CalculatePlayingHandicap(player.ExactHandicap),
                                       HandicapCategory = this.CalculateHandicapCategory(this.CalculatePlayingHandicap(player.ExactHandicap))
                                   });
                }
            }
        }

        private Int32 CalculatePlayingHandicap(Decimal exactHandicap)
        {
            return Convert.ToInt32(Math.Round(exactHandicap, MidpointRounding.AwayFromZero));
        }

        private Int32 CalculateHandicapCategory(Int32 playingHandicap)
        {
            Int32 category = 0;

            switch (playingHandicap)
            {
                case var h when (h < 5):
                    category = 1;
                    break;
                case var h when (h >= 6 && h <= 12):
                    category = 2;
                    break;
                case var h when (h >= 13 && h <= 21):
                    category = 3;
                    break;
                case var h when (h >= 22 && h <= 28):
                    category = 4;
                    break;
                case var h when (h >= 29):
                    category = 5;
                    break;
            }

            return category;
        }
    }
}

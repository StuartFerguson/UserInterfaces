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
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Primitives;
    using MockDatabase.Database.Models;

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
                await context.RegisteredUsers.AddAsync(user,cancellationToken);
                await context.Players.AddAsync(player, cancellationToken);

                await context.SaveChangesAsync(cancellationToken);
            }

            return this.Ok(new RegisterPlayerResponse
                           {
                               PlayerId = player.PlayerId
                           });
        }

        [HttpGet]
        [Route("{playerId}")]
        public async Task<IActionResult> GetPlayer([FromRoute] Guid playerId)
        {
            List<KeyValuePair<String, StringValues>> headers = this.Request.Headers.ToList();
            
            using(MockDatabaseDbContext context = this.MockDatabaseDbContextResolver())
            {
                // Find the player
                Player player = context.Players.SingleOrDefault(p => p.PlayerId == playerId);

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

        [HttpGet]
        [Route("{playerId}/Memberships")]
        public async Task<IActionResult> GetPlayerMemberships([FromRoute] Guid playerId, CancellationToken cancellationToken)
        {
            List<KeyValuePair<String, StringValues>> headers = this.Request.Headers.ToList();
            String authHeader = headers.Where(x => x.Key == "Authorization").Select(x => x.Value).SingleOrDefault().SingleOrDefault();

            if (authHeader == null)
            {
                return this.Unauthorized();
            }
            
            using(MockDatabaseDbContext context = this.MockDatabaseDbContextResolver())
            {
                IQueryable<GolfClubMembership> playerMemberships = context.GolfClubMemberships.Where(m => m.PlayerId == playerId);

                if (!playerMemberships.Any())
                {
                    return this.NotFound();
                }

                List<ClubMembershipResponse> membershipResponses = new List<ClubMembershipResponse>();
                foreach (GolfClubMembership golfClubMembership in playerMemberships)
                {
                    membershipResponses.Add(new ClubMembershipResponse
                                            {
                                                AcceptedDateTime = golfClubMembership.AcceptedDateTime,
                                                GolfClubId = golfClubMembership.GolfClubId,
                                                MembershipId = golfClubMembership.MembershipId,
                                                GolfClubName = golfClubMembership.GolfClubName,
                                                MembershipNumber = "000001",
                                                Status = MembershipStatus.Accepted
                    });
                }

                return this.Ok(membershipResponses);
            }
        }

        [HttpGet]
        [Route("GolfClubList")]
        public async Task<IActionResult> GetGolfClubList(CancellationToken cancellationToken)
        {
            List<KeyValuePair<String, StringValues>> headers = this.Request.Headers.ToList();
            String authHeader = headers.Where(x => x.Key == "Authorization").Select(x => x.Value).SingleOrDefault().SingleOrDefault();

            if (authHeader == null)
            {
                return this.Unauthorized();
            }

            using (MockDatabaseDbContext context = this.MockDatabaseDbContextResolver())
            {
                // Find the clubs
                List<GolfClub> golfClubs = await context.GolfClubs.ToListAsync(cancellationToken);

                if (!golfClubs.Any())
                {
                    return this.NotFound();
                }
                else
                {
                    List<GetGolfClubResponse> response = new List<GetGolfClubResponse>();

                    foreach (GolfClub golfClub in golfClubs)
                    {
                        response.Add(new GetGolfClubResponse
                        {
                            AddressLine1 = golfClub.AddressLine1,
                            AddressLine2 = golfClub.AddressLine2,
                            EmailAddress = golfClub.EmailAddress,
                            Id = golfClub.GolfClubId,
                            Name = golfClub.Name,
                            PostalCode = golfClub.PostalCode,
                            Region = golfClub.Region,
                            TelephoneNumber = golfClub.TelephoneNumber,
                            Town = golfClub.Town,
                            Website = golfClub.Website
                        });
                    }

                    return this.Ok(response);
                }
            }
        }

        [HttpPost]
        [Route("{playerId}/GolfClub/{golfClubId}/RequestMembership")]
        public async Task<IActionResult> RequestClubMembership([FromRoute] Guid playerId,
                                                               [FromRoute] Guid golfClubId,
                                                               CancellationToken cancellationToken)
        {
            List<KeyValuePair<String, StringValues>> headers = this.Request.Headers.ToList();
            String authHeader = headers.Where(x => x.Key == "Authorization").Select(x => x.Value).SingleOrDefault().SingleOrDefault();

            if (authHeader == null)
            {
                return this.Unauthorized();
            }

            using (MockDatabaseDbContext context = this.MockDatabaseDbContextResolver())
            {
                Player player = context.Players.SingleOrDefault(p => p.PlayerId == playerId);

                if (player == null)
                {
                    return this.BadRequest();
                }

                GolfClub golfClub = context.GolfClubs.SingleOrDefault(c => c.GolfClubId == golfClubId);

                if (golfClub == null)
                {
                    return this.BadRequest();
                }

                GolfClubMembership membership = new GolfClubMembership
                {
                    PlayerId = playerId,
                    AcceptedDateTime = DateTime.Now,
                    GolfClubId = golfClubId,
                    GolfClubName = golfClub.Name,
                    MembershipId = Guid.NewGuid(),
                    PlayerDateOfBirth = player.DateOfBirth,
                    PlayerFullName = $"{player.FirstName} {player.LastName}",
                    PlayerGender = player.Gender,
                };

                await context.GolfClubMemberships.AddAsync(membership, cancellationToken);

                await context.SaveChangesAsync(cancellationToken);
            }

            return this.NoContent();
        }

        [HttpPut]
        [Route("{playerId}/Tournament/{tournamentId}/SignUp")]
        public async Task<IActionResult> SignUpForTournament([FromRoute] Guid playerId,
                                                             [FromRoute] Guid tournamentId,
                                                             CancellationToken cancellationToken)
        {
            List<KeyValuePair<String, StringValues>> headers = this.Request.Headers.ToList();
            String authHeader = headers.Where(x => x.Key == "Authorization").Select(x => x.Value).SingleOrDefault().SingleOrDefault();

            if (authHeader == null)
            {
                return this.Unauthorized();
            }

            using (MockDatabaseDbContext context = this.MockDatabaseDbContextResolver())
            {
                Player player = context.Players.SingleOrDefault(p => p.PlayerId == playerId);

                if (player == null)
                {
                    return this.BadRequest();
                }

                Tournament tournament = context.Tournaments.SingleOrDefault(t => t.TournamentId == tournamentId);

                if (tournament == null)
                {
                    return this.BadRequest();
                }

                PlayerTournamentSignIn playerTournamentSignIn = new PlayerTournamentSignIn
                                                                {
                                                                    PlayerId = playerId,
                                                                    TournamentId = tournamentId
                                                                };

                await context.PlayerTournamentSignIns.AddAsync(playerTournamentSignIn, cancellationToken);

                await context.SaveChangesAsync(cancellationToken);
            }

            return this.NoContent();
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

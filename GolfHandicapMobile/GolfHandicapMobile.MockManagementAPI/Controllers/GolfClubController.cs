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
    public class GolfClubController : ControllerBase
    {
        private readonly Func<MockDatabaseDbContext> MockDatabaseDbContextResolver;

        public GolfClubController(Func<MockDatabaseDbContext> mockDatabaseDbContextResolver)
        {
            this.MockDatabaseDbContextResolver = mockDatabaseDbContextResolver;
        }

        [HttpGet]
        [Route("List")]
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
                    List<GetGolfClubResponse> reponse = new List<GetGolfClubResponse>();

                    foreach (GolfClub golfClub in golfClubs)
                    {
                        reponse.Add(new GetGolfClubResponse
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

                    return this.Ok(reponse);
                }
            }
        }

        [HttpPost]
        [Route("{golfClubId}/RequestClubMembership")]
        public async Task<IActionResult> RequestClubMembership([FromRoute] Guid golfClubId,
                                                               CancellationToken cancellationToken)
        {
            List<KeyValuePair<String, StringValues>> headers = this.Request.Headers.ToList();
            String authHeader = headers.Where(x => x.Key == "Authorization").Select(x => x.Value).SingleOrDefault().SingleOrDefault();

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
                                                    GolfClubName =  golfClub.Name,
                                                    MembershipId = Guid.NewGuid(),
                                                    PlayerDateOfBirth = player.DateOfBirth,
                                                    PlayerFullName = $"{player.FirstName} {player.LastName}",
                                                    PlayerGender = player.Gender,
                                                };

                context.GolfClubMemberships.Add(membership);

                await context.SaveChangesAsync(cancellationToken);
            }

            return this.NoContent();
        }
    }
}

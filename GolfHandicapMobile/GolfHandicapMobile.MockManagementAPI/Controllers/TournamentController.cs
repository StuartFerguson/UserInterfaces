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
    using MockDatabase.Database.Models;

    [Route("/api/golfClub/{golfClubId}/Tournament")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly Func<MockDatabaseDbContext> MockDatabaseDbContextResolver;

        public TournamentController(Func<MockDatabaseDbContext> mockDatabaseDbContextResolver)
        {
            this.MockDatabaseDbContextResolver = mockDatabaseDbContextResolver;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetTournamentList([FromRoute] Guid golfClubId, CancellationToken cancellationToken)
        {
            GetTournamentListResponse response = new GetTournamentListResponse();

            using (MockDatabaseDbContext context = this.MockDatabaseDbContextResolver())
            {
                List<Tournament> tournaments = await context.Tournaments.Where(t => t.GolfClubId == golfClubId).ToListAsync(cancellationToken);

                foreach (Tournament tournament in tournaments)
                {
                    response.Tournaments.Add(new GetTournamentResponse
                                             {
                                                 TournamentName = tournament.TournamentName,
                                                 TournamentId = tournament.TournamentId,
                                                 TournamentDate = tournament.TournamentDate,
                                                 HasBeenCancelled = tournament.HasBeenCancelled,
                                                 HasBeenCompleted = tournament.HasBeenCompleted,
                                                 HasResultBeenProduced = tournament.HasResultBeenProduced,
                                                 MeasuredCourseId = tournament.MeasuredCourseId,
                                                 MeasuredCourseName = tournament.MeasuredCourseName,
                                                 MeasuredCourseSSS = tournament.MeasuredCourseSSS,
                                                 MeasuredCourseTeeColour = tournament.MeasuredCourseTeeColour,
                                                 PlayerCategory = (PlayerCategory)tournament.PlayerCategory,
                                                 PlayersScoresRecordedCount = tournament.PlayersScoresRecordedCount,
                                                 PlayersSignedUpCount = tournament.PlayersSignedUpCount,
                                                 TournamentFormat = (TournamentFormat)tournament.TournamentFormat
                                             });
                }
            }

            return this.Ok(response);
        }
    }

    public class GetTournamentListResponse
    {
        #region Properties

        /// <summary>
        /// Gets or sets the tournaments.
        /// </summary>
        /// <value>
        /// The tournaments.
        /// </value>
        public List<GetTournamentResponse> Tournaments { get; set; }

        public GetTournamentListResponse()
        {
            this.Tournaments= new List<GetTournamentResponse>();
        }

        #endregion
    }

    public class GetTournamentResponse
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether this instance has been cancelled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has been cancelled; otherwise, <c>false</c>.
        /// </value>
        public Boolean HasBeenCancelled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has been completed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has been completed; otherwise, <c>false</c>.
        /// </value>
        public Boolean HasBeenCompleted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has result been produced.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has result been produced; otherwise, <c>false</c>.
        /// </value>
        public Boolean HasResultBeenProduced { get; set; }

        /// <summary>
        /// Gets or sets the measured course identifier.
        /// </summary>
        /// <value>
        /// The measured course identifier.
        /// </value>
        public Guid MeasuredCourseId { get; set; }

        /// <summary>
        /// Gets or sets the name of the measured course.
        /// </summary>
        /// <value>
        /// The name of the measured course.
        /// </value>
        public String MeasuredCourseName { get; set; }

        /// <summary>
        /// Gets or sets the measured course SSS.
        /// </summary>
        /// <value>
        /// The measured course SSS.
        /// </value>
        public Int32 MeasuredCourseSSS { get; set; }

        /// <summary>
        /// Gets or sets the measured course tee colour.
        /// </summary>
        /// <value>
        /// The measured course tee colour.
        /// </value>
        public String MeasuredCourseTeeColour { get; set; }

        /// <summary>
        /// Gets or sets the player category.
        /// </summary>
        /// <value>
        /// The player category.
        /// </value>
        public PlayerCategory PlayerCategory { get; set; }

        /// <summary>
        /// Gets or sets the players scores recorded count.
        /// </summary>
        /// <value>
        /// The players scores recorded count.
        /// </value>
        public Int32 PlayersScoresRecordedCount { get; set; }

        /// <summary>
        /// Gets or sets the players signed up count.
        /// </summary>
        /// <value>
        /// The players signed up count.
        /// </value>
        public Int32 PlayersSignedUpCount { get; set; }

        /// <summary>
        /// Gets or sets the tournament date.
        /// </summary>
        /// <value>
        /// The tournament date.
        /// </value>
        public DateTime TournamentDate { get; set; }

        /// <summary>
        /// Gets or sets the tournament format.
        /// </summary>
        /// <value>
        /// The tournament format.
        /// </value>
        public TournamentFormat TournamentFormat { get; set; }

        /// <summary>
        /// Gets or sets the tournament identifier.
        /// </summary>
        /// <value>
        /// The tournament identifier.
        /// </value>
        public Guid TournamentId { get; set; }

        /// <summary>
        /// Gets or sets the name of the tournament.
        /// </summary>
        /// <value>
        /// The name of the tournament.
        /// </value>
        public String TournamentName { get; set; }

        #endregion
    }

    public enum TournamentFormat
    {
        StrokePlay = 1,
        Stableford = 2
    }

    public enum PlayerCategory
    {
        /// <summary>
        /// The gents
        /// </summary>
        Gents = 1,

        /// <summary>
        /// The gents senior
        /// </summary>
        GentsSenior,

        /// <summary>
        /// The female
        /// </summary>
        Female,

        /// <summary>
        /// The female senior
        /// </summary>
        FemaleSenior,

        /// <summary>
        /// The junior
        /// </summary>
        Junior
    }
}

namespace GolfClubAdminWebSite.Services
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using GolfHandicapMobile.ViewModels;
    using ManagementAPI.Service.Client;
    using ManagementAPI.Service.DataTransferObjects.Requests;
    using ManagementAPI.Service.DataTransferObjects.Responses;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="GolfClubAdminWebSite.Services.IClient" />
    [ExcludeFromCodeCoverage]
    public class ApiClient : IClient
    {
        #region Fields

        /// <summary>
        /// The golf club client
        /// </summary>
        private readonly IGolfClubClient GolfClubClient;

        /// <summary>
        /// The player client
        /// </summary>
        private readonly IPlayerClient PlayerClient;

        private readonly ITournamentClient TournamentClient;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient" /> class.
        /// </summary>
        /// <param name="playerClient">The player client.</param>
        /// <param name="golfClubClient">The golf club client.</param>
        public ApiClient(IPlayerClient playerClient,
                         IGolfClubClient golfClubClient,
                         ITournamentClient tournamentClient)
        {
            this.PlayerClient = playerClient;
            this.GolfClubClient = golfClubClient;
            this.TournamentClient = tournamentClient;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the golf club list.
        /// </summary>
        /// <param name="passwordToken">The password token.</param>
        /// <param name="playerId">The player identifier.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task GetGolfClubList(String passwordToken,
                                          Guid playerId,
                                          MyMembershipRequestClubListViewModel viewModel,
                                          CancellationToken cancellationToken)
        {
            List<GetGolfClubResponse> apiResponse = await this.PlayerClient.GetGolfClubList(passwordToken, playerId, cancellationToken);

            foreach (GetGolfClubResponse getGolfClubResponse in apiResponse)
            {
                viewModel.GolfClubList.Add(new GolfClubViewModel
                                           {
                                               GolfClubId = getGolfClubResponse.Id,
                                               GolfClubName = getGolfClubResponse.Name,
                                               PostCode = getGolfClubResponse.PostalCode,
                                               Region = getGolfClubResponse.Region,
                                               Town = getGolfClubResponse.Town
                                           });
            }
        }

        public async Task GetNextAvailableTournamentsForSignIn(String passwordToken,
                                                               Guid playerId,
                                                               MyTournamentsSignInViewModel viewModel,
                                                               CancellationToken cancellationToken)
        {
            // Get memberships
            List<ClubMembershipResponse> memberships = await this.PlayerClient.GetPlayerMemberships(passwordToken, playerId, cancellationToken);

            List<GetTournamentResponse> tournaments = new List<GetTournamentResponse>();

            // Get Tournaments
            foreach (ClubMembershipResponse clubMembershipResponse in memberships)
            {
                GetTournamentListResponse tournamentsForClub =
                    await this.TournamentClient.GetTournamentList(passwordToken, clubMembershipResponse.GolfClubId, cancellationToken);
                tournaments.AddRange(tournamentsForClub.Tournaments);
            }

            // Get First one (Need to decide how to actually sort these....)
            IEnumerable<GetTournamentResponse> availableTournaments = tournaments.Where(t => t.HasBeenCompleted == false && t.TournamentDate.Date == DateTime.Today);

            foreach (GetTournamentResponse getTournamentResponse in availableTournaments)
            {
                if (viewModel.Tournaments == null)
                {
                    viewModel.Tournaments = new ObservableCollection<TournamentSignInViewModel>();
                }

                viewModel.Tournaments.Add(new TournamentSignInViewModel
                                          {
                                              TournamentId = getTournamentResponse.TournamentId,
                                              CourseName = getTournamentResponse.MeasuredCourseName,
                                              TournamentName = getTournamentResponse.TournamentName,
                                              TournamentDate = getTournamentResponse.TournamentDate,
                                              Format = getTournamentResponse.TournamentFormat.ToString()
                                          });
            }
        }

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <param name="passwordToken">The password token.</param>
        /// <param name="playerId">The player identifier.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task GetPlayer(String passwordToken,
                                    Guid playerId,
                                    MyDetailsViewModel viewModel,
                                    CancellationToken cancellationToken)
        {
            GetPlayerDetailsResponse apiResponse = await this.PlayerClient.GetPlayer(passwordToken, playerId, cancellationToken);

            viewModel.FirstName = apiResponse.FirstName;
            viewModel.HasBeenRegistered = apiResponse.HasBeenRegistered;
            viewModel.LastName = apiResponse.LastName;
            viewModel.MiddleName = apiResponse.MiddleName;
            viewModel.PlayingHandicap = apiResponse.PlayingHandicap;
            viewModel.DateOfBirth = apiResponse.DateOfBirth;
            viewModel.EmailAddress = apiResponse.EmailAddress;
            viewModel.ExactHandicap = apiResponse.ExactHandicap;
            viewModel.FullName = apiResponse.FullName;
            viewModel.Gender = apiResponse.Gender == "M" ? 0 : 1;
            viewModel.GenderDescription = apiResponse.Gender == "M" ? "Male" : "Female";
            viewModel.HandicapCategory = apiResponse.HandicapCategory;
        }

        /// <summary>
        /// Gets the player memberships.
        /// </summary>
        /// <param name="passwordToken">The password token.</param>
        /// <param name="playerId">The player identifier.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task GetPlayerMemberships(String passwordToken,
                                               Guid playerId,
                                               MyMembershipsListViewModel viewModel,
                                               CancellationToken cancellationToken)
        {
            try
            {
                List<ClubMembershipResponse> apiResponse = await this.PlayerClient.GetPlayerMemberships(passwordToken, playerId, cancellationToken);

                foreach (ClubMembershipResponse clubMembershipResponse in apiResponse)
                {
                    // Only show accepted memberships
                    if (clubMembershipResponse.Status == MembershipStatus.Accepted)
                    {
                        viewModel.Memberships.Add(new MembershipViewModel
                                                  {
                                                      GolfClubId = clubMembershipResponse.GolfClubId,
                                                      GolfClubName = clubMembershipResponse.GolfClubName,
                                                      MembershipId = clubMembershipResponse.MembershipId,
                                                      MembershipNumber = clubMembershipResponse.MembershipNumber,
                                                      DateJoined = clubMembershipResponse.AcceptedDateTime.Value
                                                  });
                    }
                }
            }
            catch(Exception ex)
            {
                // Look at the inner exception
                if (ex.InnerException is KeyNotFoundException)
                {
                    // Swallow this exception and set the view model list to empty
                    viewModel.Memberships = new ObservableCollection<MembershipViewModel>();
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task GetSignedUpTournament(String passwordToken,
                                                Guid playerId,
                                                MyTournamentsViewModel viewModel,
                                                CancellationToken cancellationToken)
        {
            // TODO: Need a new API method so will hardcode for now
            viewModel.SignedUpTournament = new SignedUpTournamentViewModel
                                           {
                                               TournamentName = "Thornton Open"
                                           };
        }

        public async Task GetTopPlayerScores(String passwordToken,
                                             Guid playerId,
                                             Int32 numberOfScores,
                                             MyTournamentsViewModel viewModel,
                                             CancellationToken cancellationToken)
        {
            // TODO: No API method yet for this so we will hardcode
            for (Int32 i = 0; i < numberOfScores; i++)
            {
                viewModel.TournamentScores.Add(new TournamentScoreViewModel
                                               {
                                                   CSS = 72,
                                                   CourseName = "Crieff Golf Club",
                                                   GrossScore = 82,
                                                   NetScore = 75,
                                                   PlayingHandicap = 7,
                                                   TournamentDate = new DateTime(2019, 7, 28),
                                                   TournamentName = "Morton Burnett Open"
                                               });
            }
        }

        /// <summary>
        /// Registers the player.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task RegisterPlayer(RegistrationViewModel viewModel,
                                         CancellationToken cancellationToken)
        {
            // Translate the view model into the api request
            RegisterPlayerRequest apiRequest = new RegisterPlayerRequest
                                               {
                                                   DateOfBirth = viewModel.DateOfBirth,
                                                   Gender = viewModel.Gender == 0 ? "M" : "F",
                                                   EmailAddress = viewModel.EmailAddress,
                                                   MiddleName = viewModel.MiddleName,
                                                   ExactHandicap = decimal.Parse(viewModel.ExactHandicap),
                                                   FamilyName = viewModel.LastName,
                                                   GivenName = viewModel.FirstName
                                               };

            RegisterPlayerResponse apiResponse = await this.PlayerClient.RegisterPlayer(apiRequest, cancellationToken);

            // Set the result in the view model
            viewModel.PlayerId = apiResponse.PlayerId;
        }

        /// <summary>
        /// Requests the club membership.
        /// </summary>
        /// <param name="passwordToken">The password token.</param>
        /// <param name="playerId">The player identifier.</param>
        /// <param name="golfClubId">The golf club identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task RequestClubMembership(String passwordToken,
                                                Guid playerId,
                                                Guid golfClubId,
                                                CancellationToken cancellationToken)
        {
            await this.PlayerClient.RequestClubMembership(passwordToken, playerId, golfClubId, cancellationToken);
        }

        /// <summary>
        /// Tournaments the sign in.
        /// </summary>
        /// <param name="passwordToken">The password token.</param>
        /// <param name="playerId">The player identifier.</param>
        /// <param name="tournamentId">The tournament identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task TournamentSignIn(String passwordToken,
                                           Guid playerId,
                                           Guid tournamentId,
                                           CancellationToken cancellationToken)
        {
            await this.PlayerClient.SignUpPlayerForTournament(passwordToken, playerId, tournamentId, cancellationToken);
        }

        #endregion
    }
}
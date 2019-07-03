namespace GolfClubAdminWebSite.Services
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
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
        /// The player client
        /// </summary>
        private readonly IPlayerClient PlayerClient;

        /// <summary>
        /// The golf club client
        /// </summary>
        private readonly IGolfClubClient GolfClubClient;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient" /> class.
        /// </summary>
        /// <param name="playerClient">The player client.</param>
        /// <param name="golfClubClient">The golf club client.</param>
        public ApiClient(IPlayerClient playerClient, IGolfClubClient golfClubClient)
        {
            this.PlayerClient = playerClient;
            this.GolfClubClient = golfClubClient;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <param name="passwordToken">The password token.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task GetPlayer(String passwordToken,
                                    MyDetailsViewModel viewModel,
                                    CancellationToken cancellationToken)
        {
            GetPlayerDetailsResponse apiResponse = await this.PlayerClient.GetPlayer(passwordToken, cancellationToken);

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
            viewModel.HandicapCategory = apiResponse.HandicapCategory;
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
                                                   FirstName = viewModel.FirstName,
                                                   LastName = viewModel.LastName
                                               };

            RegisterPlayerResponse apiResponse = await this.PlayerClient.RegisterPlayer(apiRequest, cancellationToken);

            // Set the result in the view model
            viewModel.PlayerId = apiResponse.PlayerId;
        }

        /// <summary>
        /// Requests the club membership.
        /// </summary>
        /// <param name="passwordToken">The password token.</param>
        /// <param name="golfClubId">The golf club identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task RequestClubMembership(String passwordToken,
                                                Guid golfClubId,
                                                CancellationToken cancellationToken)
        {
            await this.GolfClubClient.RequestClubMembership(passwordToken, golfClubId, cancellationToken);
        }

        /// <summary>
        /// Gets the golf club list.
        /// </summary>
        /// <param name="passwordToken">The password token.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task GetGolfClubList(String passwordToken,
                                          MyMembershipRequestClubListViewModel viewModel,
                                          CancellationToken cancellationToken)
        {
            List<GetGolfClubResponse> apiResponse = await this.GolfClubClient.GetGolfClubList(passwordToken, cancellationToken);

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

        /// <summary>
        /// Gets the player memberships.
        /// </summary>
        /// <param name="passwordToken">The password token.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task GetPlayerMemberships(String passwordToken,
                                               MyMembershipsListViewModel viewModel,
                                               CancellationToken cancellationToken)
        {
            try
            {
                List<ClubMembershipResponse> apiResponse = await this.PlayerClient.GetPlayerMemberships(passwordToken, cancellationToken);

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

        #endregion
    }
}
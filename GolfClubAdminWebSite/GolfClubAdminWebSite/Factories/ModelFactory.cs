namespace GolfClubAdminWebSite.Factories
{
    using System.Collections.Generic;
    using Areas.Account.Models;
    using Areas.GolfClubAdministrator.Models;
    using ManagementAPI.Service.DataTransferObjects;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="GolfClubAdminWebSite.Factories.IModelFactory" />
    public class ModelFactory : IModelFactory
    {
        #region Methods

        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        public RegisterClubAdministratorRequest ConvertFrom(RegisterClubAdministratorViewModel viewModel)
        {
            RegisterClubAdministratorRequest registerRegisterClubAdministratorRequest = new RegisterClubAdministratorRequest
                                                                                        {
                                                                                            ConfirmPassword = viewModel.ConfirmPassword,
                                                                                            EmailAddress = viewModel.Email,
                                                                                            Password = viewModel.Password,
                                                                                            TelephoneNumber = viewModel.TelephoneNumber
                                                                                        };

            return registerRegisterClubAdministratorRequest;
        }

        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        public CreateGolfClubRequest ConvertFrom(CreateGolfClubViewModel viewModel)
        {
            CreateGolfClubRequest createGolfClubRequest = new CreateGolfClubRequest
                                                          {
                                                              AddressLine1 = viewModel.AddressLine1,
                                                              Region = viewModel.Region,
                                                              Town = viewModel.Town,
                                                              Website = viewModel.Website,
                                                              Name = viewModel.Name,
                                                              TelephoneNumber = viewModel.TelephoneNumber,
                                                              EmailAddress = viewModel.EmailAddress,
                                                              AddressLine2 = viewModel.AddressLine2,
                                                              PostalCode = viewModel.PostalCode,
                                                              TournamentDivisions = new List<TournamentDivision>()
                                                          };

            return createGolfClubRequest;
        }

        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="apiResponse">The API response.</param>
        /// <returns></returns>
        public UpdateGolfClubViewModel ConvertFrom(GetGolfClubResponse apiResponse)
        {
            UpdateGolfClubViewModel viewModel = new UpdateGolfClubViewModel
                                                {
                                                    Region = apiResponse.Region,
                                                    Town = apiResponse.Town,
                                                    Website = apiResponse.Website,
                                                    EmailAddress = apiResponse.EmailAddress,
                                                    Name = apiResponse.Name,
                                                    TelephoneNumber = apiResponse.TelephoneNumber,
                                                    AddressLine1 = apiResponse.AddressLine1,
                                                    AddressLine2 = apiResponse.AddressLine2,
                                                    PostalCode = apiResponse.PostalCode,
                                                    Id = apiResponse.Id
                                                };

            return viewModel;
        }

        #endregion
    }
}
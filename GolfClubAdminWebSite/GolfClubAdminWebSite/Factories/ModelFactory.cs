namespace GolfClubAdminWebSite.Factories
{
    using Areas.Account.Models;
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

        #endregion
    }
}
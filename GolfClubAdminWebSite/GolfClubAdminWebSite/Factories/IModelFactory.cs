namespace GolfClubAdminWebSite.Factories
{
    using Areas.Account.Models;
    using Areas.GolfClubAdministrator.Models;
    using ManagementAPI.Service.DataTransferObjects;

    /// <summary>
    /// 
    /// </summary>
    public interface IModelFactory
    {
        #region Methods

        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        RegisterClubAdministratorRequest ConvertFrom(RegisterClubAdministratorViewModel viewModel);

        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        CreateGolfClubRequest ConvertFrom(CreateGolfClubViewModel viewModel);

        #endregion

        UpdateGolfClubViewModel ConvertFrom(GetGolfClubResponse apiResponse);
    }
}
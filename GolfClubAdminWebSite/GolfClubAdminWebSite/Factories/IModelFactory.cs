namespace GolfClubAdminWebSite.Factories
{
    using Areas.Account.Models;
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

        #endregion
    }
}
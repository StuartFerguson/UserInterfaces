namespace GolfClubAdminWebSite.Factories
{
    using System.Collections.Generic;
    using Areas.Account.Models;
    using Areas.GolfClubAdministrator.Models;
    using ManagementAPI.Service.DataTransferObjects;
    using ManagementAPI.Service.DataTransferObjects.Requests;
    using ManagementAPI.Service.DataTransferObjects.Responses;

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

        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="apiResponse">The API response.</param>
        /// <returns></returns>
        UpdateGolfClubViewModel ConvertFrom(GetGolfClubResponse apiResponse);

        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        AddMeasuredCourseToClubRequest ConvertFrom(MeasuredCourseViewModel viewModel);

        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="apiResponse">The API response.</param>
        /// <returns></returns>
        List<MeasuredCourseListViewModel> ConvertFrom(GetMeasuredCourseListResponse apiResponse);
    }
}
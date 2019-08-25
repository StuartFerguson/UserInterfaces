namespace GolfClubAdminWebSite.Factories
{
    using System.Collections.Generic;
    using Areas.Account.Models;
    using Areas.GolfClubAdministrator.Models;
    using Areas.MatchSecretary.Models;
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

        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="apiResponse">The API response.</param>
        /// <returns></returns>
        List<GetGolfClubUserListViewModel> ConvertFrom(GetGolfClubUserListResponse apiResponse);

        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        CreateMatchSecretaryRequest ConvertFrom(CreateGolfClubUserViewModel viewModel);

        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        CreateTournamentRequest ConvertFrom(CreateTournamentViewModel viewModel);

        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="apiResponse">The API response.</param>
        /// <returns></returns>
        List<GetTournamentListViewModel> ConvertFrom(GetTournamentListResponse apiResponse);

        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="apiResponse">The API response.</param>
        /// <returns></returns>
        ChartJsLineChartDataViewModel ConvertFrom(GetNumberOfMembersByTimePeriodReportResponse apiResponse);

        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="apiResponse">The API response.</param>
        /// <returns></returns>
        ChartJsPieChartDataViewModel ConvertFrom(GetNumberOfMembersByHandicapCategoryReportResponse apiResponse);

        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="apiResponse">The API response.</param>
        /// <returns></returns>
        ChartJsPieChartDataViewModel ConvertFrom(GetNumberOfMembersByAgeCategoryReportResponse apiResponse);

        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="apiResponse">The API response.</param>
        /// <returns></returns>
        NumberOfMembersReportViewModel ConvertFrom(GetNumberOfMembersReportResponse apiResponse);

        #endregion
    }
}
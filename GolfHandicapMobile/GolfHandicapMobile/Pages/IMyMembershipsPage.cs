using System;
using System.Collections.Generic;
using System.Text;

namespace GolfHandicapMobile.Pages
{
    using ViewModels;

    public interface IMyMembershipsPage
    {
        /// <summary>
        /// Occurs when [home button click].
        /// </summary>
        event EventHandler HomeButtonClick;

        /// <summary>
        /// Occurs when [request club membership button click].
        /// </summary>
        event EventHandler RequestClubMembershipButtonClick;

        #region Methods

        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        void Init(MyMembershipsListViewModel viewModel);

        #endregion
    }
}

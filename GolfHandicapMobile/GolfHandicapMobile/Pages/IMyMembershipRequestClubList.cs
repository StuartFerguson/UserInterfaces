using System;
using System.Collections.Generic;
using System.Text;

namespace GolfHandicapMobile.Pages
{
    using ViewModels;

    public interface IMyMembershipRequestClubListPage
    {
        event EventHandler RequestMembershipButtonClick;

        /// <summary>
        /// Occurs when [home button click].
        /// </summary>
        event EventHandler HomeButtonClick;

        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        void Init(MyMembershipRequestClubListViewModel viewModel);
    }
}

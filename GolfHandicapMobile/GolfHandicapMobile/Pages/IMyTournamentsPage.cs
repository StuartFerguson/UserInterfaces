using System;
using System.Collections.Generic;
using System.Text;

namespace GolfHandicapMobile.Pages
{
    using ViewModels;

    public interface IMyTournamentsPage
    {
        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        void Init(MyTournamentsViewModel viewModel);
    }
}

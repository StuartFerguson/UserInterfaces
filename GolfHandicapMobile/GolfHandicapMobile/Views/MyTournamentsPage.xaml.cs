using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GolfHandicapMobile.Views
{
    using Pages;
    using ViewModels;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyTournamentsPage : ContentPage, IMyTournamentsPage, IPage
    {
        public MyTournamentsPage()
        {
            InitializeComponent();
            Shell.Current.FlyoutIsPresented = false;
        }

        public void Init(MyTournamentsViewModel viewModel)
        {
            this.BindingContext = viewModel;
        }
    }
}
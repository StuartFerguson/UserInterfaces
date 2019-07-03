using System;
using System.Collections.Generic;
using System.Text;

namespace GolfHandicapMobile.ViewModels
{
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class MyMembershipRequestClubListViewModel : BindableObject
    {
        private ObservableCollection<GolfClubViewModel> golfClubList;
        public ObservableCollection<GolfClubViewModel> GolfClubList
        {
            get
            {
                if (this.golfClubList == null)
                {
                    this.golfClubList = new ObservableCollection<GolfClubViewModel>();
                }

                return this.golfClubList;
            }
            set
            {
                if (this.golfClubList != value)
                {
                    this.golfClubList = value;

                    this.OnPropertyChanged(nameof(this.GolfClubList));
                }
            }
        }

        private GolfClubViewModel selectedGolfClub;

        public GolfClubViewModel SelectedGolfClub
        {
            get
            {
                return this.selectedGolfClub;
            }
            set
            {
                this.selectedGolfClub = value;
                this.OnPropertyChanged(nameof(this.SelectedGolfClub));
            }
        }
    }

    public class GolfClubViewModel
    {
        public Guid GolfClubId { get; set; }

        public String GolfClubName { get; set; }

        public String Town { get; set; }

        public String Region { get; set; }
        
        public String PostCode { get; set; }
    }
}

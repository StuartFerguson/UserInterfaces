using System;
using System.Collections.Generic;
using System.Text;

namespace GolfHandicapMobile.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Xamarin.Forms;

    public class MyMembershipsListViewModel : BindableObject
    {
        public MyMembershipsListViewModel()
        {
            this.memberships = new ObservableCollection<MembershipViewModel>();
        }

        private ObservableCollection<MembershipViewModel> memberships;
        public ObservableCollection<MembershipViewModel> Memberships
        {
            get
            {
                if (this.memberships == null)
                {
                    this.memberships = new ObservableCollection<MembershipViewModel>();
                }

                return this.memberships;
            }
            set
            {
                if (this.memberships != value)
                {
                    this.memberships = value;

                    this.OnPropertyChanged(nameof(this.Memberships));
                }
            }
        }
    }

    public class MembershipViewModel
    {
        public Guid MembershipId { get; set; }
        public Guid GolfClubId { get; set; }
        public String GolfClubName { get; set; }
        public String MembershipNumber { get; set; }
        public DateTime DateJoined { get; set; }
    }
}

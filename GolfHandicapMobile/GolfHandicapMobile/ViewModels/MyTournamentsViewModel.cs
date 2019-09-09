using System;
using System.Collections.Generic;
using System.Text;

namespace GolfHandicapMobile.ViewModels
{
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class MyTournamentsViewModel : BindableObject
    {
        private ObservableCollection<TournamentScoreViewModel> tournamentScores;

        private SignedUpTournamentViewModel signedUpTournament;

        public SignedUpTournamentViewModel SignedUpTournament
        {
            get
            {
                return this.signedUpTournament;
            }
            set
            {
                this.signedUpTournament = value;
                this.OnPropertyChanged(nameof(this.SignedUpTournament));
            }
        }

        public ObservableCollection<TournamentScoreViewModel> TournamentScores
        {
            get
            {
                if (this.tournamentScores == null)
                {
                    this.tournamentScores = new ObservableCollection<TournamentScoreViewModel>();
                }

                return this.tournamentScores;
            }
            set
            {
                if (this.tournamentScores != value)
                {
                    this.tournamentScores = value;

                    this.OnPropertyChanged(nameof(this.TournamentScores));
                }
            }
        }
    }

    public class TournamentScoreViewModel
    {
        public String TournamentName { get; set; }

        public DateTime TournamentDate { get; set; }

        public String CourseName { get; set; }

        public Int32 CSS { get; set; }

        public Int32 GrossScore { get; set; }

        public Int32 PlayingHandicap { get; set; }

        public Int32 NetScore { get; set; }
    }

    public class SignedUpTournamentViewModel
    {
        public String TournamentName { get; set; }
    }
}

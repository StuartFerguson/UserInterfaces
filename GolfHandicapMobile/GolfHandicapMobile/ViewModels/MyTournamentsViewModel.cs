namespace GolfHandicapMobile.ViewModels
{
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Xamarin.Forms.BindableObject" />
    public class MyTournamentsViewModel : BindableObject
    {
        #region Fields

        /// <summary>
        /// The signed up tournament
        /// </summary>
        private SignedUpTournamentViewModel signedUpTournament;

        /// <summary>
        /// The tournament scores
        /// </summary>
        private ObservableCollection<TournamentScoreViewModel> tournamentScores;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the signed up tournament.
        /// </summary>
        /// <value>
        /// The signed up tournament.
        /// </value>
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

        /// <summary>
        /// Gets or sets the tournament scores.
        /// </summary>
        /// <value>
        /// The tournament scores.
        /// </value>
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

        #endregion
    }
}
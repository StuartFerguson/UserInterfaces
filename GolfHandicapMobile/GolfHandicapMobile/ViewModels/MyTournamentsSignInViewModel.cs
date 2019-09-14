namespace GolfHandicapMobile.ViewModels
{
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Xamarin.Forms.BindableObject" />
    public class MyTournamentsSignInViewModel : BindableObject
    {
        #region Fields

        /// <summary>
        /// The selected tournament
        /// </summary>
        private TournamentSignInViewModel selectedTournament;

        /// <summary>
        /// The tournaments
        /// </summary>
        private ObservableCollection<TournamentSignInViewModel> tournaments;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the selected tournament.
        /// </summary>
        /// <value>
        /// The selected tournament.
        /// </value>
        public TournamentSignInViewModel SelectedTournament
        {
            get
            {
                return this.selectedTournament;
            }
            set
            {
                this.selectedTournament = value;
                this.OnPropertyChanged(nameof(this.SelectedTournament));
            }
        }

        /// <summary>
        /// Gets or sets the tournaments.
        /// </summary>
        /// <value>
        /// The tournaments.
        /// </value>
        public ObservableCollection<TournamentSignInViewModel> Tournaments
        {
            get
            {
                if (this.tournaments == null)
                {
                    this.tournaments = new ObservableCollection<TournamentSignInViewModel>();
                }

                return this.tournaments;
            }
            set
            {
                if (this.tournaments != value)
                {
                    this.tournaments = value;

                    this.OnPropertyChanged(nameof(this.Tournaments));
                }
            }
        }

        #endregion
    }
}
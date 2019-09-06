namespace GolfHandicapMobile.ViewModels
{
    using System;
    using Xamarin.Forms;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Xamarin.Forms.BindableObject" />
    public class MyDetailsViewModel : BindableObject
    {
        #region Fields

        /// <summary>
        /// The date of birth
        /// </summary>
        private DateTime dateOfBirth;

        /// <summary>
        /// The email address
        /// </summary>
        private String emailAddress;

        /// <summary>
        /// The exact handicap
        /// </summary>
        private Decimal exactHandicap;

        /// <summary>
        /// The first name
        /// </summary>
        private String firstName;

        /// <summary>
        /// The full name
        /// </summary>
        private String fullName;

        /// <summary>
        /// The gender
        /// </summary>
        private Int32 gender;

        /// <summary>
        /// The genderdescription
        /// </summary>
        private String genderdescription;

        /// <summary>
        /// The handicap category
        /// </summary>
        private Int32 handicapCategory;

        /// <summary>
        /// The has been registered
        /// </summary>
        private Boolean hasBeenRegistered;

        /// <summary>
        /// The last name
        /// </summary>
        private String lastName;

        /// <summary>
        /// The middle name
        /// </summary>
        private String middleName;

        /// <summary>
        /// The playing handicap
        /// </summary>
        private Int32 playingHandicap;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>
        /// The date of birth.
        /// </value>
        public DateTime DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }
            set
            {
                this.dateOfBirth = value;
                this.OnPropertyChanged(nameof(this.DateOfBirth));
            }
        }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        public String EmailAddress
        {
            get
            {
                return this.emailAddress;
            }
            set
            {
                this.emailAddress = value;
                this.OnPropertyChanged(nameof(this.EmailAddress));
            }
        }

        /// <summary>
        /// Gets or sets the exact handicap.
        /// </summary>
        /// <value>
        /// The exact handicap.
        /// </value>
        public Decimal ExactHandicap
        {
            get
            {
                return this.exactHandicap;
            }
            set
            {
                this.exactHandicap = value;
                this.OnPropertyChanged(nameof(this.ExactHandicap));
            }
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public String FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
                this.OnPropertyChanged(nameof(this.FirstName));
            }
        }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public String FullName
        {
            get
            {
                return this.fullName;
            }
            set
            {
                this.fullName = value;
                this.OnPropertyChanged(nameof(this.FullName));
            }
        }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        public Int32 Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                this.gender = value;
                this.OnPropertyChanged(nameof(this.Gender));
            }
        }

        /// <summary>
        /// Gets or sets the gender description.
        /// </summary>
        /// <value>
        /// The gender description.
        /// </value>
        public String GenderDescription
        {
            get
            {
                return this.genderdescription;
            }
            set
            {
                this.genderdescription = value;
                this.OnPropertyChanged(nameof(this.Gender));
            }
        }

        /// <summary>
        /// Gets or sets the handicap category.
        /// </summary>
        /// <value>
        /// The handicap category.
        /// </value>
        public Int32 HandicapCategory
        {
            get
            {
                return this.handicapCategory;
            }
            set
            {
                this.handicapCategory = value;
                this.OnPropertyChanged(nameof(this.HandicapCategory));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has been registered.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has been registered; otherwise, <c>false</c>.
        /// </value>
        public Boolean HasBeenRegistered
        {
            get
            {
                return this.hasBeenRegistered;
            }
            set
            {
                this.hasBeenRegistered = value;
                this.OnPropertyChanged(nameof(this.HasBeenRegistered));
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public String LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
                this.OnPropertyChanged(nameof(this.LastName));
            }
        }

        /// <summary>
        /// Gets or sets the name of the middle.
        /// </summary>
        /// <value>
        /// The name of the middle.
        /// </value>
        public String MiddleName
        {
            get
            {
                return this.middleName;
            }
            set
            {
                this.middleName = value;
                this.OnPropertyChanged(nameof(this.MiddleName));
            }
        }

        /// <summary>
        /// Gets or sets the playing handicap.
        /// </summary>
        /// <value>
        /// The playing handicap.
        /// </value>
        public Int32 PlayingHandicap
        {
            get
            {
                return this.playingHandicap;
            }
            set
            {
                this.playingHandicap = value;
                this.OnPropertyChanged(nameof(this.PlayingHandicap));
            }
        }

        #endregion
    }
}
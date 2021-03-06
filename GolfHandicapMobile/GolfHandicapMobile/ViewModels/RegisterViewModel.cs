﻿namespace GolfHandicapMobile.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using Xamarin.Forms;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Xamarin.Forms.BindableObject" />
    public class RegistrationViewModel : BindableObject
    {
        #region Fields

        /// <summary>
        /// The date of birth
        /// </summary>
        private DateTime dateOfBirth;

        /// <summary>
        /// The default date of birth
        /// </summary>
        private ObservableCollection<Object> defaultDateOfBirth;

        /// <summary>
        /// The email address
        /// </summary>
        private String emailAddress;

        /// <summary>
        /// The exact handicap
        /// </summary>
        private String exactHandicap;

        /// <summary>
        /// The first name
        /// </summary>
        private String firstName;

        /// <summary>
        /// The gender
        /// </summary>
        private Int32 gender;

        /// <summary>
        /// The last name
        /// </summary>
        private String lastName;

        /// <summary>
        /// The middle name
        /// </summary>
        private String middleName;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        /// <value>
        /// The age.
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
        /// Gets or sets the default date of birth.
        /// </summary>
        /// <value>
        /// The default date of birth.
        /// </value>
        public ObservableCollection<Object> DefaultDateOfBirth
        {
            get
            {
                return this.defaultDateOfBirth;
            }
            set
            {
                this.defaultDateOfBirth = value;
                this.OnPropertyChanged(nameof(this.DefaultDateOfBirth));
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
        public String ExactHandicap
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
        /// Gets or sets the player identifier.
        /// </summary>
        /// <value>
        /// The player identifier.
        /// </value>
        public Guid PlayerId { get; set; }

        /// <summary>
        /// Gets or sets the registration failed message.
        /// </summary>
        /// <value>
        /// The registration failed message.
        /// </value>
        public String RegistrationFailedMessage { get; set; }

        public RegistrationViewModel()
        {
            ObservableCollection<object> todaycollection = new ObservableCollection<object>();

            //Select today dates
            todaycollection.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Date.Month).Substring(0, 3));
            if (DateTime.Now.Date.Day < 10)
                todaycollection.Add("0" + DateTime.Now.Date.Day);
            else
                todaycollection.Add(DateTime.Now.Date.Day.ToString());
            todaycollection.Add(DateTime.Now.Date.Year.ToString());

            this.DefaultDateOfBirth = todaycollection;
        }

        #endregion
    }
}
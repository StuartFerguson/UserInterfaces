﻿namespace GolfHandicapMobile.Views
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using Pages;
    using Plugin.Toast;
    using Syncfusion.XForms.TextInputLayout;
    using ViewModels;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using SelectionChangedEventArgs = Syncfusion.XForms.ComboBox.SelectionChangedEventArgs;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    /// <seealso cref="GolfHandicapMobile.Pages.IRegistrationPage" />
    /// <seealso cref="GolfHandicapMobile.Pages.IPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage, IRegistrationPage, IPage
    {
        #region Fields

        /// <summary>
        /// The view model
        /// </summary>
        private RegistrationViewModel ViewModel;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationPage" /> class.
        /// </summary>
        public RegistrationPage()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when [register button click].
        /// </summary>
        public event EventHandler RegisterButtonClick;

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public void Init(RegistrationViewModel viewModel)
        {
            this.ViewModel = viewModel;
            
            this.FirstName.TextChanged += this.FirstName_TextChanged;
            this.FirstName.Completed += this.FirstName_OnCompleted;

            this.LastName.TextChanged += this.LastName_TextChanged;
            this.LastName.Completed += this.LastName_OnCompleted;

            this.Gender.SelectionChanged += this.GenderOnSelectionChanged;
            
            this.ExactHandicap.TextChanged += this.ExactHandicap_TextChanged;
            this.ExactHandicap.Completed += this.ExactHandicap_OnCompleted;

            this.EmailAddress.TextChanged += this.EmailAddress_TextChanged;
            this.EmailAddress.Completed += this.EmailAddress_OnCompleted;

            this.Register.Clicked += this.Register_Clicked;
        }

        /// <summary>
        /// Sets the registration failure message.
        /// </summary>
        /// <param name="failureMessage">The failure message.</param>
        public void SetRegistrationFailureMessage(String failureMessage)
        {
            if (!string.IsNullOrEmpty(failureMessage))
            {
                this.RegistrationStatus.IsVisible = true;
                if (!string.IsNullOrEmpty(this.RegistrationStatus.Text))
                {
                    this.RegistrationStatus.Text += Environment.NewLine;
                }

                this.RegistrationStatus.Text += failureMessage;
                this.RegistrationStatus.TextColor = Color.Red;
            }
            else
            {
                this.RegistrationStatus.IsVisible = false;
                this.RegistrationStatus.Text = failureMessage;
            }
        }

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.FirstName.Focus();
        }

        /// <summary>
        /// Clears the error.
        /// </summary>
        /// <param name="label">The label.</param>
        private void ClearError(Label label)
        {
            label.Text = string.Empty;
            label.IsVisible = false;
            label.TextColor = Color.Default;
        }

        /// <summary>
        /// Clears the error.
        /// </summary>
        /// <param name="sfTextInputLayout">The sf text input layout.</param>
        private void ClearError(SfTextInputLayout sfTextInputLayout)
        {
            sfTextInputLayout.ErrorText = string.Empty;
            sfTextInputLayout.HasError = false;
        }

        /// <summary>
        /// Handles the OnCompleted event of the Age control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void DateOfBirth_OnCompleted(Object sender,
                                             EventArgs e)
        {
            this.ExactHandicap.Focus();
        }
        
        /// <summary>
        /// Handles the OnCompleted event of the EmailAddress control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void EmailAddress_OnCompleted(Object sender,
                                              EventArgs e)
        {
            // TODO: This is not working for some reason :'(
            this.Register.Focus();
        }

        /// <summary>
        /// Handles the TextChanged event of the EmailAddress control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs" /> instance containing the event data.</param>
        private void EmailAddress_TextChanged(Object sender,
                                              TextChangedEventArgs e)
        {
            this.ViewModel.EmailAddress = e.NewTextValue;
        }

        /// <summary>
        /// Handles the OnCompleted event of the ExactHandicap control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void ExactHandicap_OnCompleted(Object sender,
                                               EventArgs e)
        {
            this.EmailAddress.Focus();
        }

        /// <summary>
        /// Handles the TextChanged event of the ExactHandicap control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs" /> instance containing the event data.</param>
        private void ExactHandicap_TextChanged(Object sender,
                                               TextChangedEventArgs e)
        {
            this.ViewModel.ExactHandicap = e.NewTextValue;
        }

        /// <summary>
        /// Handles the OnCompleted event of the FirstName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void FirstName_OnCompleted(Object sender,
                                           EventArgs e)
        {
            this.LastName.Focus();
        }

        /// <summary>
        /// Handles the TextChanged event of the FirstName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs" /> instance containing the event data.</param>
        private void FirstName_TextChanged(Object sender,
                                           TextChangedEventArgs e)
        {
            this.ViewModel.FirstName = e.NewTextValue;
        }

        /// <summary>
        /// Genders the on selection changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs" /> instance containing the event data.</param>
        private void GenderOnSelectionChanged(Object sender,
                                              SelectionChangedEventArgs e)
        {
            this.ViewModel.Gender = this.Gender.SelectedIndex;

        }

        /// <summary>
        /// Handles the OnCompleted event of the LastName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void LastName_OnCompleted(Object sender,
                                          EventArgs e)
        {
            this.Gender.Focus();
        }

        /// <summary>
        /// Handles the TextChanged event of the LastName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs" /> instance containing the event data.</param>
        private void LastName_TextChanged(Object sender,
                                          TextChangedEventArgs e)
        {
            this.ViewModel.LastName = e.NewTextValue;
        }

        /// <summary>
        /// Handles the Clicked event of the Register control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void Register_Clicked(Object sender,
                                      EventArgs e)
        {
            if (this.ValidateFirstName() && this.ValidateLastName() && this.ValidateGender() && this.ValidateDateOfBirth() && this.ValidateExactHandicap() &&
                this.ValidateEmailAddress())
            {
                this.RegisterButtonClick(sender, e);
            }
        }

        /// <summary>
        /// Sets the error.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="label">The label.</param>
        /// <param name="errorMessage">The error message.</param>
        private void SetError(View control,
                              Label label,
                              String errorMessage)
        {
            label.Text = errorMessage;
            label.IsVisible = true;
            label.TextColor = Color.Red;
            control.Focus();
        }

        /// <summary>
        /// Sets the error.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="sfTextInputLayout">The sf text input layout.</param>
        /// <param name="errorMessage">The error message.</param>
        private void SetError(View control,
                              SfTextInputLayout sfTextInputLayout,
                              String errorMessage)
        {
            sfTextInputLayout.ErrorText = errorMessage;
            sfTextInputLayout.HasError = true;
            control.Focus();
        }
        
        /// <summary>
        /// Validates the date of birth.
        /// </summary>
        /// <returns></returns>
        private Boolean ValidateDateOfBirth()
        {
            if (this.DateOfBirth.Value == null || String.IsNullOrEmpty(this.DateOfBirth.Value.ToString()))
            {
                this.SetError(this.DateOfBirth, this.DateOfBirthLayout, "A date of birth is required to register");
                return false;
            }

            // Validate a valid date has been entered
            if (!DateTime.TryParseExact(this.DateOfBirth.Value.ToString(), "dd/MM/yyyy", null, DateTimeStyles.None, out DateTime dateCodePickerDate))
            {
                this.SetError(this.DateOfBirth, this.DateOfBirthLayout, "A valid date of birth is required to register");
                return false;
            }

            this.ViewModel.DateOfBirth = new DateTime(dateCodePickerDate.Year,
                                                      dateCodePickerDate.Month,
                                                      dateCodePickerDate.Day,
                                                      dateCodePickerDate.Hour,
                                                      dateCodePickerDate.Minute,
                                                      dateCodePickerDate.Second,
                                                      DateTimeKind.Unspecified);

            this.ClearError(this.DateOfBirthLayout);
            return true;
        }

        /// <summary>
        /// Validates the email address.
        /// </summary>
        /// <returns></returns>
        private Boolean ValidateEmailAddress()
        {
            if (string.IsNullOrEmpty(this.EmailAddress.Text))
            {
                this.SetError(this.EmailAddress, this.EmailAddressLayout, "An email address is required to register");
                return false;
            }

            String emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

            Boolean validEmailAddress = Regex.IsMatch(this.EmailAddress.Text, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));

            if (validEmailAddress == false)
            {
                this.SetError(this.EmailAddress, this.EmailAddressLayout, "A valid email address is required to register");
                return false;
            }

            this.ClearError(this.EmailAddressLayout);
            return true;
        }

        /// <summary>
        /// Validates the exact handicap.
        /// </summary>
        /// <returns></returns>
        private Boolean ValidateExactHandicap()
        {
            if (string.IsNullOrEmpty(this.ExactHandicap.Text))
            {
                this.SetError(this.ExactHandicap, this.ExactHandicapLayout, "An exact handicap is required to register");
                return false;
            }

            Boolean isValidDecimal = decimal.TryParse(this.ExactHandicap.Text, out Decimal exactHandicap);

            if (isValidDecimal == false)
            {
                this.SetError(this.ExactHandicap, this.ExactHandicapLayout, "A numeric value must be provided for exact handicap to register");
                return false;
            }

            if (exactHandicap < -10.0m || exactHandicap > 36.0m)
            {
                this.SetError(this.ExactHandicap, this.ExactHandicapLayout, "Exact handicap must be between -10.0 and 36.0 to register");
                return false;
            }

            this.ClearError(this.ExactHandicapLayout);
            return true;
        }

        /// <summary>
        /// Validates the first name.
        /// </summary>
        /// <returns></returns>
        private Boolean ValidateFirstName()
        {
            if (string.IsNullOrEmpty(this.FirstName.Text))
            {
                this.SetError(this.FirstName, this.FirstNameLayout, "A first name is required to register");
                return false;
            }

            this.ClearError(this.FirstNameLayout);
            return true;
        }

        /// <summary>
        /// Validates the gender.
        /// </summary>
        /// <returns></returns>
        private Boolean ValidateGender()
        {
            if (this.Gender.SelectedIndex == -1)
            {
                this.SetError(this.Gender, this.GenderLayout, "A gender must be selected to register");
                return false;
            }

            this.ClearError(this.GenderLayout);
            return true;
        }

        /// <summary>
        /// Validates the last name.
        /// </summary>
        /// <returns></returns>
        private Boolean ValidateLastName()
        {
            if (string.IsNullOrEmpty(this.LastName.Text))
            {
                this.SetError(this.LastName, this.LastNameLayout, "A last name is required to register");
                return false;
            }

            this.ClearError(this.LastNameLayout);
            return true;
        }

        #endregion
    }
}
using System;
using TechTalk.SpecFlow;

namespace GolfHandicapMobile.IntegrationTests.Steps
{
    using System.Linq;
    using Shouldly;
    using Xamarin.UITest;
    using Xamarin.UITest.Queries;

    [Binding]
    [Scope(Tag = "registerplayer")]
    public class RegisterPlayerSteps
    {
        private readonly IApp App;

        public RegisterPlayerSteps(ScenarioContext scenarioContext)
        {
            this.App = scenarioContext.Get<IApp>("App");
        }

        [When(@"I tap on Register")]
        public void WhenITapOnRegister()
        {
            this.App.WaitForElement(c => c.Marked("Register"));
            this.App.Tap(c => c.Marked("Register"));
        }
        
        [When(@"I enter the First Name ""(.*)""")]
        public void WhenIEnterTheFirstName(String firstName)
        {
            this.App.WaitForElement(x => x.Marked("FirstName"));
            this.App.EnterText("FirstName", firstName);
        }
        
        [When(@"I enter the Last Name ""(.*)""")]
        public void WhenIEnterTheLastName(String lastName)
        {
            this.App.WaitForElement(x => x.Marked("LastName"));
            this.App.EnterText("LastName", lastName);
        }

        [When(@"I open the gender picker")]
        public void WhenIOpenTheGenderPicker()
        {
            this.App.WaitForElement(c => c.Marked("Gender"));
            this.App.Tap(c => c.Marked("Gender"));
        }

        [When(@"I select ""(.*)"" from the Gender picker")]
        public void WhenISelectFromTheGenderPicker(String gender)
        {
            this.App.DismissKeyboard();

            this.App.WaitForElement(gender, timeout: TimeSpan.FromSeconds(5));
            this.App.Tap(gender);
        }
        
        [When(@"I enter the Date Of Birth as ""(.*)""")]
        public void WhenIEnterTheDateOfBirthAs(String dateOfBirth)
        {
            this.App.WaitForElement(x => x.Marked("DateOfBirth"));
            this.App.EnterText("DateOfBirth", dateOfBirth.ToString());
        }

        [When(@"I enter the Exact Handicap as ""(.*)""")]
        public void WhenIEnterTheExactHandicapAs(String exactHandicap)
        {
            this.App.WaitForElement(x => x.Marked("ExactHandicap"));
            this.App.EnterText("ExactHandicap", exactHandicap);
        }

        [Then(@"an error indicating a numeric exact handicap is required will be displayed")]
        public void ThenAnErrorIndicatingANumericExactHandicapIsRequiredWillBeDisplayed()
        {
            AppResult[] elements = this.App.WaitForElement(x => x.Marked("ExactHandicapError"), timeout: TimeSpan.FromSeconds(15));

            // Get the first element
            elements.First().Text.ShouldBe("A numeric value must be provided for exact handicap to register");
        }

        [When(@"I enter the Email Address as ""(.*)""")]
        public void WhenIEnterTheEmailAddressAs(String emailAddress)
        {
            this.App.WaitForElement(x => x.Marked("EmailAddress"));
            this.App.EnterText("EmailAddress", emailAddress);
        }
        
        [When(@"I tap the Register button")]
        public void WhenITapTheRegisterButton()
        {
            this.App.WaitForElement(c => c.Marked("Register"));
            this.App.Tap(c => c.Marked("Register"));
        }
        
        [Then(@"I should be on the Register Player screen")]
        public void ThenIShouldBeOnTheRegisterPlayerScreen()
        {
            this.App.WaitForElement(x => x.Text("Registration"), timeout: TimeSpan.FromSeconds(5));
        }

        [Then(@"the Registration Success message should be displayed")]
        public void ThenTheRegistrationSuccessMessageShouldBeDisplayed()
        {
            this.App.WaitForElement("Registration Successful", timeout: TimeSpan.FromSeconds(15));
        }


        [Then(@"an error indicating first name is required will be displayed")]
        public void ThenAnErrorIndicatingFirstNameIsRequiredWillBeDisplayed()
        {
            AppResult[] elements = this.App.WaitForElement(x => x.Marked("FirstNameError"), timeout: TimeSpan.FromSeconds(15));

            // Get the first element
            elements.First().Text.ShouldBe("A first name is required to register");
        }

        [Then(@"an error indicating last name is required will be displayed")]
        public void ThenAnErrorIndicatingLastNameIsRequiredWillBeDisplayed()
        {
            AppResult[] elements = this.App.WaitForElement(x => x.Marked("LastNameError"), timeout: TimeSpan.FromSeconds(15));

            // Get the first element
            elements.First().Text.ShouldBe("A last name is required to register");
        }

        [Then(@"an error indicating gender is required will be displayed")]
        public void ThenAnErrorIndicatingGenderIsRequiredWillBeDisplayed()
        {
            AppResult[] elements = this.App.WaitForElement(x => x.Marked("GenderError"), timeout: TimeSpan.FromSeconds(15));

            // Get the first element
            elements.First().Text.ShouldBe("A gender must be selected to register");
        }

        [Then(@"an error indicating date of birth is required will be displayed")]
        public void ThenAnErrorIndicatingDateOfBirthIsRequiredWillBeDisplayed()
        {
            AppResult[] elements = this.App.WaitForElement(x => x.Marked("DateOfBirthError"), timeout: TimeSpan.FromSeconds(15));

            // Get the first element
            elements.First().Text.ShouldBe("A date of birth is required to register");
        }

        [Then(@"an error indicating date of birth is invalid will be displayed")]
        public void ThenAnErrorIndicatingDateOfBirthIsInvalidWillBeDisplayed()
        {
            AppResult[] elements = this.App.WaitForElement(x => x.Marked("DateOfBirthError"), timeout: TimeSpan.FromSeconds(15));

            // Get the first element
            elements.First().Text.ShouldBe("A valid date of birth is required to register");
        }

        [Then(@"an error indicating exact handicap is required will be displayed")]
        public void ThenAnErrorIndicatingExactHandicapIsRequiredWillBeDisplayed()
        {
            AppResult[] elements = this.App.WaitForElement(x => x.Marked("ExactHandicapError"), timeout: TimeSpan.FromSeconds(15));

            // Get the first element
            elements.First().Text.ShouldBe("An exact handicap is required to register");
        }

        [Then(@"an error indicating exact handicap is outwith the valid range will be displayed")]
        public void ThenAnErrorIndicatingExactHandicapIsOutwithTheValidRangeWillBeDisplayed()
        {
            AppResult[] elements = this.App.WaitForElement(x => x.Marked("ExactHandicapError"), timeout: TimeSpan.FromSeconds(15));

            // Get the first element
            elements.First().Text.ShouldBe("Exact handicap must be between -10.0 and 36.0 to register");
        }

        [Then(@"an error indicating email adddress is required will be displayed")]
        public void ThenAnErrorIndicatingEmailAdddressIsRequiredWillBeDisplayed()
        {
            AppResult[] elements = this.App.WaitForElement(x => x.Marked("EmailAddressError"), timeout: TimeSpan.FromSeconds(15));

            // Get the first element
            elements.First().Text.ShouldBe("An email address is required to register");
        }

        [Then(@"an error indicating email address is invalid is required will be displayed")]
        public void ThenAnErrorIndicatingEmailAddressIsInvalidIsRequiredWillBeDisplayed()
        {
            AppResult[] elements = this.App.WaitForElement(x => x.Marked("EmailAddressError"), timeout: TimeSpan.FromSeconds(15));

            // Get the first element
            elements.First().Text.ShouldBe("A valid email address is required to register");
        }


    }
}

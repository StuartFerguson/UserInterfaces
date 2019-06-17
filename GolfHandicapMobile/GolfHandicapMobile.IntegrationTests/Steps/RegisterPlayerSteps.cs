using System;
using TechTalk.SpecFlow;

namespace GolfHandicapMobile.IntegrationTests.Steps
{
    using Xamarin.UITest;

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


        [When(@"I enter the Exact Handicap as (.*)")]
        public void WhenIEnterTheExactHandicapAs(Decimal exactHandicap)
        {
            this.App.WaitForElement(x => x.Marked("ExactHandicap"));
            this.App.EnterText("ExactHandicap", exactHandicap.ToString());
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
        
        [Then(@"the Registration Success screen should be displayed")]
        public void ThenTheRegistrationSuccessScreenShouldBeDisplayed()
        {
            this.App.WaitForElement(x => x.Text("Registration Success"), timeout: TimeSpan.FromSeconds(5));
        }
    }
}

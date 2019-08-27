using System;
using TechTalk.SpecFlow;

namespace GolfClubAdminWebSite.IntegrationTests.Steps
{
    using System.Linq;
    using Common;
    using System.Threading.Tasks;
    using Coypu;
    using Shouldly;

    [Binding]
    [Scope(Tag = "registration")]
    public class RegistrationSteps
    {
        private readonly BrowserSession BrowserSession;
        private readonly TestingContext TestingContext;

        public RegistrationSteps(TestingContext testingContext, BrowserSession browserSession)
        {
            this.TestingContext = testingContext;
            this.BrowserSession = browserSession;
        }
        
        [Given(@"I click on the register golf club administrator button")]
        public void GivenIClickOnTheRegisterGolfClubAdministratorButton()
        {
            this.BrowserSession.ClickButton("registerButton");
        }
        
        [When(@"I use the follwing details to register")]
        public void WhenIUseTheFollwingDetailsToRegister(Table table)
        {
            var tableRow = table.Rows.First();

            this.BrowserSession.FillIn("FirstName").With(tableRow["FirstName"]);
            this.BrowserSession.FillIn("LastName").With(tableRow["LastName"]);
            this.BrowserSession.FillIn("Email").With(tableRow["Email"]);
            this.BrowserSession.FillIn("TelephoneNumber").With(tableRow["TelephoneNumber"]);
            this.BrowserSession.FindId("Password").FillInWith(tableRow["Password"]);
            this.BrowserSession.FindId("ConfirmPassword").FillInWith(tableRow["ConfirmPassword"]);
        }
        
        [When(@"I click the register button")]
        public void WhenIClickTheRegisterButton()
        {
            this.BrowserSession.ClickButton("Register");
        }
        
        [Then(@"I should be displayed the registration form")]
        public void ThenIShouldBeDisplayedTheRegistrationForm()
        {
            var registrationForm = this.BrowserSession.FindId("registrationForm");
            registrationForm.ShouldNotBeNull();
        }
        
        [Then(@"I should be presented with the Registration Success Page")]
        public void ThenIShouldBePresentedWithTheRegistrationSuccessPage()
        {
            this.BrowserSession.Title.ShouldBe("Golf Club Administrator Registered");
        }
    }
}

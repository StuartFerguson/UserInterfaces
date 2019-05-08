using System;
using TechTalk.SpecFlow;

namespace GolfClubAdminWebSite.IntegrationTests.Steps
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Common;
    using Coypu;
    using Coypu.Queries;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using Shouldly;

    [Binding]
    [Scope(Tag = "userlogin")]
    public class UserLoginSteps : GenericSteps
    {
        private readonly BrowserSession BrowserSession;

        public UserLoginSteps(ScenarioContext scenarioContext, BrowserSession browserSession) : base(scenarioContext)
        {
            this.BrowserSession = browserSession;
        }

        [BeforeScenario(Order = 1)]
        public async Task BeforeScenario()
        {
            await this.RunSystem(this.ScenarioContext.ScenarioInfo.Title).ConfigureAwait(false);
        }

        [AfterScenario(Order = 1)]
        public void AfterScenario()
        {
            this.StopSystem();
        }

        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            this.BrowserSession.Visit($"http://localhost:{this.GolfClubAdminUIPort}");
            this.BrowserSession.Title.ShouldBe("Welcome");
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
        
        [Given(@"I click on the login button")]
        public void GivenIClickOnTheLoginButton()
        {
            this.BrowserSession.ClickButton("loginButton");
        }
        
        [When(@"I enter the username '(.*)'")]
        public void WhenIEnterTheUsername(String userName)
        {
            this.BrowserSession.FillIn("Username").With(userName);
        }
        
        [When(@"I enter the password '(.*)'")]
        public void WhenIEnterThePassword(String password)
        {
            this.BrowserSession.FillIn("Password").With(password);
        }
        
        [When(@"I click on the forms login button")]
        public void WhenIClickOnTheFormsLoginButton()
        {
            this.BrowserSession.ClickButton("Login");
        }
        
        [Then(@"I am presented with the login screen")]
        public void ThenIAmPresentedWithTheLoginScreen()
        {
            ElementScope section = this.BrowserSession.FindSection("Local Login");
            section.ShouldNotBeNull();
        }
        
        [Then(@"I should be presented with the logged in screen")]
        public void ThenIShouldBePresentedWithTheLoggedInScreen()
        {
            this.BrowserSession.Title.ShouldBe("Dashboard");
        }
    }
}

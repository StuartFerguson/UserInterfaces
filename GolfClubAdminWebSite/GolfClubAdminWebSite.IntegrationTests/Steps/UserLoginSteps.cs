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
/*
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

        [When(@"I click on the Manage Golf Club sidebar option")]
        public void WhenIClickOnTheManageGolfClubSidebarOption()
        {
            this.BrowserSession.ClickLink("Golf Club Details");
        }

        [Then(@"I am presented with the Create Golf Club Screen")]
        public void ThenIAmPresentedWithTheCreateGolfClubScreen()
        {
            this.BrowserSession.Title.ShouldBe("Create Golf Club");
        }

        [When(@"I use the following details to create a new golf club")]
        public void WhenIUseTheFollowingDetailsToCreateANewGolfClub(Table table)
        {
            var tableRow = table.Rows.First();

            this.BrowserSession.FillIn("Name").With(tableRow["GolfClubName"]);
            this.BrowserSession.FillIn("AddressLine1").With(tableRow["AddressLine1"]);
            this.BrowserSession.FillIn("AddressLine2").With(tableRow["AddressLine2"]);
            this.BrowserSession.FillIn("Town").With(tableRow["TownCity"]);
            this.BrowserSession.FindId("Region").FillInWith(tableRow["Region"]);
            this.BrowserSession.FindId("PostalCode").FillInWith(tableRow["PostCode"]);
            this.BrowserSession.FindId("TelephoneNumber").FillInWith(tableRow["TelephoneNumber"]);
            this.BrowserSession.FindId("EmailAddress").FillInWith(tableRow["EmailAddress"]);
            this.BrowserSession.FindId("Website").FillInWith(tableRow["Website"]);
        }

        [When(@"I click the Create Club button")]
        public void WhenIClickTheCreateClubButton()
        {
            this.BrowserSession.ClickButton("Create Club");
        }

        [Then(@"I should be presented with the Edit Golf Club screen")]
        public void ThenIShouldBePresentedWithTheEditGolfClubScreen()
        {
            this.BrowserSession.Title.ShouldBe("Edit Golf Club");
        }

        [When(@"I click on the Users sidebar option")]
        public void WhenIClickOnTheUsersSidebarOption()
        {
            this.BrowserSession.ClickLink("Users");
        }

        [Then(@"I am presented with the list of golf club users")]
        public void ThenIAmPresentedWithTheListOfGolfClubUsers()
        {
            this.BrowserSession.Title.ShouldBe("Users");
        }

        [Then(@"a user with the name ""(.*)"" should be in the list")]
        public void ThenAUserWithTheNameShouldBeInTheList(String username)
        {
            Boolean hasContent = this.BrowserSession.HasContent(username, new Options
                                                                          {
                                                                              Timeout = TimeSpan.FromSeconds(30),
                                                                              RetryInterval = TimeSpan.FromSeconds(1)
                                                                          });
            hasContent.ShouldBeTrue();
        }

        [When(@"I click on the New Match Secretary Button")]
        public void WhenIClickOnTheNewMatchSecretaryButton()
        {
            this.BrowserSession.ClickLink("New Match Secretary");
        }

        [When(@"I use the following details to create a match secretary")]
        public void WhenIUseTheFollowingDetailsToCreateAMatchSecretary(Table table)
        {
            TableRow tableRow = table.Rows.First();

            this.BrowserSession.FillIn("GivenName").With(tableRow["FirstName"]);
            this.BrowserSession.FillIn("FamilyName").With(tableRow["LastName"]);
            this.BrowserSession.FindId("TelephoneNumber").FillInWith(tableRow["TelephoneNumber"]);
            this.BrowserSession.FindId("Email").FillInWith(tableRow["Email"]);
        }

        [When(@"I click on the create user button")]
        public void WhenIClickOnTheCreateUserButton()
        {
            ElementScope section = this.BrowserSession.FindButton("Create User");
            section.Click();
        }

        [Then(@"I have logged out of the application")]
        public void ThenIHaveLoggedOutOfTheApplication()
        {
            //userDropdown
            //logout
            ElementScope userDropdown = this.BrowserSession.FindId("userDropdown");
            userDropdown.Click();

            ElementScope logout = this.BrowserSession.FindId("logout");
            logout.Click();

            ElementScope logoutButton = this.BrowserSession.FindButton("Logout");
            logoutButton.Click();
        }
        */

    }
}

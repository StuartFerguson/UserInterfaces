﻿using System;
using TechTalk.SpecFlow;

namespace GolfClubAdminWebSite.IntegrationTests.Steps
{
    using System.Linq;
    using System.Threading.Tasks;
    using Common;
    using Coypu;
    using Shouldly;

   /*
    public class GetGolfClubUserListSteps_orig : GenericSteps
    {
        private readonly BrowserSession BrowserSession;

        public GetGolfClubUserListSteps(ScenarioContext scenarioContext, BrowserSession browserSession) : base(scenarioContext)
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
        
        [Given(@"I click on the login button")]
        public void GivenIClickOnTheLoginButton()
        {
            this.BrowserSession.ClickButton("loginButton");
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
        
        [When(@"I enter the username '(.*)'")]
        public void WhenIEnterTheUsername(string userName)
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
        
        [When(@"I click on the Manage Golf Club sidebar option")]
        public void WhenIClickOnTheManageGolfClubSidebarOption()
        {
            this.BrowserSession.ClickLink("Golf Club Details");
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
        
        [When(@"I click on the Users sidebar option")]
        public void WhenIClickOnTheUsersSidebarOption()
        {
            this.BrowserSession.ClickLink("Users");
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
        
        [Then(@"I am presented with the Create Golf Club Screen")]
        public void ThenIAmPresentedWithTheCreateGolfClubScreen()
        {
            this.BrowserSession.Title.ShouldBe("Create Golf Club");
        }
        
        [Then(@"I should be presented with the Edit Golf Club screen")]
        public void ThenIShouldBePresentedWithTheEditGolfClubScreen()
        {
            this.BrowserSession.Title.ShouldBe("Edit Golf Club");
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
    }*/
}

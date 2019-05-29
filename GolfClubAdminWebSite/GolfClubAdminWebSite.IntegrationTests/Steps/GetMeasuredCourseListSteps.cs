using System;
using TechTalk.SpecFlow;

namespace GolfClubAdminWebSite.IntegrationTests.Steps
{
    using System.Linq;
    using System.Threading.Tasks;
    using Common;
    using Coypu;
    using Shouldly;

    [Binding]
    [Scope(Tag= "getmeasuredcourselist")]
    public class GetMeasuredCourseListSteps : GenericSteps
    {
        private readonly BrowserSession BrowserSession;

        public GetMeasuredCourseListSteps(ScenarioContext scenarioContext, BrowserSession browserSession) : base(scenarioContext)
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

        [When(@"I click on the Measured Courses sidebar option")]
        public void WhenIClickOnTheMeasuredCoursesSidebarOption()
        {
            this.BrowserSession.ClickLink("Measured Courses");
        }

        [When(@"I click on the New Measured Course button")]
        public void WhenIClickOnTheNewMeasuredCourseButton()
        {
            this.BrowserSession.ClickButton("New Measured Course");
        }

        [When(@"I add the following details for the new measured course")]
        public void WhenIAddTheFollowingDetailsForTheNewMeasuredCourse(Table table)
        {
            var tableRow = table.Rows.First();

            this.BrowserSession.FillIn("Name").With(tableRow["Name"]);
            this.BrowserSession.FillIn("TeeColour").With(tableRow["TeeColour"]);
            this.BrowserSession.FillIn("StandardScratchScore").With(tableRow["SSS"]);
        }

        [When(@"I add the following hole information for the new measured course")]
        public void WhenIAddTheFollowingHoleInformationForTheNewMeasuredCourse(Table table)
        {
            Int32 holeCounter = 0;
            foreach (TableRow tableRow in table.Rows)
            {
                holeCounter++;
                this.BrowserSession.FillIn($"HoleNumber{holeCounter}Yards").With(tableRow["Yardage"]);
                this.BrowserSession.FillIn($"HoleNumber{holeCounter}Par").With(tableRow["Par"]);
                this.BrowserSession.FillIn($"HoleNumber{holeCounter}StrokeIndex").With(tableRow["StrokeIndex"]);
            }
        }

        [When(@"I click the Create Measured Course")]
        public void WhenIClickTheCreateMeasuredCourse()
        {
            this.BrowserSession.ClickButton("Create Measured Course");
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

        [Then(@"I am presented with the list of measured courses")]
        public void ThenIAmPresentedWithTheListOfMeasuredCourses()
        {
            this.BrowserSession.Title.ShouldBe("Measured Courses");
        }

        [Then(@"I am presented with the New Measured Course screen")]
        public void ThenIAmPresentedWithTheNewMeasuredCourseScreen()
        {
            this.BrowserSession.Title.ShouldBe("New Measured Course");
        }

        [Then(@"a measured course with the name ""(.*)"" should be in the list")]
        public void ThenAMeasuredCourseWithTheNameShouldBeInTheList(String golfClubName)
        {
            Boolean hasContent = this.BrowserSession.HasContent(golfClubName, new Options
                                                                              {
                                                                                  Timeout = TimeSpan.FromSeconds(30),
                                                                                  RetryInterval = TimeSpan.FromSeconds(1)
                                                                              });
            hasContent.ShouldBeTrue();
        }

    }
}

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
    public class RegsisterGolfClubAdministratorSteps : GenericSteps
    {
        private BrowserSession BrowserSession;

        public RegsisterGolfClubAdministratorSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {            
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            await this.RunSystem(this.ScenarioContext.ScenarioInfo.Title).ConfigureAwait(false);

            SessionConfiguration sessionConfiguration = new SessionConfiguration
                                                        {
                                                            AppHost = "localhost",
                                                            Port = this.GolfClubAdminUIPort,
                                                            SSL = false,
                                                        };

            sessionConfiguration.Driver = Type.GetType("Coypu.Drivers.Selenium.SeleniumWebDriver, Coypu");
            sessionConfiguration.Browser = Coypu.Drivers.Browser.Parse("chrome");

            this.BrowserSession = new BrowserSession(sessionConfiguration);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            this.StopSystem();
            this.BrowserSession.Dispose();
        }

        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            this.BrowserSession.Visit($"http://localhost:{this.GolfClubAdminUIPort}");
        }
        
        [Given(@"I click on the register golf club administrator button")]
        public void GivenIClickOnTheRegisterGolfClubAdministratorButton()
        {
            this.BrowserSession.ClickButton("Register as Club Administrator");
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
            this.BrowserSession.Title.ShouldBe("Registered - GolfClubAdminWebSite");
        }
    }
}

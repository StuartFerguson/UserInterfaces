using System;
using TechTalk.SpecFlow;

namespace GolfClubAdminWebSite.IntegrationTests.Steps
{
    using System.Linq;
    using Common;
    using Coypu;

    [Binding]
    [Scope(Tag = "creatematchsecretary")]
    public class CreateMatchSecretarySteps
    {
        private readonly BrowserSession BrowserSession;

        private readonly TestingContext TestingContext;

        public CreateMatchSecretarySteps(TestingContext testingContext, BrowserSession browserSession)
        {
            this.TestingContext = testingContext;
            this.BrowserSession = browserSession;
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
    }
}

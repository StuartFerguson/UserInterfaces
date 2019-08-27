using System;
using TechTalk.SpecFlow;

namespace GolfClubAdminWebSite.IntegrationTests.Steps
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Coypu;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using Shouldly;

    [Binding]
    [Scope(Tag = "creategolfclub")]
    public class CreateGolfClubSteps
    {
        private readonly BrowserSession BrowserSession;

        private readonly TestingContext TestingContext;

        public CreateGolfClubSteps(TestingContext testingContext, BrowserSession browserSession)
        {
            this.TestingContext = testingContext;
            this.BrowserSession = browserSession;
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
            TableRow tableRow = table.Rows.First();

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

    }
}

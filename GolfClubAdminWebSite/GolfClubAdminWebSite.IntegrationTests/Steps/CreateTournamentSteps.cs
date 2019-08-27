using System;
using TechTalk.SpecFlow;

namespace GolfClubAdminWebSite.IntegrationTests.Steps
{
    using System.Linq;
    using Common;
    using Coypu;
    using Shouldly;

    [Binding]
    [Scope(Tag = "createtournament")]
    public class CreateTournamentSteps
    {
        private readonly BrowserSession BrowserSession;

        private readonly TestingContext TestingContext;

        public CreateTournamentSteps(TestingContext testingContext, BrowserSession browserSession)
        {
            this.TestingContext = testingContext;
            this.BrowserSession = browserSession;
        }

        [When(@"I click on the Tournaments sidebar option")]
        public void WhenIClickOnTheTournamentsSidebarOption()
        {
            this.BrowserSession.ClickLink("Tournaments");
        }
        
        [When(@"I click on the New Tournament button")]
        public void WhenIClickOnTheNewTournamentButton()
        {
            ElementScope section = this.BrowserSession.FindButton("New Tournament");
            section.Click();
        }
        
        [When(@"I enter the following details for a new tournament")]
        public void WhenIEnterTheFollowingDetailsForANewTournament(Table table)
        {
            TableRow tableRow = table.Rows.First();

            this.BrowserSession.FindId("measuredCourses").SelectOption(tableRow["MeasuredCourse"]);
            this.BrowserSession.FindId("formats").SelectOption(tableRow["Format"]);
            this.BrowserSession.FindId("memberCategories").SelectOption(tableRow["MemberCategory"]);
            this.BrowserSession.FillIn("Name").With(tableRow["Name"]);
            this.BrowserSession.FillIn("TournamentDate").With(tableRow["TournamentDate"]);
        }
        
        [When(@"I click on the create tournament button")]
        public void WhenIClickOnTheCreateTournamentButton()
        {
            ElementScope section = this.BrowserSession.FindButton("Create Tournament");
            section.Click();
        }
        
        [Then(@"I am presented with the Tournament List screen")]
        public void ThenIAmPresentedWithTheTournamentListScreen()
        {
            this.BrowserSession.Title.ShouldBe("Tournaments");
        }
        
        [Then(@"I am presented with the Create Tournament screen")]
        public void ThenIAmPresentedWithTheCreateTournamentScreen()
        {
            this.BrowserSession.Title.ShouldBe("Create Tournament");
        }
        
        [Then(@"a tournament with the name ""(.*)"" should be in the list")]
        public void ThenATournamentWithTheNameShouldBeInTheList(String tournamentName)
        {
            Boolean hasContent = this.BrowserSession.HasContent(tournamentName, new Options
                                                                                {
                                                                                    Timeout = TimeSpan.FromSeconds(30),
                                                                                    RetryInterval = TimeSpan.FromSeconds(1)
                                                                                });
            hasContent.ShouldBeTrue();
        }
    }
}

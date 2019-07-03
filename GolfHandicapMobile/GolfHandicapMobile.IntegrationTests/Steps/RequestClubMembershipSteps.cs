namespace GolfHandicapMobile.IntegrationTests.Steps
{
    using System;
    using System.Linq;
    using HandicapMobile.MockAPI.Database;
    using MockDatabase.Database.Models;
    using Shouldly;
    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Configuration.AppConfig;
    using Xamarin.UITest;
    using Xamarin.UITest.Queries;

    [Binding]
    [Scope(Tag = "requestclubmembership")]
    public class RequestClubMembershipSteps
    {
        private readonly IApp App;

        private readonly MockDatabaseDbContext MockDatabase;

        public RequestClubMembershipSteps(ScenarioContext scenarioContext)
        {
            this.App = scenarioContext.Get<IApp>("App");

            String connectionString = "server=192.168.1.132;database=MockDatabase;user id=root;password=Pa55word";
            this.MockDatabase = new MockDatabaseDbContext(connectionString);
        }

        [Then(@"the My Memberships screen is shown")]
        public void ThenTheMyMembershipsScreenIsShown()
        {
            this.App.WaitForElement(x => x.Text("My Club Memberships"), timeout: TimeSpan.FromSeconds(5));
        }

        [Then(@"I have no memberships currently")]
        public void ThenIHaveNoMembershipsCurrently()
        {
            // TODO:
        }

        [When(@"I click on this Request Club Membership button")]
        public void WhenIClickOnThisRequestClubMembershipButton()
        {
            this.App.WaitForElement(c => c.Marked("Request Club Membership"));
            this.App.Tap(c => c.Marked("Request Club Membership"));
        }

        [Then(@"the Request Club Membership screen is shown")]
        public void ThenTheRequestClubMembershipScreenIsShown()
        {
            this.App.WaitForElement(x => x.Text("Request Membership"), timeout: TimeSpan.FromSeconds(5));
        }

        [When(@"I open the golf club picker")]
        public void WhenIOpenTheGolfClubPicker()
        {
            this.App.WaitForElement(c => c.Marked("Select Golf Club"));
            this.App.Tap(c => c.Marked("Select Golf Club"));
        }

        [When(@"I select ""(.*)"" from the Golf Club picker")]
        public void WhenISelectFromTheGolfClubPicker(String golfClubName)
        {
            this.App.DismissKeyboard();

            this.App.WaitForElement(golfClubName, timeout: TimeSpan.FromSeconds(5));
            this.App.Tap(golfClubName);
        }

        [Then(@"the details for '(.*)' are shown")]
        public void ThenTheDetailsForAreShown(String golfClubName)
        {
            MockDatabaseDbContext context = this.MockDatabase;

            GolfClub golfClub = context.GolfClubs.Single(c => c.Name == golfClubName);

            AppResult golfClubNameLabel = this.App.WaitForElement(c => c.Marked("GolfClubName")).Single();
            AppResult townLabel = this.App.WaitForElement(c => c.Marked("Town")).Single();
            AppResult regionLabel = this.App.WaitForElement(c => c.Marked("Region")).Single();
            AppResult postCodeLabel = this.App.WaitForElement(c => c.Marked("PostCode")).Single();

            golfClubNameLabel.Text.ShouldBe(golfClub.Name);
            townLabel.Text.ShouldBe(golfClub.Town);
            regionLabel.Text.ShouldBe(golfClub.Region);
            postCodeLabel.Text.ShouldBe(golfClub.PostalCode);
        }

        [When(@"I click on the Request Membership button")]
        public void WhenIClickOnTheRequestMembershipButton()
        {
            this.App.WaitForElement(c => c.Button("Request Membership"));
            this.App.Tap(c => c.Button("Request Membership"));
        }

        [Then(@"the membership request success message should be displayed for '(.*)'")]
        public void ThenTheMembershipRequestSuccessMessageShouldBeDisplayedFor(String golfClubName)
        {
            this.App.WaitForElement($"Membership Requested for Golf Club {golfClubName}", timeout: TimeSpan.FromSeconds(15));
        }



    }
}

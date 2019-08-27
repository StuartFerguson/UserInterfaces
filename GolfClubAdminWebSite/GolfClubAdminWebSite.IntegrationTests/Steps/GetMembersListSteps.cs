using System;
using TechTalk.SpecFlow;

namespace GolfClubAdminWebSite.IntegrationTests.Steps
{
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Common;
    using Coypu;
    using Shouldly;

    [Binding]
    [Scope(Tag = "getmemberslist")]
    public class GetMembersListSteps
    {
        private readonly BrowserSession BrowserSession;
        private readonly TestingContext TestingContext;

        public GetMembersListSteps(TestingContext testingContext, BrowserSession browserSession)
        {
            this.TestingContext = testingContext;
            this.BrowserSession = browserSession;
        }

        [When(@"I click on the Members sidebar option")]
        public void WhenIClickOnTheMembersSidebarOption()
        {
            this.BrowserSession.ClickLink("Members");
        }

        [Then(@"the following players have registered and requested membership of '(.*)'")]
        public async Task ThenTheFollowingPlayersHaveRegisteredAndRequestedMembershipOf(String golfClubName, Table table)
        {
            await this.TestingContext.DockerHelper.RegisterPlayer(golfClubName, table.Rows.First()).ConfigureAwait(false);
        }

        [Then(@"I am presented with the Members List Screen")]
        public void ThenIAmPresentedWithTheMembersListScreen()
        {
            this.BrowserSession.Title.ShouldBe("Members");
        }


        [Then(@"a member with the following details should be in the list")]
        public void ThenAMemberWithTheFollowingDetailsShouldBeInTheList(Table table)
        {
            TableRow tableRow = table.Rows.First();
            
            Boolean foundName = this.BrowserSession.HasContent(tableRow["Name"], new Options
            {
                Timeout = TimeSpan.FromSeconds(30),
                RetryInterval = TimeSpan.FromSeconds(1)
            });

            DateTime dateOfBirth = DateTime.Now.AddYears(Int32.Parse(tableRow["Age"]) * -1).AddDays(-1);
            Boolean foundDateOfBirth = this.BrowserSession.HasContent(dateOfBirth.Date.ToString("dd/MM/yyyy"), new Options
                                                                                 {
                                                                                     Timeout = TimeSpan.FromSeconds(30),
                                                                                     RetryInterval = TimeSpan.FromSeconds(1)
                                                                                 });

            Boolean foundGender = this.BrowserSession.HasContent(tableRow["Gender"], new Options
                                                                                 {
                                                                                     Timeout = TimeSpan.FromSeconds(30),
                                                                                     RetryInterval = TimeSpan.FromSeconds(1)
                                                                                 });

            Boolean foundMembershipStatus = this.BrowserSession.HasContent(tableRow["MembershipStatus"], new Options
                                                                                     {
                                                                                         Timeout = TimeSpan.FromSeconds(30),
                                                                                         RetryInterval = TimeSpan.FromSeconds(1)
                                                                                     });

            Boolean foundMembershipNumber = this.BrowserSession.HasContent(tableRow["MembershipNumber"], new Options
                                                                                                         {
                                                                                                             Timeout = TimeSpan.FromSeconds(30),
                                                                                                             RetryInterval = TimeSpan.FromSeconds(1)
                                                                                                         });

            foundName.ShouldBeTrue();
            foundDateOfBirth.ShouldBeTrue();
            foundGender.ShouldBeTrue();
            foundMembershipStatus.ShouldBeTrue();
            foundMembershipNumber.ShouldBeTrue();
        }
    }
}

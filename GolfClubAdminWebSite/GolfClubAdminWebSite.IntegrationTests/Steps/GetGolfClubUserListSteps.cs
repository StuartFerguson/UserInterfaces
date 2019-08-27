using System;
using TechTalk.SpecFlow;

namespace GolfClubAdminWebSite.IntegrationTests.Steps
{
    using Common;
    using Coypu;
    using Shouldly;

    [Binding]
    [Scope(Tag = "getgolfclubuserlist")]
    public class GetGolfClubUserListSteps
    {
        private readonly BrowserSession BrowserSession;
        private readonly TestingContext TestingContext;

        public GetGolfClubUserListSteps(TestingContext testingContext, BrowserSession browserSession)
        {
            this.TestingContext = testingContext;
            this.BrowserSession = browserSession;
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
        public void ThenAUserWithTheNameShouldBeInTheList(String userName)
        {
            Boolean hasContent = this.BrowserSession.HasContent(userName, new Options
                                                                          {
                                                                              Timeout = TimeSpan.FromSeconds(30),
                                                                              RetryInterval = TimeSpan.FromSeconds(1)
                                                                          });
            hasContent.ShouldBeTrue();
        }
    }
}

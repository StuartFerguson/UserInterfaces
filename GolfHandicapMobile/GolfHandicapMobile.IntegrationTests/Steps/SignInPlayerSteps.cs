using System;
using TechTalk.SpecFlow;

namespace GolfHandicapMobile.IntegrationTests.Steps
{
    using System.Linq;
    using Shouldly;
    using Xamarin.UITest;
    using Xamarin.UITest.Queries;

    [Binding]
    [Scope(Tag = "signinplayer")]
    public class SignInPlayerSteps
    {
        private readonly IApp App;

        public SignInPlayerSteps(ScenarioContext scenarioContext)
        {
            this.App = scenarioContext.Get<IApp>("App");
        }

        [When(@"I enter '(.*)' as the Email Address")]
        public void WhenIEnterAsTheEmailAddress(String emailAddress)
        {
            this.App.WaitForElement(x => x.Marked("EmailAddress"));
            this.App.EnterText("EmailAddress", emailAddress);
        }
        
        [When(@"I enter '(.*)' as the Password")]
        public void WhenIEnterAsThePassword(String password)
        {
            this.App.WaitForElement(x => x.Marked("Password"));
            this.App.EnterText("Password", password);
        }
        
        [When(@"I tap on Sign In")]
        public void WhenITapOnSignIn()
        {
            this.App.WaitForElement(c => c.Marked("Sign In"));
            this.App.Tap(c => c.Marked("Sign In"));
        }
        
        [Then(@"the Player Home Page is displayed")]
        public void ThenThePlayerHomePageIsDisplayed()
        {
            AppResult[] elements = this.App.WaitForElement(x => x.Marked("HomePageLabel"), timeout: TimeSpan.FromSeconds(15));

            // Get the first element
            elements.First().Text.ShouldBe("This is my home!");
        }
    }
}

using System;
using TechTalk.SpecFlow;

namespace GolfClubAdminWebSite.IntegrationTests.Steps
{
    using System.Linq;
    using System.Threading.Tasks;
    using Common;
    using Coypu;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using Shouldly;

    [Binding]
    [Scope(Tag = "userlogin")]
    public class UserLoginSteps : GenericSteps
    {
        private IWebDriver WebDriver;

        public UserLoginSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            await this.RunSystem(this.ScenarioContext.ScenarioInfo.Title).ConfigureAwait(false);

            this.WebDriver = new ChromeDriver(@"D:\Projects\WebDrivers");
            this.WebDriver.Navigate().GoToUrl($"http://localhost:{this.GolfClubAdminUIPort}/");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            this.StopSystem();
            this.WebDriver.Dispose();
        }

        [Given(@"I click on the login button")]
        public void GivenIClickOnTheLoginButton()
        {
            IWebElement loginButton = this.WebDriver.FindElement(By.Id("loginButton"));
            loginButton.Click();
        }
        
        [When(@"I enter the username '(.*)'")]
        public void WhenIEnterTheUsername(String userName)
        {
            IWebElement userNameInput = this.WebDriver.FindElement(By.Name("Username"));
            userNameInput.SendKeys(userName);
        }
        
        [When(@"I enter the password '(.*)'")]
        public void WhenIEnterThePassword(String password)
        {
            IWebElement passwordInput = this.WebDriver.FindElement(By.Name("Password"));
            passwordInput.SendKeys(password);
        }
        
        [When(@"I click on the forms login button")]
        public void WhenIClickOnTheFormsLoginButton()
        {
            //IWebElement loginButton = this.WebDriver.FindElement(By.Name("Login"));
            //loginButton.Click();
            var buttons = this.WebDriver.FindElements(By.Name("button"));
            var loginButton = buttons.Where(b => b.Text == "Login").SingleOrDefault();

            if (loginButton != null)
            {
                loginButton.Click();
            }
        }
        
        [Then(@"I am presented with the login screen")]
        public void ThenIAmPresentedWithTheLoginScreen()
        {
            var url = this.WebDriver.Url;

            ITakesScreenshot scrShot = ((ITakesScreenshot)this.WebDriver);
            var ss = scrShot.GetScreenshot();
            ss.SaveAsFile("C:\\temp\\screenshot1.png", ScreenshotImageFormat.Png); //use any of the built in image formating


            this.WebDriver.FindElement(By.ClassName("panel-title")).Text.ShouldBe("Local Login");
        }
        
        [Then(@"I should be presented with the logged in screen")]
        public void ThenIShouldBePresentedWithTheLoggedInScreen()
        {
            this.WebDriver.Title.Contains("Logged In").ShouldBeTrue();
        }
    }
}

namespace GolfClubAdminWebSite.IntegrationTests.Common
{
    using System;
    using System.Threading.Tasks;
    using BoDi;
    using Coypu;
    using TechTalk.SpecFlow;

    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer ObjectContainer;
        private BrowserSession BrowserSession;

        public Hooks(IObjectContainer objectContainer)
        {
            this.ObjectContainer = objectContainer;
        }

        [BeforeScenario(Order = 0)]
        public async Task BeforeScenario()
        {
            SessionConfiguration sessionConfiguration = new SessionConfiguration
                                                        {
                                                            AppHost = "localhost",
                                                            SSL = false,
                                                        };

            sessionConfiguration.Driver = Type.GetType("Coypu.Drivers.Selenium.SeleniumWebDriver, Coypu");
            sessionConfiguration.Browser = Coypu.Drivers.Browser.Parse("chrome");

            this.BrowserSession = new BrowserSession(sessionConfiguration);
            this.ObjectContainer.RegisterInstanceAs(this.BrowserSession);
        }
        
        [AfterScenario(Order = 0)]
        public void AfterScenario()
        {
            this.BrowserSession.Dispose();
        }
    }
}
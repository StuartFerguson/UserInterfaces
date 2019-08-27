using System;
using TechTalk.SpecFlow;

namespace GolfClubAdminWebSite.IntegrationTests.Steps
{
    using System.Linq;
    using Common;
    using Coypu;
    using Shouldly;

    [Binding]
    [Scope(Tag = "addmeasuredcourse")]
    public class AddMeasuredCourseSteps
    {
        private readonly BrowserSession BrowserSession;

        private readonly TestingContext TestingContext;

        public AddMeasuredCourseSteps(TestingContext testingContext, BrowserSession browserSession)
        {
            this.TestingContext = testingContext;
            this.BrowserSession = browserSession;
        }

        [When(@"I click on the Measured Courses sidebar option")]
        public void WhenIClickOnTheMeasuredCoursesSidebarOption()
        {
            this.BrowserSession.ClickLink("Measured Courses");
        }
        
        [When(@"I click on the New Measured Course button")]
        public void WhenIClickOnTheNewMeasuredCourseButton()
        {
            this.BrowserSession.ClickButton("New Measured Course");
        }
        
        [When(@"I add the following details for the new measured course")]
        public void WhenIAddTheFollowingDetailsForTheNewMeasuredCourse(Table table)
        {
            TableRow tableRow = table.Rows.First();

            this.BrowserSession.FillIn("Name").With(tableRow["Name"]);
            this.BrowserSession.FillIn("TeeColour").With(tableRow["TeeColour"]);
            this.BrowserSession.FillIn("StandardScratchScore").With(tableRow["SSS"]);
        }
        
        [When(@"I add the following hole information for the new measured course")]
        public void WhenIAddTheFollowingHoleInformationForTheNewMeasuredCourse(Table table)
        {
            Int32 holeCounter = 0;
            foreach (TableRow tableRow in table.Rows)
            {
                holeCounter++;
                this.BrowserSession.FillIn($"HoleNumber{holeCounter}Yards").With(tableRow["Yardage"]);
                this.BrowserSession.FillIn($"HoleNumber{holeCounter}Par").With(tableRow["Par"]);
                this.BrowserSession.FillIn($"HoleNumber{holeCounter}StrokeIndex").With(tableRow["StrokeIndex"]);
            }
        }
        
        [When(@"I click the Create Measured Course")]
        public void WhenIClickTheCreateMeasuredCourse()
        {
            this.BrowserSession.ClickButton("Create Measured Course");
        }
        
        [Then(@"I am presented with the list of measured courses")]
        public void ThenIAmPresentedWithTheListOfMeasuredCourses()
        {
            this.BrowserSession.Title.ShouldBe("Measured Courses");
        }
        
        [Then(@"I am presented with the New Measured Course screen")]
        public void ThenIAmPresentedWithTheNewMeasuredCourseScreen()
        {
            this.BrowserSession.Title.ShouldBe("New Measured Course");
        }
        
        [Then(@"a measured course with the name ""(.*)"" should be in the list")]
        public void ThenAMeasuredCourseWithTheNameShouldBeInTheList(String measuredCourseName)
        {
            Boolean hasContent = this.BrowserSession.HasContent(measuredCourseName, new Options
                                                                              {
                                                                                  Timeout = TimeSpan.FromSeconds(30),
                                                                                  RetryInterval = TimeSpan.FromSeconds(1)
                                                                              });
            hasContent.ShouldBeTrue();
        }
    }
}

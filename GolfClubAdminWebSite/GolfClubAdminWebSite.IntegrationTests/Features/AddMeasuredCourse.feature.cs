// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.0.0.0
//      SpecFlow Generator Version:3.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace GolfClubAdminWebSite.IntegrationTests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Xunit.TraitAttribute("Category", "addmeasuredcourse")]
    public partial class AddMeasuredCourseFeature : Xunit.IClassFixture<AddMeasuredCourseFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "AddMeasuredCourse.feature"
#line hidden
        
        public AddMeasuredCourseFeature(AddMeasuredCourseFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "AddMeasuredCourse", null, ProgrammingLanguage.CSharp, new string[] {
                        "addmeasuredcourse"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 4
#line 5
 testRunner.Given("I am on the home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
 testRunner.And("I click on the register golf club administrator button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 7
 testRunner.Then("I should be displayed the registration form", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "FirstName",
                        "LastName",
                        "Email",
                        "TelephoneNumber",
                        "Password",
                        "ConfirmPassword"});
            table1.AddRow(new string[] {
                        "Test",
                        "User",
                        "testuser@testgolfclub.co.uk",
                        "1234567890",
                        "123456",
                        "123456"});
#line 8
 testRunner.When("I use the follwing details to register", ((string)(null)), table1, "When ");
#line 11
 testRunner.And("I click the register button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.Then("I should be presented with the Registration Success Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
 testRunner.Given("I am on the home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
 testRunner.And("I click on the login button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.Then("I am presented with the login screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
 testRunner.When("I enter the username \'testuser@testgolfclub.co.uk\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
 testRunner.And("I enter the password \'123456\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And("I click on the forms login button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.Then("I should be presented with the logged in screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
 testRunner.When("I click on the Manage Golf Club sidebar option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
 testRunner.Then("I am presented with the Create Golf Club Screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "GolfClubName",
                        "AddressLine1",
                        "AddressLine2",
                        "TownCity",
                        "Region",
                        "PostCode",
                        "TelephoneNumber",
                        "EmailAddress",
                        "Website"});
            table2.AddRow(new string[] {
                        "Test Golf Club",
                        "Address Line 1",
                        "",
                        "TestTown",
                        "TestRegion",
                        "TE57 1NG",
                        "1234567890",
                        "testclub@testclub.co.uk",
                        "www.testclub.co.uk"});
#line 22
 testRunner.When("I use the following details to create a new golf club", ((string)(null)), table2, "When ");
#line 25
 testRunner.And("I click the Create Club button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.Then("I should be presented with the Edit Golf Club screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Add a measured course")]
        [Xunit.TraitAttribute("FeatureTitle", "AddMeasuredCourse")]
        [Xunit.TraitAttribute("Description", "Add a measured course")]
        public virtual void AddAMeasuredCourse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add a measured course", null, ((string[])(null)));
#line 28
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
this.FeatureBackground();
#line 29
 testRunner.When("I click on the Measured Courses sidebar option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
 testRunner.Then("I am presented with the list of measured courses", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 31
 testRunner.When("I click on the New Measured Course button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
 testRunner.Then("I am presented with the New Measured Course screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "TeeColour",
                        "SSS"});
            table3.AddRow(new string[] {
                        "Test Golf Course",
                        "White",
                        "70"});
#line 33
 testRunner.When("I add the following details for the new measured course", ((string)(null)), table3, "When ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "HoleNumber",
                        "Yardage",
                        "Par",
                        "StrokeIndex"});
            table4.AddRow(new string[] {
                        "1",
                        "348",
                        "4",
                        "10"});
            table4.AddRow(new string[] {
                        "2",
                        "402",
                        "4",
                        "4"});
            table4.AddRow(new string[] {
                        "3",
                        "207",
                        "3",
                        "14"});
            table4.AddRow(new string[] {
                        "4",
                        "405",
                        "4",
                        "8"});
            table4.AddRow(new string[] {
                        "5",
                        "428",
                        "4",
                        "2"});
            table4.AddRow(new string[] {
                        "6",
                        "477",
                        "5",
                        "12"});
            table4.AddRow(new string[] {
                        "7",
                        "186",
                        "3",
                        "16"});
            table4.AddRow(new string[] {
                        "8",
                        "397",
                        "4",
                        "6"});
            table4.AddRow(new string[] {
                        "9",
                        "130",
                        "3",
                        "18"});
            table4.AddRow(new string[] {
                        "10",
                        "399",
                        "4",
                        "3"});
            table4.AddRow(new string[] {
                        "11",
                        "401",
                        "4",
                        "13"});
            table4.AddRow(new string[] {
                        "12",
                        "421",
                        "4",
                        "1"});
            table4.AddRow(new string[] {
                        "13",
                        "530",
                        "5",
                        "11"});
            table4.AddRow(new string[] {
                        "14",
                        "196",
                        "3",
                        "5"});
            table4.AddRow(new string[] {
                        "15",
                        "355",
                        "4",
                        "7"});
            table4.AddRow(new string[] {
                        "16",
                        "243",
                        "4",
                        "15"});
            table4.AddRow(new string[] {
                        "17",
                        "286",
                        "4",
                        "17"});
            table4.AddRow(new string[] {
                        "18",
                        "399",
                        "4",
                        "9"});
#line 36
 testRunner.When("I add the following hole information for the new measured course", ((string)(null)), table4, "When ");
#line 56
 testRunner.And("I click the Create Measured Course", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.Then("I am presented with the list of measured courses", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 58
 testRunner.And("a measured course with the name \"Test Golf Course\" should be in the list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                AddMeasuredCourseFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                AddMeasuredCourseFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion

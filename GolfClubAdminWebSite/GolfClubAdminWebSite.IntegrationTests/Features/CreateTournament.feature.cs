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
    [Xunit.TraitAttribute("Category", "createtournament")]
    public partial class CreateTournamentFeature : Xunit.IClassFixture<CreateTournamentFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "CreateTournament.feature"
#line hidden
        
        public CreateTournamentFeature(CreateTournamentFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CreateTournament", null, ProgrammingLanguage.CSharp, new string[] {
                        "createtournament"});
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
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "FirstName",
                        "LastName",
                        "Email",
                        "TelephoneNumber",
                        "Password",
                        "ConfirmPassword"});
            table10.AddRow(new string[] {
                        "Test",
                        "User",
                        "testuser@testgolfclub.co.uk",
                        "1234567890",
                        "123456",
                        "123456"});
#line 8
 testRunner.When("I use the follwing details to register", ((string)(null)), table10, "When ");
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
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "GolfClubName",
                        "AddressLine1",
                        "AddressLine2",
                        "TownCity",
                        "Region",
                        "PostCode",
                        "TelephoneNumber",
                        "EmailAddress",
                        "Website"});
            table11.AddRow(new string[] {
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
 testRunner.When("I use the following details to create a new golf club", ((string)(null)), table11, "When ");
#line 25
 testRunner.And("I click the Create Club button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.Then("I should be presented with the Edit Golf Club screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
 testRunner.When("I click on the Measured Courses sidebar option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
 testRunner.Then("I am presented with the list of measured courses", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
 testRunner.When("I click on the New Measured Course button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
 testRunner.Then("I am presented with the New Measured Course screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "TeeColour",
                        "SSS"});
            table12.AddRow(new string[] {
                        "Test Golf Course",
                        "White",
                        "70"});
#line 31
 testRunner.When("I add the following details for the new measured course", ((string)(null)), table12, "When ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "HoleNumber",
                        "Yardage",
                        "Par",
                        "StrokeIndex"});
            table13.AddRow(new string[] {
                        "1",
                        "348",
                        "4",
                        "10"});
            table13.AddRow(new string[] {
                        "2",
                        "402",
                        "4",
                        "4"});
            table13.AddRow(new string[] {
                        "3",
                        "207",
                        "3",
                        "14"});
            table13.AddRow(new string[] {
                        "4",
                        "405",
                        "4",
                        "8"});
            table13.AddRow(new string[] {
                        "5",
                        "428",
                        "4",
                        "2"});
            table13.AddRow(new string[] {
                        "6",
                        "477",
                        "5",
                        "12"});
            table13.AddRow(new string[] {
                        "7",
                        "186",
                        "3",
                        "16"});
            table13.AddRow(new string[] {
                        "8",
                        "397",
                        "4",
                        "6"});
            table13.AddRow(new string[] {
                        "9",
                        "130",
                        "3",
                        "18"});
            table13.AddRow(new string[] {
                        "10",
                        "399",
                        "4",
                        "3"});
            table13.AddRow(new string[] {
                        "11",
                        "401",
                        "4",
                        "13"});
            table13.AddRow(new string[] {
                        "12",
                        "421",
                        "4",
                        "1"});
            table13.AddRow(new string[] {
                        "13",
                        "530",
                        "5",
                        "11"});
            table13.AddRow(new string[] {
                        "14",
                        "196",
                        "3",
                        "5"});
            table13.AddRow(new string[] {
                        "15",
                        "355",
                        "4",
                        "7"});
            table13.AddRow(new string[] {
                        "16",
                        "243",
                        "4",
                        "15"});
            table13.AddRow(new string[] {
                        "17",
                        "286",
                        "4",
                        "17"});
            table13.AddRow(new string[] {
                        "18",
                        "399",
                        "4",
                        "9"});
#line 34
 testRunner.When("I add the following hole information for the new measured course", ((string)(null)), table13, "When ");
#line 54
 testRunner.And("I click the Create Measured Course", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.Then("I am presented with the list of measured courses", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
 testRunner.When("I click on the Users sidebar option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 57
 testRunner.Then("I am presented with the list of golf club users", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 58
 testRunner.When("I click on the New Match Secretary Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "FirstName",
                        "LastName",
                        "Email",
                        "TelephoneNumber"});
            table14.AddRow(new string[] {
                        "Test",
                        "Match Secretary",
                        "testmatchsecretary@testgolfclub.co.uk",
                        "1234567890"});
#line 59
 testRunner.And("I use the following details to create a match secretary", ((string)(null)), table14, "And ");
#line 62
 testRunner.And("I click on the create user button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.Then("I am presented with the list of golf club users", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 64
 testRunner.And("a user with the name \"Test Match Secretary\" should be in the list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.And("I have logged out of the application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
 testRunner.Given("I am on the home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 67
 testRunner.And("I click on the login button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.Then("I am presented with the login screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 69
 testRunner.When("I enter the username \'testmatchsecretary@testgolfclub.co.uk\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 70
 testRunner.And("I enter the password \'123456\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
 testRunner.And("I click on the forms login button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
 testRunner.Then("I should be presented with the logged in screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Create Tournament")]
        [Xunit.TraitAttribute("FeatureTitle", "CreateTournament")]
        [Xunit.TraitAttribute("Description", "Create Tournament")]
        public virtual void CreateTournament()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Tournament", null, ((string[])(null)));
#line 74
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
this.FeatureBackground();
#line 75
 testRunner.When("I click on the Tournaments sidebar option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 76
 testRunner.Then("I am presented with the Create Tournament screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "MeasuredCourse",
                        "Format",
                        "MemberCategory",
                        "Name",
                        "TournamentDate"});
            table15.AddRow(new string[] {
                        "Test Golf Course",
                        "Strokeplay",
                        "Gents",
                        "Test Tournament",
                        "2019-07-23"});
#line 77
 testRunner.When("I enter the following details for a new tournament", ((string)(null)), table15, "When ");
#line 80
 testRunner.And("I click on the create tournament button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
 testRunner.Then("I should be presented with the logged in screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                CreateTournamentFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                CreateTournamentFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion

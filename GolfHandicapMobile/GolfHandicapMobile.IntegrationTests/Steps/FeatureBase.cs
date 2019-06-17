using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfHandicapMobile.IntegrationTests.Steps
{
    using HandicapMobile.MockAPI.Database;
    using HandicapMobile.MockAPI.Database.Models;
    using NUnit.Framework;
    using System.Diagnostics;
    using System.Threading;
    using TechTalk.SpecFlow;
    using Xamarin.UITest;
    using Xamarin.UITest.Configuration;

    [Binding]
    [Scope(Tag = "base")]
    public class FeatureBase
    {
        private readonly FeatureContext FeatureContext;

        private readonly ScenarioContext ScenarioContext;

        protected readonly MockDatabaseDbContext MockDatabase;

        private IApp App;

        public FeatureBase(FeatureContext featureContext,
                           ScenarioContext scenarioContext)
        {
            this.FeatureContext = featureContext;
            this.ScenarioContext = scenarioContext;
            String connectionString = "server=golfhandicapping.ck9ila7cw53m.eu-west-2.rds.amazonaws.com;database=MockDatabase;user id=ghawsuser;password=Sc0tland";
            this.MockDatabase = new MockDatabaseDbContext(connectionString);
        }

        [BeforeScenario]
        public void BeforeEachTest()
        {
            // TODO: iOS and Windows...

            // Read the Is CI value from the TestContext
            Boolean.TryParse(TestContext.Parameters["IsCI"], out Boolean isCI);
            
            if (isCI)
            {
                //String apkFile = "C:\\BuildAgent\\work\\e5cf2393c6fba2b1\\hht prototype\\uitest1\\bin\\debug\\VME.HHT-Signed.apk";
                String apkFile = "VME.HHT-Signed.apk";
                //apkFile = $"C:\\Git\\hht-prototype\\HHT Prototype\\UITest1\\bin\\Debug\\{apkFile}";
                this.App = ConfigureApp.Android.ApkFile(apkFile).DeviceSerial("emulator-5554").EnableLocalScreenshots().StartApp(AppDataMode.Clear);

                //Logger.WriteToLog("Starting Application");
            }
            else
            {
                this.App = ConfigureApp.Android.InstalledApp("com.golfhandicapping.mobile").DeviceSerial("emulator-5554").EnableLocalScreenshots().StartApp(AppDataMode.Clear);
            }


            this.ScenarioContext.Add("App", this.App);
        }

        [Given(@"I am on the Main Page")]
        public void GivenIAmOnTheMainPage()
        {

        }
        
        [Given(@"There are no players signed up")]
        public void GivenThereAreNoPlayersSignedUp()
        {
            MockDatabaseDbContext context = this.MockDatabase;

            List<RegisteredUser> usersToRemove = context.RegisteredUsers.ToList();
            context.RemoveRange(usersToRemove);

            List<Player> playersToRemove = context.Players.ToList();
            context.RemoveRange(usersToRemove);

            context.SaveChanges();
        }

        [BeforeFeature]
        public static void StartEmulator()
        {
            //SharedSteps.WriteLogMessage("In Start Emulator");
            Boolean.TryParse(TestContext.Parameters["IsCI"], out Boolean isCI);

            if (isCI)
            {
                //Check if we already have an emulator running
                Process runningEmulator = Process.GetProcessesByName("qemu-system-i386").SingleOrDefault();
                FeatureBase.ManualResetEvent = new ManualResetEvent(false);
                if (runningEmulator != null)
                {
                    //SharedSteps.WriteLogMessage($"Found process qemu-system-i386 running with PID {runningEmulator.Id} ");
                    runningEmulator.SafeClose();
                    FeatureBase.ManualResetEvent.Set();
                }
                else
                {
                    //SharedSteps.WriteLogMessage("No current running emulators found signalling to go");
                    FeatureBase.ManualResetEvent.Set();
                }

                if (!FeatureBase.ManualResetEvent.WaitOne(TimeSpan.FromSeconds(10)))
                {
                    //SharedSteps.WriteLogMessage("Wait one exceeded timeout");
                }

                //SharedSteps.WriteLogMessage("About to create a new emulator");

                Process androidEmulatorProcess = new Process();
                androidEmulatorProcess.EnableRaisingEvents = true;

                androidEmulatorProcess.StartInfo.FileName = @"F:\Android\AndroidSDK\tools\emulator.exe";
                androidEmulatorProcess.StartInfo.Arguments = "-avd test_device -verbose -noaudio -gpu off";
                androidEmulatorProcess.StartInfo.UseShellExecute = false;
                androidEmulatorProcess.StartInfo.RedirectStandardOutput = true;
                androidEmulatorProcess.StartInfo.RedirectStandardError = true;
                androidEmulatorProcess.OutputDataReceived += FeatureBase.AndroidEmulatorProcess_OutputDataReceived;
                androidEmulatorProcess.ErrorDataReceived += FeatureBase.AndroidEmulatorProcess_ErrorDataReceived;

                FeatureBase.ManualResetEvent.Reset();

                androidEmulatorProcess.Start();

                androidEmulatorProcess.BeginOutputReadLine();
                androidEmulatorProcess.BeginErrorReadLine();

                FeatureBase.ProcessId = androidEmulatorProcess.Id;

                androidEmulatorProcess.Exited += (sender,
                                                  e) => FeatureBase.AndroidEmulatorProcess_Exited(new Object(),
                                                                                                  new EventArgs(),
                                                                                                  FeatureBase.ProcessId); //maybe for trace?

                //SharedSteps.WriteLogMessage($"Emulator Started with PID {SharedSteps.ProcessId}");

                if (!FeatureBase.ManualResetEvent.WaitOne(30000))
                {
                    //SharedSteps.WriteLogMessage("Emulator not marked as started within timeout");
                    throw new Exception("Emulator not marked as started within timeout");
                }

                //SharedSteps.WriteLogMessage($"Emulator Ready with PID {SharedSteps.ProcessId}");
            }
        }

        private static Int32 ProcessId;

        private static void AndroidEmulatorProcess_Exited(Object o,
                                                          EventArgs eventArgs,
                                                          Int32 processId)
        {
            //SharedSteps.WriteLogMessage($"Emulator Exited PID {processId}");
            FeatureBase.ManualResetEvent.Set();
        }

        private static void AndroidEmulatorProcess_ErrorDataReceived(Object sender,
                                                                     DataReceivedEventArgs e)
        {
            //SharedSteps.WriteLogMessage(e.Data);
        }

        private static ManualResetEvent ManualResetEvent;

        private static void AndroidEmulatorProcess_OutputDataReceived(Object sender,
                                                                      DataReceivedEventArgs e)
        {
            if (e != null && e.Data != null)
            {
                if (e.Data.Contains("emulator: got message from guest system fingerprint HAL"))
                {
                    FeatureBase.ManualResetEvent.Set();
                }
            }
        }

        [AfterFeature]
        public static void StopEmulator()
        {
            //SharedSteps.WriteLogMessage("In Stop Emulator");
            Boolean.TryParse(TestContext.Parameters["IsCI"], out Boolean isCI);

            if (isCI)
            {
                Process runningEmulator = Process.GetProcessesByName("qemu-system-i386").SingleOrDefault();
                runningEmulator.SafeClose();
            }
        }
    }

    public static class Extensions
    {
        public static void SafeClose(this Process process)
        {
            //FeatureBase.WriteLogMessage($"About to CloseMainWindow on PID {process.Id}");
            Boolean closeResult = process.CloseMainWindow();
            process.Close();

            //SharedSteps.WriteLogMessage($"CloseMainWindow result {closeResult}");

            Stopwatch stopwatch = Stopwatch.StartNew();

            while (stopwatch.ElapsedMilliseconds < 1000)
            {
                var qemuprocessList = Process.GetProcessesByName("qemu-system-i386").ToList();
                var emulatorsProcessList = Process.GetProcessesByName("emulator").ToList();

                qemuprocessList.AddRange(emulatorsProcessList);

                if (qemuprocessList.Any() == false)
                {
                    break;
                }

                foreach (Process emulator in qemuprocessList)
                {
                    //SharedSteps.WriteLogMessage($"PID: {emulator.Id} Name: {emulator.ProcessName} Status: {emulator.HasExited}");
                }
                Thread.Sleep(20);
            }
        }
    }
}

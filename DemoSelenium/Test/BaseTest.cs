using AventStack.ExtentReports;
using System.Reflection;
using TestFrameworkCore.Helper;
using TestFrameworkCore.Helper.Report;
using WebDriverHelper.Helper;

namespace DemoSelenium.Test {
    public class BaseTest {
        public BrowserHelper Browser;
        public static ReportHelper ReportHelper;
        public TestContext TestContext { get; set; }
        protected ExtentTest extentTest;

        public virtual void SetupPage() {

        }

        [TestInitialize]
        public void InitializeTest() {
            Browser = new BrowserHelper();
            Browser.OpenBrowser(ConfigurationHelper.GetConfig<string>("url"));
            SetupPage();

            MethodInfo testMethod = GetType().GetMethod(TestContext.TestName);
            TestMethodAttribute displayNameAttribute = testMethod.GetCustomAttribute<TestMethodAttribute>();
            string displayName = displayNameAttribute != null ? displayNameAttribute.DisplayName : TestContext.TestName;

            // Create a test
            extentTest = ReportHelper.CreateTest(TestContext.TestName, displayName);
        }

        [TestCleanup]
        public void CleanupTest() {

            if (extentTest != null) {
                if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed) {
                    extentTest.AddImageBase64(Browser.TakeScreenshotAsBase64());
                }
                extentTest.AddResult(TestContext.CurrentTestOutcome.ToString());
            }
            Browser.QuitBrowser();
        }
    }
}

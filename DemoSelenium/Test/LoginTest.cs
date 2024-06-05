using DemoSelenium.Page;
using FluentAssertions;
using TestFrameworkCore.Helper;
using TestFrameworkCore.Helper.Report;

namespace DemoSelenium.Test {

    [TestClass]
    public class LoginTest : BaseTest {
        private LoginPage loginPage;
        private DashboardPage dashboardPage;

        public override void SetupPage() {
            loginPage = new LoginPage(Browser.Driver);
            dashboardPage = new DashboardPage(Browser.Driver);
        }

        [TestCategory("smoketest")]
        [TestMethod("TC01: Login with valid username and password")]
        public void VerifyValidUser() {

            string username = ConfigurationHelper.GetConfig<string>("username");
            extentTest.LogMessage($"Read configuration - username: {username}");

            string password = ConfigurationHelper.GetConfig<string>("password");
            extentTest.LogMessage($"Read configuration - password: {password}");

            // Input username & password
            loginPage.LoginWithUsernameAndPassword(username, password);
            extentTest.LogMessage($"Login with valid username and password");

            // Verify the dashboard page is displayed
            dashboardPage.IsLabelDashboardDisplayed(timeout: 10).Should().BeTrue();
        }

        [TestCategory("smoketest")]
        [TestMethod("TC02: Login with invalid username and password")]
        public void VerifyInvalidUser() {
            //throw new Exception("asdasd");

            string username = ConfigurationHelper.GetConfig<string>("username");

            // Login with invalid account
            loginPage.LoginWithUsernameAndPassword(username, "asdssssad");

            // Verify the alert message is displayed
            loginPage.GetErrorMessage().Should().Contain("Invalid");

            // Verify the label dashboard is not displayed
            dashboardPage.IsLabelDashboardDisplayed(timeout: 10).Should().BeFalse();
        }

        [TestMethod("TC03: Dynamic data")]
        [DynamicData(nameof(DataLoginUser))]
        public void VerifyLoginUser(string username, string password, bool isLabelDashboardDisplayed) {
            loginPage.LoginWithUsernameAndPassword(username, password);
            dashboardPage.IsLabelDashboardDisplayed(timeout: 10).Should().Be(isLabelDashboardDisplayed);
        }

        public static IEnumerable<object[]> DataLoginUser {
            get {
                return new ExcelHelper(Path.Combine("Resources", "VerifyLoginUser.xlsx")).GetLoginUserData();
            }
        }
    }
}
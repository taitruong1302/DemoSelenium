using DemoSelenium.Model;
using DemoSelenium.Page;
using FluentAssertions;
using Newtonsoft.Json;
using TestFrameworkCore.Model;
using WebDriverHelper.Helper;

namespace DemoSelenium.Helper {
    public class KeywordHelper {
        private List<KeywordData> keywords;
        private BrowserHelper browserHelper;

        public KeywordHelper(List<KeywordData> keywords) {
            this.keywords = keywords;
        }

        /// <summary>
        /// Execute keyword in the list
        /// </summary>
        public void ExecuteKeywords() {
            foreach (var keyword in keywords) {
                ExecuteKeyword(keyword);
            }
        }

        public void ExecuteKeyword(KeywordData keyword) {
            switch (keyword.Keyword) {
                case "Open Browser":
                    browserHelper = new BrowserHelper();
                    browserHelper.OpenBrowser(browserType: keyword.Data);
                    break;

                case "Go to URL":
                    browserHelper.GoToUrl(keyword.Data);
                    break;

                case "Enter username":
                    EnterUsername(keyword.Data);
                    break;

                case "Enter password":
                    EnterPassword(keyword.Data);
                    break;

                case "Click login button":
                    ClickLoginButton();
                    break;

                case "Close Browser":
                    browserHelper.QuitBrowser();
                    break;

                case "Verify dashboard display":
                    DashboardModel model = JsonConvert.DeserializeObject<DashboardModel>(keyword.Data);
                    VerifyDashboardDisplay(model.Expected);
                    break;

                case "Enter username and password":
                    UserModel userModel = JsonConvert.DeserializeObject<UserModel>(keyword.Data);
                    EnterUsername(userModel.Username);
                    EnterPassword(userModel.Password);
                    break;

                default:
                    throw new Exception("Not support this keyword");
            }
        }

        private void EnterUsername(string username) {
            LoginPage loginPage = new LoginPage(browserHelper.Driver);
            loginPage.InputUsername(username);
        }

        private void EnterPassword(string password) {
            LoginPage loginPage = new LoginPage(browserHelper.Driver);
            loginPage.InputPassword(password);
        }

        private void ClickLoginButton() {
            LoginPage loginPage = new LoginPage(browserHelper.Driver);
            loginPage.ClickLogin();
        }

        private void VerifyDashboardDisplay(bool expected) {
            DashboardPage dashboardPage = new DashboardPage(browserHelper.Driver);
            dashboardPage.IsLabelDashboardDisplayed(10).Should().Be(expected);
        }
    }
}

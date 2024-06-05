using OpenQA.Selenium;

namespace DemoSelenium.Page {
    public class LoginPage : BasePage {
        private By xpathUserName = By.XPath("//input[contains(@name, 'username')]");
        private By xpathPassword = By.XPath("//input[contains(@name, 'password')]");
        private By xpathBtnLogin = By.XPath("//button[contains(.,'Login')]");
        private By xpathAlertText = By.XPath("//p[contains(@class, 'alert-content-text')] | //div[contains(@class, 'toast-message')]");

        public LoginPage(IWebDriver _driver) : base(_driver) {

        }

        public void InputUsername(string username) {
            driver.FindElement(xpathUserName).SendKeys(username);
        }

        public void InputPassword(string password) {
            driver.FindElement(xpathPassword).SendKeys(password);
        }

        public void ClickLogin() {
            driver.FindElement(xpathBtnLogin).Click();
        }

        public void LoginWithUsernameAndPassword(string username, string password) {
            InputUsername(username);
            InputPassword(password);
            ClickLogin();
        }

        public string GetErrorMessage() {
            return driver.FindElement(xpathAlertText).Text;
        }
    }
}

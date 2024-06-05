using OpenQA.Selenium;

namespace DemoSelenium.Page {
    public class DashboardPage : BasePage {

        private By xpathLabelDashboard = By.XPath("//h6[text() = 'Dashboard'] | //div[contains(@class, 'pcoded-content')]");
        private By xpathLabelTimeAtWork = By.XPath("//p[contains(.,'Time at Work')]");
        private By xpathLabelMyAction = By.XPath("//p[contains(.,'My Actions')]");
        public DashboardPage(IWebDriver _driver) : base(_driver) {
        }

        public bool IsLabelDashboardDisplayed(int timeout = 2) {
            var defaultTimeout = driver.Manage().Timeouts().ImplicitWait;
            try {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
                return driver.FindElement(xpathLabelDashboard).Displayed;
            }
            catch {
                return false;
            }
            finally {
                driver.Manage().Timeouts().ImplicitWait = defaultTimeout;
            }
        }

    }
}

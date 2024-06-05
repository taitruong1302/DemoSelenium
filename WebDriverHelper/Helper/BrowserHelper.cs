using OpenQA.Selenium;
using TestFrameworkCore.Helper;

namespace WebDriverHelper.Helper {
    public class BrowserHelper {
        public IWebDriver Driver;
        public void OpenBrowser(string url = null, string browserType = null) {

            if (string.IsNullOrEmpty(browserType)) {

                browserType = ConfigurationHelper.GetConfig<string>("browser");
            }
            Driver = DriverFactoryHelper.InitDriver(browserType);

            // Setting implicit wait
            int timeout = ConfigurationHelper.GetConfig<int>("timeout");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);

            Driver.Manage().Window.Maximize();
            if (!string.IsNullOrEmpty(url)) {
                GoToUrl(url);
            }
        }

        public void GoToUrl(string url) {
            Driver.Navigate().GoToUrl(url);
        }

        public string TakeScreenshotAsBase64() {
            // Convert WebDriver object to ITakesScreenshot
            ITakesScreenshot screenshotDriver = (ITakesScreenshot)Driver;

            // Take the screenshot
            Screenshot screenshot = screenshotDriver.GetScreenshot();

            return screenshot.AsBase64EncodedString;
        }

        public void QuitBrowser() {
            if (Driver is null) {
                return;
            }
            Driver.Quit();
        }
    }
}

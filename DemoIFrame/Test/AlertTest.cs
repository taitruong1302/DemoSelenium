using FluentAssertions;
using OpenQA.Selenium;
using WebDriverHelper.Helper;

namespace DemoIFrame.Test {
    [TestClass]
    public class AlertTest {
        BrowserHelper browserHelper;
        private By xpathButton(string text) => By.XPath($"//button[text() = '{text}']");
        private By xpathLabelResult = By.XPath("//p[@id = 'result']");
        [TestInitialize]
        public void TestInitialize() {
            browserHelper = new BrowserHelper();
            browserHelper.OpenBrowser("https://the-internet.herokuapp.com/javascript_alerts");

        }

        [TestCleanup]
        public void TestCleanup() {
            browserHelper.QuitBrowser();
        }

        [TestMethod]
        public void VerifyAlert() {
            browserHelper.Driver.FindElement(xpathButton("Click for JS Alert")).Click();
            browserHelper.Driver.SwitchTo().Alert().Accept();
        }

        [TestMethod]
        public void VerifyConfirmAlert() {
            browserHelper.Driver.FindElement(xpathButton("Click for JS Confirm")).Click();
            browserHelper.Driver.SwitchTo().Alert().Accept();
        }

        [TestMethod]
        public void VerifyPrompt() {
            browserHelper.Driver.FindElement(xpathButton("Click for JS Prompt")).Click();

            var value = "Account" + DateTime.Now.ToFileTimeUtc();
            browserHelper.Driver.SwitchTo().Alert().SendKeys(value);
            browserHelper.Driver.SwitchTo().Alert().Accept();

            string actualResult = browserHelper.Driver.FindElement(xpathLabelResult).Text;
            List<string> splitString = actualResult.Split(':').ToList();
            string actualInput = splitString.Last().Trim();
            actualResult.Should().Be(actualInput);
        }
    }
}
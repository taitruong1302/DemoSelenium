using OpenQA.Selenium;
using WebDriverHelper.Helper;

namespace DemoIFrame.Test {
    [TestClass]
    public class IFrameTest {
        private BrowserHelper browserHelper;
        private By xpathInput = By.XPath("//div[@class = 'row']/div/input[@type = 'text']");
        private By xpathIFrameSingle = By.XPath("//iframe[@id = 'singleframe']");
        private By xpathButtonMultipleFrame = By.XPath("//a[text() = 'Iframe with in an Iframe']");
        [TestInitialize]
        public void TestInitialize() {
            browserHelper = new BrowserHelper();
            browserHelper.OpenBrowser("https://demo.automationtesting.in/Frames.html");

        }

        [TestCleanup]
        public void TestCleanup() {
            browserHelper.QuitBrowser();
        }

        [TestMethod]
        public void VerifyIFrame() {
            var frame = browserHelper.Driver.FindElement(xpathIFrameSingle);

            browserHelper.Driver.SwitchTo().Frame(frame);
            browserHelper.Driver.FindElement(xpathInput).SendKeys("abc");

            browserHelper.Driver.SwitchTo().DefaultContent();
            browserHelper.Driver.FindElement(xpathButtonMultipleFrame).Click();
        }
    }
}

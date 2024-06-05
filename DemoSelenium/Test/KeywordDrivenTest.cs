using DemoSelenium.Helper;
using TestFrameworkCore.Helper;

namespace DemoSelenium.Test {
    [TestClass]
    public class KeywordDrivenTest {
        [TestMethod("TC04: Verify login by using keyword driven")]
        public void VerifyLogin() {
            ExcelHelper excelHelper = new ExcelHelper(Path.Combine("Resources", "KeywordDriven.xlsx"));
            var keywords = excelHelper.GetKeywordDatas();

            var keywordHelper = new KeywordHelper(keywords);
            keywordHelper.ExecuteKeywords();
        }
    }
}

using AventStack.ExtentReports;

namespace TestFrameworkCore.Helper.Report {
    public static class ExtensionReportHelper {
        public static void LogMessage(this ExtentTest test, string message) {
            test.Log(Status.Info, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="test"></param>
        /// <param name="result">Passed/Failed</param>
        public static void AddResult(this ExtentTest test, string result) {
            if (result.Equals("Passed")) {
                test.Pass("Passed");
            }
            else {
                test.Fail("Failed");
            }
        }

        public static void AddImageBase64(this ExtentTest test, string imageBase64) {
            test.AddScreenCaptureFromBase64String(imageBase64, "screenshot");
        }
    }
}

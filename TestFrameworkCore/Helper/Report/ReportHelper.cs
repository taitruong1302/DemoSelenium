using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace TestFrameworkCore.Helper.Report {
    public class ReportHelper {
        private ExtentReports extent;

        public ReportHelper() {
            InitReport();
        }

        public void InitReport() {
            extent = new ExtentReports();
            var reportName = $"Report_{DateTime.Now.ToFileTimeUtc()}.html";
            var reportPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", reportName);
            var spark = new ExtentSparkReporter(reportPath);
            extent.AttachReporter(spark);
        }

        public void ExportReport() {
            extent.Flush();
        }

        public ExtentTest CreateTest(string testName, string description) {
            return extent.CreateTest(testName, description);
        }

    }
}

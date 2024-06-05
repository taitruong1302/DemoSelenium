using TestFrameworkCore.Helper.Report;

[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.MethodLevel)]
namespace DemoSelenium.Test {
    [TestClass]
    public class AssemplyTest {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext) {
            // Setup report
            BaseTest.ReportHelper = new ReportHelper();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup() {
            if (BaseTest.ReportHelper != null) {
                BaseTest.ReportHelper.ExportReport();
            }
        }
    }
}

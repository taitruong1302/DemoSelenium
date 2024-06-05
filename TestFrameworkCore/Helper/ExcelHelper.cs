using OfficeOpenXml;
using TestFrameworkCore.Model;
namespace TestFrameworkCore.Helper {
    public class ExcelHelper {
        private string filePath;
        public ExcelHelper(string _filePath) {
            filePath = _filePath;
        }

        public List<KeywordData> GetKeywordDatas() {

            var keywords = new List<KeywordData>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(filePath)) {
                var workSheet = package.Workbook.Worksheets.FirstOrDefault();
                var table = workSheet.Tables.FirstOrDefault();

                var totalColumn = table.Range.Columns;
                var totalRow = table.Range.Rows;

                for (var i = 2; i <= totalRow; i++) {
                    // Data from column 1
                    var keyword = workSheet.Cells[i, 1].Value.ToString();

                    // Data from column 2
                    var data = workSheet.Cells[i, 2].Value?.ToString();

                    keywords.Add(new KeywordData {
                        Keyword = keyword,
                        Data = data
                    });
                }
            }
            return keywords;
        }

        public List<object[]> GetLoginUserData() {
            var result = new List<object[]>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(filePath)) {
                var workSheet = package.Workbook.Worksheets.FirstOrDefault();
                var table = workSheet.Tables.FirstOrDefault();
                var totalColumn = table.Range.Columns;
                var totalRow = table.Range.Rows;
                for (var i = 2; i <= totalRow; i++) {
                    result.Add(new object[] { workSheet.Cells[i, 1].Value.ToString(),
                                             workSheet.Cells[i, 2].Value.ToString(),
                                             bool.Parse(workSheet.Cells[i, 3].Value.ToString()) });
                }
            }
            return result;
        }
    }
}
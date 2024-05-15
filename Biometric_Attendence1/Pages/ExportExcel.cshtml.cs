using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Biometric_Attendence1.Pages
{
    public class ExportExcelModel : PageModel
    {
        public IActionResult OnGetExportToExcel()
        {
            // Create sample DataTable (replace with your actual data)
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Column1", typeof(int));
            dataTable.Columns.Add("Column2", typeof(string));
            dataTable.Rows.Add(1, "Value1");
            dataTable.Rows.Add(2, "Value2");

            // Export DataTable to Excel
            using (var memoryStream = new MemoryStream())
            {
                using (var excelPackage = new OfficeOpenXml.ExcelPackage(memoryStream))
                {
                    var worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");
                    worksheet.Cells["A1"].LoadFromDataTable(dataTable, true);
                    excelPackage.Save();
                }

                return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "exported_data.xlsx");
            }
        }
    }
}


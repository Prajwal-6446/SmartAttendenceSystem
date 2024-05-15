using Azure;
using Biometrics_DataAccess.Repository;
using Biometrics_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OfficeOpenXml;
using System.Data;

namespace Biometric_Attendence1.Pages
{
    public class TIndex2Model : PageModel
    {
		private readonly ITrackUsersRepository _tb;
		private readonly IManageUsersRepository _db;
		private readonly IMarkAttendenceRepository _markAttendenceRepository;
		public IEnumerable<TrackUser> TrackUsers { get; set; }
		public IEnumerable<Filtereddata> filterResult { get; set; }
		public List<ManageUser> ManageUser = new List<ManageUser>();

        public TIndex2Model(ITrackUsersRepository tb, IManageUsersRepository db,IMarkAttendenceRepository markAttendenceRepository)
		{
			_db = db;
			_tb = tb;
			_markAttendenceRepository = markAttendenceRepository;
		}

		public void OnGet(int id = 0)
		{
			 ManageUser = _tb.GetUsersOnTrackingUsers(id);
			
            //_tb.GetAll();
            //TrackUsers = _tb.GetAll(); //retrieve all the list of categories from db and store that in categories varible (array)
        }
		
		public JsonResult OnPostGetFilteredData(int? id, string? toDate, string? fromDate)
		{
			filterResult=_markAttendenceRepository.GetFilteredData(id, toDate, fromDate);
			return new JsonResult(filterResult.ToList());
		}

		//public IActionResult OnGetExportToExcel()
		//{
		//	// Assuming dataTable is properly filled with data
		//	DataTable dataTable = new DataTable();
		//	// Fill the DataTable with your data (replace this with your actual data retrieval logic)

		//	// Create a memory stream to hold the Excel file
		//	using (var memoryStream = new MemoryStream())
		//	{
		//		using (var excelPackage = new ExcelPackage(memoryStream))
		//		{
		//			var worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");
		//			// Load data from DataTable to Excel worksheet
		//			// For example: worksheet.Cells["A1"].LoadFromDataTable(dataTable, true);
		//			excelPackage.Save();
		//		}
		//		// Return the Excel file as a downloadable file
		//		return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "exported_data.xlsx");
		//	}
		//}
	}
}


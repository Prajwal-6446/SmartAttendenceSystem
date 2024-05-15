using Biometrics_DataAccess.Repository;
using Biometrics_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Biometric_Attendence1.Pages
{
	public class MDelete1Model : PageModel
	{
		private readonly IManageUsersRepository _db;
		public ManageUser ManageUser { get; set; }
		public MDelete1Model(IManageUsersRepository db)
		{
			_db = db;
		}
		public void OnGet(int? Id)
		{
			ManageUser = _db.Find(Id.GetValueOrDefault());
		}

		public JsonResult OnPostDeleteUsers(int? FingerId)//using iactn becoz i need to return to some page or redirect to view
		{


			if ( FingerId != null)
			{
				_db.Remove(FingerId.GetValueOrDefault());
			}

			return new JsonResult(new { success = true, message = "successfully deleted the details" });
		}
	}
}


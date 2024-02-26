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
		public void OnGet(int? id)
		{
			ManageUser = _db.Find(id.GetValueOrDefault());
		}

		public async Task<IActionResult> OnPost(int? id)//using iactn becoz i need to return to some page or redirect to view
		{


			if (id == null)
			{
				return NotFound();
			}

			_db.Remove(id.GetValueOrDefault());
			TempData["Success"] = "User Deleted Successfully";
			return RedirectToPage("MIndex1");
		}
	}
}


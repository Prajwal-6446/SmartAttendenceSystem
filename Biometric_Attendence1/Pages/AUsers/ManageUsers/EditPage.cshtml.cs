
using Biometrics_DataAccess.Repository;
using Biometrics_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BioMetric_Attendence.Pages.ManageUsers
{
	[BindProperties]
	public class EditModel : PageModel
	{
		private readonly IManageUsersRepository _db;
		public ManageUser ManageUser { get; set; }
		public EditModel(IManageUsersRepository db)
		{
			_db = db;
		}

		public void OnGet(int? id)
		{
			ManageUser = _db.Find(id.GetValueOrDefault());
			// Category = _db.Category.FirstOrDefault(u=>u.Id==id); //if there is no record with that id then first will throw error and default will just return error
			//Category = _db.Category.SingleOrDefault(u=>u.Id==id);
			//Category = _db.Category.Where(u=>u.Id==id).FirstOrDefault();//it can return 10 or more records wherevr the id matches so thasty firstordefaylt is called
		}


			public async Task<IActionResult> OnPost(int id)
			{
				if (ModelState.IsValid)
				{
					await Task.Run(() => _db.Update(ManageUser)); // Run the synchronous method asynchronously

					return RedirectToPage("Index");
				}

				return Page();
			}

		}
	}

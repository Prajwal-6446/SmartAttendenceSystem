using Biometrics_DataAccess.Repository;
using Biometrics_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Biometric_Attendence1.Pages
{
    public class MIndex1Model : PageModel
    {
		private readonly IManageUsersRepository _db;
		public IEnumerable<ManageUser> ManageUsers { get; set; }
		public MIndex1Model(IManageUsersRepository db)
		{
			_db = db;
		}

		public void OnGet()
		{
			ManageUsers = _db.GetAll(); //retrieve all the list of categories from db and store that in categories varible (array)
		}
	}
}


using Biometrics_DataAccess.Data;
using Biometrics_DataAccess.Repository;
using Biometrics_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BioMetric_Attendence.Pages.ManageUsers
{
    public class IndexModel : PageModel
    {
        private readonly IManageUsersRepository _db;
        public IEnumerable<ManageUser> ManageUsers { get; set; }
        public IndexModel(IManageUsersRepository db)
		{
			_db = db;
		}

		public void OnGet()
		{
			ManageUsers = _db.GetAll(); //retrieve all the list of categories from db and store that in categories varible (array)
		}
	}
}


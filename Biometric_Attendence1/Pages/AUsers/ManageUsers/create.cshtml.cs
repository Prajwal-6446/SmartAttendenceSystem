using Biometrics_DataAccess.Repository;
using Biometrics_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BioMetric_Attendence.Pages.ManageUsers
{
	[BindProperties]
    public class createModel : PageModel
    {
        private readonly IManageUsersRepository _db;
        public ManageUser ManageUser { get; set; }
        public createModel(IManageUsersRepository db)
        {
           _db = db;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost([Bind("Name,Gender,FingerId,Date,FingerprintData")] ManageUser manageUser)
        {
            
                _db.Add(manageUser);
                return RedirectToPage("Index");
            
     
        }
        

    }
}

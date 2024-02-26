using Biometrics_DataAccess.Repository;
using Biometrics_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Biometric_Attendence1.Pages
{
    public class MCreate1Model : PageModel
    {
        private readonly IManageUsersRepository _mb;
        private readonly IMarkAttendenceRepository _markAttendenceRepository1;

        //creating properties
        public ManageUser manageUser = new ManageUser();

        public GetFingerId GetfingerId = new GetFingerId();
        public MCreate1Model(IManageUsersRepository mb,IMarkAttendenceRepository markAttendenceRepository)
        {
            _mb = mb;
            _markAttendenceRepository1=markAttendenceRepository;
        }
        public void OnGet()
        {
            GetfingerId.fingerId = _mb.getfingerId();
        }

        public JsonResult OnPostAddUsers(string fingerhashData, int fingerId, string name, DateTime date, string gender)
        {

            try
            {
                manageUser.FingerprintData = fingerhashData;
                manageUser.FingerId = fingerId;
                manageUser.Name = name;
                manageUser.Date = date;
                manageUser.Gender = gender;


                _mb.Add(manageUser);
                TempData["Success"] = "User Added Successfully";

                return new JsonResult(new { success = true, message = "successfully added the details" });

                //return new JsonResult(new { success = true, message = "Fingerprint captured successfully" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = $"Error Adding UserDetails: {ex.Message}" });
            }
        }

        // Add other actions for adding, updating, and deleting employees
        
    }

}


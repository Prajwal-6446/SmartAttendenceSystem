using Biometrics_DataAccess.Repository;
using Biometrics_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Biometric_Attendence1.Pages
{
    public class MarkAttendenceModel : PageModel
    {
        private readonly IMarkAttendenceRepository _markAttendenceRepository1;

        //creating properties

        public GetFingerId GetfingerId = new GetFingerId();
        public MarkAttendenceModel( IMarkAttendenceRepository markAttendenceRepository)
        {
    
            _markAttendenceRepository1 = markAttendenceRepository;
        }
        public void OnGet()
        {
        }
        public JsonResult OnPostUserExistence(int id)
        {

            bool userExistence = _markAttendenceRepository1.UserExtistnce(id);
            return new JsonResult(new { success = userExistence });
        }

        //public JsonResult OnPostMarkUserAttendence(int stID) {

        //}
    }
}

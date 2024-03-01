using Biometrics_DataAccess.Repository;
using Biometrics_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Biometric_Attendence1.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IRegistrationRepository _rd;
        private readonly IMarkAttendenceRepository _ma;

        //creating properties

        public GetFingerId GetfingerId = new GetFingerId();
        public Registration registration { get; set; }
        public IndexModel(ILogger<IndexModel> logger , IRegistrationRepository rd , IMarkAttendenceRepository ma)
        {
            _logger = logger;
            _rd = rd;
            _ma = ma;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {

            if (registration.Password != registration.confirmPassword)
            {
                ModelState.AddModelError("registration.confirmPassword", "Passwords do not match.");
                return Page();
            }
            _rd.Adduser(registration);
            TempData["Success"] = "Registration Successfully";
            return RedirectToPage("MIndex1");
        }
        //public JsonResult OnPostUserExistence(int id)
        //{

        //    bool userExistence = _ma.UserExtistnce(id);
        //    return new JsonResult(new { success = userExistence });
        //}
    }
}

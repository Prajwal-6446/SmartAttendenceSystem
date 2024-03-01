using Biometrics_DataAccess.Repository;
using Biometrics_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol.Plugins;

namespace Biometric_Attendence1.Pages
{
    [BindProperties]
    public class LoginModel : PageModel
    {
        private readonly IRegistrationRepository _rd;
        public Registration registration { get; set; }
        public LoginModel(IRegistrationRepository rd)
        {
            _rd = rd;
        }
        public void OnGet()
        {
         
        }
        public IActionResult OnPost()
        {

            var userExist = _rd.UserExist(registration.Username, registration.Password);
            if (userExist)
            {
                return RedirectToPage("/MIndex1");
            }
            else
            {
                return RedirectToPage("/Index");
            }
        }
    }
    }


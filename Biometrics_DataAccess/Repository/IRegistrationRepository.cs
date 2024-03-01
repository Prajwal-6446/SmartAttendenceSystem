using Biometrics_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biometrics_DataAccess.Repository
{
    public interface IRegistrationRepository
    {
        Registration Adduser(Registration registration);
       public bool UserExist(string Username , string Password ) ;
    }
}

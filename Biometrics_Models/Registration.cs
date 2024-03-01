using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Biometrics_Models
{
    public  class Registration
    {
        [Key]
        public int UserId { get; set; }
        public string  Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string confirmPassword {  get; set; }
    }
}

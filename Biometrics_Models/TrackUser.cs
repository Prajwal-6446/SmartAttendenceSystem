using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biometrics_Models
{
    public class TrackUser
    {
        public int Id { get; set; }
        public int ManageUserId { get; set; }
        public ManageUser ManageUser { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        [NotMapped]
        public List<ManageUser> ManageUsers { get; set; }
 
    }
}


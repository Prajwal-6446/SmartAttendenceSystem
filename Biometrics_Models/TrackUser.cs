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
        public ManageUser ManageUser { get; set; }  //foreign key from manage user table 
        public string? Attendence { get; set; } 
        public TimeSpan? TimeIn { get; set; }
        public TimeSpan? TimeOut { get; set; }
        [NotMapped]
        public List<ManageUser>? ManageUsers { get; set; }
        public DateTime? date { get; set; }
 
    }

    public class Time
    {
        public TimeSpan? TimeIn { get; set; }
        public TimeSpan? TimeOut { get; set;}
    }

    public class Filtereddata { 
        public int? Id { get; set; }
        public long? SrNo { get ; set; } 
        public string? name { get; set;}
        public DateTime? date { get; set;}
        public int? fingerId { get; set;}
		public TimeSpan? TimeIn { get; set; }
		public TimeSpan? TimeOut { get; set; }
	}

}


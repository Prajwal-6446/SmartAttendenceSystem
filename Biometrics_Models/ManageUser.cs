using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biometrics_Models
{
    public class ManageUser
    {
        [Key]
        public int Id { get; set; }
        //[Required]
        public string? Name { get; set; }
        public string? Gender { get; set; }
        //[Required]
        //[Range(0, 100, ErrorMessage = "Enter Finger ID between 1 - 127:")]
        public int FingerId { get; set; }
        //[Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; }
        public string FingerprintData { get; set; }
        [NotMapped]
         public virtual TrackUser? TrackUser { get; set; }

	
	}

    public class GetFingerId
    {
       public int? fingerId { get; set; }
    }
}

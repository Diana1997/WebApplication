using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Visit
    {
        [Key]
        public int VisitID { set; get; }
        [Required]
        public int UserID { set; get; }
        [Required]
        public int PatientID { set; get; }
        [Required]
        public DateTime DateTime { set; get; }
        public string Comment { set; get; }
        [Required]
        public int ResearchID { set; get; }
        public User User { set; get; }
        public Patient Patient { set; get; }
        public Research Research { set; get; }
    }
}
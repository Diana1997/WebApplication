using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { set; get; }
        [Required]
        public int CardNumber { set; get; }
        [Required]
        public int ContactID { set; get; }
        [Required]
        public PatientStatus PatientStatus { set; get; }
        [Required]
        public DateTime CreationDate { set; get; }
        public string Comment { set; get; }
        public int ImageID { set; get; }
        public DateTime DateTimeNextVisit { set; get; }
        public Contact Contact { set; get; }
        public Image Image { set; get; }
        public ICollection<Visit> Visits { set; get; }
        public Patient()
        {
            Visits = new List<Visit>();
        }
    }
}
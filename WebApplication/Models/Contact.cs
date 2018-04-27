using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Contact
    {
        [Key]
        public int ContactID { set; get; }
        [Required]
        [MaxLength(100)]
        public string Firstname { set; get; }
        [Required]
        [MaxLength(100)]
        public string Secondname { set; get; }
        [Required]
        [MaxLength(100)]
        public string Lastname { set; get; }
        [Required]
        public Gender Gender { set; get; }
        [Required]
        public DateTime Birthday { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public string Address { set; get; }
        public string Position { set; get; }
        public string Specialty { set; get; }
        public string Education { set; get; }
        public string Comment { set; get; }
        public string Degree { set; get; }

        public ICollection<Patient> Patients { set; get; }
        public ICollection<User> Users { set; get; }
        public Contact()
        {
            Patients = new List<Patient>();
            Users = new List<User>();
        }
    }
}
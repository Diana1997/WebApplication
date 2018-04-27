using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class User
    {
        [Key]
        public int UserID { set; get; }
        [Required]
        [MaxLength(50)]
        public string Login { set; get; }
        [Required]
        public byte[] Password { set; get; }
        public DateTime LastLoginTime { set; get; }
        public int LensID { set; get; }
        public int DiagnosticID { set; get; }
        public int SettingID { set; get; }
        [Required]
        public int ContactID { set; get; }
        public Diagnostic Diagnostic { set; get; }
        public Setting Setting { set; get; }
        public Contact Contact { set; get; }
        public ICollection<Visit> Visits { set; get; }
        public User()
        {
            Visits = new List<Visit>();
        }
    }
}
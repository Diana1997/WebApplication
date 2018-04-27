using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Diagnostic
    {
        [Key]
        public int DiagnosticID { set; get; }
        [Required]
        [MaxLength(2000)]
        public string DiagnosticText { set; get; }
        [Required]
        public DateTime CreationDate { set; get; }
        [Required]
        public DateTime DateOfLastConfirmation { set; get; }
        public string Comment { set; get; }
        public ICollection<Research> Researchs { set; get; }
        public ICollection<User> Users { set; get; }
        public Diagnostic()
        {
            Researchs = new List<Research>();
            Users = new List<User>();
        }
    }
}
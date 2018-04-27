using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Lens
    {
        [Key]
        public int LensID { set; get; }
        [Required]
        [MaxLength(50)]
        public string Name { set; get; }
        [Required]
        public int Scale { set; get; }
        public ICollection<Research> Researchs { set; get; }
        public Lens()
        {
            Researchs = new List<Research>();
        }
    }
}
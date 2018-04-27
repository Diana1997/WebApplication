using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Hair
    {
        [Key]
        public int HairID { set; get; }
        [Required]
        public int Width { set; get; }
        [Required]
        public int X1 { set; get; }
        [Required]
        public int X2 { set; get; }
        [Required]
        public int Y1 { set; get; }
        [Required]
        public int Y2 { set; get; }
        public ICollection<Research> Researchs { set; get; }
        public Hair()
        {
            Researchs = new List<Research>();
        }
    }
}
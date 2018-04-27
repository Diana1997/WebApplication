using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Research
    {
        [Key]
        public int ResearchID { set; get; }
        [Required]
        public ResearchType ResearchType { set; get; }
        [Required]
        public StateOfTheResearch StateOfTheResearch { set; get; }
        [Required]
        public byte[] Thumbnail { set; get; }
        [Required]
        public int ImageID { set; get; }
        [Required]
        public int HairID { set; get; }
        [Required]
        public int ResearchArea { set; get; }
        public string Comment { set; get; }
        public DateTime ResearchTime { set; get; }
        public int DiagnosticID { set; get; }
        public string Treatment { set; get; }
        [Required]
        public int SettingID { set; get; }
        [Required]
        public int LensID { set; get; }
        public Image Image { set; get; }
        public Hair Hair { set; get; }
        public Diagnostic Diagnostic { set; get; }
        public Setting Setting { set; get; }
        public Lens Lens { set; get; }
        public ICollection<Visit> Visits { set; get; }
        public Research()
        {
            Visits = new List<Visit>();
        }
    }
}
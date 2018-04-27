using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Setting
    {
        [Key]
        public int SettingsID { set; get; }
        [Required]
        public int HairSizeSettingsID { set; get; }
        [Required]
        public int StatisticalSettingsID { set; get; }
        public HairSizeSettings HairSizeSettings { set; get; }
        public StatisticalSettings StatisticalSettings { set; get; }
        public ICollection<Research> Researchs { set; get; }
        public ICollection<User> Users { set; get; }
        public Setting()
        {
            Researchs = new List<Research>();
            Users = new List<User>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class StatisticalSettings
    {
        [Key]
        public int StatisticalSettingsID { set; get; }
        [Required]
        public int AnagenAll { set; get; }
        [Required]
        public int TelogenAll { set; get; }
        [Required]
        public int AnagenTerm { set; get; }
        [Required]
        public int TelogenTerm { set; get; }
        [Required]
        public int AnagenVallus { set; get; }
        [Required]
        public int TelogenVallus { set; get; }
        public ICollection<Setting> Settings { set; get; }
        public StatisticalSettings()
        {
            Settings = new List<Setting>();
        }
    }
}
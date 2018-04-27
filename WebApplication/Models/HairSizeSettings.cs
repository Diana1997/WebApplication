using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class HairSizeSettings
    {
        [Key]
        public int HairSizeSettingsID { set; get; }
        [Required]
        public int LengthOfTelogenHair { set; get; }
        [Required]
        public int DiameterOfVelusTerminal { set; get; }
        [Required]
        public int DiameterOfTerminalsThinMedium { set; get; }
        [Required]
        public int DiameterOfTerminalsMediumThick { set; get; }
        [Required]
        public int RadiusOfFollicularUnits { set; get; }

        public ICollection<Setting> Settings { set; get; }
        public HairSizeSettings()
        {
            Settings = new List<Setting>();
        }
    }
}
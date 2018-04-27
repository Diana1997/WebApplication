using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ReportField
    {
        [Key]
        public int ReportFieldID { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public FieldType FieldType { set; get; }
        [Required]
        public int FieldOptionID { set; get; }
        public FieldOption FieldOption { set; get; }
    }
}
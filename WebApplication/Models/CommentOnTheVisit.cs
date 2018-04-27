using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class CommentOnTheVisit
    {
        [Key]
        public int CommentOnTheVisitID { set; get; }
        [Required]
        public TypeOfComment TypeOfComment { set; get; }
        [Required]
        [MaxLength(2000)]
        public string Comment { set; get; }
    }
}
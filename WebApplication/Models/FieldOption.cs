using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class FieldOption
    {
        public int FieldOptionID { set; get; }
        public string Title { set; get; }
        public bool Selected { set; get; }
        public string Text { set; get; }

        public ICollection<ReportField> ReportFields { set; get; }
        public FieldOption()
        {
            ReportFields = new List<ReportField>();
        }
    }
}
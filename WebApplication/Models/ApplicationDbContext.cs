using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace WebApplication.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CommentOnTheVisit> CommentOnTheVisits { set; get; }
        public DbSet<Contact> Contacts { set; get; }
        public DbSet<FieldOption> FieldOptions { set; get; }
        public DbSet<Hair> Hairs { set; get; }
        public DbSet<HairSizeSettings> HairSizeSettings { set; get; }
        public DbSet<Image> Images { set; get; }
        public DbSet<Lens> Lenses { set; get; }
        public DbSet<Patient> Patients { set; get; }
        public DbSet<Picture> Pictures { set; get; }
        public DbSet<ReportField> ReportFields { set; get; }
        public DbSet<Research> Researchs { set; get; }
        public DbSet<Setting> Settings { set; get; }
        public DbSet<StatisticalSettings> StatisticalSettings { set; get; }
        public DbSet<User> Users { set; get; }
        public DbSet<Visit> Visits { set; get; }

        public System.Data.Entity.DbSet<WebApplication.Models.Diagnostic> Diagnostics { get; set; }
    }
}
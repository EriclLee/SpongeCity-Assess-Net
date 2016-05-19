using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpongeCity.Assess.DAL
{
    public class AssessDBContext:DbContext
    {
        public AssessDBContext() : base("name=AssessContextString") {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AssessDBContext>());
        }
        
        public DbSet<DBModels.Category> Categorys { get; set; }
        public DbSet<DBModels.KPI> KPIs { get; set; }
        public DbSet<DBModels.ViewTemplate> ViewTemplates { get; set; }
        public DbSet<DBModels.View> Views { get; set; }
        public DbSet<DBModels.Activity> Activitys { get; set; }
        public DbSet<DBModels.SubCategory> SubCategorys { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}

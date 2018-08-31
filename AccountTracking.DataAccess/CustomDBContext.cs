using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountTracking.DataAccess
{
    public class CustomDBContext : DbContext
    {
        public CustomDBContext() : base("DbConn")
        {
            Database.SetInitializer<CustomDBContext>(new CreateDatabaseIfNotExists<CustomDBContext>());
            Database.Initialize(true);
        }

        public DbSet<Project> Projects {get; set;}
        public DbSet<TaskQuality> TaskQuality { get; set; }
        public DbSet<TaskStatus> TaskStatus { get; set; }
        public DbSet<TaskDetail> TaskDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();            
        }

    }
}

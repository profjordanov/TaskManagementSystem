using System.Collections;
using Microsoft.AspNet.Identity.EntityFramework;
using TaskManagementSystem.Models.EntityModels;

namespace TaskManagementSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TaskManagementSystemContext : IdentityDbContext<ApplicationUser>
    {

        public TaskManagementSystemContext()
            : base("name=TaskManagementSystemContext", throwIfV1Schema: false)
        {
        }
        static TaskManagementSystemContext()
        {
            Database.SetInitializer<TaskManagementSystemContext>(null);
        }
        public DbSet<TaskModel> Tasks { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Apply> Applies { get; set; }
        public DbSet<JobAd> JobAds { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>()
               .HasRequired(t => t.TaskModel)
               .WithMany(c => c.Comments)
               .WillCascadeOnDelete(false);
        }

        public static TaskManagementSystemContext Create()
        {
            return new TaskManagementSystemContext();
        }
    }

}
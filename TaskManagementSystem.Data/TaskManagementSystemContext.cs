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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>()
               .HasOptional(anom => anom.TaskModel)
               .WithMany(planet => planet.Comments)
               .WillCascadeOnDelete(false);
        }

        public static TaskManagementSystemContext Create()
        {
            return new TaskManagementSystemContext();
        }
    }

}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Models.EntityModels
{
    [Table("Task")]
    public class TaskModel
    {
        public TaskModel()
        {
            this.Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime RequiredByDate { get; set; }
        public string TaskDescription { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public TaskType TaskType { get; set; }
        public DateTime NextActionDate { get; set; }
        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual ApplicationUser User  { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }



    }
}
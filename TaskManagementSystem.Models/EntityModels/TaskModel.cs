using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Required By Date")]
        public DateTime RequiredByDate { get; set; }

        [DisplayName("Task Description")]
        [DataType(DataType.MultilineText)]
        public string TaskDescription { get; set; }

        [DisplayName("Task Status")]
        public TaskStatus TaskStatus { get; set; }

        [DisplayName("Task Type")]
        public TaskType TaskType { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Next Action Date")]
        public DateTime NextActionDate { get; set; }

        [DisplayName("Assigned To")]
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        [DisplayName("Assigned To")]
        public virtual ApplicationUser User  { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }



    }
}
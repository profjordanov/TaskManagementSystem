using System;

namespace TaskManagementSystem.Models.EntityModels
{
    public class Comment
    {
        public int Id { get; set; }
        public virtual TaskModel TaskModel { get; set; }
        public DateTime DateAdded { get; set; }
        public string CommentDescription { get; set; }
        public DateTime ReminderDate { get; set; }
    }
}
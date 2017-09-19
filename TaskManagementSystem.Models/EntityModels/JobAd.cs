using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TaskManagementSystem.Models.EntityModels
{
    public class JobAd
    {
        //TODO: I need to put the whole information about "Add"
        public JobAd()
        {
            this.Applies = new HashSet<Apply>();
        }
        [Key]
        public int Id { get; set; }
        public string Position { get; set; }

        //TODO: Image tobe from the computer
        public string ImageUrl { get; set; }
        public StudentProfile StudentProfile { get; set; }
        public string Location { get; set; }
        public DateTime CreateOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ValidUntil { get; set; }

        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Apply> Applies { get; set; }
    }
    public enum StudentProfile
    {
        ActionOriented, ProcessOriented, PeopleOriented, IdeaOriented
    }
}
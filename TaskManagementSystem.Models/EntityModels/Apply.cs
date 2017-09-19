using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Models.EntityModels
{
    public class Apply
    {
        [Key]
        public int Id { get; set; }

        [Index("JobAd_Id", 1, IsUnique = true)]
        public virtual JobAd JobAd { get; set; }

        [Index("User_Id", 2, IsUnique = true)]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public ApplyStatus ApplyStatus { get; set; }

    }
    public enum ApplyStatus
    {
        [Display(Name = "Неопределен")]
        Undefined,

        [Display(Name = "Неподходящ")]
        Inappropriate,

        [Display(Name = "Подходящ")]
        Appropriate,

        [Display(Name = "Средноподходящ")]
        ModeratelyAppropriate,

        [Display(Name = "За Интервю")]
        ForAnInterview
    }
}
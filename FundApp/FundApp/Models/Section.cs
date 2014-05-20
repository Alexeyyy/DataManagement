using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace FundApp.Models
{
    public class Section
    {
        [Key]
        public int SectionID { get; set; }

        [Display(Name = "Название секции")]
        [Required]
        public string Title { get; set; }
        
        [Display(Name = "Описание секции")]
        [Required]
        public string Description { get; set; }
        
        [Display(Name = "Время старта занятий")]
        [Required]
        public DateTime StartLessonsTime { get; set; }
        
        [Display(Name = "Число участников")]
        public int ParticipantsCount { get; set; }
        
        [Display(Name = "Число мест")]
        public int SpotsCount { get; set; }
        
        [Display(Name="Число свободных мест")]
        public int FreeSpotsCount { get; set; }
        
        [Display(Name="Число занятий")]
        public int LessonsCount { get; set; }

        [Required]
        public virtual Ecologist Ecologist { get; set; }
        
        public virtual ICollection<RankUser> Participants { get; set; }

        public void CalculateFreeSpots()
        {
            FreeSpotsCount = SpotsCount - ParticipantsCount;
        }

        public void CalculateParticipantsCount()
        {
            if (Participants != null)
                ParticipantsCount = Participants.Count();
            else
                ParticipantsCount = 0;
        }
    }
}
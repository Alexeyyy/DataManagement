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

        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public DateTime StartLessonsTime { get; set; }
        
        public int ParticipantsCount { get; set; }
        
        public int SpotsCount { get; set; }
        
        public int FreeSpotsCount { get; set; }
        
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
            if (Participants.Count != null)
                ParticipantsCount = Participants.Count();
            else
                ParticipantsCount = 0;
        }
    }
}
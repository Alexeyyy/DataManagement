using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FundApp.Models
{
    public class Section
    {
        [Key]
        public int SectionID { get; set; }
        public string Description { get; set; }
        public DateTime StartLessonsTime { get; set; }
        public DateTime EndLessonsTime { get; set; }
        public int ParticipantsCount { get; set; }
        public int SpotsCount { get; set; }
        public int FreeSpotsCount { get; set; }
        public int LessonsCount { get; set; }

        [Required]
        public virtual Ecologist Ecologist { get; set; }
        public virtual ICollection<RankUser> Participants { get; set; }
    }
}
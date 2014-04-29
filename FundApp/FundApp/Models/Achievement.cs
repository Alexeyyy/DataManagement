﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FundApp.Models
{
    public class Achievement
    {
        [Key]
        public int AchievementID { get; set; }
        public string Description { get; set; }
        public string PhotoType { get; set; }
        public byte[] PhotoFile { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public virtual Administrator Administrator { get; set; }
        [Required]
        public virtual EcologicalProblem EcologicalProblem { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FundApp.Models
{
    public class Complaint
    {
        [Key]
        public int ComplaintID { get; set; }

        [Display(Name="Название жалобы")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Описание жалобы")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Дата публикации жалобы")]
        [Required]
        public DateTime AppearingDate { get; set; }
              
        public bool IsHidden { get; set; }
        
        [Required]
        public virtual User Creator { get; set; }
                
        public virtual OrganisationDeptor OrganisationDeptor { get; set; }
        public virtual EcologicalProblem EcologicalProblem { get; set; }
    }
}
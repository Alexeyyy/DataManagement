using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FundApp.Models
{
    public class EcologicalProblem
    {
        [Key]
        public int ProblemID { get; set; }

        [Display(Name="Название проблемы")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Описание проблемы")]
        [Required]
        public string Description { get; set; }

        public string PhotoType { get; set; }
        public byte[] PhotoFile { get; set; }

        [Display(Name = "Требуемая сумма")]
        public decimal RequiredSum { get; set; }

        [Display(Name = "Ход решения")]
        public bool IsSolved { get; set; }

        [Display(Name = "Дата публикации проблемы")]
        [Required]
        public DateTime PublicationDate { get; set; }

        [Required]
        public virtual Complaint Complaint { get; set; }
        [Required]
        public virtual Ecologist Creator { get; set; }
        
        public virtual Achievement Achievement { get; set; }
    }
}
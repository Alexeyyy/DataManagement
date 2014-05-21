using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FundApp.Models
{
    public class Council
    {
        [Key]
        public int CouncilID { get; set; }
        
        [Display(Name="Название совета")]
        [Required]
        public string Title { get; set; }
        
        [Display(Name="Дата проведения")]
        [Required]
        public DateTime AssignmentDate { get; set; }

        [Display(Name = "Результат совета")]
        [Required]
        public bool CounsilResult { get; set; }

        [Display(Name = "Описание")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Экологическая проблема")]
        [Required]
        public virtual EcologicalProblem Problem { get; set; }
        
        public virtual ICollection<Ecologist> Ecologists { get; set; }
    }
}
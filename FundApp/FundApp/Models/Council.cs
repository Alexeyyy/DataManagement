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
        [Required]
        public DateTime AssignmentDate { get; set; }
        
        [Required]
        public bool CounsilResult { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public virtual EcologicalProblem Problem { get; set; }
        public virtual ICollection<Ecologist> Ecologists { get; set; }
    }
}
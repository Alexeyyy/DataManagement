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
        public string Description { get; set; }

        public string PhotoType { get; set; }
        public byte[] PhotoFile { get; set; }

        public decimal RequiredSum { get; set; }
        public bool IsSolved { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }

        [Required]
        public virtual Complaint Complaint { get; set; }
        [Required]
        public virtual Ecologist Ecologist { get; set; }
    }
}
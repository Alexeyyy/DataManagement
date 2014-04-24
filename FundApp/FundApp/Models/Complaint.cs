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
        public DateTime AppearingDate { get; set; }
        public string Description { get; set; }

        //[Required]
        //public virtual RankUser User { get; set; }
        [Required]
        public virtual Partner Partner { get; set; }
        [Required]
        public virtual Ecologist Ecologist { get; set; }

        public virtual OrganisationDeptor OrganisationDeptor { get; set; }
        public virtual EcologicalProblem EcologicalProblem { get; set; }
    }
}
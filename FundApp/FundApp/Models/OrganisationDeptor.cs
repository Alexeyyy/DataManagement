using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FundApp.Models
{
    public class OrganisationDeptor
    {
        [Key]
        public int OrganisationDeptorID { get; set; }
        public string Reason { get; set; }
        public decimal FineAmount { get; set; }
        public DateTime PayTime { get; set; }
        public bool IsPayed { get; set; }
        public string Email { get; set; }

        [Required]
        public virtual Complaint Complaint { get; set; }
        [Required]
        public virtual Secretary Secretary { get; set; }
    }
}
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
        [Required]
        public string Name { get; set; }
        [Required]
        public string Reason { get; set; }
        [Required]
        public decimal FineAmount { get; set; }
        [Required]
        public DateTime PayTime { get; set; }
        [Required]
        public bool IsPayed { get; set; }
        [Required]
        public virtual Complaint Complaint { get; set; }
        
        public virtual Secretary ResponsiblePerson { get; set; }
        public string Email { get; set; }
    }
}
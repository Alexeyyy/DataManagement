using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FundApp.Models
{
    public class Partner
    {
        [Key]
        public int PartnerID { get; set; }
        public string Adress { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string PresenterInitials { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Complaint> Complaints { get; set; }
        [Required]
        public virtual PartnershipRequest PartnershipRequest { get; set; } 
    }
}
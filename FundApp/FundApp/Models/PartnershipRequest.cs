using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FundApp.Models
{
    public class PartnershipRequest
    {
        [Key]
        public int RequestID { get; set; }
        public int Description { get; set; }
        public bool IsAccepted { get; set; }

        [Required]
        public virtual Secretary Secretary { get; set; }
        [Required]
        public virtual RankUser RankUser { get; set; }
        public virtual Partner Partner { get; set; }
    }
}
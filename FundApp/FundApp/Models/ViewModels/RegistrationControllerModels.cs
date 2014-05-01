using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FundApp.Models
{
    public class RegistrationViewModel
    {
        public Ecologist ItemEcologist { get; set; }
        public RankUser ItemRankUser { get;set; }
        public PartnershipRequest ItemPartnershipRequest { get; set; }
        public Partner ItemPartner { get; set; }
        public User ItemUser { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FundApp.Models.ViewModels
{
    public class DebtorComplaint
    {
        public List<Complaint> listComplaints { get; set; }
        public List<OrganisationDeptor> listDebtors { get; set; }
    }
}
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

        [Display(Name="ФИО/Название организации")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Причина")]
        [Required]
        public string Reason { get; set; }

        [Display(Name = "Сумма платежа")]
        [Required]
        public decimal FineAmount { get; set; }

        [Display(Name = "Сроки платежа")]
        [Required]
        public DateTime PayTime { get; set; }

        [Display(Name = "Ход уплаты штрафа")]
        [Required]
        public bool IsPayed { get; set; }

        [Display(Name="Email")]
        public string Email { get; set; }

        [Required]
        public virtual Complaint Complaint { get; set; }
        
        public virtual Secretary ResponsiblePerson { get; set; }

    }
}
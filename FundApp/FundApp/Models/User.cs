using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FundApp.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Параметр введен неверно или не задан вообще")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Параметр введен неверно или не задан вообще")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Параметр введен неверно или не задан вообще")]
        public string FatherName { get; set; }
        [Required(ErrorMessage = "Параметр введен неверно или не задан вообще")]
        public bool Sex { get; set; }
        [Required(ErrorMessage = "Параметр введен неверно или не задан вообще")]
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        [Required(ErrorMessage = "Параметр введен неверно или не задан вообще")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Параметр введен неверно или не задан вообще")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Параметр введен неверно или не задан вообще")]
        public string Email { get; set; }
    }
    
    [Table("RankUsers")]
    public class RankUser : User
    {
        public string Information { get; set; }
        //public virtual ICollection<Complaint> Complaints { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }

    [Table("Secretaries")]
    public class Secretary : User
    {
        public string IndividualTaxNumber { get; set; }

        //public virtual ICollection<PartnershipRequest> PartnershipRequests { get; set; }
        public virtual ICollection<OrganisationDeptor> OrganisationDeptors { get; set; }
    }

    [Table("Ecologists")]
    public class Ecologist : User
    {
        public string InterestsSphere { get; set; }
        [Required(ErrorMessage = "Параметр введен неверно или не задан вообще")]
        public string Education { get; set; }
        public string DistrictLocation { get; set; }

        public virtual ICollection<Section> Sections { get; set; }
        public virtual ICollection<Complaint> Complaints { get; set; }
        public virtual ICollection<EcologicalProblem> EcologicalProblems { get; set; }
    }

    [Table("Administrators")]
    public class Administrator : User
    {
        public string PhoneNumber { get; set; }

        public virtual ICollection<Achievement> Achievements { get; set; }
    }

    public class Partner:User
    {
        [Required(ErrorMessage = "Введите адрес компании")]
        public string Address { get; set; }
        [Required(ErrorMessage="Введите название компании")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Введите описание")]
        public string Description { get; set; }
        
        public virtual ICollection<Complaint> Complaints { get; set; }
        public virtual PartnershipRequest PartnershipRequest { get; set; }
    }
}
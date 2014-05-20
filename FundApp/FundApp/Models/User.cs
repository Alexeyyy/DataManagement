using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Web;

namespace FundApp.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Параметр 'Имя' введен неверно или не задан вообще")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Параметр 'Фамилия' введен неверно или не задан вообще")]
        public string Surname { get; set; }
        
        [Required(ErrorMessage = "Параметр 'Отчество' введен неверно или не задан вообще")]
        public string FatherName { get; set; }
        
        [Required(ErrorMessage = "Параметр 'Пол' введен неверно или не задан вообще")]
        public bool Sex { get; set; }
        
        [Required(ErrorMessage = "Параметр 'Дата Рождения' введен неверно или не задан вообще")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Параметр 'Логин' введен неверно или не задан вообще")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Параметр 'Пароль' введен неверно или не задан вообще")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Параметр 'Email' введен неверно или не задан вообще")]
        public string Email { get; set; }

        public DateTime RegistrationDate { get; set; }
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
        public virtual ICollection<Partner> Partners { get; set; }
        public virtual ICollection<OrganisationDeptor> OrganisationDeptors { get; set; }
    }

    [Table("Ecologists")]
    public class Ecologist : User
    {
        [Required(ErrorMessage = "Параметр введен неверно или не задан вообще")]
        public string Education { get; set; }

        public string InterestsSphere { get; set; }
        public string DistrictLocation { get; set; }
        
        public virtual ICollection<Section> Sections { get; set; }
        public virtual ICollection<Complaint> Complaints { get; set; }
        public virtual ICollection<EcologicalProblem> EcologicalProblems { get; set; }

        public virtual ICollection<Council> Councils { get; set; }
    }

    [Table("Administrators")]
    public class Administrator : User
    {
        public string PhoneNumber { get; set; }

        public virtual ICollection<Achievement> Achievements { get; set; }
    }

    [Table("Partners")]
    public class Partner : User
    {
        [Required(ErrorMessage = "Введите адрес компании")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Введите название компании")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Введите описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Введите причину подачи заявки")]
        public string Reason { get; set; }

        [Required]
        public bool IsSolved { get; set; }

        [Required]
        public virtual Secretary Secretary { get; set; }

        public virtual ICollection<Complaint> Complaints { get; set; }
        //public virtual PartnershipRequest PartnershipRequest { get; set; }
    }
}
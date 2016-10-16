using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace HungryCells.Models
{
    public class Patient
    {
        public int PatientID { get; set; } 

        public string UR { get; set; }
        
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("DOB")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        [DisplayName("Referral Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ReferralDate { get; set; }

        [DisplayName("Referral Source")]
        public string ReferralSource { get; set; }

        public bool? DVA { get; set; }

        public string Status { get; set; }
        public IEnumerable<SelectListItem> Statuses { get; set; }

        [DisplayName("Procedure Type")]
        public string Procedure { get; set; }
        public IEnumerable<SelectListItem> Procedures { get; set; }

        [DisplayName("Procedure Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ProcedureDate { get; set; }

        [DisplayName("Valve Type")]
        public string ValveType { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ICollection<Test> Tests { get; set; }

    }
}
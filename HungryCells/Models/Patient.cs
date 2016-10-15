using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HungryCells.Models
{
    public class Patient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("UR")]
        public int PatientID { get; set; }
        
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("DOB")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [DisplayName("Referral Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ReferralDate { get; set; }

        [DisplayName("Referral Source")]
        public string ReferralSource { get; set; }

        [DisplayName("Wait Listed")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? WaitListed { get; set; }

        public bool? DVA { get; set; }
        public string Status { get; set; }
        public string Procedure { get; set; }

        [DisplayName("Valve Type")]
        public string ValveType { get; set; }

        public virtual ICollection<Test> Tests { get; set; }

    }
}
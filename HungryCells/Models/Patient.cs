using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HungryCells.Models
{
    public class Patient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime ReferralDate { get; set; }
        public string ReferralSource { get; set; }
        public DateTime? WaitListed { get; set; }
        public bool? DVA { get; set; }
        public string Status { get; set; }
        public string Procedure { get; set; }

        public virtual ICollection<Test> Tests { get; set; }

    }
}
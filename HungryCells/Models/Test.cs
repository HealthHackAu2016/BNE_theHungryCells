using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HungryCells.Models
{
    public class Test
    {
        public int TestID { get; set; }

        [DisplayName("Test")]
        public string TestName { get; set; }

        [ForeignKey("Patient")]
        public int PatientID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime TestDate { get; set; }
        
    }
}
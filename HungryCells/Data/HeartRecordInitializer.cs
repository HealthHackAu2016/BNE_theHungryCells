using System;
using System.Collections.Generic;
using HungryCells.Models;

namespace HungryCells.Data
{
    public class HeartRecordInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<HeartRecordContext>
    {
        protected override void Seed(HeartRecordContext context)
        {
            var patients = new List<Patient>
            {
                new Patient{PatientID = 1, UR = "123456", FirstName="Carson",LastName="Alexander",BirthDate=DateTime.Parse("1955-12-01"),ReferralDate=DateTime.Parse("2016-10-13"), DVA=true,ReferralSource="Dr Davids",Status="Referred"},
                new Patient{PatientID = 2, UR = "123457", FirstName="Meredith",LastName="Alonso",BirthDate=DateTime.Parse("1982-09-19"),ReferralDate=DateTime.Parse("2016-03-12"), DVA=true,ReferralSource="Dr Harbison",Status="Referred"},
                new Patient{PatientID = 3, UR = "123458", FirstName="Arturo",LastName="Anand",BirthDate=DateTime.Parse("1947-10-15"),ReferralDate=DateTime.Parse("2016-08-16"), DVA=false,ReferralSource="Dr Koutsoukis",Status="In Testing"},
                new Patient{PatientID = 4, UR = "123459", FirstName="Gytis",LastName="Barzdukas",BirthDate=DateTime.Parse("1945-02-22"),ReferralDate=DateTime.Parse("2016-02-02"), DVA=false,ReferralSource="Dr Goldstein",Status="In Testing"},
                new Patient{PatientID = 5, UR = "123450", FirstName="Yan",LastName="Li",BirthDate=DateTime.Parse("1929-04-04"),ReferralDate=DateTime.Parse("2016-10-13"), DVA=false,ReferralSource="Dr Helfer",Status="In Testing"},
                new Patient{PatientID = 6, UR = "123451", FirstName="Peggy",LastName="Justice",BirthDate=DateTime.Parse("1963-05-10"),ReferralDate=DateTime.Parse("2016-07-04"), DVA=true,ReferralSource="Dr Harbison",Status="Having Procedure",Procedure="Femoral",ProcedureDate=DateTime.Parse("2016-07-04")},
                new Patient{PatientID = 7, UR = "123452", FirstName="Laura",LastName="Norman",BirthDate=DateTime.Parse("1942-07-19"),ReferralDate=DateTime.Parse("2016-06-10"), DVA=false,ReferralSource="Dr Stowasser",Status="Not fit for Procedure"},
                new Patient{PatientID = 8, UR = "123453", FirstName="Nino",LastName="Olivetto",BirthDate=DateTime.Parse("1956-03-30"),ReferralDate=DateTime.Parse("2016-02-20"), DVA=false,ReferralSource="Dr Cooper",Status="Had Procedure",Procedure="Apical",ValveType="LOTUS",ProcedureDate=DateTime.Parse("2016-07-04")}
            };

            patients.ForEach(s => context.Patients.Add(s));
            context.SaveChanges();

            var tests = new List<Test>
            {
                new Test{TestName="PBAV", PatientID=3, TestDate=DateTime.Parse("2016-10-14")},
                new Test{TestName="Echo", PatientID=3, TestDate=DateTime.Parse("2016-10-15")},
                new Test{TestName="PBAV", PatientID=4, TestDate=DateTime.Parse("2016-02-13")},
                new Test{TestName="RFTs", PatientID=4, TestDate=DateTime.Parse("2016-03-02")},
                new Test{TestName="Angio", PatientID=4, TestDate=DateTime.Parse("2016-03-25")},
                new Test{TestName="3 Mensio", PatientID=4, TestDate=DateTime.Parse("2016-03-30")},
                new Test{TestName="Carotid", PatientID=5, TestDate=DateTime.Parse("2016-04-13")},
                new Test{TestName="PBAV", PatientID=5, TestDate=DateTime.Parse("2016-10-14")},
                new Test{TestName="Angio", PatientID=5, TestDate=DateTime.Parse("2016-07-19")},
                new Test{TestName="Dental Clearance", PatientID=5, TestDate=DateTime.Parse("2016-08-29")}
            };
            tests.ForEach(s => context.Tests.Add(s));
            context.SaveChanges();
        }
    }
}
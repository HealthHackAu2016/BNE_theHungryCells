using HungryCells.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HungryCells.Data
{
    public class HeartRecordContext : DbContext
    {
        public HeartRecordContext() : base("HeartRecordContext")
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Test> Tests { get; set; }

    }
}
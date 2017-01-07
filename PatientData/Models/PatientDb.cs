using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PatientData.Models
{
    public class PatientDb : DbContext
    {
        public PatientDb() : base("DefaultConnection")
        {
            
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Ailment> Ailments { get; set; }
    }

}
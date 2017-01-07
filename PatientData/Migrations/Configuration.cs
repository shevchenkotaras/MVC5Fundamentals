using System.Collections.Generic;
using PatientData.Models;

namespace PatientData.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PatientData.Models.PatientDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(PatientData.Models.PatientDb context)
        {
            //if (!context.Patients.AsQueryable().Any(p => p.Name == "Mike"))
            //{
            context.Patients.AddOrUpdate(p => p.Name,
                                new Patient
                                {
                                    Name = "Taras",
                                    Ailments = new List<Ailment>() { new Ailment { Name = "crazy" } },
                                    Medications = new List<Medication>() { new Medication { Name = "heal", Doses = 2 } }
                                },
                                new Patient
                                {
                                    Name = "Mike",
                                    Ailments = new List<Ailment>() { new Ailment { Name = "crazy2" } },
                                    Medications = new List<Medication>() { new Medication { Name = "heal2", Doses = 2 } }
                                },
                                new Patient
                                {
                                    Name = "Paul",
                                    Ailments = new List<Ailment>() { new Ailment { Name = "crazy2" } },
                                    Medications = new List<Medication>() { new Medication { Name = "heal2", Doses = 2 } }
                                });
            //}

        }
    }
}

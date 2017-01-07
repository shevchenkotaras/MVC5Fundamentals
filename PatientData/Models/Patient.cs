using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace PatientData.Models
{
    public class  Patient
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Ailment> Ailments { get; set; }
        public virtual ICollection<Medication> Medications { get; set; }
    }

    public class Medication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Doses { get; set; }
        public int PatientId { get; set; }
    }

    public class Ailment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
    }
}
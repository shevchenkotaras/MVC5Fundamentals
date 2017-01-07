using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PatientData.Models;

namespace PatientData.Controllers
{
    public class PatientsController : ApiController
    {
        private PatientDb _db;

        public PatientsController()
        {
            _db = new PatientDb();
            _db.Configuration.ProxyCreationEnabled = false;
        }
        public IEnumerable<Patient> Get()
        {
            return  _db.Patients;
        }

        public HttpResponseMessage Get(int id)
        {
            try
            {
                Patient patien = _db.Patients.First(x => x.Id == id);
                return Request.CreateResponse(patien);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient not found");
            }
        }

        [Route("api/patiensts/{id}/medications")]
        public HttpResponseMessage GetMedications(int id)
        {
            try
            {
                var medications = _db.Medications.Where(x => x.PatientId == id);
                if (!medications.Any())
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "medications not found");
                }
                return Request.CreateResponse(medications);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "medications not found");
            }
        }
    }
}

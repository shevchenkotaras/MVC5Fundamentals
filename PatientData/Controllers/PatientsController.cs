using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using PatientData.Models;

namespace PatientData.Controllers
{
    [EnableCors("*", "*", "GET")]
    [Authorize]
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
            return _db.Patients;
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                Patient patien = _db.Patients.First(x => x.Id == id);
                return Ok(patien);
                //return Request.CreateResponse(patien);
            }
            catch (Exception e)
            {
                return NotFound();
                //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient not found");
            }
        }

        [Route("api/patiensts/{id}/medications")]
        public IHttpActionResult GetMedications(int id)
        {
            try
            {
                var medications = _db.Medications.Where(x => x.PatientId == id);
                if (!medications.Any())
                {
                    return NotFound();
                }
                return Ok(medications);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
    }
}

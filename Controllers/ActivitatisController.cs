using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Examen.Models;

namespace Examen.Controllers
{
    public class ActivitatisController : ApiController
    {
        private Database2Entities db = new Database2Entities();

        // GET: api/Activitatis
/*        public IQueryable<Activitati> GetActivitati()
        {
            return db.Activitati;
        }*/
        [HttpGet]
        public List<Activitati> getActivitati()
        {
            var rez = db.Activitati.ToList();
            return rez;
        }
        // GET: api/Activitatis/5
        [ResponseType(typeof(Activitati))]
        public IHttpActionResult GetActivitati(int id)
        {
            Activitati activitati = db.Activitati.Find(id);
            if (activitati == null)
            {
                return NotFound();
            }

            return Ok(activitati);
        }

        // PUT: api/Activitatis/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutActivitati(int id, Activitati activitati)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activitati.idActivitate)
            {
                return BadRequest();
            }

            db.Entry(activitati).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivitatiExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Activitatis
        [ResponseType(typeof(Activitati))]
        public IHttpActionResult PostActivitati(Activitati activitati)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Activitati.Add(activitati);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = activitati.idActivitate }, activitati);
        }


        // DELETE: api/Activitatis/5
        [ResponseType(typeof(Activitati))]
        public IHttpActionResult DeleteActivitati(int id)
        {
            Activitati activitati = db.Activitati.Find(id);
            if (activitati == null)
            {
                return NotFound();
            }

            db.Activitati.Remove(activitati);
            db.SaveChanges();

            return Ok(activitati);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActivitatiExists(int id)
        {
            return db.Activitati.Count(e => e.idActivitate == id) > 0;
        }
    }
}
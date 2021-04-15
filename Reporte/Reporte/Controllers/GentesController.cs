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
using Reporte.Models;

namespace Reporte.Controllers
{
    public class GentesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Gentes
        [Authorize]
        public IQueryable<Gente> GetGentes()
        {
            return db.Gentes;
        }

        // GET: api/Gentes/5
        [Authorize]
        [ResponseType(typeof(Gente))]
        public IHttpActionResult GetGente(int id)
        {
            Gente gente = db.Gentes.Find(id);
            if (gente == null)
            {
                return NotFound();
            }

            return Ok(gente);
        }

        // PUT: api/Gentes/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGente(int id, Gente gente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gente.PerosnId)
            {
                return BadRequest();
            }

            db.Entry(gente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenteExists(id))
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

        // POST: api/Gentes
        [Authorize]
        [ResponseType(typeof(Gente))]
        public IHttpActionResult PostGente(Gente gente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Gentes.Add(gente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gente.PerosnId }, gente);
        }

        // DELETE: api/Gentes/5
        [Authorize]
        [ResponseType(typeof(Gente))]
        public IHttpActionResult DeleteGente(int id)
        {
            Gente gente = db.Gentes.Find(id);
            if (gente == null)
            {
                return NotFound();
            }

            db.Gentes.Remove(gente);
            db.SaveChanges();

            return Ok(gente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GenteExists(int id)
        {
            return db.Gentes.Count(e => e.PerosnId == id) > 0;
        }
    }
}
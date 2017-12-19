using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Models;

namespace WebApiQUizz.Controllers
{
    public class ChapitresController : ApiController
    {
        private QuizzContext db = new QuizzContext();

        // GET: api/Chapitres
        public IQueryable<Chapitre> GetChapitres()
        {
            return db.Chapitres;
        }

        // GET: api/Chapitres/5
        [ResponseType(typeof(Chapitre))]
        public async Task<IHttpActionResult> GetChapitre(int id)
        {
            Chapitre chapitre = await db.Chapitres.FindAsync(id);
            if (chapitre == null)
            {
                return NotFound();
            }

            return Ok(chapitre);
        }

        // PUT: api/Chapitres/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutChapitre(int id, Chapitre chapitre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chapitre.ChapitreID)
            {
                return BadRequest();
            }

            db.Entry(chapitre).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChapitreExists(id))
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

        // POST: api/Chapitres
        [ResponseType(typeof(Chapitre))]
        public async Task<IHttpActionResult> PostChapitre(Chapitre chapitre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Chapitres.Add(chapitre);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = chapitre.ChapitreID }, chapitre);
        }

        // DELETE: api/Chapitres/5
        [ResponseType(typeof(Chapitre))]
        public async Task<IHttpActionResult> DeleteChapitre(int id)
        {
            Chapitre chapitre = await db.Chapitres.FindAsync(id);
            if (chapitre == null)
            {
                return NotFound();
            }

            db.Chapitres.Remove(chapitre);
            await db.SaveChangesAsync();

            return Ok(chapitre);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChapitreExists(int id)
        {
            return db.Chapitres.Count(e => e.ChapitreID == id) > 0;
        }
    }
}
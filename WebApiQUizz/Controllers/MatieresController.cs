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
    public class MatieresController : ApiController
    {
        private QuizzContext db = new QuizzContext();

        // GET: api/Matieres
        public IQueryable<Matiere> GetMatieres()
        {
            return db.Matieres;
        }

        // GET: api/Matieres/5
        [ResponseType(typeof(Matiere))]
        public async Task<IHttpActionResult> GetMatiere(int id)
        {
            Matiere matiere = await db.Matieres.FindAsync(id);
            if (matiere == null)
            {
                return NotFound();
            }

            return Ok(matiere);
        }

        // PUT: api/Matieres/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMatiere(int id, Matiere matiere)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != matiere.MatiereID)
            {
                return BadRequest();
            }

            db.Entry(matiere).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatiereExists(id))
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

        // POST: api/Matieres
        [ResponseType(typeof(Matiere))]
        public async Task<IHttpActionResult> PostMatiere(Matiere matiere)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Matieres.Add(matiere);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = matiere.MatiereID }, matiere);
        }

        // DELETE: api/Matieres/5
        [ResponseType(typeof(Matiere))]
        public async Task<IHttpActionResult> DeleteMatiere(int id)
        {
            Matiere matiere = await db.Matieres.FindAsync(id);
            if (matiere == null)
            {
                return NotFound();
            }

            db.Matieres.Remove(matiere);
            await db.SaveChangesAsync();

            return Ok(matiere);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MatiereExists(int id)
        {
            return db.Matieres.Count(e => e.MatiereID == id) > 0;
        }
    }
}
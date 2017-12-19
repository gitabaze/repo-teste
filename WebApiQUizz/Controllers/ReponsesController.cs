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
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using Models;

namespace WebApiQUizz.Controllers
{
    /*
    La classe WebApiConfig peut exiger d'autres modifications pour ajouter un itinéraire à ce contrôleur. Fusionnez ces instructions dans la méthode Register de la classe WebApiConfig, le cas échéant. Les URL OData sont sensibles à la casse.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Reponses>("Reponses");
    builder.EntitySet<Jeux>("Jeuxs"); 
    builder.EntitySet<Questionnaire>("Questionnaires"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ReponsesController : ODataController
    {
        private QuizzContext db = new QuizzContext();

        // GET: odata/Reponses
        [EnableQuery]
        public IQueryable<Reponses> GetReponses()
        {
            return db.Reponses;
        }

        // GET: odata/Reponses(5)
        [EnableQuery]
        public SingleResult<Reponses> GetReponses([FromODataUri] int key)
        {
            return SingleResult.Create(db.Reponses.Where(reponses => reponses.ReponseID == key));
        }

        // PUT: odata/Reponses(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Reponses> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Reponses reponses = await db.Reponses.FindAsync(key);
            if (reponses == null)
            {
                return NotFound();
            }

            patch.Put(reponses);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReponsesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(reponses);
        }

        // POST: odata/Reponses
        public async Task<IHttpActionResult> Post(Reponses reponses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reponses.Add(reponses);
            await db.SaveChangesAsync();

            return Created(reponses);
        }

        // PATCH: odata/Reponses(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Reponses> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Reponses reponses = await db.Reponses.FindAsync(key);
            if (reponses == null)
            {
                return NotFound();
            }

            patch.Patch(reponses);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReponsesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(reponses);
        }

        // DELETE: odata/Reponses(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Reponses reponses = await db.Reponses.FindAsync(key);
            if (reponses == null)
            {
                return NotFound();
            }

            db.Reponses.Remove(reponses);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Reponses(5)/Jeux
        [EnableQuery]
        public IQueryable<Jeux> GetJeux([FromODataUri] int key)
        {
            return db.Reponses.Where(m => m.ReponseID == key).SelectMany(m => m.Jeux);
        }

        // GET: odata/Reponses(5)/Questionnaire
        [EnableQuery]
        public SingleResult<Questionnaire> GetQuestionnaire([FromODataUri] int key)
        {
            return SingleResult.Create(db.Reponses.Where(m => m.ReponseID == key).Select(m => m.Questionnaire));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReponsesExists(int key)
        {
            return db.Reponses.Count(e => e.ReponseID == key) > 0;
        }
    }
}

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
    builder.EntitySet<Questionnaire>("Questionnaires");
    builder.EntitySet<Jeux>("Jeuxs"); 
    builder.EntitySet<Matiere>("Matieres"); 
    builder.EntitySet<Module>("Modules"); 
    builder.EntitySet<Reponses>("Reponses"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class QuestionnairesController : ODataController
    {
        private QuizzContext db = new QuizzContext();

        // GET: odata/Questionnaires
        [EnableQuery]
        public IQueryable<Questionnaire> GetQuestionnaires()
        {
            return db.Questionnaires;
        }

        // GET: odata/Questionnaires(5)
        [EnableQuery]
        public SingleResult<Questionnaire> GetQuestionnaire([FromODataUri] int key)
        {
            IQueryable<Questionnaire> result = db.Questionnaires.Where(qz => qz.QuestionnaireID == key);
            return SingleResult.Create(result);
          //  return SingleResult.Create(db.Questionnaires.Where(questionnaire => questionnaire.QuestionnaireID == key));
        }

        // PUT: odata/Questionnaires(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Questionnaire> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Questionnaire questionnaire = await db.Questionnaires.FindAsync(key);
            if (questionnaire == null)
            {
                return NotFound();
            }

            patch.Put(questionnaire);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionnaireExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(questionnaire);
        }

        // POST: odata/Questionnaires
        public async Task<IHttpActionResult> Post(Questionnaire questionnaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Questionnaires.Add(questionnaire);
            await db.SaveChangesAsync();

            return Created(questionnaire);
        }

        // PATCH: odata/Questionnaires(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Questionnaire> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Questionnaire questionnaire = await db.Questionnaires.FindAsync(key);
            if (questionnaire == null)
            {
                return NotFound();
            }

            patch.Patch(questionnaire);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionnaireExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(questionnaire);
        }

        // DELETE: odata/Questionnaires(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Questionnaire questionnaire = await db.Questionnaires.FindAsync(key);
            if (questionnaire == null)
            {
                return NotFound();
            }

            db.Questionnaires.Remove(questionnaire);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Questionnaires(5)/Jeux
        [EnableQuery]
        public IQueryable<Jeux> GetJeux([FromODataUri] int key)
        {
            return db.Questionnaires.Where(m => m.QuestionnaireID == key).SelectMany(m => m.Jeux);
        }

        // GET: odata/Questionnaires(5)/Matiere
        [EnableQuery]
        public SingleResult<Matiere> GetMatiere([FromODataUri] int key)
        {
            return SingleResult.Create(db.Questionnaires.Where(m => m.QuestionnaireID == key).Select(m => m.Matiere));
        }

        // GET: odata/Questionnaires(5)/Module
        [EnableQuery]
        public SingleResult<Module> GetModule([FromODataUri] int key)
        {
            return SingleResult.Create(db.Questionnaires.Where(m => m.QuestionnaireID == key).Select(m => m.Module));
        }

        // GET: odata/Questionnaires(5)/Reponses
        [EnableQuery]
        public IQueryable<Reponses> GetReponses([FromODataUri] int key)
        {
            return db.Questionnaires.Where(m => m.QuestionnaireID == key).SelectMany(m => m.Reponses);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionnaireExists(int key)
        {
            return db.Questionnaires.Count(e => e.QuestionnaireID == key) > 0;
        }
    }
}

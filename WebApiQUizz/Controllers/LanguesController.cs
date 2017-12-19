
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Models;
using WebApiQUizz.Service;
using System.Data.Entity.Infrastructure;
using System.Net;
using System;

namespace WebApiQUizz.Controllers
{
    public class LanguesController : ApiController
    {
        private readonly IGenericRepository<Langue> _langueRepository;
        public LanguesController(IGenericRepository<Langue> langueRepository)
        {
            _langueRepository = langueRepository;
         
        }
        // GET: api/Langues
        [Route("api/langues/GetLangues")]
        public IQueryable<Langue> GetLangue()
        {
           return _langueRepository.GetAll();
           
        }

        // GET: api/Langues/5
        [ResponseType(typeof(Langue))]
        public async Task<IHttpActionResult> GetLangue(int id)
        {
            Langue langue = await _langueRepository.GetByKey(id);

            if (langue == null)
            {
                return NotFound();
            }
            return Ok(langue);
           
        }

       // PUT: api/Langues/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLangue(int id, Langue langue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != langue.Id)
            {
                return BadRequest();
            }

           // db.Entry(langue).State = EntityState.Modified;

            try
            {
                // await db.SaveChangesAsync();
                _langueRepository.Add(langue);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LangueExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch(Exception ex)
            {
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Langues
        [ResponseType(typeof(Langue))]
        public IHttpActionResult PostLangue(Langue langue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _langueRepository.Create(langue);

            return CreatedAtRoute("DefaultApi", new { id = langue.Id }, langue);
        }
        //public async Task<IHttpActionResult> PostLangue(Langue langue)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Langues.Add(langue);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = langue.LangueID }, langue);
        //}

        // DELETE: api/Langues/5
        [ResponseType(typeof(Langue))]
        public async Task<IHttpActionResult> DeleteLangue(int id)
        {
            try
            {
                var langue = await _langueRepository.GetByKey(id);

                // var langue = languEreulte.Result;

                if (langue == null)
                {
                    return NotFound();
                }
               await  _langueRepository.RemoveAsync(langue);

                return Ok(langue);
            }catch(Exception ex)
            {
                throw;
            }
        }
        //public async Task<IHttpActionResult> DeleteLangue(int id)
        //{
        //    Langue langue = await db.Langues.FindAsync(id);
        //    if (langue == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Langues.Remove(langue);
        //    await db.SaveChangesAsync();

        //    return Ok(langue);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool LangueExists(int id)
        {
            return _langueRepository.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}
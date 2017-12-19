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
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNet.Identity;

namespace WebApiQUizz.Controllers
{
   // [RoutePrefix("api/profile")]
    public class ProfilesController : ApiController
    {
        private QuizzContext db = new QuizzContext();

        //[Route("profile")]
        //[EnableCors(origins: "*", headers: "*", methods: "OPTIONS")]
        public HttpResponseMessage Options()
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Headers.Add("Access-Control-Allow-Origin", "*");
            resp.Headers.Add("Access-Control-Allow-Methods", "*");
            return resp;
        }

        // GET: api/Profiles
        //public IQueryable<Profile> GetProfiles()
        //{
        //    return db.Profiles;
        //}
        // [AllowAnonymous]
        //[HostAuthentication(DefaultAuthenticationTypes.ApplicationCookie)]
        public HttpResponseMessage Get()
        {
            return ToJson(db.Profiles.AsEnumerable());
        }
       // [AllowAnonymous]
        //public HttpResponseMessage Get(int id)
        //{
        //    return ToJson(db.Profiles.Find(id));
        //}


        // GET: api/Profiles/5
        [ResponseType(typeof(Profile))]
        public async Task<IHttpActionResult> GetProfile(int id)
        {
            Profile profile = await db.Profiles.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        // PUT: api/Profiles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Put(int id, Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profile.ProfileID)
            {
                return BadRequest();
            }

            db.Entry(profile).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
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

        // POST: api/Profiles
        [ResponseType(typeof(Profile))]
        public async Task<IHttpActionResult> Post(Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Profiles.Add(profile);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = profile.ProfileID }, profile);
        }

        // DELETE: api/Profiles/5
        [ResponseType(typeof(Profile))]
        public async Task<IHttpActionResult> Delete(int id)
        {
            Profile profile = await db.Profiles.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }

            db.Profiles.Remove(profile);
            await db.SaveChangesAsync();

            return Ok(profile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProfileExists(int id)
        {
            return db.Profiles.Count(e => e.ProfileID == id) > 0;
        }

        protected HttpResponseMessage ToJson(dynamic obj)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("Access-Control-Allow-Methods", "*");
            return response;
        }
    }
}
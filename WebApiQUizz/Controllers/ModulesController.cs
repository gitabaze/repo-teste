﻿using System;
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
    public class ModulesController : ApiController
    {
        private QuizzContext db = new QuizzContext();

        // GET: api/Modules
        public IQueryable<Module> GetModules()
        {
            return db.Modules;
        }

        // GET: api/Modules/5
        [ResponseType(typeof(Module))]
        public async Task<IHttpActionResult> GetModule(int id)
        {
            Module module = await db.Modules.FindAsync(id);
            if (module == null)
            {
                return NotFound();
            }

            return Ok(module);
        }

        // PUT: api/Modules/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutModule(int id, Module module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != module.ModuleID)
            {
                return BadRequest();
            }

            db.Entry(module).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleExists(id))
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

        // POST: api/Modules
        [ResponseType(typeof(Module))]
        public async Task<IHttpActionResult> PostModule(Module module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Modules.Add(module);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = module.ModuleID }, module);
        }

        // DELETE: api/Modules/5
        [ResponseType(typeof(Module))]
        public async Task<IHttpActionResult> DeleteModule(int id)
        {
            Module module = await db.Modules.FindAsync(id);
            if (module == null)
            {
                return NotFound();
            }

            db.Modules.Remove(module);
            await db.SaveChangesAsync();

            return Ok(module);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModuleExists(int id)
        {
            return db.Modules.Count(e => e.ModuleID == id) > 0;
        }
    }
}
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
using WebApiCRUD.Models;

namespace WebApiCRUD.Controllers
{
    public class InfoController : ApiController
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: api/Info
        public IQueryable<Info> GetInfos()
        {
            return db.Infos;
        }

        // GET: api/Info/5
        [ResponseType(typeof(Info))]
        public IHttpActionResult GetInfo(int id)
        {
            Info info = db.Infos.Find(id);
            if (info == null)
            {
                return NotFound();
            }

            return Ok(info);
        }

        // PUT: api/Info/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInfo(int id, Info info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != info.Id)
            {
                return BadRequest();
            }

            db.Entry(info).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoExists(id))
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

        // POST: api/Info
        [ResponseType(typeof(Info))]
        public IHttpActionResult PostInfo(Info info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Infos.Add(info);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = info.Id }, info);
        }

        // DELETE: api/Info/5
        [ResponseType(typeof(Info))]
        public IHttpActionResult DeleteInfo(int id)
        {
            Info info = db.Infos.Find(id);
            if (info == null)
            {
                return NotFound();
            }

            db.Infos.Remove(info);
            db.SaveChanges();

            return Ok(info);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InfoExists(int id)
        {
            return db.Infos.Count(e => e.Id == id) > 0;
        }
    }
}
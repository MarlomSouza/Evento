﻿using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Zaggie_Festa_.Contexto;
using Zaggie_Festa_.Models;

namespace Zaggie_Festa_.Controllers
{
    public class ItemController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Itens
        public IQueryable<Item> GetItens()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Itens;
        }

        // GET: api/Itens
        public IQueryable<Item> GetItens(int eventoId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Itens.Where(i => i.EventoId.Equals(eventoId));
        }


        // GET: api/Itens/5
        [ResponseType(typeof(Item))]
        public IHttpActionResult GetItem(int id)
        {
            Item item = db.Itens.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // PUT: api/Itens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutItem(int id, Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.Id)
            {
                return BadRequest();
            }

            db.Entry(item).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        // POST: api/Itens
        [ResponseType(typeof(Item))]
        public IHttpActionResult PostItem(Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Itens.Add(item);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = item.Id }, item);
        }

        // DELETE: api/Itens/5
        [ResponseType(typeof(Item))]
        public IHttpActionResult DeleteItem(int id)
        {
            Item item = db.Itens.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            db.Itens.Remove(item);
            db.SaveChanges();

            return Ok(item);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemExists(int id)
        {
            return db.Itens.Count(e => e.Id == id) > 0;
        }
    }
}
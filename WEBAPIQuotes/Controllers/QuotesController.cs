﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WEBAPIQuotes.Models;

namespace WEBAPIQuotes.Controllers
{
    public class QuotesController : ApiController
    {
        private quotesEntities db = new quotesEntities();

        // GET: api/Quotes
        public IQueryable<Quote> GetQuotes()
        {
            
            return db.Quotes;
        }

        // GET: api/Quotes/5
        [ResponseType(typeof(Quote))]
        public IHttpActionResult GetQuote(long id)
        {
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return NotFound();
            }

            return Ok(quote);
        }

        // PUT: api/Quotes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuote(long id, Quote quote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quote.ID)
            {
                return BadRequest();
            }

            db.Entry(quote).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuoteExists(id))
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

        // POST: api/Quotes
        [ResponseType(typeof(Quote))]
        public IQueryable<Quote> PostQuote(Quote quote)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            db.Quotes.Add(quote);
            db.SaveChanges();

            return GetQuotes();
        }

        /* public IHttpActionResult PostQuote(Quote quote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Quotes.Add(quote);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = quote.ID }, quote);
        }*/

        // DELETE: api/Quotes/5
        [ResponseType(typeof(Quote))]
        public IQueryable<Quote> DeleteQuote(long id)
        {
             
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return null;
            }

            db.Quotes.Remove(quote);
            db.SaveChanges();

            return GetQuotes();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuoteExists(long id)
        {
            return db.Quotes.Count(e => e.ID == id) > 0;
        }
    }
}
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
using AT_AspNet.Data.Context;
using AT_AspNet.Domain;

namespace AT_AspNet.Service.Controllers
{
    [RoutePrefix("api/Livros")]
    public class LivrosController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Livros
        public IList<Livro> GetLivros()
        {
            var retorno = db.Livros.ToList();
            List<Livro> livros = new List<Livro>();
            foreach (var item in retorno)
            {
                var livro = new Livro()
                {
                    LivroId = item.LivroId,
                    Titulo = item.Titulo,
                    Isbn = item.Isbn,
                    Ano = item.Ano,
                    Autores = new List<Autor>()
                };
                foreach (var item2 in item.Autores)
                {
                    item2.Livros = new List<Livro>();
                    livro.Autores.Add(item2);
                }
                livros.Add(livro);
            }

            return livros;
            
        }

        // GET: api/Livros/5
        [ResponseType(typeof(Livro))]
        public IHttpActionResult GetLivro(int id)
        {
            Livro busca = db.Livros.Find(id);
            if (busca == null)
            {
                return NotFound();
            }
            Livro livro = new Livro()
            {
                LivroId = busca.LivroId,
                Titulo = busca.Titulo,
                Isbn = busca.Isbn,
                Ano = busca.Ano,
                Autores = new List<Autor>()
            };
            return Ok(livro);
        }

        // PUT: api/Livros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLivro(int id, Livro livro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != livro.LivroId)
            {
                return BadRequest();
            }

            db.Entry(livro).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroExists(id))
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

        // POST: api/Livros
        [ResponseType(typeof(Livro))]
        public IHttpActionResult PostLivro(Livro livro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Livros.Add(livro);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = livro.LivroId }, livro);
        }

        // DELETE: api/Livros/5
        [ResponseType(typeof(Livro))]
        public IHttpActionResult DeleteLivro(int id)
        {
            Livro livro = db.Livros.Find(id);
            if (livro == null)
            {
                return NotFound();
            }

            db.Livros.Remove(livro);
            db.SaveChanges();

            return Ok(livro);
        }
        [HttpGet]
        [Route("FazRelacionamento")]
        public void FazRelacionamento(int autorId, int livroId)
        {
            var autor = db.Autores.Where(a => a.AutorId == autorId).FirstOrDefault();
            var livro = db.Livros.Where(b => b.LivroId == livroId).FirstOrDefault();

            autor.Livros.Add(livro);
            livro.Autores.Add(autor);
            db.SaveChanges();

        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LivroExists(int id)
        {
            return db.Livros.Count(e => e.LivroId == id) > 0;
        }
    }
}
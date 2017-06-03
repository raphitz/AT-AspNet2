using AT_AspNet.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AT_AspNet.Presentation.Controllers
{
    [Authorize]
    public class LivrosController : Controller
    {
        // GET: Livros
        public ActionResult Index()
        {
            using (var apiClient = new System.Net.Http.HttpClient())
            {
                var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                apiClient.BaseAddress = new Uri("https://localhost:44380/");
                apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = apiClient.GetAsync("/api/Livros").Result;

                if (response.IsSuccessStatusCode)
                {
                    var JsonString = response.Content.ReadAsStringAsync().Result;
                    var livros = JsonConvert.DeserializeObject<List<Livro>>(JsonString);

                    return View(livros);

                }
                return View();
            }
        }

        // GET: Livros/Details/5
        public ActionResult Details(int id)
        {
            using (var apiClient = new System.Net.Http.HttpClient())
            {
                var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                apiClient.BaseAddress = new Uri("https://localhost:44380/");
                apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = apiClient.GetAsync("/api/Livros/"+id).Result;

                if (response.IsSuccessStatusCode)
                {
                    var JsonString = response.Content.ReadAsStringAsync().Result;
                    var livro = JsonConvert.DeserializeObject<Livro>(JsonString);

                    return View(livro);

                }
                return View();
            }
        }

        // GET: Livros/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Livros/Create
        [HttpPost]
        public async Task<ActionResult> Create(Livro livro)
        {
            int id = 0;
            try
            {
                using (var apiClient = new HttpClient())
                {
                    var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                    apiClient.BaseAddress = new Uri("https://localhost:44380/");
                    apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                    var resposta = await apiClient.PostAsJsonAsync("/api/Livros", livro);
                    var response = apiClient.GetAsync("/api/Livros").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var JsonString = response.Content.ReadAsStringAsync().Result;
                        var livros = JsonConvert.DeserializeObject<List<Livro>>(JsonString);

                        foreach (var item in livros)
                        {
                            if (item.Titulo == livro.Titulo)
                            {
                                id = item.LivroId;
                            }
                        }

                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        

        // GET: Livros/Edit/5
        public ActionResult Edit(int id)
        {
            using (var apiClient = new System.Net.Http.HttpClient())
            {
                var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                apiClient.BaseAddress = new Uri("https://localhost:44380/");
                apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = apiClient.GetAsync("/api/Livros/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    var JsonString = response.Content.ReadAsStringAsync().Result;
                    var livro = JsonConvert.DeserializeObject<Livro>(JsonString);

                    return View(livro);

                }
                return View();
            }
        }

        // POST: Livros/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Livro  livro)
        {
            try
            {
                using (var apiClient = new HttpClient())
                {
                    var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                    apiClient.BaseAddress = new Uri("https://localhost:44380/");
                    apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                    var resposta = await apiClient.PutAsJsonAsync("/api/Livros/" + id, livro);

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Livros/Delete/5
        public ActionResult Delete(int id)
        {
            using (var apiClient = new System.Net.Http.HttpClient())
            {
                var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                apiClient.BaseAddress = new Uri("https://localhost:44380/");
                apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = apiClient.GetAsync("/api/Livros/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    var JsonString = response.Content.ReadAsStringAsync().Result;
                    var livro = JsonConvert.DeserializeObject<Livro>(JsonString);

                    return View(livro);

                }
                return View();
            }
        }

        // POST: Livros/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                using (var apiClient = new HttpClient())
                {
                    var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                    apiClient.BaseAddress = new Uri("https://localhost:44380/");
                    apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                    var resposta = await apiClient.DeleteAsync("/api/Livros/" + id);

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //public ActionResult AdicionarAutores(int id)
        //{
        //    TempData["livroid"] = id;
        //    TempData.Keep();
        //    using (var apiClient = new System.Net.Http.HttpClient())
        //    {
        //        var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
        //        apiClient.BaseAddress = new Uri("https://localhost:44380/");
        //        apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
        //        var response = apiClient.GetAsync("/api/Autores").Result;

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var JsonString = response.Content.ReadAsStringAsync().Result;
        //            var autores = JsonConvert.DeserializeObject<List<Autor>>(JsonString);

        //            TempData.Keep();

        //            return View(autores);

        //        }
        //        return View();
        //    }
        //}

        //public async Task<ActionResult> FazRelacionamento(int id)
        //{
        //    var livroid = (int)TempData["livroid"];

        //    try
        //    {
        //        using (var apiClient = new HttpClient())
        //        {
        //            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
        //            apiClient.BaseAddress = new Uri("https://localhost:44380/");
        //            apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
        //            var uri = "/api/Livros/FazRelacionamento?autorId=" + id + "&livroId=" + livroid;

        //            var resposta = await apiClient.GetAsync(uri);

        //            return RedirectToAction("Index");
        //        }


        //    }
        //    catch
        //    {
        //        return View();
        //    }

        //}
    }
}

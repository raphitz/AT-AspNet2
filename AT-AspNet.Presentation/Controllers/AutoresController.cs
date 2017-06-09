
using AT_AspNet.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    [RequireHttps]
    public class AutoresController : Controller
    {
        // GET: Autores
        
        public ActionResult Index()
        {
            using (var apiClient = new System.Net.Http.HttpClient())
            {
                var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                apiClient.BaseAddress = new Uri("https://localhost:44380/");
                apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = apiClient.GetAsync("/api/Autores").Result;

                if (response.IsSuccessStatusCode)
                {
                    var JsonString = response.Content.ReadAsStringAsync().Result;
                    var autores = JsonConvert.DeserializeObject<List<Autor>>(JsonString);

                    return View(autores);

                }
                return View();
            }
        }

        // GET: Autores/Details/5
        public ActionResult Details(int id)
        {
            using (var apiClient = new HttpClient())
            {
                var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                apiClient.BaseAddress = new Uri("https://localhost:44380/");
                apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = apiClient.GetAsync("/api/Autores/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    var JsonString = response.Content.ReadAsStringAsync().Result;
                    var autor = JsonConvert.DeserializeObject<Autor>(JsonString);

                    return View(autor);

                }
                return View();
            }
        }

        // GET: Autores/Create        
        public ActionResult Create()
        {
            return View();
        }

        // POST: Autores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Autor autor)
        {
            try
            {
                using (var apiClient = new HttpClient())
                {
                    var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                    apiClient.BaseAddress = new Uri("https://localhost:44380/");
                    apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                    var resposta = await apiClient.PostAsJsonAsync("/api/Autores", autor);
                                       
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Autores/Edit/5
        public ActionResult Edit(int id)
        {
            using (var apiClient = new HttpClient())
            {
                var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                apiClient.BaseAddress = new Uri("https://localhost:44380/");
                apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = apiClient.GetAsync("/api/Autores/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    var JsonString = response.Content.ReadAsStringAsync().Result;
                    var autor = JsonConvert.DeserializeObject<Autor>(JsonString);

                    return View(autor);

                }
                return View();
            }
            
        }

        // POST: Autores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Autor autor)
        {
            try
            {
                using (var apiClient = new HttpClient())
                {
                    var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                    apiClient.BaseAddress = new Uri("https://localhost:44380/");
                    apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                    var resposta = await apiClient.PutAsJsonAsync("/api/Autores/"+id, autor);

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Autores/Delete/5
        public ActionResult Delete(int id)
        {
            using (var apiClient = new HttpClient())
            {
                var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                apiClient.BaseAddress = new Uri("https://localhost:44380/");
                apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = apiClient.GetAsync("/api/Autores/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    var JsonString = response.Content.ReadAsStringAsync().Result;
                    var autor = JsonConvert.DeserializeObject<Autor>(JsonString);

                    return View(autor);

                }
                return View();
            }
            
        }

        // POST: Autores/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                using (var apiClient = new HttpClient())
                {
                    var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                    apiClient.BaseAddress = new Uri("https://localhost:44380/");
                    apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                    var resposta = await apiClient.DeleteAsync("/api/Autores/" + id);

                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

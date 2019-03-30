using Domaine;
using MVC.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;


namespace MVC.Controllers
{
    public class ProjectController : Controller
    {// GET: Client



        public async System.Threading.Tasks.Task<ActionResult> ListProject(int? page)
        {
           
            HttpClient Client = new HttpClient();
            //  Client.BaseAddress = new Uri("http://localhost:10240");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/MapLevio-web/rest/projets/list").GetAwaiter().GetResult();
            ViewBag.result = response.Content.ReadAsAsync<IEnumerable<project>>().Result;
            
            return View();
        }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            project cls = null;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");

            HttpResponseMessage response = client.GetAsync("http://localhost:18080/MapLevio-web/rest/projets/" + id.ToString()).Result;

            if (response.IsSuccessStatusCode)
            {
                cls = response.Content.ReadAsAsync<project>().Result;

            }

            return View(cls);
        }

        [HttpPost]
        public ActionResult Edit(project r)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");

            ProjectViewModele prs = new ProjectViewModele();
            prs.projectId = r.projectId;
            prs.projectName = r.projectName;
            prs.ProjectType = "Finished";
            

            prs.description = r.description;

            client.PutAsJsonAsync<ProjectViewModele>("/MapLevio-web/api/projets/edit/" + r.projectId, prs).Result.EnsureSuccessStatusCode();


            return RedirectToAction("ListProject");

        }
        public ActionResult Delete(int id)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DeleteAsync("http://localhost:18080/MapLevio-web/rest/projets/del/" + id.ToString()).Result.EnsureSuccessStatusCode();
            return RedirectToAction("ListProject");
        }



        [HttpPost]
        [ValidateInput(false)]
        public FileResult Export(string tableHtml)
        {
            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader sr = new StringReader(tableHtml);
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                return File(stream.ToArray(), "application/pdf", "Liste des projets.pdf");
            }
        }
    }
    }


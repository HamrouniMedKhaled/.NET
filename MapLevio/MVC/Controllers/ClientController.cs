using Domaine;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;


namespace MVC.Controllers
{
    public class ClientController : Controller
    {
       


        // GET: Client
        public async System.Threading.Tasks.Task<ActionResult> ListClient()
        {
            HttpClient Client = new HttpClient();
            //  Client.BaseAddress = new Uri("http://localhost:10240");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/MapLevio-web/rest/clients/list").GetAwaiter().GetResult();
            ViewBag.result = response.Content.ReadAsAsync<IEnumerable<client>>().Result;

            return View();
        }
        public ActionResult Delete(int id)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DeleteAsync("http://localhost:18080/MapLevio-web/rest/clients/del/" + id.ToString()).Result.EnsureSuccessStatusCode();
            return RedirectToAction("ListClient");
        }

        

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(client c)
        {
            HttpClient Client = new HttpClient();

            //  Client.BaseAddress = new Uri("");
            ClientViewModele cc = new ClientViewModele();

            cc.nom = c.nom;
            cc.email = c.email;
            if (c.clientCategory.Equals("private") || c.clientCategory.Equals("Private"))
            {
                cc.clientCategory = "Private";
            }
            else if (c.clientCategory.Equals("public"))
            {
                cc.clientCategory = "Public";
            }

            cc.clientType = "New";
            cc.password = c.password;


            Client.PostAsJsonAsync<ClientViewModele>("http://localhost:18080/MapLevio-web/rest/clients/add", cc).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("ListClient");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            client cls = null;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");

            HttpResponseMessage response = client.GetAsync("http://localhost:18080/MapLevio-web/rest/clients/" + id.ToString()).Result;

            if (response.IsSuccessStatusCode)
            {
                cls = response.Content.ReadAsAsync<client>().Result;

            }

            return View(cls);
        }

        [HttpPost]
        public ActionResult Edit(client r)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");

            ClientViewModele res = new ClientViewModele();
            res.userId = r.userId;
            res.nom = r.nom;

            res.email = r.email;

            res.password = r.password;

            client.PutAsJsonAsync<ClientViewModele>("http://localhost:18080/MapLevio-web/rest/clients/edit/" + res.userId.ToString(), res).Result.EnsureSuccessStatusCode();


            return RedirectToAction("ListClient");

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
                return File(stream.ToArray(), "application/pdf", "Liste des clients.pdf");
            }
        }






     
        public async System.Threading.Tasks.Task<ActionResult> ListOrg()
        {
            HttpClient Client = new HttpClient();
            //  Client.BaseAddress = new Uri("http://localhost:10240");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/MapLevio-web/rest/clients/list").GetAwaiter().GetResult();
            ViewBag.result = response.Content.ReadAsAsync<IEnumerable<client>>().Result;

            return View();
        }
    }
}

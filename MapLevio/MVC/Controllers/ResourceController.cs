using Domaine;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ResourceController : Controller
    {

        public ActionResult ListeResource()
        {

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/MapLevio-web/rest/Resource").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<ResourceViewModels>>().Result;


            }
            else
            {
                ViewBag.result = "erreur";
            }
            return View();
        }

        public ActionResult ListeResourceArchive()
        {

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/MapLevio-web/rest/Resource/resarchive").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.res = response.Content.ReadAsAsync<IEnumerable<ResourceViewModels>>().Result;

            }
            else
            {
                ViewBag.res = "erreur";
            }
            return View("ListeResourceArchive");
        }
        [HttpGet]
        public ActionResult Create()
        {
            List<String> competance = (new List<string> { "Android", "JEE", "JAVA", "IOS", "PHP", "SYMFONY" });
            ViewBag.list = competance;
            List<String> resourceType = (new List<string> { "Employee", "Freelancer" });
            ViewBag.list1 = resourceType;
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(resource r,HttpPostedFileBase file)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            ResourceViewModels res = new ResourceViewModels();
            res.nom = r.nom;
            res.prenom = r.prenom;
            res.email = r.email;
            res.dateNaissance = r.dateNaissance;
            res.password = r.password;
            res.archivé = false;
            res.competance = r.competance;
            res.role = "Ressource";
            res.resourceState = "Available";
            res.resourceType = r.resourceType;
            res.seniority = r.seniority;
            Adresse adresse = new Adresse();
            adresse.codePostal = r.codePostal;
            adresse.pays = r.pays;
            adresse.rue = r.rue;
            adresse.ville = r.ville;
            res.adresse = adresse;
            var fileName = "";
            if (file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Upload"), file.FileName);
                file.SaveAs(path);
            }
            res.image = file.FileName;

            client.PostAsJsonAsync<ResourceViewModels>("http://localhost:18080/MapLevio-web/rest/Resource/addresource", res).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("ListeResource");
        }

        //DELETE: Declaration

        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DeleteAsync("http://localhost:18080/MapLevio-web/rest/Resource/" + id.ToString()).Result.EnsureSuccessStatusCode();
            return RedirectToAction("ListeResource");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            resource resource = null;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");

            HttpResponseMessage response = client.GetAsync("http://localhost:18080/MapLevio-web/rest/Resource/" + id.ToString()).Result;

            if (response.IsSuccessStatusCode)
            {
                resource = response.Content.ReadAsAsync<resource>().Result;

            }
            List<String> competance = (new List<string> { "Android", "JEE", "JAVA", "IOS", "PHP", "SYMFONY" });
            ViewBag.list = competance;
            List<String> resourceType = (new List<string> { "Employee", "Freelancer" });
            ViewBag.list1 = resourceType;
            return View(resource);
        }

        [HttpPost]
        public ActionResult Edit(resource r)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");

            ResourceViewModels res = new ResourceViewModels();
            res.userId = r.userId;
            res.nom = r.nom;
            res.prenom = r.prenom;
            res.email = r.email;
            res.dateNaissance = r.dateNaissance;
            res.password = r.password;
            res.competance = r.competance;
            res.resourceType = r.resourceType;
            res.seniority = r.seniority;
            res.resourceState = "Available";
            res.role = "Ressource";
            Adresse adresse = new Adresse();
            adresse.codePostal = "2222";
            adresse.pays = "Tunis";
            adresse.rue = "aa";
            adresse.ville = "aa";
            res.adresse = adresse;

            client.PutAsJsonAsync<ResourceViewModels>("http://localhost:18080/MapLevio-web/rest/Resource/" + res.userId.ToString(), res).Result.EnsureSuccessStatusCode();


            return RedirectToAction("ListeResource");

        }


    }
}
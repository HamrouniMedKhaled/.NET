using Domaine;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Converters;
using MVC.Models;
using System.IO;
using Services.Candidat;
using Services.Passage;

namespace MVC.Controllers
{

    
    public class CandidateController : Controller
    {
        candidate c = new candidate();
        CandidatService cas = new CandidatService();
        public CandidateController()
        {
            
        }
        // GET: CandidateEntrevu
        public ActionResult CandidateEntrevu()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/MapLevio-web/rest/candidate/CandidateEntrevu").Result;
            if (response.IsSuccessStatusCode)
            {
                ICollection<candidate> listcandidate = new List<candidate>();

                IEnumerable<CandidateModel> listcandidateViewModel =  response.Content.ReadAsAsync<IEnumerable<CandidateModel>>().Result;
                foreach (CandidateModel programmeViewModel in listcandidateViewModel)
                {
                    candidate prog = new candidate();
                    string s = "/Date(" + 1485298353000 + ")/";
                    string sa = @"""" + s + @"""";
                    prog.dateNaissance = programmeViewModel.dateNaissance;
                    prog.userId = programmeViewModel.userId;
                    prog.codePostal = programmeViewModel.codePostal;
                    prog.email = programmeViewModel.email;
                    prog.role = programmeViewModel.role;
                    prog.etat = programmeViewModel.etat;


                    listcandidate.Add(prog);
                }
                ViewBag.result = listcandidate;
            }
            else
            {
                ViewBag.result = "erreur";
            }
            return View();
        }
        // GET: CandidateEntretien
        public ActionResult CandidateEntretien()
        {
            PassageService ps = new PassageService();
            IEnumerable<passage> pasages = ps.allpasage();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/MapLevio-web/rest/candidate/CandidateEntretien").Result;
          
            if (response.IsSuccessStatusCode)
            {
                ICollection<candidate> listcandidate = new List<candidate>();

                IEnumerable<CandidateModel> listcandidateViewModel = response.Content.ReadAsAsync<IEnumerable<CandidateModel>>().Result;
                foreach (CandidateModel programmeViewModel in listcandidateViewModel)
                {
                    candidate prog = new candidate();
                    string s = "/Date(" + 1485298353000 + ")/";
                    string sa = @"""" + s + @"""";
                    prog.dateNaissance = programmeViewModel.dateNaissance;
                    prog.userId = programmeViewModel.userId;
                    prog.codePostal = programmeViewModel.codePostal;
                    prog.email = programmeViewModel.email;
                    prog.role = programmeViewModel.role;
                    prog.etat = programmeViewModel.etat;

                    listcandidate.Add(prog);
                }
                ViewBag.result = listcandidate;
                ViewBag.respas = pasages;
            }
            else
            {
                ViewBag.result = "erreur";
            }
            return View();
        }
        // GET: CandidateFr
        public ActionResult CandidateFr()
        {
            PassageService ps = new PassageService();
            IEnumerable<passage> pasages = ps.allpasage();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/MapLevio-web/rest/candidate/CandidateFr").Result;
            if (response.IsSuccessStatusCode)
            {
                ICollection<candidate> listcandidate = new List<candidate>();

                IEnumerable<CandidateModel> listcandidateViewModel = response.Content.ReadAsAsync<IEnumerable<CandidateModel>>().Result;
                foreach (CandidateModel programmeViewModel in listcandidateViewModel)
                {
                    candidate prog = new candidate();
                    string s = "/Date(" + 1485298353000 + ")/";
                    string sa = @"""" + s + @"""";
                    prog.dateNaissance = programmeViewModel.dateNaissance;
                    prog.userId = programmeViewModel.userId;
                    prog.codePostal = programmeViewModel.codePostal;
                    prog.email = programmeViewModel.email;
                    prog.role = programmeViewModel.role;
                    prog.etat = programmeViewModel.etat;


                    listcandidate.Add(prog);
                }
                ViewBag.result = listcandidate;
                ViewBag.respas = pasages;

            }
            else
            {
                ViewBag.result = "erreur";
            }
            return View();
        }
        // GET: CandidateAccepter
        public ActionResult CandidateAccepter()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/MapLevio-web/rest/candidate/CandidateAccepter").Result;
            if (response.IsSuccessStatusCode)
            {
                ICollection<candidate> listcandidate = new List<candidate>();

                IEnumerable<CandidateModel> listcandidateViewModel = response.Content.ReadAsAsync<IEnumerable<CandidateModel>>().Result;
                foreach (CandidateModel programmeViewModel in listcandidateViewModel)
                {
                    candidate prog = new candidate();
                    string s = "/Date(" + 1485298353000 + ")/";
                    string sa = @"""" + s + @"""";
                    prog.dateNaissance = programmeViewModel.dateNaissance;
                    prog.userId = programmeViewModel.userId;
                    prog.codePostal = programmeViewModel.codePostal;
                    prog.email = programmeViewModel.email;
                    prog.role = programmeViewModel.role;
                    prog.etat = programmeViewModel.etat;


                    listcandidate.Add(prog);
                }
                ViewBag.result = listcandidate;
            }
            else
            {
                ViewBag.result = "erreur";
            }
            return View();
        }

        // GET: Candidate/Details/5
        public ActionResult DetailsCandidate(int id)
        {

            CandidateModel cm = new CandidateModel() ;
            candidate can = new candidate();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            var responseTask = client.GetAsync("/MapLevio-web/rest/candidate/findByid/" + id);
            responseTask.Wait();
            var result = responseTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<CandidateModel>();
                readTask.Wait();
                cm = readTask.Result;
                can.userId = cm.userId;
                can.codePostal = cm.codePostal;
                can.email = cm.email;
                can.role = cm.role;
                can.etat = cm.etat;
                can.prenom = cm.prenom;
                can.nom = cm.nom;
                can.pays = cm.pays;
                can.ville = cm.ville;
                can.image = cm.image;
                can.cv = cm.cv;
                string s = "/Date(" + 1485298353000 + ")/";
                string sa = @"""" + s + @"""";
                can.dateNaissance = cm.dateNaissance;
              
            }
            Console.WriteLine(can);
            return View(can);

        }

        // GET: Candidate/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Candidate/Create
        [HttpPost]
        public ActionResult Create(candidate c , HttpPostedFileBase Image1 , HttpPostedFileBase Cv1)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");


            if (!ModelState.IsValid || Image1 == null || Image1.ContentLength == 0 || Cv1 == null || Cv1.ContentLength == 0)
            {
                RedirectToAction("Create");
            }
            string pic = System.IO.Path.GetFileName(Image1.FileName);
            string cvv = System.IO.Path.GetFileName(Cv1.FileName);
            string path = System.IO.Path.Combine(Server.MapPath("~/Content/Upload/"), pic);
            string path1 = System.IO.Path.Combine(Server.MapPath("~/Content/UploadCv/"), cvv);

            Image1.SaveAs(path);
            Cv1.SaveAs(path1);
            c.image = Image1.FileName;
            c.cv = Cv1.FileName;
            c.etat = "Attente_entrevu";
            c.role = "Candidate";
            Adresse adresse = new Adresse();
            adresse.codePostal = c.codePostal;
            adresse.pays = c.pays;
            adresse.pays = c.rue;
            adresse.ville = c.ville;
            Candidate can = new Candidate();
            can.adresse = adresse;
            can.cv = c.cv;
            can.image = c.image;
            can.email = c.email;
            can.nom = c.nom;
            can.prenom = c.prenom;
            can.role = c.role;
            can.etat = c.etat;
            can.password = c.password;
           
            

           client.PostAsJsonAsync<Candidate>("/MapLevio-web/rest/candidate/createCandidate", can).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            return RedirectToAction("Index","Home");
        }

        // GET: approuverCandidate
        public ActionResult approuverCandidate(int id)
        {
            Candidate cm = new Candidate();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");

            var responseTask = client.PutAsJsonAsync("/MapLevio-web/rest/candidate/approuverCandidate/" + id,cm);
            responseTask.Wait();
            var result = responseTask.Result;
           
                return RedirectToAction("CandidateEntretien");
            
        }
        // GET: refuserCandidate
        public ActionResult refuserCandidate(int id)
        {

            Candidate cm = new Candidate();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
           
            var responseTask = client.PutAsJsonAsync("/MapLevio-web/rest/candidate/refuserCandidate/" + id,cm);
            responseTask.Wait();
            var result = responseTask.Result;

            return RedirectToAction("CandidateEntrevu");

        }

        // GET: Candidate/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Candidate/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Candidate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Candidate/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Domaine;
using MVC.Models;


namespace MVC.Controllers
{
    public class ManagementController : Controller
    {
        
        
        // GET: Index
        public ActionResult Index()
        {

            IEnumerable<project> res = new List<project>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/MapLevio-web/rest/Monitor/Projects").Result;
            if (response.IsSuccessStatusCode)
            {
                res = response.Content.ReadAsAsync<IEnumerable<project>>().Result;

                int[] n = new int[10];
                int annee = 2014; 
                for (int i = 0; i < 11; i++)
                {
                    n[i] = res.Count(x=> x.dateDebut.Value.Year==annee);
                    annee++;
                }
                ViewBag.graph = n;
            }
            else
            {
                ViewBag.result = "Error";
            }
            return View();

            //int PrivateClients = 200;
            //int PublicClients = 20;
            //int Candidates = 20;
            //int CandidatesFr = 6;
            //int Employees = 420;
            //int freelancers = 920;
            ////  Ratio obj = new Ratio();
            //// obj.Candidates = Candidates;
            ////  obj.CandidatesFR = CandidatesFr;
            ////   return Json(obj,JsonRequestBehavior.AllowGet);
            //ViewBag.Candidates = Candidates;
            //ViewBag.CandidatesFR= CandidatesFr;
            //ViewBag.PrivateClients = PrivateClients;
            //ViewBag.PublicClients = PublicClients;
            //ViewBag.Emp = Employees;
            //ViewBag.Free = freelancers;
            //return View();
        }

        // Get Candidates
        public ActionResult Candidates()
        {
            int all = 0;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/MapLevio-web/rest/candidate/CandidateAccepter").Result;
            if (response.IsSuccessStatusCode)
            {

                // accepté
                ICollection<candidate> candidates = new List<candidate>();
                IEnumerable<CandidateModel> candidatesViewModel = response.Content.ReadAsAsync<IEnumerable<CandidateModel>>().Result;
                foreach (CandidateModel programmeViewModel in candidatesViewModel)
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
                    candidates.Add(prog);
                }
                ViewBag.accepted = candidates;
                ViewBag.naccepted = candidates.Count;
                all = all + candidates.Count;
            }
            else
            {
                ViewBag.result = "erreur";
            }

        
            //entrevue
              response = client.GetAsync("/MapLevio-web/rest/candidate/CandidateEntrevu").Result;
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
                ViewBag.entrevue = listcandidate;
                ViewBag.nentrevue = listcandidate.Count;
                all = all + listcandidate.Count;
            }
            else
            {
                ViewBag.result = "erreur";
            }

            //entretien
            response = client.GetAsync("/MapLevio-web/rest/candidate/CandidateEntretien").Result;
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
                ViewBag.entretien = listcandidate;
                ViewBag.nentretien = listcandidate.Count;
                all = all + listcandidate.Count;
            }
            else
            {
                ViewBag.result = "erreur";
            }

            //fr
             response = client.GetAsync("/MapLevio-web/rest/candidate/CandidateFr").Result;
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
                ViewBag.fr = listcandidate;
                ViewBag.nfr = listcandidate.Count;
                all = all + listcandidate.Count;
            }
            else
            {
                ViewBag.result = "erreur";
            }
            ViewBag.all = all;
            return View();
        }



        public ActionResult Projects()
        {
            int all =0;
            int res;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // New projects number
            HttpResponseMessage response = client.GetAsync("/MapLevio-web/rest/Monitor/Projects/New/Number").Result ;
            
            if (response.IsSuccessStatusCode)
            {
                res = response.Content.ReadAsAsync<int>().Result ;
                ViewBag.nnew= res;
                all = all + res;
            }

            // In progress projects number
            response = client.GetAsync("/MapLevio-web/rest/Monitor/Projects/InProgress/Number").Result;

            if (response.IsSuccessStatusCode)
            {
                res = response.Content.ReadAsAsync<int>().Result;
                ViewBag.nip = res;
                all = all + res;
            }

            //Finished projects number
            response = client.GetAsync("/MapLevio-web/rest/Monitor/Projects/Finished/Number").Result;

            if (response.IsSuccessStatusCode)
            {
                res = response.Content.ReadAsAsync<int>().Result;
                ViewBag.nfinished = res;
                all = all + res;
            }
            ViewBag.all = all;
            return View();
        }


        public ActionResult Ressources()
        {
            IEnumerable<resource> res = new List<resource>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/MapLevio-web/rest/Monitor/Resources").Result;
            if (response.IsSuccessStatusCode)
            {
                res = response.Content.ReadAsAsync<IEnumerable<resource>>().Result;
                ViewBag.Emp = res.Count(x => x.resourceType == "Employee");
                ViewBag.Empl = res.Select(x => x.resourceType == "Employee");
                ViewBag.freel = res.Select(x => x.resourceType == "Freelancer");
                ViewBag.free = res.Count(x => x.resourceType == "Freelancer");
            }
            else
            {
                ViewBag.result = "Error";
            }
            return View();
        }



        public ActionResult Clients()
        {

            IEnumerable<client> res = new List<client>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/MapLevio-web/rest/Monitor/Public/Number").Result;
            if (response.IsSuccessStatusCode)
            {
                res = response.Content.ReadAsAsync<IEnumerable<client>>().Result;
                ViewBag.npublic= res.Count(x => x.clientCategory == "Public");
                
            }
            else
            {
                ViewBag.result = "Error";
            }

            response = client.GetAsync("/MapLevio-web/rest/Monitor/Private/Number").Result;
            if (response.IsSuccessStatusCode)
            {
                res = response.Content.ReadAsAsync<IEnumerable<client>>().Result;
                ViewBag.nprivate = res.Count(x => x.clientCategory == "Private");

            }
            else
            {
                ViewBag.result = "Error";
            }



            return View();
        }




        //Printing to Pdf
/*
        public ActionResult PrintViewToPdf()
        {
            var report = new ActionAsPdf("Index");
            return report;
        }

        public ActionResult PrintDetailsAsPdf(int id)
        {
            var report = new ActionAsPdf("/Candidate/DetailsCandidate", id);
            return report;
        }
        */
    }
}
using Domaine;
using MVC.Models;
using Services.Passage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class PassageController : Controller
    {
        int cc = 0;
        PassageService ps = new PassageService();
        Passage psag = new Passage();
        // GET: Passage
        public ActionResult Index()
        {

          
            return View();
        }

        // GET: Passage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult verificationfalse()
        {
            return View();
        }
        // GET: Passage/Create
        public ActionResult CreatePassage()
        {
            //normalment en pprend id de user conecter 
            int id = 3;
            PassageService ps = new PassageService();
if(ps.verification(id) == true)
            {
                test t = ps.findTest(id);
                ViewBag.testt = t;
                return View();
            }
            else
            {
                return RedirectToAction("verificationfalse");
            }

          
        }
        [HttpPost]
        public ActionResult CreatePassage(passage p)
        {

            bool b = ps.passgeTest(p);
            int id = p.candidateId;

            if (b == true)
            {
                Candidate cm = new Candidate();
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:18080");

                var responseTask = client.PutAsJsonAsync("/MapLevio-web/rest/candidate/approuverFRCandidate/" + id, cm);
                responseTask.Wait();
                var result = responseTask.Result;
            }
            else
            {
                Candidate cm = new Candidate();
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:18080");

                var responseTask = client.PutAsJsonAsync("/MapLevio-web/rest/candidate/refuserCandidate/" + id, cm);
                responseTask.Wait();
                var result = responseTask.Result;
            }
            return RedirectToAction("Index", "Home");
        }
        // GET: Passage/Create
        public ActionResult CreateTechnic(long id)
        {
            int dd = unchecked((int)id);
           Session["cc"] = dd;
            return View();
        }

        // POST: Passage/Create
        [HttpPost]
        public ActionResult CreateTechnic(passage p)
        {
            DateTime ds = DateTime.Now;

            DateTime d = p.dateOfPassing;
            int result = DateTime.Compare(ds, d);
            if (result < 0)
            {
                int c = (int)Session["cc"];
                ps.affecterDateTech(c, d);
                return RedirectToAction("CandidateEntretien", "Candidate");
            }else
            {
                return RedirectToAction("CreateTechnic");

            }
        }
        // GET: Passage/Create
        public ActionResult CreateFr(long id)
        {
            int dd = unchecked((int)id);
            Session["cc"] = dd;
            return View();
        }

        // POST: Passage/Create
        [HttpPost]
        public ActionResult CreateFr(passage p)
        {
            DateTime ds = DateTime.Now;

            DateTime d = p.dateOfPassing;
            int result = DateTime.Compare(ds, d);
            if (result < 0)
            {
                int c = (int)Session["cc"];
                ps.affecterDateFr(c, d);
                return RedirectToAction("CandidateFr", "Candidate");
            }else
            {
                return RedirectToAction("CreateFr");
            }
        }
        // GET: Passage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Passage/Edit/5
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

        // GET: Passage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Passage/Delete/5
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

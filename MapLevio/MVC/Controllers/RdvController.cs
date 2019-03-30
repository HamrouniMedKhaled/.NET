using Services;
using Services.Rdv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class RdvController : Controller
    {

        RdvService cs = new RdvService();

        // GET: Rdv
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult AllRdv()
        {
            var listRdvs = cs.GetAll();

            return View(listRdvs);


        }

        // GET: Rdv/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rdv/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rdv/Create
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

        // GET: Rdv/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rdv/Edit/5
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

        // GET: Rdv/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rdv/Delete/5
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

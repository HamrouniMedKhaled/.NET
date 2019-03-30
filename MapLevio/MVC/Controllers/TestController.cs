using Domaine;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using MVC.Models;


namespace MVC.Controllers
{
    public class TestController : Controller
    {

        test c = new test();
        public TestController()
        {

        }
        // GET: Test
        public ActionResult Index()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/MapLevio-web/rest/test/afficherTest").Result;
            if (response.IsSuccessStatusCode)
            {
                ICollection<TestModel> listtest = new List<TestModel>();
                IEnumerable<TestModel> testViewModel = response.Content.ReadAsAsync<IEnumerable<TestModel>>().Result;
                foreach (TestModel programmeViewModel in testViewModel)
                {

                    TestModel prog = new TestModel();

                    prog.testId = programmeViewModel.testId;
                    prog.type = programmeViewModel.type;



                    listtest.Add(prog);
                }
                ViewBag.result = listtest;
            }
            else
            {
                ViewBag.result = "erreur";
            }
                return View();
        }

        // GET: Test/Details/5
        public ActionResult Details(int id)
        {
            TestModel cm = new TestModel();
            TestModel can = new TestModel();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            var responseTask = client.GetAsync("/MapLevio-web/rest/test/afficheTest/" + id);
            responseTask.Wait();
            var result = responseTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<TestModel>();
                readTask.Wait();
                cm = readTask.Result;
                can.testId = cm.testId;
                can.type = cm.type;
                can.q1 = cm.q1;
                can.q2 = cm.q2;
                can.q3 = cm.q3;
                can.q4 = cm.q4;
                can.q5 = cm.q5;
                can.q6 = cm.q6;
                can.q7 = cm.q7;
                can.q8 = cm.q8;
                can.q9 = cm.q9;
                can.q10 = cm.q10;
                can.answer1 = cm.answer1;
                can.answer2 = cm.answer2;
                can.answer3 = cm.answer3;
                can.answer4 = cm.answer4;
                can.answer5 = cm.answer5;
                can.answer6 = cm.answer6;
                can.answer7 = cm.answer7;
                can.answer8 = cm.answer8;
                can.answer9 = cm.answer9;
                can.answer10 = cm.answer10;
            }
            Console.WriteLine(can);
            return View(can);
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            List<string> Types = new List<string> { "Technic", "Fr" };
            ViewData["Types"] = new SelectList(Types);
            return View();
        }

        // POST: Test/Create
        [HttpPost]
        public ActionResult Create(Test  t)
        {
            Console.WriteLine(t);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            
            client.PostAsJsonAsync<Test>("/MapLevio-web/rest/test/createTest", t).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            return RedirectToAction("index");
        }

        // GET: Test/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        } 

        // POST: Test/Edit/5
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

        // GET: Test/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            var deleteTask = client.DeleteAsync("/MapLevio-web/rest/test/deletTest/" + id);
            deleteTask.Wait();
            var result = deleteTask.Result;
            if (result.IsSuccessStatusCode)
            {
                
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // POST: Test/Delete/5
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

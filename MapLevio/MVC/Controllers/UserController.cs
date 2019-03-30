

using Data;
using Domaine;
using MailKit.Net.Smtp;
using MapLevio.Data.Infrastructure;
using MimeKit;
using MVC.Models;
using ServicePattern;
using Services;
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
    public class UserController : Controller
    {

        
        public ActionResult ListUsers()
         {
             HttpClient p = new HttpClient();
             p.BaseAddress = new Uri("http://localhost:18080/");
             p.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
             HttpResponseMessage response = p.GetAsync("MapLevio-web/rest/users/c").Result;
             if (response.IsSuccessStatusCode)
             {
                 ViewBag.result = response.Content.ReadAsAsync<IEnumerable<candidate>>().Result;
             }
             else
             {
                 ViewBag.result = "error";
             }
             return View();



         }


        public ActionResult ListCandidat()
        {
            HttpClient p = new HttpClient();
            p.BaseAddress = new Uri("http://localhost:18080/");
            p.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = p.GetAsync("MapLevio-web/rest/users/c").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<candidate>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();

        }


        public ActionResult GestionClients()
        {
            HttpClient p = new HttpClient();
            p.BaseAddress = new Uri("http://localhost:18080/");
            p.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = p.GetAsync("MapLevio-web/rest/users/list").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<client>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }
        public ActionResult ListClients()
        {
            HttpClient p = new HttpClient();
            p.BaseAddress = new Uri("http://localhost:18080/");
            p.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = p.GetAsync("MapLevio-web/rest/users/list").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<client>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();



        }


        // GET: User
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult LoginUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginUser(user p)
        {
            if (ModelState.IsValid)
            {
                UserService sc = new UserService();

               

                    Session["role"] = p.role;
                    string t = (string)Session["role"];
                    if (t == "Candidate")
                    {

                        var log = sc.GetuserByEmail(p.email , p.password);
                        if (log != null)
                        {

                            Session["nomm"] = log;
                            Session["id"] = log.userId;
                            return RedirectToAction("Profile");
                        }
                        else
                        {
                            Response.Write("<script>alert('invalid =')</script>");
                        }
                    }


                   else if (t == "Resource")
                    {
                    var log = sc.GetuserByEmailr(p.email, p.password);
                    // var log = sc.Get(a => a.email.Equals(p.email) && a.password.Equals(p.password));
                    if (log != null)
                        {

                            Session["nomm"] = log;
                            return View();
                        }
                    }

                    else if (t == "Manager")
                    {

                    var log = sc.Get(a => a.email.Equals(p.email) && a.password.Equals(p.password));
                    if (log != null)
                        {

                            Session["nomm"] = log;
                            return RedirectToAction("gestionClients");
                        }
                    }


                    else if (t == "Client")
                    {

                    var log = sc.Get(a => a.email.Equals(p.email) && a.password.Equals(p.password));
                    if (log != null)
                        {

                            Session["nomm"] = log;
                            return RedirectToAction("ListUsers");
                        }
                    }

 
                    else
                    {
                        Response.Write("<script>alert('invalid password')</script>");
                    }

                
            }
            return View();
        }

       
        public ActionResult Profile()
        {
            UserService sc = new UserService();

            int id = (int)Session["id"];


            candidate p = sc.GetuserById(id);
            ViewBag.result = p;

            return View(p);
        }


      /*  public ActionResult ProfileSingle()
        {
            return View();
        }*/
         [HttpGet]
        public ActionResult ProfileSingle(int id )
        {
            UserService sc = new UserService();
            candidate c = sc.GetById(id);
         
            ViewBag.result =c;

            return View(c);
        }




        public ActionResult EditProfile()
        {
            return View();
        }

       // POST: User/Edit/5
       [HttpPut]
        public ActionResult EditProfile(candidate c , HttpPostedFileBase image, HttpPostedFileBase cv)
        {
           
                UserService sc = new UserService();
            if (c == null) {
                Response.Write("<script>alert('invalid password')</script>");


            }
            string img = System.IO.Path.GetFileNameWithoutExtension(image.FileName);
            string cvs = System.IO.Path.GetFileNameWithoutExtension(cv.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), image.FileName);
            var path1 = Path.Combine(Server.MapPath("~/Content/UploadCv"), cv.FileName);
            image.SaveAs(path);
            cv.SaveAs(path1);
            int id = (int)Session["id"];
             candidate1 candidate = new candidate1();
            candidate.nom = c.nom;
            candidate.prenom = c.prenom;
            candidate.email = c.email;
            candidate.password = c.password;
            candidate.pays = c.pays;
            candidate.rue = c.rue;
            candidate.ville = c.ville;
            candidate.userId = c.userId;
            candidate.image = img;
            candidate.cv = cvs;


            candidate.role = c.role;
                        
                HttpClient p = new HttpClient();
                p.BaseAddress = new Uri("http://localhost:18080/");
                var responseTask = p.PutAsJsonAsync("MapLevio-web/rest/users/update/" + id, candidate);
                responseTask.Wait();
                var result = responseTask.Result;
                return RedirectToAction("Profile");
            


        }

      

        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("LoginUser", "User");
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(candidate c, HttpPostedFileBase image , HttpPostedFileBase cv)
        {
            if (!ModelState.IsValid || image == null )
            {
                RedirectToAction("LoginUser");
            }
            UserService sc = new UserService();
            string img =System.IO.Path.GetFileNameWithoutExtension(image.FileName);
            string cvs = System.IO.Path.GetFileNameWithoutExtension(cv.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), image.FileName);
            var path1 = Path.Combine(Server.MapPath("~/Content/UploadCv"), cv.FileName);
            image.SaveAs(path);
            cv.SaveAs(path1);
            c.image = img;
            c.cv = cvs;
            Random rnd = new Random();
            int id = rnd.Next(50, 999);
            c.userId = id;
            c.etat = "Attente_entrevu";
            sc.add(c);
              
                       
                return RedirectToAction("ListUsers");
                       

               }

        [HttpGet]
        public ActionResult ClientSingle(int id)
        {
            ClientService sc = new ClientService();
            client client = sc.GetById(id);
            ViewBag.result = client;

            return View(client);
        }


        [HttpGet]
        public ActionResult DeleteCandidate(int id)
        {
            UserService sc = new UserService();
            candidate c = sc.GetById(id);
            sc.Delete(c);
            sc.Commit();
            var message1 = new MimeMessage();
            message1.From.Add(new MailboxAddress("Compte Supprimé ", "medtrd14@gmail.com"));
            message1.To.Add(new MailboxAddress("Compte Supprimé", c.email));
            message1.Subject = "Compte Supprimé";
            message1.Body = new TextPart("plain")
            {
                Text = "Bonjour  Mr " + c.nom + " Votre compte a eté supprimé Votre compte a été supprimé de la part de l'equipe MapLevio"

            };
            using (var Client = new SmtpClient())
            {
                Client.Connect("smtp.gmail.com", 587, false);
                Client.Authenticate("medtrd14@gmail.com", "98551708nlysmrrobot");
                Client.Send(message1);
                Client.Disconnect(true);
            }

            return RedirectToAction("ListCandidat");
        }


        [HttpGet]
        public ActionResult DeleteClient(int id)
        {
            ClientService sc = new ClientService();
            client c = sc.GetById(id);
            sc.Delete(c);
            sc.Commit();

            var message1 = new MimeMessage();
            message1.From.Add(new MailboxAddress("Compte Supprimé ", "medtrd14@gmail.com"));
            message1.To.Add(new MailboxAddress("Compte Supprimé", c.email));
            message1.Subject = "Compte Supprimé";
            message1.Body = new TextPart("plain")
            {
                Text = "Bonjour  Client  " + c.nom + " Votre compte a été supprimé de la part de l'equipe MapLevio"

            };
            using (var Client = new SmtpClient())
            {
                Client.Connect("smtp.gmail.com", 587, false);
                Client.Authenticate("medtrd14@gmail.com", "98551708nlysmrrobot");
                Client.Send(message1);
                Client.Disconnect(true);
            } 

            return RedirectToAction("GestionClients");
        }



    }
}

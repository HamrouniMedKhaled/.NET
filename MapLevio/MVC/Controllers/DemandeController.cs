using Domaine;
using MVC.Models;
using Services.Demande;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class DemandeController : Controller
    {
        //IServiceDemande s = new ServiceDemande();
        ServiceDemande s = new ServiceDemande();

        // GET: Demande
        public ActionResult Index()
        {
            return View();
        }

        // GET: Demande/Details/5
        public ActionResult Details(int id)
        {

            var c = s.GetById(id);

            DemandeModel d = new DemandeModel();

            d.idDemande = c.idDemande;
            d.anneeExp = c.anneeExp;
            d.bac = c.bac;
            d.competance = c.competance;
            d.description = c.description;
            d.diplome = c.diplome;
            d.cout = c.cout;
            d.directeur = c.directeur;
            d.duree = c.duree;
            d.nomProjet = c.nomProjet;

            return View(d);

        }

        // GET: Demande/Create
        public ActionResult Create()

        {
            List<string> BacType = new List<string> { "Mathématiques", "SciencesExpérimentales", "SciencesInformatiques" };
            ViewData["BacType"] = new SelectList(BacType);

            List<string> CompetanceType = new List<string> { "Android", "JEE", "JAVA", "IOS", "PHP", "SYMFONY" };
            ViewData["CompetanceType"] = new SelectList(CompetanceType);

            List<string> DiplomeType = new List<string> { "Licence", "Master", "Formation", "Ingénierie" };
            ViewData["DiplomeType"] = new SelectList(DiplomeType);
            return View();

            //List<string> BacType = (new List<string> { "Mathématiques", "SciencesExpérimentales", "SciencesInformatiques" });
            //ViewBag.listBac = BacType;
            //List<string> CompetanceType = (new List<string> { "Android", "JEE", "JAVA", "IOS", "PHP", "SYMFONY" });
            //ViewBag.listCompetance = CompetanceType;
            //List<string> DiplomeType = (new List<string> { "Licence", "Master", "Formation", "Ingénierie"});
            //ViewBag.listDiplome = DiplomeType;
            // return View("Create");
            // return RedirectToAction("Create");

        }


        public ActionResult demandeEnvoye()
        {
            return View();
        }


        // POST: Demande/Create
        [HttpPost]
        public ActionResult Create(DemandeModel DM)
        {
            demande d = new demande();
            d.idDemande = DM.idDemande;
            d.nomProjet = DM.nomProjet;
            d.directeur = DM.directeur;
            d.diplome = DM.diplome;
            d.description = DM.description;
            d.bac = DM.bac;
            d.anneeExp = DM.anneeExp;
            d.cout = DM.cout;
            d.competance = DM.competance;
            d.duree = DM.duree;


            s.Add(d);
            s.Commit();
            return RedirectToAction("demandeEnvoye");


        }



        public ActionResult ListeDemandes()
        {
            List<DemandeModel> list = new List<DemandeModel>();
            foreach (var c in s.GetAll())
            {
                DemandeModel d = new DemandeModel();

                d.idDemande = c.idDemande;
                d.anneeExp = c.anneeExp;
                d.bac = c.bac;
                d.competance = c.competance;
                d.description = c.description;
                d.diplome = c.diplome;
                d.cout = c.cout;
                d.duree = c.duree;
                d.directeur = c.directeur;
                d.nomProjet = c.nomProjet;



                list.Add(d);
            }
            return View(list);
        }




        public void SendMail()
        {
            //1:eli chtabath bih: 2li chtabathlou
            MailMessage mailMessage = new MailMessage("didi.dohaa@gmail.com", "chaiebyasmine16@gmail.com");
            mailMessage.Subject = "Demande Service";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = string.Format("<html><head></head><body><b>Cher Client  </b> <br>Votre demande est en cours <b> de traitement</b></body></html>");

            SmtpClient smtpClient = new SmtpClient();
            //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;

            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "didi.dohaa@gmail.com",
                Password = "lesours2012"
            };
            //smtpClient.UseDefaultCredentials = false;
            smtpClient.Send(mailMessage);


        }

        public ActionResult envoiMail()
        {
            SendMail();

            return RedirectToAction("ListeDemandes");
        }




        // GET: Demande/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Demande/Edit/5
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

        // GET: Demande/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Demande/Delete/5
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

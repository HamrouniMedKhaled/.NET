using Domaine;
using MVC.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class CongeController : Controller
    {
        Iserviceconge sc = new Serviceconge();
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(CongViewModels collection)
        {
            if (collection.congeDebut < DateTime.Now || collection.congeFin < DateTime.Now)
            {
                Response.Write("<script>alert('invalid date')</script>");
                return View();
            }
            conge c = new conge();


            c.idConge = collection.idConge;
            c.congeDebut = collection.congeDebut;
            c.congeFin = collection.congeFin;

            sc.Add(c);
            sc.Commit();
            Response.Write("<script>alert('Your request has been sent')</script>");
            return View();

        }

        public ActionResult ListeConge()
        {
            List<CongViewModels> list = new List<CongViewModels>();
            foreach (var c in sc.GetAll())
            {
                CongViewModels cn = new CongViewModels();
                if (c.congeFin < DateTime.Now)
                {

                    sc.Delete(c);
                    sc.Commit();
                }
                else {
                cn.idConge = c.idConge;
                cn.congeDebut = c.congeDebut;
                cn.congeFin = c.congeFin;
                if (c.accepter == false)
                    cn.accepter = false;
                else
                    cn.accepter = true;
                }
                list.Add(cn);


            }


            return View(list);
        }

        public ActionResult Delete(int id)
        {
            conge c = sc.GetById(id);

            sc.Delete(c);
            sc.Commit();
            return RedirectToAction("ListeConge");
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("ListeConge");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Accept(int id)
        {
            conge c = sc.GetById(id);
            c.accepter = true;
            sc.Update(c);
            sc.Commit();
            SendMail(id);
            return RedirectToAction("ListeConge");
        }
        public void SendMail(int id)
        {
            CongViewModels pro = new CongViewModels();
            conge proj = sc.GetById(id);
          //  pro.customer = serviceC.GetById(proj.userId);

            MailMessage mailMessage = new MailMessage("ibtihel.slimi.is@gmail.com", "didi.dohaa@gmail.com");
            mailMessage.Subject = "Conge Accepté";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = string.Format("<html><head></head><body><b>Dear Mister cc </b> <br> your conge <b>approved</b></body></html>");

            SmtpClient smtpClient = new SmtpClient();
            //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;

            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "ibtihel.slimi.is@gmail.com",
                Password = "samsung2move"
            };
            //smtpClient.UseDefaultCredentials = false;
            smtpClient.Send(mailMessage);


        }


    }
}
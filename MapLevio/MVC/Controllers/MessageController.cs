using Domaine;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class MessageController : Controller
    {

        //GetAllMessage
        public ActionResult GetAllMessage()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/MapLevio-web/rest/Message?typeMsg=").Result;
            if (response.IsSuccessStatusCode)
            {
                ICollection<message> listmsg = new List<message>();

                IEnumerable<MessageModel> listMessageModel = response.Content.ReadAsAsync<IEnumerable<MessageModel>>().Result;
                
                //List<string> msgCible = new List<string> { "Resource", "Projet", "Client" };
                //ViewData["MsgCible"] = new SelectList(msgCible);

               // List<string> msgType = new List<string> { "Satisfaction", "Reclamation", "Probleme_technique" };
              //  ViewData["MsgType"] = new SelectList(msgType);

                foreach (MessageModel m in listMessageModel)
                {
                    message msg = new message();
                    msg.body = m.body;
                    msg.isArchive = m.isArchive;
                    msg.lu = m.lu;
                    msg.idMessage = m.idMessage;
                    msg.messageCible = m.messageCible.ToString();
                    msg.messageType = m.messageType.ToString();
                    msg.dateEnvoi = m.dateEnvoi;

                  //  m.idUserSender = m.sender.userId;
                    //msg.sender = m.sender.userId;             
                    

                    listmsg.Add(msg);
                }
                ViewBag.result = listmsg;
            }
            else
            {
                ViewBag.result = "erreur";
            }
            return View();
        }




        //GetMessageNonLu
        public ActionResult GetMessageNonLu()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/MapLevio-web/rest/Message?typeMsg=NonLu").Result;
            if (response.IsSuccessStatusCode)
            {
                ICollection<message> listmsg = new List<message>();

                IEnumerable<MessageModel> listMessageModel = response.Content.ReadAsAsync<IEnumerable<MessageModel>>().Result;
                //List<string> msgCible = new List<string> { "Resource", "Projet", "Client" };
                //ViewData["MsgCible"] = new SelectList(msgCible);

                //List<string> msgType = new List<string> { "Satisfaction", "Reclamation", "Probleme_technique" };
               // ViewData["MsgType"] = new SelectList(msgType);

                foreach (MessageModel m in listMessageModel)
                {
                    message msg = new message();
                    msg.body = m.body;
                    msg.isArchive = m.isArchive;
                    msg.lu = m.lu;
                    msg.idMessage = m.idMessage;
                    msg.messageCible = m.messageCible.ToString();
                    msg.messageType = m.messageType.ToString();
                    msg.dateEnvoi = m.dateEnvoi;

                    //  m.idUserSender = m.sender.userId;
                    //msg.sender = m.sender.userId;             


                    listmsg.Add(msg);
                }
                ViewBag.result = listmsg;
            }
            else
            {
                ViewBag.result = "erreur";
            }
            return View();
        }


        //GetMessagesArchive
        public ActionResult GetMessageArchive()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/MapLevio-web/rest/Message?typeMsg=archive").Result;
            if (response.IsSuccessStatusCode)
            {
                ICollection<message> listmsg = new List<message>();

                IEnumerable<MessageModel> listMessageModel = response.Content.ReadAsAsync<IEnumerable<MessageModel>>().Result;
                //List<string> msgCible = new List<string> { "Resource", "Projet", "Client" };
                //ViewData["MsgCible"] = new SelectList(msgCible);

                //List<string> msgType = new List<string> { "Satisfaction", "Reclamation", "Probleme_technique" };
                // ViewData["MsgType"] = new SelectList(msgType);

                foreach (MessageModel m in listMessageModel)
                {
                    message msg = new message();
                    msg.body = m.body;
                    msg.isArchive = m.isArchive;
                    msg.lu = m.lu;
                    msg.idMessage = m.idMessage;
                    msg.messageCible = m.messageCible.ToString();
                    msg.messageType = m.messageType.ToString();
                    msg.dateEnvoi = m.dateEnvoi;

                    //  m.idUserSender = m.sender.userId;
                    //msg.sender = m.sender.userId;             


                    listmsg.Add(msg);
                }
                ViewBag.result = listmsg;
            }
            else
            {
                ViewBag.result = "erreur";
            }
            return View();
        }


        // GET: Message/Details/5
        public ActionResult Details(int id)
        {
            MessageModel m = new MessageModel();
            message msg = new message();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            var responseTask = client.GetAsync("/MapLevio-web/rest/Message/findBy/" + id);
            responseTask.Wait();
            var result = responseTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<MessageModel>();
                readTask.Wait();
                m = readTask.Result;
                //msg.sender = m.userId;
                msg.body = m.body;
                msg.dateEnvoi = m.dateEnvoi;
                msg.messageType = m.messageType;
                msg.messageCible = m.messageCible;
                //can.etat = cm.etat;

            }
            Console.WriteLine(msg);
            return View(msg);
        }



           

        // GET: Message/Create
        public ActionResult Create()
        {
            List<string> msgCible = new List<string> { "Resource", "Projet", "Client" };
            ViewData["MsgCible"] = new SelectList(msgCible);

            List<string> msgType = new List<string> { "Satisfaction", "Reclamation", "Probleme_technique" };
            ViewData["MsgType"] = new SelectList(msgType);

            return View();
        }

        // POST: Message/Create
        [HttpPost]
        public ActionResult Create(message msg)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");

            if (!ModelState.IsValid || msg.body == null )
            {
                RedirectToAction("Create");
            }

            message m = new message();
            m.body = msg.body;
            m.messageCible = msg.messageCible;
            m.messageType = msg.messageType;
            m.lu = 0;
            m.isArchive = 0;

            m.sender = 0;


            client.PostAsJsonAsync<message>("/MapLevio-web/rest/Message", m).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            
            return RedirectToAction("Create");

        }


        // GET: ArchiverMessage
        public ActionResult archiverMessage(int id)
        {

            MessageModel m = new MessageModel();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");

            var responseTask = client.PutAsJsonAsync("/MapLevio-web/rest/Message/archiver/" + id, m);
            responseTask.Wait();
            var result = responseTask.Result;
           
                return RedirectToAction("GetAllMessage");
           
        }

       
          


        //GetNombreMsgNonLu
        public Int32 GetNbrMsgNonLu()
        {
            

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/MapLevio-web/rest/Message?typeMsg=NbrMsgNonLu").Result;
            Int32 nbr = response.Content.ReadAsAsync<Int32>().Result;
            if (response.IsSuccessStatusCode)
            {
               // Int32 test = nbr;
                return nbr;
            }
            return 0;
        }




        // GET: Message
        public ActionResult Index()
        {
            return View();
        }


        // GET: Message/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Message/Edit/5
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

        // GET: Message/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Message/Delete/5
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

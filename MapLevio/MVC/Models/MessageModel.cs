using Domaine;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Models
{
    public class MessageModel
    {
        [Key]
        public int idMessage { get; set; }

        [DataType(DataType.MultilineText)]
        public string body { get; set; }

        public string dateEnvoi { get; set; }

        public int? isArchive { get; set; }

        public int? lu { get; set; }

        public string messageCible { get; set; }
        public string messageType { get; set; }


        public user sender { get; set; }

        public int idUserSender { get; set; }






    }
}
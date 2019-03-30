using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Adresse
    {
        public string pays { get; set; }
        public string rue { get; set; }
        public string ville { get; set; }
        public string codePostal { get; set; }

    }
}
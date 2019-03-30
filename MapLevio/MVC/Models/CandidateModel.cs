using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class CandidateModel
    {
        public int userId { get; set; }
        public string codePostal { get; set; }
        public DateTime dateNaissance { get; set; }
        public string email { get; set; }
        public string etat { get; set; }
        public string role { get; set; }
        public string prenom { get; set; }
        public string nom { get; set; }
        public string pays { get; set; }
        public string rue { get; set; }
        public string ville { get; set; }
        public string classType { get; set; }
        public string image { get; set; }
        public string password { get; set; }
        public string cv { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace MVC.Models
{
    public class Candidate
    {
        public int userId { get; set; }
        public DateTime dateNaissance { get; set; }
        public string email { get; set; }
        public string etat { get; set; }
        public string role { get; set; }
        public string prenom { get; set; }
        public string nom { get; set; }
        public Adresse adresse { get; set; }
        public string classType { get; set; }
        public string image { get; set; }
        public string password { get; set; }
        public string cv { get; set; }
    }
}
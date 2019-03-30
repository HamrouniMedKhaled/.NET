using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class ResourceViewModels
    {
        public int userId { get; set; }
        public DateTime? dateNaissance { get; set; }
        public string email { get; set; }
        public string nom { get; set; }
        public string password { get; set; }
        public string prenom { get; set; }
        public Adresse adresse { get; set; }
        public string cv { get; set; }
        public string role { get; set; }
        public bool archivé { get; set; }
        public string competance { get; set; }
        public string resourceState { get; set; }
        public string resourceType { get; set; }
        public int seniority { get; set; }
        public string image { get; set; }


    }
}
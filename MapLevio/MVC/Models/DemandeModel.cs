using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class DemandeModel
    {
        [Key]
        public int idDemande { get; set; }
            
        public int? anneeExp { get; set; }

       
        public string bac { get; set; }

        public string competance { get; set; }

        public float cout { get; set; }

       

        public string description { get; set; }

        public string diplome { get; set; }

        public string directeur { get; set; }

        public int? duree { get; set; }

      
        public string nomProjet { get; set; }


    }
}
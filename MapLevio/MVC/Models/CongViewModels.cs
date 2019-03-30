using Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class CongViewModels
    {
        public int idConge { get; set; }
        public DateTime? congeDebut { get; set; }
        public DateTime? congeFin { get; set; }
        public int? resourceId { get; set; }
        public bool accepter { get; set; }

        public virtual resource resource { get; set; }


    }
}
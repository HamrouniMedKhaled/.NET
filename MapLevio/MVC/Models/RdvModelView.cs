using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class RdvModelView
    {
        [Key]
        
        public int rdId { get; set; }

        [StringLength(255)]
        public string ClientNom { get; set; }

        [Column(TypeName = "bit")]
        public bool arch { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateInsert { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateRdv { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        public int etat { get; set; }
    }



}

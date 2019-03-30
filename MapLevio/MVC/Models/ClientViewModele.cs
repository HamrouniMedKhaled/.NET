using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class ClientViewModele
    {


        [Key]
        public int userId { get; set; }
        [StringLength(255)]
        public string email { get; set; }
        [StringLength(255)]
        public string password { get; set; }
        [StringLength(255)]
        public string nom { get; set; }
        [StringLength(255)]
        public string clientCategory { get; set; }

        [StringLength(255)]
        public string clientType { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateNaissance { get; set; }


    }
}
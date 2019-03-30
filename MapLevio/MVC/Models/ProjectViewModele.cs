using Domaine;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class ProjectViewModele
    {

        [Key]
        public int projectId { get; set; }

        [StringLength(255)]
        public string ProjectType { get; set; }

        [StringLength(255)]
        public string codePostal { get; set; }

        [StringLength(255)]
        public string pays { get; set; }

        [StringLength(255)]
        public string rue { get; set; }

        [StringLength(255)]
        public string ville { get; set; }

        [StringLength(255)]
        public string competence { get; set; }

        public DateTime? dateDebut { get; set; }

        public DateTime? dateFin { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public int nbrResource { get; set; }

        [StringLength(255)]
        public string photo { get; set; }

        [StringLength(255)]
        public string projectName { get; set; }

        public int? client { get; set; }

        public virtual client client1 { get; set; }
    }
}
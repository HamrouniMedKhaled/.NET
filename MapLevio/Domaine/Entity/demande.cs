namespace Domaine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("demande")]
    public partial class demande
    {
        [Key]
        public int idDemande { get; set; }

        [StringLength(255)]
        public string TestInteger { get; set; }

        [StringLength(255)]
        public string TestString { get; set; }

        public int? anneeExp { get; set; }

        [StringLength(255)]
        public string bac { get; set; }

        [StringLength(255)]
        public string competance { get; set; }

        public float cout { get; set; }

        [StringLength(255)]
        public string dateDebutMandat { get; set; }

        [StringLength(255)]
        public string dateDepot { get; set; }

        [StringLength(255)]
        public string dateFinMandat { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string diplome { get; set; }

        [StringLength(255)]
        public string directeur { get; set; }

        public int? duree { get; set; }

        [StringLength(255)]
        public string heureDepot { get; set; }

        [StringLength(255)]
        public string nomProjet { get; set; }
    }
}

namespace Domaine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("rendvous")]
    public partial class rendvous
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

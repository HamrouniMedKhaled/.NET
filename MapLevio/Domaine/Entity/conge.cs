namespace Domaine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("conge")]
    public partial class conge
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public conge()
        {
            resource1 = new HashSet<resource>();
        }

        [Key]
        public int idConge { get; set; }

        public DateTime? congeDebut { get; set; }

        public DateTime? congeFin { get; set; }

        public int? resourceId { get; set; }

        [Column(TypeName = "bit")]
        public bool accepter { get; set; }

        public virtual resource resource { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<resource> resource1 { get; set; }
    }
}

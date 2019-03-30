namespace Domaine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("test")]
    public partial class test
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public test()
        {
            passage = new HashSet<passage>();
            passage1 = new HashSet<passage>();
        }

        public int testId { get; set; }

        [Column(TypeName = "bit")]
        public bool? answer1 { get; set; }

        [Column(TypeName = "bit")]
        public bool? answer10 { get; set; }

        [Column(TypeName = "bit")]
        public bool? answer2 { get; set; }

        [Column(TypeName = "bit")]
        public bool? answer3 { get; set; }

        [Column(TypeName = "bit")]
        public bool? answer4 { get; set; }

        [Column(TypeName = "bit")]
        public bool? answer5 { get; set; }

        [Column(TypeName = "bit")]
        public bool? answer6 { get; set; }

        [Column(TypeName = "bit")]
        public bool? answer7 { get; set; }

        [Column(TypeName = "bit")]
        public bool? answer8 { get; set; }

        [Column(TypeName = "bit")]
        public bool? answer9 { get; set; }

        [StringLength(255)]
        public string q1 { get; set; }

        [StringLength(255)]
        public string q10 { get; set; }

        [StringLength(255)]
        public string q2 { get; set; }

        [StringLength(255)]
        public string q3 { get; set; }

        [StringLength(255)]
        public string q4 { get; set; }

        [StringLength(255)]
        public string q5 { get; set; }

        [StringLength(255)]
        public string q6 { get; set; }

        [StringLength(255)]
        public string q7 { get; set; }

        [StringLength(255)]
        public string q8 { get; set; }

        [StringLength(255)]
        public string q9 { get; set; }

        public int type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<passage> passage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<passage> passage1 { get; set; }
    }
}

namespace Domaine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("passage")]
    public partial class passage
    {
       [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public passage()
        {
            candidate1 = new HashSet<candidate>();
            test1 = new HashSet<test>();
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TestId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int candidateId { get; set; }

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
       
       
        public DateTime dateOfPassing { get; set; }

        public int mark { get; set; }

        public virtual candidate candidate { get; set; }

        public virtual test test { get; set; }

       [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<candidate> candidate1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<test> test1 { get; set; }
    }
}

namespace Domaine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("message")]
    public partial class message
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public message()
        {
            user_message = new HashSet<user_message>();
            user_message1 = new HashSet<user_message>();
        }

        [Key]
        public int idMessage { get; set; }

        [StringLength(255)]
        public string body { get; set; }

        [StringLength(255)]
        public string dateEnvoi { get; set; }

        public int? isArchive { get; set; }

        public int? lu { get; set; }

        [StringLength(255)]
        public string messageCible { get; set; }

        [StringLength(255)]
        public string messageType { get; set; }

        public int? receiver { get; set; }

        public int? sender { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_message> user_message { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_message> user_message1 { get; set; }
    }
}

using Domaine;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Passage
    {
        public Passage()
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

        public bool? answer1 { get; set; }

        public bool? answer10 { get; set; }

        public bool? answer2 { get; set; }

        public bool? answer3 { get; set; }

        public bool? answer4 { get; set; }

        public bool? answer5 { get; set; }

        public bool? answer6 { get; set; }

        public bool? answer7 { get; set; }

        
        public bool? answer8 { get; set; }

   
        public bool? answer9 { get; set; }
      
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? dateOfPassing { get; set; }

        public int mark { get; set; }

        public virtual candidate candidate { get; set; }

        public virtual test test { get; set; }

        public virtual ICollection<candidate> candidate1 { get; set; }

        public virtual ICollection<test> test1 { get; set; }
    }
}
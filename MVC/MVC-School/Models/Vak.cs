using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_School.Models
{
    public class Vak
    {
        public int ID { get; set; }

        [MaxLength(40)]
        public string Naam { get; set; }

        [ForeignKey("Docent")]
        [Display(Name = "Docent")]
        public int DocentId { get; set; }

        // dit is de navigatie propperty
        public virtual Docent Docent { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_School.Models
{
    public class Docent
    {
        public int ID { get; set; }

        [MaxLength(20)]
        public string Voornaam { get; set; }

        [MaxLength(40)]
        public string Achternaam { get; set; }

        [ForeignKey("Locatie")]
        public int LocatieId { get; set; }

        // dit is de navigatie propperty
        public virtual Locatie Locatie { get; set; }
    }
}

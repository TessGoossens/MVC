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
        /*public int ID { get; set; }

        [MaxLength(20)]
        public string Voornaam { get; set; }

        [MaxLength(40)]
        public string Achternaam { get; set; }

        [ForeignKey("Locatie")]
        [Display(Name = "Locatie")]
        public int LocatieId { get; set; }

        // dit is de navigatie propperty
        public virtual Locatie Locatie { get; set; }

        [ForeignKey("Vak")]
        public int VakId { get; internal set; }
        */
        public Docent()
        {
            Vakken = new HashSet<Vak>();
        }
        [Key]
        public int ID { get; set; }

        [StringLength(20)]
        public string Voornaam { get; set; }

        [StringLength(40)]
        public string Achternaam { get; set; }

        [ForeignKey("Locatie")]
        [Display(Name = "Locatie")]
        public int LocatieId { get; set; }

        public virtual Locatie Locatie { get; set; }

        public ICollection<Vak> Vakken { get; set; }
        public int VakId { get; internal set; }
        //public int DocentId { get; internal set; }
    }
}

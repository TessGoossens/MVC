using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVC_School.Models
{
    public class Locatie
    {
        public Locatie()
        {
            Docenten = new HashSet<Docent>();
        }
        public int ID { get; set; }

        [MaxLength(20)]
        public string Naam { get; set; }

        [MaxLength(40)]
        public string Adres { get; set; }

        [MaxLength(40)]
        public string Woonplaats { get; set; }

        public ICollection<Docent> Docenten { get; set; }
    }
}

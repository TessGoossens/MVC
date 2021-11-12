using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVC_School.Models
{
    public class Student
    {
        public int ID { get; set; }

        [MaxLength(20)]
        public string Voornaam { get; set; }

        [MaxLength(40)]
        public string Achternaam { get; set; }

        [MaxLength(40)]
        public string Adres { get; set; }

        [MaxLength(40)]
        public string Woonplaats { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Models
{
    class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required, StringLength(15)]
        public string ProductName { get; set; }

        [Required, StringLength(15)]
        public string ProductSuppliers { get; set; }

        [Required, StringLength(15)]
        public string ProductsInStorrage { get; set; }
    }   
}

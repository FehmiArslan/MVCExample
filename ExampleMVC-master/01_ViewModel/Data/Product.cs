using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01_ViewModel.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desription { get; set; }
        public decimal Price { get;  set; }
        public int CategoryID { get; set; }

        public Category Category { get; set; }

        public List<Patlangac> Patlangacs { get; set; }

       

    }
}
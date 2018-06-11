using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team3CAS.Models
{
    public class Drug
    {
        public int DrugID { get; set; }
        public string Name { get; set; }
        public string Composition { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
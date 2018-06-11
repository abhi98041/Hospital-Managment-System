using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team3CAS.ViewModels
{
    public class CartViewModel
    {
        public int DrugID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
    }
}
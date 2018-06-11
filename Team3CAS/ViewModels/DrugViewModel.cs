﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Team3CAS.ViewModels
{
    public class DrugViewModel
    {
        public int DrugID { get; set; }
        [Required(ErrorMessage = "Drug name is required")]
        [StringLength(50, ErrorMessage = "Name should be above 3 chars and with in 50 chars", MinimumLength = 3)]
        [MaxLength(50, ErrorMessage = "Name should be within 50 char")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Composition is required")]
        public string Composition { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
    }

 }

using System;
using System.ComponentModel.DataAnnotations;

namespace SportsApp.Models
{
    public class ProductPriceGroup
    {
        public string PriceRange {get; set;}

        public int ProductCount { get; set; }
    }
}
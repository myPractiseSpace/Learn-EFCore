using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.Models
{
    [MetadataType(typeof(ProductsMD))]
    public partial class Products
    {
        public class ProductsMD
        {
            [Display(Name = "ProdID")]
            public int Id { get; set; }
            [Display(Name = "品名")]
            public string Name { get; set; }
            [Display(Name = "價格")]
            public decimal Price { get; set; }
        }
    }
}

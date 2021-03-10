using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreMVC.Models.EFCore
{
    public partial class Products
    {
        public Products()
        {
            ProductOrders = new HashSet<ProductOrders>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<ProductOrders> ProductOrders { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreMVC.Models.EFCore
{
    public partial class ProductOrders
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty(nameof(Orders.ProductOrders))]
        public virtual Orders Order { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty(nameof(Products.ProductOrders))]
        public virtual Products Product { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.Models
{
    public partial class Orders
    {
        public Orders()
        {
            ProductOrders = new HashSet<ProductOrders>();
        }

        [Key]
        public int Id { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime? OrderFulfilled { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customers.Orders))]
        public virtual Customers Customer { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<ProductOrders> ProductOrders { get; set; }
    }
}

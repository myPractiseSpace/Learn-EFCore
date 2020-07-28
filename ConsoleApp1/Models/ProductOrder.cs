namespace ConsoleApp1.Models
{
    public class ProductOrder
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public Order Order { get; set; }   //Navigation Property
        public Product Product { get; set; }   //Navigation Property 
    }
}
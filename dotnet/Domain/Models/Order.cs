namespace Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public required string UserName { get; set; }
        public int StockId { get; set; }
        public required string StockName { get; set; }
    }
}


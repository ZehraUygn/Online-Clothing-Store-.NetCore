namespace DataAccess.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; } = null!;
        public List<OrderDetails> Order_details { get; set; } = null!;
    }
}
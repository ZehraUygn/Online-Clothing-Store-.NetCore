using DataAccess.Entities;

namespace Business.Models
{
    public class OrderDto
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public List<OrderDetails> Order_details;

    }
}

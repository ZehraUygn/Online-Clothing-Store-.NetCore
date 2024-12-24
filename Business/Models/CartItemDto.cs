
using DataAccess.Entities;

namespace Business.Models
{
    public class CartItemDto
    {
            public int Id { get; set; }
            public int CartId { get; set; }
            public int ProductId { get; set; }
            public string Size { get; set; } = string.Empty;
            public decimal Price { get; set; }
            public string Color { get; set; } = string.Empty;
            public int Quantity { get; set; }
    
    }
}

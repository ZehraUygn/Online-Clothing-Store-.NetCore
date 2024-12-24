using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; } 
        public int ProductId{ get; set; }
        public Product Product { get; set; } = null!;
        public string Size { get; set; } = null!;
        public decimal Price { get; set; }                              
        public string Color { get; set; } = null!;
        public int Quantity { get; set; }
    }
}

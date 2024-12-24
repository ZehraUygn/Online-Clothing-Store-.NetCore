using System;
using System.Collections.Generic;


namespace DataAccess.Entities
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public  Category category{ get; set; }
        public DateTime Created_At { get; set; }
        public int Stock_Quantity { get; set; }

    }
}

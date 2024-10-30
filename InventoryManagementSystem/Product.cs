using System;

namespace InventoryManagementSystem
{
    internal class Product
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public DateTime LastRestocked { get; set; }
    }
}

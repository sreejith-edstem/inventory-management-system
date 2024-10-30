using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    internal class Product
    {
        public string ProductId { get; set; }  // Format: XXX-999
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public DateTime LastRestocked { get; set; }
    }
}

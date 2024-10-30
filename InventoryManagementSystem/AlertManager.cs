using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    internal class AlertManager
    {
        private List<Product> products;

        public AlertManager(List<Product> products)
        {
            this.products = products;
        }

        public void CheckLowStock()
        {
            var lowStockProducts = products.Where(p => p.Quantity < 5);
            foreach (var product in lowStockProducts)
            {
                Console.WriteLine(
                    $"Low stock alert: {product.ProductId} - {product.Name} - {product.Quantity} items left.");
            }
        }

        public void CheckOutOfStock()
        {
            var outOfStockProducts = products.Where(p => p.Quantity == 0);
            foreach (var product in outOfStockProducts)
            {
                Console.WriteLine($"Out of stock alert: {product.ProductId} - {product.Name}.");
            }
        }

        public void CheckHighValueItems()
        {
            var highValueProducts = products.Where(p => p.Price > 1000);
            foreach (var product in highValueProducts)
            {
                Console.WriteLine($"High value item alert: {product.ProductId} - {product.Name} - {product.Price:C}.");
            }
        }

        public void DailyInventorySummary()
        {
            Console.WriteLine("Daily Inventory Summary:");
            foreach (var product in products)
            {
                Console.WriteLine(
                    $"{product.ProductId} - {product.Name} - {product.Quantity} - {product.Price:C} - {product.Category} - Last Restocked: {product.LastRestocked}");
            }

            Console.WriteLine($"Total Inventory Value: {products.Sum(p => p.Price * p.Quantity):C}");
        }
    }
}

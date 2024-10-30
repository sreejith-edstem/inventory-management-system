using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    internal class InventoryReporter
    {
        private List<Product> products;
        public InventoryReporter(List<Product> products)
        {
            this.products = products;
        }
        public void ListAllProducts()
        {
            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductId} - {product.Name} - {product.Quantity} - {product.Price:C} - {product.Category} - Last Restocked: {product.LastRestocked}");
            }
        }
        public void FilterByCategory(Category category)
        {
            var filteredProducts = products.Where(p => p.Category == category);
            foreach (var product in filteredProducts)
            {
                Console.WriteLine($"{product.ProductId} - {product.Name} - {product.Quantity} - {product.Price:C} - {product.Category} - Last Restocked: {product.LastRestocked}");
            }
        }
        public void FilterByPriceRange(decimal minPrice, decimal maxPrice)
        {
            var filteredProducts = products.Where(p => p.Price >= minPrice && p.Price <= maxPrice);
            foreach (var product in filteredProducts)
            {
                Console.WriteLine($"{product.ProductId} - {product.Name} - {product.Quantity} - {product.Price:C} - {product.Category} - Last Restocked: {product.LastRestocked}");
            }
        }
    }
}

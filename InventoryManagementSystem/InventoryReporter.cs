using System;
using System.Collections.Generic;
using System.Linq;

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
            Console.WriteLine("ID      Name            Qty   Price   Category    Last Restocked");
            Console.WriteLine("-----------------------------------------------------------");
            foreach (var product in products)
            {
                Console.WriteLine(
                    $"{product.ProductId} {product.Name.PadRight(15)} {product.Quantity.ToString().PadRight(5)} {product.Price.ToString("C").PadRight(8)} {product.Category.ToString().PadRight(12)} {product.LastRestocked.ToShortDateString()}");
            }
        }

        public void FilterByCategory(Category category)
        {
            var filteredProducts = products.Where(p => p.Category == category);
            foreach (var product in filteredProducts)
            {
                Console.WriteLine(
                    $"{product.ProductId} - {product.Name} - {product.Quantity} - {product.Price:C} - {product.Category} - Last Restocked: {product.LastRestocked}");
            }
        }

        public void FilterByPriceRange(decimal minPrice, decimal maxPrice)
        {
            var filteredProducts = products.Where(p => p.Price >= minPrice && p.Price <= maxPrice);
            foreach (var product in filteredProducts)
            {
                Console.WriteLine(
                    $"{product.ProductId} - {product.Name} - {product.Quantity} - {product.Price:C} - {product.Category} - Last Restocked: {product.LastRestocked}");
            }
        }

        public void FilterByStockLevel(int minStock, int maxStock)
        {
            var filteredProducts = products.Where(p => p.Quantity >= minStock && p.Quantity <= maxStock);
            foreach (var product in filteredProducts)
            {
                Console.WriteLine(
                    $"{product.ProductId} - {product.Name} - {product.Quantity} - {product.Price:C} - {product.Category} - Last Restocked: {product.LastRestocked}");
            }
        }

        public void SortByName()
        {
            var sortedProducts = products.OrderBy(p => p.Name);
            foreach (var product in sortedProducts)
            {
                Console.WriteLine(
                    $"{product.ProductId} - {product.Name} - {product.Quantity} - {product.Price:C} - {product.Category} - Last Restocked: {product.LastRestocked}");
            }
        }

        public void SortByQuantity()
        {
            var sortedProducts = products.OrderBy(p => p.Quantity);
            foreach (var product in sortedProducts)
            {
                Console.WriteLine(
                    $"{product.ProductId} - {product.Name} - {product.Quantity} - {product.Price:C} - {product.Category} - Last Restocked: {product.LastRestocked}");
            }
        }

        public void SortByPrice()
        {
            var sortedProducts = products.OrderBy(p => p.Price);
            foreach (var product in sortedProducts)
            {
                Console.WriteLine(
                    $"{product.ProductId} - {product.Name} - {product.Quantity} - {product.Price:C} - {product.Category} - Last Restocked: {product.LastRestocked}");
            }
        }

        public void SortByLastRestockDate()
        {
            var sortedProducts = products.OrderBy(p => p.LastRestocked);
            foreach (var product in sortedProducts)
            {
                Console.WriteLine(
                    $"{product.ProductId} - {product.Name} - {product.Quantity} - {product.Price:C} - {product.Category} - Last Restocked: {product.LastRestocked}");
            }
        }
    }
}

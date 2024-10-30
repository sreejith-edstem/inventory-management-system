using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagementSystem
{
    internal class InventoryManager
    {
        private List<Product> products = new List<Product>();
        private ProductValidator validator = new ProductValidator();
        public List<Product> GetProducts() => products;

        public void AddProduct(Product product)
        {
            if (validator.ValidateProduct(product))
            {
                products.Add(product);
                Console.WriteLine("Product added successfully.");
            }
        }

        public void UpdateProduct(string productId, Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null && validator.ValidateProduct(updatedProduct))
            {
                product.Name = updatedProduct.Name;
                product.Quantity = updatedProduct.Quantity;
                product.Price = updatedProduct.Price;
                product.Category = updatedProduct.Category;
                product.LastRestocked = updatedProduct.LastRestocked;
                Console.WriteLine("Product updated successfully.");
            }
            else
            {
                Console.WriteLine("Product not found or invalid data.");
            }
        }

        public void RemoveProduct(string productId)
        {
            var product = products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                products.Remove(product);
                Console.WriteLine("Product removed successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public void IncreaseStock(string productId, int amount)
        {
            var product = products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null && amount > 0)
            {
                product.Quantity += amount;
                product.LastRestocked = DateTime.Now;
                Console.WriteLine("Stock increased successfully.");
            }
            else
            {
                Console.WriteLine("Product not found or invalid amount.");
            }
        }

        public void DecreaseStock(string productId, int amount)
        {
            var product = products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null && amount > 0 && product.Quantity >= amount)
            {
                product.Quantity -= amount;
                Console.WriteLine("Stock decreased successfully.");
            }
            else
            {
                Console.WriteLine("Product not found, invalid amount, or insufficient stock.");
            }
        }

        public decimal CalculateTotalInventoryValue()
        {
            return products.Sum(p => p.Price * p.Quantity);
        }
    }
}

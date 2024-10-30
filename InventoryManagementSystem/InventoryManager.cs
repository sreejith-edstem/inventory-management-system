using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    internal class InventoryManager
    {
        private List<Product> products = new List<Product>();
        public void AddProduct(Product product)
        {
            if (ValidateProduct(product))
            {
                products.Add(product);
                Console.WriteLine("Product added successfully.");
            }
        }
        public void UpdateProduct(string productId, Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null && ValidateProduct(updatedProduct))
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
        private bool ValidateProduct(Product product)
        {
            if (string.IsNullOrEmpty(product.ProductId) || !System.Text.RegularExpressions.Regex.IsMatch(product.ProductId, @"^[A-Z]{3}-\d{3}$"))
            {
                Console.WriteLine("Invalid ProductId format.");
                return false;
            }
            if (string.IsNullOrEmpty(product.Name) || product.Name.Length < 3 || product.Name.Length > 50)
            {
                Console.WriteLine("Invalid Name length.");
                return false;
            }
            if (product.Quantity < 0)
            {
                Console.WriteLine("Quantity cannot be negative.");
                return false;
            }
            if (product.Price < 0.01m || product.Price > 10000.00m)
            {
                Console.WriteLine("Price must be between $0.01 and $10000.00.");
                return false;
            }
            if (!Enum.IsDefined(typeof(Category), product.Category))
            {
                Console.WriteLine("Invalid Category.");
                return false;
            }
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    internal class ProductValidator
    {
        public bool ValidateProduct(Product product)
        {
            if (string.IsNullOrEmpty(product.ProductId) || !Regex.IsMatch(product.ProductId, @"^[A-Z]{3}-\d{3}$"))
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

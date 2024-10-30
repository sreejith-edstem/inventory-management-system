using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InventoryManager inventoryManager = new InventoryManager();
            List<Product> products = inventoryManager.GetProducts();
            InventoryReporter inventoryReporter = new InventoryReporter(products);
            AlertManager alertManager = new AlertManager(products);
            while (true)
            {
                Console.WriteLine("=== Inventory Management System ===");
                Console.WriteLine("1. View Inventory");
                Console.WriteLine("2. Add Product");
                Console.WriteLine("3. Update Stock");
                Console.WriteLine("4. Generate Reports");
                Console.WriteLine("5. View Alerts");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Enter choice (1-6): ");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        ViewInventory(inventoryReporter, alertManager, inventoryManager);
                        break;
                    case 2:
                        AddProduct(inventoryManager);
                        break;
                    case 3:
                        UpdateStock(inventoryManager);
                        break;
                    case 4:
                        GenerateReports(inventoryReporter);
                        break;
                    case 5:
                        ViewAlerts(alertManager);
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;

                }
            }
        }

        static void ViewInventory(InventoryReporter inventoryReporter, AlertManager alertManager, InventoryManager inventoryManager)
        {
            inventoryReporter.ListAllProducts();
            alertManager.CheckLowStock();
            Console.WriteLine($"Total Inventory Value: {inventoryManager.CalculateTotalInventoryValue():C}");
            Console.Write("Enter product ID to view details or 'M' for menu: ");
            String input = Console.ReadLine();
            if (input.ToUpper() == "M")
            {
                return;
            }
            else
            {
                var product = inventoryManager.GetProducts().FirstOrDefault(p => p.ProductId == input);
                if (product != null)
                {
                    Console.WriteLine($"Product Details: {product.ProductId} - {product.Name} - {product.Quantity} - {product.Price:C} - {product.Category} - Last Restocked: {product.LastRestocked}");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
        }

        static void AddProduct(InventoryManager inventoryManager)
        {
            Console.Write("Enter ProductId (XXX-999): ");
            String productId = Console.ReadLine();
            Console.Write("Enter Name: ");
            String name = Console.ReadLine();
            Console.Write("Enter Quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            Console.Write("Enter Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Category (Electronics, Clothing, Food, Books)");
            Category category = (Category)Enum.Parse(typeof(Category), Console.ReadLine());
            DateTime lastRestocked = DateTime.Now;
            Product product = new Product()
            {
                ProductId = productId,
                Name = name,
                Quantity = quantity,
                Price = price,
                Category = category,
                LastRestocked = lastRestocked
            };
            inventoryManager.AddProduct(product);
        }

        static void UpdateStock(InventoryManager inventoryManager)
        {
            Console.Write("Enter ProductId to update stock: ");
            String productId = Console.ReadLine();
            Console.Write("Enter amount to increase (positive) or decrease (negative): ");
            int amount = int.Parse(Console.ReadLine());
            if (amount > 0)
            {
                inventoryManager.IncreaseStock(productId, amount);
            }
            else
            {
                inventoryManager.DecreaseStock(productId, -amount);
            }
        }

        static void GenerateReports(InventoryReporter inventoryReporter)
        {
            Console.WriteLine("Generate Reports:");
            Console.WriteLine("1. Filter by Category");
            Console.WriteLine("2. Filter by Price Range");
            Console.WriteLine("3. Filter by Stock Level");
            Console.WriteLine("4. Sort by Name");
            Console.WriteLine("5. Sort by quantity");
            Console.WriteLine("6. Sort by price");
            Console.WriteLine("7. Sort by Last Restock Date");
            Console.Write("Select an option: ");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.Write("Enter Category (Electronics, Clothing, Food, Books): ");
                    Category category = (Category)Enum.Parse(typeof(Category), Console.ReadLine());
                    inventoryReporter.FilterByCategory(category);
                    break;
                case 2:
                    Console.Write("Enter minimum price: ");
                    decimal minPrice = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter maximum price: ");
                    decimal maxPrice = decimal.Parse(Console.ReadLine());
                    inventoryReporter.FilterByPriceRange(minPrice, maxPrice);
                    break;
                case 3:
                    Console.Write("Enter minimum stock level: ");
                    int minStock = int.Parse(Console.ReadLine());
                    Console.Write("Enter maximum stock level: ");
                    int maxStock = int.Parse(Console.ReadLine());
                    inventoryReporter.FilterByStockLevel(minStock, maxStock);
                    break;
                case 4:
                    inventoryReporter.SortByName();
                    break;
                case 5:
                    inventoryReporter.SortByQuantity();
                    break;
                case 6:
                    inventoryReporter.SortByPrice();
                    break;
                case 7:
                    inventoryReporter.SortByLastRestockDate();
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
        static void ViewAlerts(AlertManager alertManager)
        {
            Console.WriteLine("View Alerts:");
            Console.WriteLine("1. Low Stock");
            Console.WriteLine("2. Out of Stock");
            Console.WriteLine("3. High Value Items");
            Console.Write("Select an option: ");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    alertManager.CheckLowStock();
                    break;
                case 2:
                    alertManager.CheckOutOfStock();
                    break;
                case 3:
                    alertManager.CheckHighValueItems();
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}

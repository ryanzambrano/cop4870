using System;
using System.Collections.Generic;

namespace MyApp.Services
{
    public class Menu
    {
        private readonly List<string> _inventory;

        public Menu()
        {
            _inventory = new List<string>();
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Amazon!");
                Console.WriteLine("------------------");
                Console.WriteLine("C. Create new inventory item");
                Console.WriteLine("R. Read all inventory items");
                Console.WriteLine("U. Update an inventory item");
                Console.WriteLine("D. Delete an inventory item");
                Console.WriteLine("Q. Quit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine()?.ToUpper();

                switch (choice)
                {
                    case "C":
                        CreateInventoryItem();
                        break;
                    case "R":
                        ReadInventoryItems();
                        break;
                    case "U":
                        UpdateInventoryItem();
                        break;
                    case "D":
                        DeleteInventoryItem();
                        break;
                    case "Q":
                        Console.WriteLine("Exiting the application. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void CreateInventoryItem()
        {
            Console.Write("Enter the name of the new inventory item: ");
            string newItem = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newItem))
            {
                _inventory.Add(newItem);
                Console.WriteLine($"'{newItem}' has been added to the inventory.");
            }
            else
            {
                Console.WriteLine("Item name cannot be empty.");
            }

            //Console.WriteLine("Press Enter to return to the menu...");
            //Console.ReadLine();
        }

        private void ReadInventoryItems()
        {
            Console.WriteLine("Inventory Items:");
            if (_inventory.Count == 0)
            {
                Console.WriteLine("No items in the inventory.");
            }
            else
            {
                for (int i = 0; i < _inventory.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_inventory[i]}");
                }
            }

            Console.WriteLine("Press Enter to return to the menu...");
            Console.ReadLine();
        }

        private void UpdateInventoryItem()
        {
            Console.WriteLine("Which product would you like to update?");
            ReadInventoryItems();

            Console.Write("Enter the number of the product to update: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _inventory.Count)
            {
                Console.Write("Enter the new name for the product: ");
                string newName = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(newName))
                {
                    _inventory[index - 1] = newName;
                    Console.WriteLine($"Product {index} has been updated to '{newName}'.");
                }
                else
                {
                    Console.WriteLine("Item name cannot be empty.");
                }
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }

            Console.WriteLine("Press Enter to return to the menu...");
            Console.ReadLine();
        }

        private void DeleteInventoryItem()
        {
            Console.WriteLine("Which product would you like to delete?");
            ReadInventoryItems();

            Console.Write("Enter the number of the product to delete: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _inventory.Count)
            {
                Console.WriteLine($"Product '{_inventory[index - 1]}' has been deleted.");
                _inventory.RemoveAt(index - 1);
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }

            Console.WriteLine("Press Enter to return to the menu...");
            Console.ReadLine();
        }
    }
}

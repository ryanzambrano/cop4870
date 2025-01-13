using System;
using MyApp.Models; // Import the namespace where the Product class is located


namespace MyApp
{
class Program
{
    static void Main(string[] args)
    {
        // Create an instance of your Test class
        Test testObject = new Test();
        
        // Call methods from your Test class
        testObject.YourMethod();

        Product product = new Product();
            
            // Set the Name property of the Product instance
        product.Name = "Sample Product";

            // Output the Name property to the console
        Console.WriteLine("Product Name: " + product.Name);
    }
}
}
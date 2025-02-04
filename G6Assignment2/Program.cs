using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace G6Assignment2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter Product ID(5 to 500):");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Product Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Product Price(10 to 5000):");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter Stock Amount(1 to 1000):");
            int stock = Convert.ToInt32(Console.ReadLine());

            Product product = new Product(id, name, price, stock);

            // Check if product was successfully created
            if (product.ProdID != 0)
            {
                Console.WriteLine($"Product Created: {product.ProdName}, Price: {product.ItemPrice}, Stock: {product.StockAmount}");

                Console.WriteLine("Enter the amount to increase stock:");
                int increase = Convert.ToInt32(Console.ReadLine());
                product.IncreaseStock(increase);

                Console.WriteLine("Enter the amount to decrease stock:");
                int decrease = Convert.ToInt32(Console.ReadLine());
                product.DecreaseStock(decrease);
            }
        }
    }
}

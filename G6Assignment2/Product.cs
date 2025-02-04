using System;

namespace G6Assignment2
{
    public class Product
    {
        public int ProdID { get; set; }
        public string ProdName { get; set; }
        public decimal ItemPrice { get; set; }
        public int StockAmount { get; set; }

        // Created Product Constructor
        public Product(int prodID, string prodName, decimal itemPrice, int stockAmount)
        {
            // Validate Product ID
            if (prodID < 5 || prodID > 50000)
            {
                Console.WriteLine("Error: Product ID must be between 5 and 50000.");
                return;
            }

            // Validate Item Price
            if (itemPrice < 5 || itemPrice > 5000)
            {
                Console.WriteLine("Error: Price must be between $5 and $5000.");
                return;
            }

            // Validate Stock Amount
            if (stockAmount < 5 || stockAmount > 500000)
            {
                Console.WriteLine("Error: Stock must be between 5 and 500000.");
                return;
            }

            // Validate Product Name
            if (string.IsNullOrWhiteSpace(prodName))
            {
                Console.WriteLine("Error: Product name cannot be empty.");
                return;
            }

            // Assign values if all validations pass
            ProdID = prodID;
            ProdName = prodName;
            ItemPrice = itemPrice;
            StockAmount = stockAmount;
        }

        // Method to increase stock
        public void IncreaseStock(int amount)
        {
            if (amount > 0)
            {
                StockAmount += amount;
                Console.WriteLine($"Stock increased by {amount}. New stock: {StockAmount}");
            }
            else
            {
                Console.WriteLine("Error: Increase amount must be greater than 0.");
            }
        }

        // Method to decrease stock
        public void DecreaseStock(int amount)
        {
            if (amount > 0)
            {
                if (StockAmount - amount >= 0)
                {
                    StockAmount -= amount;
                    Console.WriteLine($"Stock decreased by {amount}. New stock: {StockAmount}");
                }
                else
                {
                    Console.WriteLine("Error: Stock cannot go below 0.");
                }
            }
            else
            {
                Console.WriteLine("Error: Decrease amount must be greater than 0.");
            }
        }
    }
}

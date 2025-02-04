using NUnit.Framework;
using G6Assignment2;
using System;

namespace G6Assignment2NUnitTest
{
    public class ProductUnitTests
    {
        private Product _product;

        [SetUp]
        public void Setup()
        {
            _product = new Product(10, "Apple", 100m, 50);
        }

        // Product ID Tests
        [TestCase(5)]
        [TestCase(250)]
        [TestCase(50000)]
        public void Product_Constructor_ValidProductID_ShouldCreateProduct(int prodID)
        {
            // Arrange
            string name = "Apple";
            decimal price = 100m;
            int stock = 50;

            // Act
            var product = new Product(prodID, name, price, stock);

            // Assert
            Assert.AreEqual(prodID, product.ProdID, "Product ID should match the given value.");
            Assert.IsTrue(product.ProdID >= 5 && product.ProdID <= 50000, "Product ID should be within the valid range.");
        }

        [TestCase(4)]
        [TestCase(50001)]
        public void Product_Constructor_InvalidProductID_ShouldNotCreateProduct(int prodID)
        {
            // Arrange
            string name = "Apple";
            decimal price = 100m;
            int stock = 50;

            // Act
            var product = new Product(prodID, name, price, stock);

            // Assert
            Assert.AreNotEqual(prodID, product.ProdID, "Invalid Product ID should not be assigned.");
        }

        // Product Name Tests
        [TestCase("Fresh Apple")]
        [TestCase("Green Apple")]
        public void Product_Constructor_ValidProductName_ShouldCreateProduct(string name)
        {
            // Arrange
            int prodID = 10;
            decimal price = 100m;
            int stock = 50;

            // Act
            var product = new Product(prodID, name, price, stock);

            // Assert
            Assert.AreEqual(name, product.ProdName);
            Assert.IsFalse(string.IsNullOrWhiteSpace(product.ProdName), "Product name should not be null or whitespace.");
        }

        [TestCase(" ")]
        public void Product_Constructor_InvalidProductName_ShouldNotCreateProduct(string name)
        {
            // Arrange
            int prodID = 10;
            decimal price = 100m;
            int stock = 50;

            // Act
            var product = new Product(prodID, name, price, stock);

            // Assert
            Assert.IsTrue(string.IsNullOrWhiteSpace(product.ProdName), "Product name should not be empty or whitespace.");
        }

        // Product Price Tests
        [TestCase(5)]
        public void Product_Constructor_ValidPrice_ShouldCreateProduct(decimal price)
        {
            // Arrange
            int prodID = 10;
            string name = "Apple";
            int stock = 50;

            // Act
            var product = new Product(prodID, name, price, stock);

            // Assert
            Assert.AreEqual(price, product.ItemPrice);
        }

        [TestCase(5001)]
        public void Product_Constructor_InvalidPrice_ShouldNotCreateProduct(decimal price)
        {
            // Arrange
            int prodID = 10;
            string name = "Apple";
            int stock = 50;

            // Act
            var product = new Product(prodID, name, price, stock);

            // Assert
            Assert.AreNotEqual(price, product.ItemPrice, "Invalid price should not be assigned.");
        }

        // Stock Amount Tests
        [TestCase(5)]
        [TestCase(500000)]
        public void Product_Constructor_ValidStock_ShouldCreateProduct(int stock)
        {
            // Arrange
            int prodID = 10;
            string name = "Apple";
            decimal price = 100m;

            // Act
            var product = new Product(prodID, name, price, stock);

            // Assert
            Assert.AreEqual(stock, product.StockAmount);
        }

        [TestCase(4)]
        public void Product_Constructor_InvalidStock_ShouldNotCreateProduct(int stock)
        {
            // Arrange
            int prodID = 10;
            string name = "Apple";
            decimal price = 100m;

            // Act
            var product = new Product(prodID, name, price, stock);

            // Assert
            Assert.AreNotEqual(stock, product.StockAmount, "Invalid stock amount should not be assigned.");
        }

        // Increase Stock Tests
        [TestCase(10000)]
        public void IncreaseStock_ValidAmount_ShouldIncreaseStock(int amount)
        {
            // Arrange
            int initialStock = _product.StockAmount;

            // Act
            _product.IncreaseStock(amount);

            // Assert
            Assert.AreEqual(initialStock + amount, _product.StockAmount);
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void IncreaseStock_InvalidAmount_ShouldNotChangeStock(int amount)
        {
            // Arrange
            int initialStock = _product.StockAmount;

            // Act
            _product.IncreaseStock(amount);

            // Assert
            Assert.AreEqual(initialStock, _product.StockAmount);
        }

        // Decrease Stock Tests
        [TestCase(10)]
        public void DecreaseStock_ValidAmount_ShouldDecreaseStock(int amount)
        {
            // Arrange
            int initialStock = _product.StockAmount;

            // Act
            _product.DecreaseStock(amount);

            // Assert
            Assert.AreEqual(initialStock - amount, _product.StockAmount);
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void DecreaseStock_InvalidAmount_ShouldNotChangeStock(int amount)
        {
            // Arrange
            int initialStock = _product.StockAmount;

            // Act
            _product.DecreaseStock(amount);

            // Assert
            Assert.AreEqual(initialStock, _product.StockAmount);
        }

        [TestCase(51)]
        public void DecreaseStock_StockBelowZero_ShouldNotChangeStock(int amount)
        {
            // Arrange
            int initialStock = _product.StockAmount;

            // Act
            _product.DecreaseStock(amount);

            // Assert
            Assert.IsFalse(_product.StockAmount < 0, "Stock should not go below zero.");
        }
    }
}

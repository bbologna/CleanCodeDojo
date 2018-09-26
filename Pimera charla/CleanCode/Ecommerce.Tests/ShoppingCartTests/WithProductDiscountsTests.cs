using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;

namespace Ecommerce.Tests.ShoppingCartTests
{
    /*
    Test cases:
        01) Calculate 2 products with discount, both in dollars, expect currency dollars.
        02) Calculate 2 products with discount, both in dollars, expect currency pesos.
        03) Calculate 2 products without discount, one in dollars, one in pesos, expect currency dollars.
        04) Calculate 2 products without discount, one in dollars, one in pesos, expect currency pesos.
        05) Calculate 3 products without discount, one in dollars, one in pesos, one in dollars, expect currency pesos.
        06) Calculate 3 products without discount, one in dollars, one in pesos, one in dollars, expect currency pesos.
    */
    [TestClass]
    public class WithDiscountsTests
    {
        [TestMethod]
        public void WithProductDiscount_01()
        {
            ISystemData dateSystem = Substitute.For<ISystemData>();
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 8, 16));

            //Arrange
            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 200m, Currency = Currency.Dollar, DiscountPercentage = 50 }, // 100 Dolares
                    new Product() { Price = 100m, Currency = Currency.Dollar }  // 100 Dolares
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(0); // Espero el precio en dolares

            //Assert
            Assert.AreEqual(200m, totalPrice);
        }

        [TestMethod]
        public void WithProductDiscount_02()
        {
            ISystemData dateSystem = Substitute.For<ISystemData>();
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 8, 16));

            //Arrange
            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 200m, Currency = Currency.Dollar, DiscountPercentage = 50 }, // 200 Dolares, descuento del 50%
                    new Product() { Price = 200m, Currency = Currency.Dollar, DiscountPercentage = 50 }  // 200 Dolares, descuento del 50%
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(Currency.Peso); // Espero el precio en pesos

            //Assert
            Assert.AreEqual(6600, totalPrice);
        }

        [TestMethod]
        public void WithProductDiscount_03()
        {
            ISystemData dateSystem = Substitute.For<ISystemData>();
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 8, 16));

            //Arrange
            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 100m, Currency = Currency.Dollar }, // 100 Dolares
                    new Product() { Price = 3400, Currency = Currency.Peso, DiscountPercentage = 20 } // 3100 Pesos, descuento del 20%
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(0); // Espero el precio en dolares

            //Assert
            Assert.AreEqual(180, totalPrice);
        }

        [TestMethod]
        public void WithProductDiscount_04()
        {
            ISystemData dateSystem = Substitute.For<ISystemData>();
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 8, 16));

            //Arrange
            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 3100m, Currency = Currency.Peso, DiscountPercentage = 20 }, // 3100 Pesos, descuento del 20%
                    new Product() { Price = 100, Currency = Currency.Dollar, DiscountPercentage = 10 } // 100 Dolares, descuento del 10%
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(Currency.Peso); // Espero el precio en pesos

            //Assert
            Assert.AreEqual(5450, totalPrice);
        }

        [TestMethod]
        public void WithProductDiscount_05()
        {
            ISystemData dateSystem = Substitute.For<ISystemData>();
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 8, 16));

            //Arrange
            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 3100m, Currency = Currency.Peso }, // 3100 Pesos
                    new Product() { Price = 100, Currency = Currency.Dollar, DiscountPercentage = 10 }, // 100 Dolares
                    new Product() { Price = 150, Currency = Currency.Dollar, DiscountPercentage = 10 } // 150 Dolares
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(Currency.Peso); // Espero el precio en pesos

            //Assert
            Assert.AreEqual(10525, totalPrice);
        }

        [TestMethod]
        public void WithProductDiscount_06()
        {
            ISystemData dateSystem = Substitute.For<ISystemData>();
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 8, 16));

            //Arrange
            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 3400m, Currency = Currency.Peso, DiscountPercentage = 15 }, // 3100 Pesos
                    new Product() { Price = 100, Currency = Currency.Dollar }, // 100 Dolares
                    new Product() { Price = 150, Currency = Currency.Dollar } // 150 Dolares
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(Currency.Dollar); // Espero el precio en dolares

            //Assert
            Assert.AreEqual(335, totalPrice);
        }
    }
}

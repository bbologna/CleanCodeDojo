﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Ecommerce.Tests.ShoppingCartTests
{
    /*
    Test cases:
        01) Calculate 2 products without discount, both in dollars, expect currency dollars.
        02) Calculate 2 products without discount, both in dollars, expect currency pesos.
        03) Calculate 2 products without discount, one in dollars, one in pesos, expect currency dollars.
        04) Calculate 2 products without discount, one in dollars, one in pesos, expect currency pesos.
        05) Calculate 3 products without discount, one in dollars, one in pesos, one in dollars, expect currency pesos.
        06) Calculate 3 products without discount, one in dollars, one in pesos, one in dollars, expect currency pesos.
    */
    [TestClass]
    public class WithoutDiscountTests
    {
        [TestMethod]
        public void WithoutDiscount_01()
        {
            ISystemData dateSystem = Substitute.For<ISystemData>();
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 8, 16));

            //Arrange
            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 100m, Currency = 0 }, // 100 Dolares
                    new Product() { Price = 100m, Currency = 0 }  // 100 Dolares
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(0); // Espero el precio en dolares

            //Assert
            Assert.AreEqual(200m, totalPrice);
        }

        [TestMethod]
        public void WithoutDiscount_02()
        {
            ISystemData dateSystem = Substitute.For<ISystemData>();
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 8, 16));

            //Arrange
            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 100m, Currency = 0 }, // 100 Dolares
                    new Product() { Price = 100m, Currency = 0 }  // 100 Dolares
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(1); // Espero el precio en pesos

            //Assert
            Assert.AreEqual(6200, totalPrice);
        }

        [TestMethod]
        public void WithoutDiscount_03()
        {
            ISystemData dateSystem = Substitute.For<ISystemData>();
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 8, 16));

            //Arrange
            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 100m, Currency = 0 }, // 100 Dolares
                    new Product() { Price = 3100, Currency = 1 } // 3100 Pesos
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(0); // Espero el precio en dolares

            //Assert
            Assert.AreEqual(200, totalPrice);
        }

        [TestMethod]
        public void WithoutDiscount_04()
        {
            ISystemData dateSystem = Substitute.For<ISystemData>();
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 8, 16));

            //Arrange
            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 3100m, Currency = 1 }, // 3100 Pesos
                    new Product() { Price = 100, Currency = 0 } // 100 Dolares
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(1); // Espero el precio en pesos

            //Assert
            Assert.AreEqual(6200, totalPrice);
        }

        [TestMethod]
        public void WithoutDiscount_05()
        {
            ISystemData dateSystem = Substitute.For<ISystemData>();
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 8, 16));

            //Arrange
            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 3100m, Currency = 1 }, // 3100 Pesos
                    new Product() { Price = 100, Currency = 0 }, // 100 Dolares
                    new Product() { Price = 150, Currency = 0 } // 150 Dolares
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(1); // Espero el precio en pesos

            //Assert
            Assert.AreEqual(10850, totalPrice);
        }

        [TestMethod]
        public void WithoutDiscount_06()
        {
            ISystemData dateSystem = Substitute.For<ISystemData>();
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 8, 16));

            //Arrange
            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 3100m, Currency = 1 }, // 3100 Pesos
                    new Product() { Price = 100, Currency = 0 }, // 100 Dolares
                    new Product() { Price = 150, Currency = 0 } // 150 Dolares
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(0); // Espero el precio en dolares

            //Assert
            Assert.AreEqual(350, totalPrice);
        }
    }
}

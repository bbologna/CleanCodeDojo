using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;

namespace Ecommerce.Tests.ShoppingCartTests
{

    /*
        Categories for fathers day:
            Afeitadoras, Herramientas, Vinos. Fathers day applies 10% discount. 
    */
    [TestClass]
    public class FathersDayDiscountTests
    {
        [TestMethod]
        public void WithFathersDayDiscount_01()
        {
            ISystemData dateSystem = Substitute.For<ISystemData>();
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 7, 7)); // Semana del padre

            //Arrange
            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 200m, Currency = 0, DiscountPercentage = 50 }, // 100 Dolares

                    // 100 Dolares, Aplica por no tener descuento previo y pertenecer a la categoria afeitadoras.
                    new Product() { Price = 100m, Currency = 0, Categories = new string[] { "Afeitadoras" } }
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(0); // Espero el precio en dolaress

            //Assert
            Assert.AreEqual(190m, totalPrice);
        }

        [TestMethod]
        public void WithFathersDayDiscount_01A()
        {
            ISystemData dateSystem = Substitute.For<ISystemData>();
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 7, 7)); // Semana del padre

            //Arrange
            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 200m, Currency = 0, DiscountPercentage = 50 }, // 100 Dolares

                    // 100 Dolares, Aplica por no tener descuento previo y pertenecer a la categoria afeitadoras.
                    // Si esta en dos categorias deberia aplicar el descuento una sola vez. 
                    new Product() { Price = 100m, Currency = 0, Categories = new string[] { "Afeitadoras", "Herramientas" } }
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(0); // Espero el precio en dolares

            //Assert
            Assert.AreEqual(190m, totalPrice);
        }

        [TestMethod]
        public void WithFathersDayDiscount_02()
        {
            ISystemData dateSystem = Substitute.For<ISystemData>();
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 7, 7)); // Semana del padre

            //Arrange
            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 200m, Currency = 0, DiscountPercentage = 10, Categories = new string[] { "Afeitadoras" } } , // 200 Dolares, descuento producto 10% + descuento dia del padre 10%
                    new Product() { Price = 200m, Currency = 0, DiscountPercentage = 10, Categories = new string[] { "Vinos" } } // 200 Dolares, descuento producto 10% + descuento dia del padre 10%
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(1); // Espero el precio en pesos

            //Assert
            Assert.AreEqual(9920, totalPrice);
        }

        [TestMethod]
        public void WithFathersDayDiscount_03()
        {
            ISystemData dateSystem = Substitute.For<ISystemData>();
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 7, 7)); // Semana del padre

            //Arrange
            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 100m, Currency = 0 }, // 100 Dolares
                    new Product() { Price = 3100, Currency = 1, DiscountPercentage = 20 } // 3100 Pesos, descuento del 20%
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(0); // Espero el precio en dolares

            //Assert
            Assert.AreEqual(180, totalPrice);
        }

        [TestMethod]
        public void WithFathersDayDiscount_04()
        {
            ISystemData dateSystem = Substitute.For<ISystemData>();
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 7, 7)); // Semana del padre

            //Arrange
            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 3100m, Currency = 1, DiscountPercentage = 20 }, // 3100 Pesos, descuento del 20%
                    new Product() { Price = 100, Currency = 0, DiscountPercentage = 10 } // 100 Dolares, descuento del 10%
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(1); // Espero el precio en pesos

            //Assert
            Assert.AreEqual(5270, totalPrice);
        }

        [TestMethod]
        public void WithFathersDayDiscount_05()
        {
            ISystemData dateSystem = Substitute.For<ISystemData>();
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 7, 7)); // Semana del padre

            //Arrange
            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 3100m, Currency = 1 }, // 3100 Pesos
                    new Product() { Price = 100, Currency = 0, DiscountPercentage = 10 }, // 100 Dolares
                    new Product() { Price = 150, Currency = 0, DiscountPercentage = 10 } // 150 Dolares
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(1); // Espero el precio en pesos

            //Assert
            Assert.AreEqual(10075, totalPrice);
        }

        [TestMethod]
        public void WithFathersDayDiscount_06()
        {
            ISystemData dateSystem = Substitute.For<ISystemData>();
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 7, 7)); // Semana del padre

            //Arrange
            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 3100m, Currency = 1, DiscountPercentage = 15 }, // 3100 Pesos
                    new Product() { Price = 100, Currency = 0 }, // 100 Dolares
                    new Product() { Price = 150, Currency = 0 } // 150 Dolares
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(0); // Espero el precio en dolares

            //Assert
            Assert.AreEqual(335, totalPrice);
        }
    }
}

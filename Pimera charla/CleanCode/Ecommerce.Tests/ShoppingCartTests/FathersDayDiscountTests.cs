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
        private ISystemData dateSystem;

        [TestInitialize]
        public void Initialize()
        {
            dateSystem = Substitute.For<ISystemData>();
            dateSystem.GetCurrencyCalculator().Returns<CurrencyCalculator>(new CurrencyCalculator(34, 33));
        }

        [TestMethod]
        public void TwoProducts_ShouldApplyDiscountOnlyToSecondProduct()
        {
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 7, 7)); // Semana del padre
            
            //Arrange
            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 200m, Currency = Currency.Dollar, DiscountPercentage = 50 }, // 100 Dolares

                    // 100 Dolares, Aplica por no tener descuento previo y pertenecer a la categoria afeitadoras.
                    new Product() { Price = 100m, Currency = Currency.Dollar, Categories = new string[] { "Afeitadoras" } }
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(Currency.Dollar); // Espero el precio en dolaress

            //Assert
            Assert.AreEqual(190m, totalPrice);
        }

        [TestMethod]
        public void WithFathersDayDiscount_01A()
        {
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 7, 7)); // Semana del padre

            //Arrange
            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 200m, Currency = Currency.Dollar, DiscountPercentage = 50 }, // 100 Dolares

                    // 100 Dolares, Aplica por no tener descuento previo y pertenecer a la categoria afeitadoras.
                    // Si esta en dos categorias deberia aplicar el descuento una sola vez. 
                    new Product() { Price = 100m, Currency = Currency.Dollar, Categories = new string[] { "Afeitadoras", "Herramientas" } }
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(Currency.Dollar); // Espero el precio en dolares

            //Assert
            Assert.AreEqual(190m, totalPrice);
        }

        [TestMethod]
        public void WithFathersDayDiscount_02()
        {
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 7, 7)); // Semana del padre

            //Arrange
            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 200m, Currency = Currency.Dollar, DiscountPercentage = 10, Categories = new string[] { "Afeitadoras" } } , // 200 Dolares, descuento producto 10% + descuento dia del padre 10%
                    new Product() { Price = 200m, Currency = Currency.Dollar, DiscountPercentage = 10, Categories = new string[] { "Vinos" } } // 200 Dolares, descuento producto 10% + descuento dia del padre 10%
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(Currency.Peso); // Espero el precio en pesos

            //Assert
            Assert.AreEqual(10560, totalPrice);
        }

        [TestMethod]
        public void WithFathersDayDiscount_03()
        {
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 7, 7)); // Semana del padre

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
            var totalPrice = shoppingCart.Buy(Currency.Dollar); // Espero el precio en dolares

            //Assert
            Assert.AreEqual(180, totalPrice);
        }

        [TestMethod]
        public void WithFathersDayDiscount_04()
        {
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 7, 7)); // Semana del padre

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
        public void WithFathersDayDiscount_05()
        {
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 7, 7)); // Semana del padre

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
        public void WithFathersDayDiscount_06()
        {
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 7, 7)); // Semana del padre

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

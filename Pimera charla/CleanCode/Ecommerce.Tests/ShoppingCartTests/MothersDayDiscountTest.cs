using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Tests.ShoppingCartTests
{
    [TestClass]
    public class MothersDayDiscountTest
    {

        [TestMethod]
        public void TwoProducts_ShouldApplyDiscountOnlyToOneProduct()
        {
            // Son Las Categorias => Flores, Bombones, Peluches.
            // Descuento => 15%.

            ISystemData dateSystem = Substitute.For<ISystemData>();
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 5, 10)); 

            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 200m, Currency = 0, DiscountPercentage = 50 }, // 100 Dolares

                    new Product() { Price = 100m, Currency = 0, Categories = new string[] { "Flores" } }
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(0); // Espero el precio en dolaress


            Assert.AreEqual(185m, totalPrice);
        }

        [TestMethod]
        public void OneProductWith15PercentDiscount_ShouldApply()
        {
            // Son Las Categorias => Flores, Bombones, Peluches.
            // Descuento => 15%.

            ISystemData dateSystem = Substitute.For<ISystemData>();
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 5, 10));

            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 100m, Currency = 0, Categories = new string[] { "Flores" } }
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(0); // Espero el precio en dolaress


            Assert.AreEqual(85m, totalPrice);
        }

        [TestMethod]
        public void OneProductNotMothersDayCategory_ShouldNotApplyDiscount()
        {
            // Son Las Categorias => Flores, Bombones, Peluches.
            // Descuento => 15%.

            ISystemData dateSystem = Substitute.For<ISystemData>();
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 5, 10)); 

            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 100m, Currency = 0, Categories = new string[] { "Pepe" } }
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(0); // Espero el precio en dolaress


            Assert.AreEqual(100m, totalPrice);
        }

        [TestMethod]
        public void OneProductNotMothersDayWeek_ShouldNotApplyDiscount()
        {
            // Son Las Categorias => Flores, Bombones, Peluches.
            // Descuento => 15%.

            ISystemData dateSystem = Substitute.For<ISystemData>();
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 12, 12)); 

            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 100m, Currency = 0, Categories = new string[] { "Flores" } }
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(0); // Espero el precio en dolaress


            Assert.AreEqual(100m, totalPrice);
        }

        [TestMethod]
        public void TwoProductsInMothersDayCategory_ShouldApplyDiscount()
        {
            ISystemData dateSystem = Substitute.For<ISystemData>();
            dateSystem.GetCurrentDate().Returns<DateTime>(new DateTime(2016, 5, 10)); 

            var shoppingCart = new ShoppingCart(dateSystem)
            {
                Products = new List<Product>()
                {
                    new Product() { Price = 100m, Currency = 0, Categories = new string[] { "Flores" } },
                    new Product() { Price = 100m, Currency = 0, Categories = new string[] { "Bombones" } }
                }
            };

            //Act
            var totalPrice = shoppingCart.Buy(0);

            Assert.AreEqual(170m, totalPrice);
        }
    }
}

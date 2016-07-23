using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ecommerce.Tests
{
    [TestClass]
    public class PriceCalculationTests
    {
        [TestMethod]
        public void CalculatePrice_DollarsToPesos_1Dollar()
        {
            //Arrange
            var dollars = 1;

            //Act
            var result = CurrencyCalculator.Calculate(dollars, 1, true);

            //Assert
            Assert.AreEqual(31, result);
        }

        [TestMethod]
        public void CalculatePrice_DollarsToPesos_5Dollars()
        {
            //Arrange
            var dollars = 5;

            //Act
            var result = CurrencyCalculator.Calculate(dollars, 1, true);

            //Assert
            Assert.AreEqual(155, result);
        }

        [TestMethod]
        public void CalculatePrice_PesosToDollars_31Pesos()
        {
            //Arrange
            var pesos = 31;

            //Act
            var result = CurrencyCalculator.Calculate(pesos, 0, false);

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CalculatePrice_PesosToDollars_155Pesos()
        {
            //Arrange
            var pesos = 155;

            //Act
            var result = CurrencyCalculator.Calculate(pesos, 0, false);

            //Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void CalculatePrice_DollarsToDollars_1Dollar()
        {
            //Arrange
            var dollars = 1;

            //Act
            var result = CurrencyCalculator.Calculate(dollars, 0, true);

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CalculatePrice_PesosToPesos_31Pesos()
        {
            //Arrange
            var pesos = 31;

            //Act
            var result = CurrencyCalculator.Calculate(pesos, 1, false);

            //Assert
            Assert.AreEqual(31, result);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ecommerce.Tests
{
    [TestClass]
    public class PriceCalculationTests
    {
        private CurrencyCalculator currencyCalculator;

        [TestInitialize]
        public void Initialize()
        {
            currencyCalculator = new CurrencyCalculator(34, 33);
        }

        [TestMethod]
        public void CalculatePrice_DollarsToPesos_1Dollar()
        {
            //Arrange
            var dollars = 1;

            //Act
            var result = currencyCalculator.Convert(dollars, Currency.Dollar, Currency.Peso);

            //Assert
            Assert.AreEqual(33, result);
        }

        [TestMethod]
        public void CalculatePrice_DollarsToPesos_5Dollars()
        {
            //Arrange
            var dollars = 5;

            //Act
            var result = currencyCalculator.Convert(dollars, Currency.Dollar, Currency.Peso);

            //Assert
            Assert.AreEqual(165, result);
        }

        [TestMethod]
        public void CalculatePrice_PesosToDollars_34Pesos()
        {
            //Arrange
            var pesos = 34;

            //Act
            var result = currencyCalculator.Convert(pesos, Currency.Peso, Currency.Dollar);

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CalculatePrice_PesosToDollars_170Pesos()
        {
            //Arrange
            var pesos = 170;

            //Act
            var result = currencyCalculator.Convert(pesos, Currency.Peso, Currency.Dollar);

            //Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void CalculatePrice_DollarsToDollars_1Dollar()
        {
            //Arrange
            var dollars = 1;

            //Act
            var result = currencyCalculator.Convert(dollars, Currency.Dollar, Currency.Dollar);

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CalculatePrice_PesosToPesos_31Pesos()
        {
            //Arrange
            var pesos = 31;

            //Act
            var result = currencyCalculator.Convert(pesos, Currency.Peso, Currency.Peso);

            //Assert
            Assert.AreEqual(31, result);
        }
    }
}

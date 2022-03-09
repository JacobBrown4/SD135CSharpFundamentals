using _08_Interfaces.Currency;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _08_Interfaces
{
    [TestClass]
    public class ICurrencyTests
    {
        [TestMethod]
        public void CurrencyValueTests()
        {
            ICurrency penny = new Penny();
            ICurrency dime = new Dime();
            ICurrency dollar = new Dollar();

            Assert.AreEqual(.01m, penny.Value);
            Assert.AreEqual(.1m, dime.Value);
            Assert.AreEqual(1m, dollar.Value);
        }
        [DataTestMethod]
        [DataRow(100.2)]
        [DataRow(38.22)]
        [DataRow(12910.49)]
        [DataRow(392.00)]
        public void ElectronicPayment_ShouldReturnCorrectValue(double value)
        {
            decimal convertedValue = Convert.ToDecimal(value);
            var ePay = new ElectronicPayment(convertedValue);

            Assert.AreEqual(convertedValue, ePay.Value);
        }
    }
}

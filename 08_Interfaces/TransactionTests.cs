using _08_Interfaces.Currency;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _08_Interfaces
{
    [TestClass]
    public class TransactionTests
    {
        private decimal _debt;

        private void PayDebt(ICurrency payment)
        {
            _debt -= payment.Value;
            Console.WriteLine($"You have paid ${payment.Value} towards your debt.");
        }

        private void CurrentDebt()
        {
            Console.WriteLine($"You have ${_debt} in debt left");
        }

        [TestInitialize]
        public void Arrange()
        {
            _debt = 9000.01m;
        }

        [TestMethod]
        public void PayDebt_ShouldLowerDebt()
        {
            PayDebt(new Dollar());
            PayDebt(new ElectronicPayment(315.52m));

            decimal expectedDebt = 9000.01m - 316.52m;
            CurrentDebt();
            Assert.AreEqual(expectedDebt, _debt);
        }

        [TestMethod]
        public void InjectionIntoConstructor()
        {
            var dollar = new Dollar();
            var epayment = new ElectronicPayment(500m);

            var firstTransaction = new Transaction(dollar); // Injection
            var secondTransaction = new Transaction(epayment); // Dependent on it because of how we coded it
            var thirdTransaction = new Transaction(new Dime());

            Console.WriteLine(firstTransaction.GetTransactionAmount());
            Console.WriteLine(firstTransaction.GetTransactionType());
            Console.WriteLine(secondTransaction.DateOfTransaction) ;
            Assert.AreEqual("Electronic Payment", secondTransaction.GetTransactionType());
        }

        [TestMethod]
        public void FurtherExamples()
        {
            var list = new List<Transaction>
            {
                new Transaction(new Dollar()),
                new Transaction(new ElectronicPayment(123.45m)),
                new Transaction(new Dime()),
                new Transaction(new Penny())
            };

            foreach(var item in list)
            {
                var type = item.GetTransactionType();
                var value = item.GetTransactionAmount();
              
                Console.WriteLine($"{type} {value} {item.DateOfTransaction}");
            }

        }
    }
}

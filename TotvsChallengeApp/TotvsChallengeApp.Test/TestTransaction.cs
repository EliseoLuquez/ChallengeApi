using Microsoft.VisualStudio.TestTools.UnitTesting;
using TotvsChallengeApp.Application.Helpers;

namespace TotvsChallengeApp.Test
{
    [TestClass]
    public class TestTransaction
    {
        [TestMethod]
        public void ExactPaymentTest()
        {
            var totalCost = (decimal)6000;
            var amountPaid = (decimal)6000.00;
            var change = CalculateTransaction.CalculateChange(totalCost, amountPaid);
           
            Assert.AreEqual((decimal)0.00, change);
        }

        [TestMethod]
        public void ChangeTest()
        {
            var change = (decimal)10.25;
            
            var message = CalculateTransaction.CalculateChangeDetail(change);

            Assert.AreEqual("1 Bilhete de BRL 10,00", message[0]);
            Assert.AreEqual("2 Moedas de BRL 0,10", message[1]);
            Assert.AreEqual("1 Moedas de BRL 0,05", message[2]);
        }
    }
}

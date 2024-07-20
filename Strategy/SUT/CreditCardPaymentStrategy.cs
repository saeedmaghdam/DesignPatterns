using Strategy.SUT.Core;
using System.Diagnostics;

namespace Strategy.SUT
{
    public class CreditCardPaymentStrategy : IPaymentStrategy
    {
        public decimal GetPaymentFee()
        {
            return 2;
        }

        public string ProcessPayment()
        {
            Debug.WriteLine($"Processing credit card payment");

            // Code to process credit card payment

            return "Credit Card Strategy";
        }
    }
}

using Strategy.SUT.Core;
using System.Diagnostics;

namespace Strategy.SUT
{
    public class PayPalPaymentStrategy : IPaymentStrategy
    {
        public decimal GetPaymentFee()
        {
            return 3;
        }

        public string ProcessPayment()
        {
            Debug.WriteLine($"Processing PayPal payment");

            // Code to process PayPal payment

            return "PayPal Strategy";
        }
    }
}

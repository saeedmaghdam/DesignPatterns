using Strategy.SUT.Core;
using System.Diagnostics;

namespace Strategy.SUT
{
    public class BankTransferPaymentStrategy : IPaymentStrategy
    {
        public decimal GetPaymentFee()
        {
            return 1;
        }

        public string ProcessPayment()
        {
            Debug.WriteLine($"Processing bank transfer payment");

            // Code to process bank transfer payment

            return "Bank Transfer Strategy";
        }
    }
}

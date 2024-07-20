using Strategy.SUT.Core;

namespace Strategy.SUT
{
    public class CryptocurrencyPaymentStrategy : IPaymentStrategy
    {
        public decimal GetPaymentFee()
        {
            return 0;
        }

        public string ProcessPayment()
        {
            throw new NotImplementedException();
        }
    }
}

using Strategy.SUT.Core;

namespace Strategy.SUT
{
    public class PaymentContext
    {
        private IPaymentStrategy? _paymentStrategy;

        public void SetPaymentMethod(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public string ProcessPayment()
        {
            if (_paymentStrategy == null)
                return "No payment method selected";

            try
            {
                return _paymentStrategy.ProcessPayment();
            }
            catch (NotImplementedException)
            {
                return "Payment method not implemented";
            }
        }

        public string[] PaymentFeesOverview(IPaymentStrategy[] strategies)
        {
            string[] fees = new string[strategies.Length];

            for (int i = 0; i < strategies.Length; i++)
            {
                SetPaymentMethod(strategies[i]);
                fees[i] = $"{strategies[i].GetType().Name}: {strategies[i].GetPaymentFee()}";
            }

            return fees;
        }
    }
}

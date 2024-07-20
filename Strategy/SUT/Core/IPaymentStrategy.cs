namespace Strategy.SUT.Core
{
    public interface IPaymentStrategy
    {
        string ProcessPayment();
        decimal GetPaymentFee();
    }
}

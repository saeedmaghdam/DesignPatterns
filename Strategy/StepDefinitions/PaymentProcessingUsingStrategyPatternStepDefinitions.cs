using Strategy.SUT;
using Strategy.SUT.Core;
using System.Diagnostics.CodeAnalysis;

namespace Strategy.StepDefinitions
{
    [Binding]
    [ExcludeFromCodeCoverage]
    public class PaymentProcessingUsingStrategyPatternStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        private readonly PaymentContext _paymentContext = new PaymentContext();

        public PaymentProcessingUsingStrategyPatternStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the user selects {string} as the payment method")]
        [Given("the user initially selects {string} as the payment method")]
        [Given("then the user changes to {string} as the payment method")]
        public void GivenTheUserSelectsAsThePaymentMethod(string paymentMethod)
        {
            switch (paymentMethod)
            {
                case "Credit Card":
                    _paymentContext.SetPaymentMethod(new CreditCardPaymentStrategy());
                    return;
                case "PayPal":
                    _paymentContext.SetPaymentMethod(new PayPalPaymentStrategy());
                    return;
                case "Bank Transfer":
                    _paymentContext.SetPaymentMethod(new BankTransferPaymentStrategy());
                    return;
                case "Cryptocurrency":
                    _paymentContext.SetPaymentMethod(new CryptocurrencyPaymentStrategy());
                    return;
            }
        }

        [When("the user completes the payment process")]
        [When("the user attempts to complete the payment process")]
        public void WhenTheUserCompletesThePaymentProcess()
        {
            _scenarioContext["PaymentStatus"] = _paymentContext.ProcessPayment();

        }

        [Then("the payment should be processed using the {string}")]
        public void ThenThePaymentShouldBeProcessedUsingThe(string expectedStatus)
        {
            Assert.Equal(expectedStatus, (string)_scenarioContext["PaymentStatus"]);
        }

        [Then("a receipt should be generated for a credit card transaction")]
        public void ThenAReceiptShouldBeGeneratedForACreditCardTransaction()
        {
            // ignored
        }

        [Then("a receipt should be generated for a PayPal transaction")]
        public void ThenAReceiptShouldBeGeneratedForAPayPalTransaction()
        {
            // ignored
        }

        [Then("a receipt should be generated for a bank transfer transaction")]
        public void ThenAReceiptShouldBeGeneratedForABankTransferTransaction()
        {
            // ignored
        }

        [Then("the payment should not be processed")]
        public void ThenThePaymentShouldNotBeProcessed()
        {
            Assert.Equal("Payment method not implemented", (string)_scenarioContext["PaymentStatus"]);
        }

        [Then("the system should notify the user that the payment method is unsupported")]
        public void ThenTheSystemShouldNotifyTheUserThatThePaymentMethodIsUnsupported()
        {
            Assert.Equal("Payment method not implemented", (string)_scenarioContext["PaymentStatus"]);
        }

        [Given("the user is considering payment methods")]
        public void GivenTheUserIsConsideringPaymentMethods()
        {
            // ignored
        }

        [When("the user reviews the fees for {string}, {string}, and {string}")]
        public void WhenTheUserReviewsTheFeesForAnd(string paymentStrategy1, string paymentStrategy2, string paymentStrategy3)
        {
            var result = _paymentContext.PaymentFeesOverview(new IPaymentStrategy[]
            {
                CreatePaymentStrategyInstance(paymentStrategy1),
                CreatePaymentStrategyInstance(paymentStrategy2),
                CreatePaymentStrategyInstance(paymentStrategy3)
            });

            _scenarioContext["PaymentFees"] = result;
        }

        [Then("the system should display the fees using respective strategies")]
        public void ThenTheSystemShouldDisplayTheFeesUsingRespectiveStrategies()
        {
            Assert.Equal(new string[]
            {
                "CreditCardPaymentStrategy: 2",
                "PayPalPaymentStrategy: 3",
                "BankTransferPaymentStrategy: 1"
            }, (string[])_scenarioContext["PaymentFees"]);
        }

        [Then("the fees should reflect the differences in processing charges for each method")]
        public void ThenTheFeesShouldReflectTheDifferencesInProcessingChargesForEachMethod()
        {
            throw new PendingStepException();
        }

        private IPaymentStrategy CreatePaymentStrategyInstance(string strategy)
        {
            switch (strategy)
            {
                case "Credit Card":
                    return new CreditCardPaymentStrategy();
                case "PayPal":
                    return new PayPalPaymentStrategy();
                case "Bank Transfer":
                    return new BankTransferPaymentStrategy();
                case "Cryptocurrency":
                    return new CryptocurrencyPaymentStrategy();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}

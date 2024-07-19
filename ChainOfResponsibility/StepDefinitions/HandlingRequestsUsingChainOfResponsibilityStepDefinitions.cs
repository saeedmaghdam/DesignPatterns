using ChainOfResponsibility.SUT;
using ChainOfResponsibility.SUT.Core;
using Moq;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace ChainOfResponsibility.StepDefinitions
{
    [Binding]
    [ExcludeFromCodeCoverage]
    public class HandlingRequestsUsingChainOfResponsibilityStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        private RequestHandlerChain? _requestHandlerChain;
        private readonly Mock<IValidator>? _validatorMock = new();
        private readonly Mock<IAuthorizer>? _authorizerMock = new();
        private readonly Mock<IProcessor>? _processorMock = new();

        public HandlingRequestsUsingChainOfResponsibilityStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("a chain consisting of a Validator, Authorizer, and Processor")]
        public void GivenAChainConsistingOfAValidatorAuthorizerAndProcessor()
        {
            var validator = new Validator();
            var authorizer = new Authorizer();
            var processor = new Processor();

            var validatorResult = false;
            var authorizerResult = false;
            var processorResult = false;

            _validatorMock!.Setup(x => x.Handle(It.IsAny<string>())).Callback<string>(r => {
                _scenarioContext["validatorCallOrder"] = GetCallbackOrder();
                validatorResult = validator.Handle(r);
            }).Returns(() => validatorResult);
            _validatorMock!.Setup(x => x.SetNext(It.IsAny<IHandler<string>>())).Callback<IHandler<string>>(next => validator.SetNext(next));

            _authorizerMock!.Setup(x => x.Handle(It.IsAny<string>())).Callback<string>(r =>
            {
                _scenarioContext["authorizerCallOrder"] = GetCallbackOrder();
                authorizerResult = authorizer.Handle(r);
            }).Returns(() => authorizerResult);
            _authorizerMock!.Setup(x => x.SetNext(It.IsAny<IHandler<string>>())).Callback<IHandler<string>>(next => authorizer.SetNext(next));

            _processorMock!.Setup(x => x.Handle(It.IsAny<string>())).Callback<string>(r =>
            {
                _scenarioContext["processorCallOrder"] = GetCallbackOrder();
                processorResult = processor.Handle(r);
            }).Returns(() => processorResult);
            _processorMock!.Setup(x => x.SetNext(It.IsAny<IHandler<string>>())).Callback<IHandler<string>>(next => processor.SetNext(next));

            _requestHandlerChain = new RequestHandlerChain(_validatorMock.Object, _authorizerMock.Object, _processorMock.Object);
        }

        [When("the request {string} is received")]
        public void WhenTheRequestIsReceived(string request)
        {
            _scenarioContext["request"] = request;
            var result = _requestHandlerChain!.HandleRequest(request);
            _scenarioContext["result"] = result;
        }

        [Then("the request should be handled by the Validator")]
        public void ThenTheRequestShouldBeHandledByTheValidator()
        {
            _validatorMock!.Verify(x => x.Handle(GetRequest()), Times.Once);
            Assert.True(GetResult());
        }

        [Then("the request should not proceed to the Authorizer")]
        public void ThenTheRequestShouldNotProceedToTheAuthorizer()
        {
            _authorizerMock!.Verify(x => x.Handle(GetRequest()), Times.Never);
        }

        [Then("the request should not proceed to the Processor")]
        public void ThenTheRequestShouldNotProceedToTheProcessor()
        {
            _processorMock!.Verify(x => x.Handle(GetRequest()), Times.Never);
        }

        [Then("the request should be handled by the Authorizer")]
        public void ThenTheRequestShouldBeHandledByTheAuthorizer()
        {
            _authorizerMock!.Verify(x => x.Handle(GetRequest()), Times.Once);
            Assert.True(GetResult());
        }

        [Then("the request should be handled by the Processor")]
        public void ThenTheRequestShouldBeHandledByTheProcessor()
        {
            _processorMock!.Verify(x => x.Handle(GetRequest()), Times.Once);
            Assert.True(GetResult());
        }

        [Then("the request should be rejected")]
        public void RequestHasRejected()
        {
            _validatorMock!.Verify(x => x.Handle(GetRequest()), Times.Once);
            _authorizerMock!.Verify(x => x.Handle(GetRequest()), Times.Once);
            _processorMock!.Verify(x => x.Handle(GetRequest()), Times.Once);
            Assert.False(GetResult());
        }

        [Then("the request should be handled first by the Validator")]
        public void ThenTheRequestShouldBeHandledFirstByTheValidator()
        {
            var validatorCallOrder = (int)_scenarioContext["validatorCallOrder"];
            Assert.Equal(1, validatorCallOrder);
        }

        [Then("then the request should be passed to the Authorizer")]
        public void ThenThenTheRequestShouldBePassedToTheAuthorizer()
        {
            var authorizerCallOrder = (int)_scenarioContext["authorizerCallOrder"];
            Assert.Equal(2, authorizerCallOrder);
        }

        [Then("finally, the request should be handled by the Processor")]
        public void ThenFinallyTheRequestShouldBeHandledByTheProcessor()
        {
            var processorCallOrder = (int)_scenarioContext["processorCallOrder"];
            Assert.Equal(3, processorCallOrder);
        }

        [Given("no handler can handle the request")]
        [Given("the Validator can handle the request")]
        [Given("the Validator cannot handle the request")]
        [Given("the Authorizer can handle the request")]
        [Given("the Authorizer cannot handle the request")]
        [Given("the Processor can handle the request")]
        public void IgnoredSteps() { /* ignored */ }

        [Given("the Validator can partially handle the request {string}")]
        [Given("the Authorizer can partially handle the request {string}")]
        [Given("the Processor can fully handle the request {string}")]
        public void IgnoredSteps(string p0) { /* ignored */ }

        private string GetRequest() => (string)_scenarioContext["request"];

        private bool GetResult() => (bool)_scenarioContext["result"];

        private int GetCallbackOrder()
        {
            var callbackOrder = 0;
            if (_scenarioContext.ContainsKey("callbackOrder"))
                callbackOrder = (int)_scenarioContext["callbackOrder"];

            callbackOrder++;
            _scenarioContext["callbackOrder"] = callbackOrder;

            return callbackOrder;
        }
    }
}

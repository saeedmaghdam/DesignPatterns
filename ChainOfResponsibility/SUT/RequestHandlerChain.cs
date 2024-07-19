namespace ChainOfResponsibility.SUT
{
    public class RequestHandlerChain
    {
        private readonly IValidator _validator;
        private readonly IAuthorizer _authorizer;
        private readonly IProcessor _processor;

        public RequestHandlerChain(IValidator validator, IAuthorizer authorizer, IProcessor processor)
        {
            _validator = validator;
            _authorizer = authorizer;
            _processor = processor;

            _validator.SetNext(_authorizer);
            _authorizer.SetNext(_processor);
        }

        public bool HandleRequest(string request)
        {
            return _validator.Handle(request);
        }
    }
}

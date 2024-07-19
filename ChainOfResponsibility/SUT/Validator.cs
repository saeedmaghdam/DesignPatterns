using ChainOfResponsibility.SUT.Core;

namespace ChainOfResponsibility.SUT
{
    public class Validator : BaseHandler<string>, IValidator
    {
        public override bool Handle(string request)
        {
            if (request == "Validate data")
            {
                // Do validation
                return true;
            }
            else if (request == "Complete transaction")
            {
                // Do validation part of the transaction
            }

            return base.Handle(request);
        }
    }

    public interface IValidator : IHandler<string> { }
}
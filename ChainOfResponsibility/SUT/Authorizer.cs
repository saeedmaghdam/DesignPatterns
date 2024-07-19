using ChainOfResponsibility.SUT.Core;

namespace ChainOfResponsibility.SUT
{
    public class Authorizer : BaseHandler<string>, IAuthorizer
    {
        public override bool Handle(string request)
        {
            if (request == "Authorize user")
            {
                // Do authorization
                return true;
            }
            else if (request == "Complete transaction")
            {
                // Do authorization part of the transaction
            }

            return base.Handle(request);
        }
    }

    public interface IAuthorizer : IHandler<string> { }
}
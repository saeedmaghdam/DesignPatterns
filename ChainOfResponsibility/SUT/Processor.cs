using ChainOfResponsibility.SUT.Core;

namespace ChainOfResponsibility.SUT
{
    public class Processor : BaseHandler<string>, IProcessor
    {
        public override bool Handle(string request)
        {
            if (request == "Process data")
            {
                // Do processing
                return true;
            }
            else if (request == "Complete transaction")
            {
                // Do process the request
            }

            return base.Handle(request);
        }
    }

    public interface IProcessor : IHandler<string> { }
}
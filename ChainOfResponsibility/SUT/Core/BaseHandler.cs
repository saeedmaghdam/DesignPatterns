namespace ChainOfResponsibility.SUT.Core
{
    public class BaseHandler<TRequestType> : IHandler<TRequestType>
    {
        private IHandler<TRequestType>? _nextHandler;

        public virtual bool Handle(TRequestType request)
        {
            if (_nextHandler != null)
                return _nextHandler.Handle(request);

            return false;
        }

        public void SetNext(IHandler<TRequestType> handler)
        {
            _nextHandler = handler;
        }
    }
}

namespace ChainOfResponsibility.SUT.Core
{
    public interface IHandler<TRequestType>
    {
        bool Handle(TRequestType request);
        void SetNext(IHandler<TRequestType> handler);
    }
}

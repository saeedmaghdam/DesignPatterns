namespace Visitor.SUT.Core
{
    public interface INode
    {
        void Accept(IVisitor visitor);
    }
}

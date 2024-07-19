namespace Visitor.SUT.Core
{
    public interface IVisitor
    {
        void Visit(NodeA node);
        void Visit(NodeB node);
        void Visit(NodeC node);
    }
}

namespace Visitor.SUT.Core
{
    public abstract class NodeBase : INode
    {
        public string Status { get; private set; } = string.Empty;

        public void SetStatus(string status)
        {
            Status += status;
        }

        public abstract void Accept(IVisitor visitor);
    }
}

using Visitor.SUT.Core;

namespace Visitor.SUT
{
    public class NodeA : NodeBase
    {
        public override void Accept(IVisitor visitor) => visitor.Visit(this);

        public int Return1() => 1;
    }
}

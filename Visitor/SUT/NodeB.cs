using Visitor.SUT.Core;

namespace Visitor.SUT
{
    public class NodeB : NodeBase
    {
        public override void Accept(IVisitor visitor) => visitor.Visit(this);

        public int Return2() => 2;
    }
}

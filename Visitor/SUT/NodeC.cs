using Visitor.SUT.Core;

namespace Visitor.SUT
{
    public class NodeC : NodeBase
    {
        public override void Accept(IVisitor visitor) => visitor.Visit(this);

        public int Return3() => 3;

        public string IHaveAFieldThatOthersDont { get; set; } = string.Empty;
    }
}

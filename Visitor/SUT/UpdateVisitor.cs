using Visitor.SUT.Core;

namespace Visitor.SUT
{
    public class UpdateVisitor : IVisitor
    {
        public void Visit(NodeA node)
        {
            // Do some logic related to updating for NodeA

            node.SetStatus("Updated");
        }

        public void Visit(NodeB node)
        {
            // Do some logic related to updating for NodeB

            node.SetStatus("Updated");
        }

        public void Visit(NodeC node)
        {
            // Do some logic related to updating for NodeC

            node.IHaveAFieldThatOthersDont = "I'm special";
            node.SetStatus("Updated");
        }
    }
}

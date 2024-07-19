using Visitor.SUT.Core;

namespace Visitor.SUT
{
    internal class HighlightVisitor : IVisitor
    {
        public void Visit(NodeA node)
        {
            // Do some logic related to highlighting for NodeA

            node.SetStatus("Highlighted");
        }

        public void Visit(NodeB node)
        {
            // Do some logic related to highlighting for NodeB

            node.SetStatus("Highlighted");
        }

        public void Visit(NodeC node)
        {
            // Do some logic related to highlighting for NodeC

            node.SetStatus("Highlighted");
        }
    }
}

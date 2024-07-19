using Visitor.SUT.Core;

namespace Visitor.SUT
{
    public class RenderVisitor : IVisitor
    {
        public void Visit(NodeA node)
        {
            // Do some logic related to rendering for NodeA

            node.SetStatus("Rendered");
        }

        public void Visit(NodeB node)
        {
            // Do some logic related to rendering for NodeB

            node.SetStatus("Rendered");
        }

        public void Visit(NodeC node)
        {
            // Do some logic related to rendering for NodeC

            node.SetStatus("Rendered");
        }
    }
}

using Visitor.SUT.Core;

namespace Visitor.SUT
{
    public class LoadVisitor : IVisitor
    {
        public void Visit(NodeA node)
        {
            // Do some logic related to loading for NodeA

            node.SetStatus("Loaded");
        }

        public void Visit(NodeB node)
        {
            // Do some logic related to loading for NodeB

            node.SetStatus("Loaded");
        }

        public void Visit(NodeC node)
        {
            // Do some logic related to loading for NodeC

            node.SetStatus("Loaded");
        }
    }
}

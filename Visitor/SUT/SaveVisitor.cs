using Visitor.SUT.Core;

namespace Visitor.SUT
{
    public class SaveVisitor : IVisitor
    {
        public void Visit(NodeA node)
        {
            // Do some logic related to saving for NodeA

            node.SetStatus("Saved");
        }

        public void Visit(NodeB node)
        {
            // Do some logic related to saving for NodeB

            node.SetStatus("Saved");
        }

        public void Visit(NodeC node)
        {
            // Do some logic related to saving for NodeC

            node.SetStatus("Saved");
        }
    }
}

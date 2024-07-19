using Visitor.SUT.Core;

namespace Visitor.SUT
{
    public class StatisticsVisitor : IVisitor
    {
        public int Total { get; private set; }

        public void Visit(NodeA node)
        {
            // Do some logic related to statistics for NodeA

            Total += node.Return1();
            node.SetStatus("Statistics");
        }

        public void Visit(NodeB node)
        {
            // Do some logic related to statistics for NodeB

            Total += node.Return2();
            node.SetStatus("Statistics");
        }

        public void Visit(NodeC node)
        {
            // Do some logic related to statistics for NodeC

            Total += node.Return3();
            node.SetStatus("Statistics");
        }
    }
}

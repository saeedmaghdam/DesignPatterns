using System.Diagnostics.CodeAnalysis;
using Visitor.SUT;
using Visitor.SUT.Core;

namespace Visitor.StepDefinitions
{
    [Binding]
    [ExcludeFromCodeCoverage]
    public class OperationExtensionUsingVisitorDesignPatternStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        private readonly List<INode> _nodes = new List<INode>();

        public OperationExtensionUsingVisitorDesignPatternStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("an object structure with elements NodeA, NodeB, NodeC")]
        public void GivenAnObjectStructureWithElementsABAndC()
        {
            _nodes.Add(new NodeA());
            _nodes.Add(new NodeB());
            _nodes.Add(new NodeC());
        }

        [Given("a Visitor HighlightVisitor that can highlight elements")]
        public void GivenAVisitorThatCanHighlightElements()
        {
            AddVisitor(new HighlightVisitor());
        }

        [When("the HighlightVisitor visits element NodeA")]
        public void WhenTheVisitorVisitsElementA()
        {
            var nodeA = _nodes.OfType<NodeA>().FirstOrDefault();
            var highlightVisitor = GetVisitors().OfType<HighlightVisitor>().FirstOrDefault();
            nodeA!.Accept(highlightVisitor!);
        }

        [Then("element NodeA should perform the highlight operation")]
        public void ThenElementAShouldPerformTheOperation()
        {
            var nodeA = _nodes.OfType<NodeA>().FirstOrDefault();
            Assert.Equal("Highlighted", nodeA!.Status);
        }

        [Given("a Visitor RenderVisitor that can render elements differently based on type")]
        public void GivenAVisitorThatCanRenderElementsDifferentlyBasedOnType()
        {
            AddVisitor(new RenderVisitor());
        }

        [When("the RenderVisitor visits element NodeB")]
        public void WhenTheVisitorVisitsElementB()
        {
            var nodeB = _nodes.OfType<NodeB>().FirstOrDefault();
            var renderVisitor = GetVisitors().OfType<RenderVisitor>().FirstOrDefault();
            nodeB!.Accept(renderVisitor!);
        }

        [Then("element NodeB should perform the render operation specific to its type")]
        public void ThenElementBShouldPerformTheOperationSpecificToItsType()
        {
            var nodeB = _nodes.OfType<NodeB>().FirstOrDefault();
            Assert.Equal("Rendered", nodeB!.Status);
        }

        [Given("a Visitor StatisticsVisitor that accumulates statistics")]
        public void GivenAVisitorThatAccumulatesStatistics()
        {
            AddVisitor(new StatisticsVisitor());
        }

        [When("the StatisticsVisitor visits all elements")]
        public void WhenTheVisitorVisitsAllElements()
        {
            var statisticsVisitor = GetVisitors().OfType<StatisticsVisitor>().FirstOrDefault();
            foreach (var node in _nodes)
                node.Accept(statisticsVisitor!);
        }

        [Then("the StatisticsVisitor should accumulate statistics from each element")]
        public void ThenTheVisitorShouldAccumulateStatisticsFromEachElement()
        {
            // This is done internally inside the StatisticsVisitor!
        }

        [Then("provide a sum of the statistics")]
        public void ThenProvideASummaryOfTheStatistics()
        {
            Assert.Equal(6, GetVisitors().OfType<StatisticsVisitor>().FirstOrDefault()!.Total);
        }

        [Given("a Visitor SaveVisitor that saves element state")]
        public void GivenAVisitorThatSavesElementState()
        {
            AddVisitor(new SaveVisitor());
        }

        [Given("another Visitor LoadVisitor that loads element state")]
        public void GivenAnotherVisitorThatLoadsElementState()
        {
            AddVisitor(new LoadVisitor());
        }

        [When("the SaveVisitor visits all elements")]
        public void WhenTheVisitsAllElements()
        {
            var saveVisitor = GetVisitors().OfType<SaveVisitor>().FirstOrDefault();
            foreach (var node in _nodes)
                node.Accept(saveVisitor!);
        }

        [When("the LoadVisitor visits all elements sequentially")]
        public void WhenTheVisitsAllElementsSequentially()
        {
            var loadVisitor = GetVisitors().OfType<LoadVisitor>().FirstOrDefault();
            foreach (var node in _nodes)
                node.Accept(loadVisitor!);
        }

        [Then("each element should have its state saved and then reloaded without errors")]
        public void ThenEachElementShouldHaveItsStateSavedAndThenReloadedWithoutErrors()
        {
            foreach (var node in _nodes)
                Assert.Equal("SavedLoaded", ((NodeBase)node).Status);
        }

        [Given("a Visitor UpdateVisitor that updates elements")]
        public void GivenAVisitorThatUpdatesElements()
        {
            AddVisitor(new UpdateVisitor());
        }

        [When("the UpdateVisitor visits element NodeC")]
        public void WhenTheVisitorVisitsElementC()
        {
            var nodeC = _nodes.OfType<NodeC>().FirstOrDefault();
            var updateVisitor = GetVisitors().OfType<UpdateVisitor>().FirstOrDefault();
            nodeC!.Accept(updateVisitor!);
        }

        [Then("element NodeC should be updated according to the Visitor's logic")]
        public void ThenElementCShouldBeUpdatedAccordingToTheVisitorsLogic()
        {
            var nodeC = _nodes.OfType<NodeC>().FirstOrDefault();
            Assert.Equal("Updated", nodeC!.Status);
            Assert.Equal("I'm special", nodeC.IHaveAFieldThatOthersDont);
        }

        private void AddVisitor(IVisitor visitor)
        {
            var result = new List<IVisitor>();
            if (_scenarioContext.ContainsKey("visitors"))
                result = (List<IVisitor>)_scenarioContext["visitors"];

            result.Add(visitor);

            _scenarioContext["visitors"] = result;
        }

        private List<IVisitor> GetVisitors()
        {
            return (List<IVisitor>)_scenarioContext["visitors"];
        }
    }
}

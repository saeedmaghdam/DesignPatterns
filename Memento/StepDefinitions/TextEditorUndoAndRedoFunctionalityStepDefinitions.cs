using Memento.SUT;
using Memento.SUT.Core;
using System.Diagnostics.CodeAnalysis;

namespace Memento.StepDefinitions
{
    [Binding]
    [ExcludeFromCodeCoverage]
    public class TextEditorUndoAndRedoFunctionalityStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        private readonly TextEditor _textEditor;
        private readonly Caretaker _caretaker;

        public TextEditorUndoAndRedoFunctionalityStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

            _textEditor = new TextEditor();
            _caretaker = new Caretaker();
        }

        [Given("the text editor is open")]
        public void GivenTheTextEditorIsOpen() { /* ignored */ }

        [Given("I type {string}")]
        [When("I type {string}")]
        public void WhenIType(string text)
        {
            TextTyped(text);
        }

        [Given("I save the current state")]
        [When("I save the current state")]
        public void WhenISaveTheCurrentState()
        {
            _caretaker.TakeSnapshot(_textEditor.Save());
            _textEditor.Append(GetTypedText());
        }

        [Then("the current state should be {string}")]
        public void ThenTheCurrentStateShouldBe(string expectedState)
        {
            var currentState = _textEditor.GetState();
            currentState.Should().Be(expectedState);
        }

        [Given("I undo the last change")]
        [When("I undo the last change")]
        [Given("I undo the change before last")]
        [When("I undo the change before last")]
        public void WhenIUndoTheLastChange()
        {
            _caretaker.Undo(_textEditor.Save());
        }

        [When("I redo the last undone change")]
        [When("I redo the change before last")]
        public void WhenIRedoTheLastUndoneChange()
        {
            _caretaker.Redo();
        }

        private void TextTyped(string text)
        {
            _scenarioContext["text"] = text;
        }

        private string GetTypedText()
        {
            if (!_scenarioContext.ContainsKey("text"))
                return string.Empty;

            var text = (string)_scenarioContext["text"];
            _scenarioContext.Remove("text");

            return text;
        }
    }
}

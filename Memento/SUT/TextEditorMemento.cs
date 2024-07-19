using Memento.SUT.Core;

namespace Memento.SUT
{
    internal class TextEditorMemento : IMemento
    {
        private readonly TextEditor _textEditor; // Originator
        private readonly string _state; // State

        internal TextEditorMemento(TextEditor textEditor, string state)
        {
            _textEditor = textEditor;
            _state = state;
        }

        public void Restore()
        {
            _textEditor.SetState(_state);
        }
    }
}

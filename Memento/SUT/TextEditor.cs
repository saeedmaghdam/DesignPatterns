using System.Text;
using Memento.SUT.Core;

namespace Memento.SUT
{
    internal class TextEditor : IOriginator
    {
        private readonly StringBuilder _text = new();

        public IMemento Save()
        {
            return new TextEditorMemento(this, _text.ToString());
        }

        internal void Append(string text)
        {
            _text.Append(text);
        }

        internal string GetState()
        {
            return _text.ToString();
        }

        internal void SetState(string state)
        {
            _text.Clear();
            _text.Append(state);
        }
    }
}
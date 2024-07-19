namespace Memento.SUT.Core
{
    internal class Caretaker
    {
        private readonly Stack<IMemento> _history = new();
        private readonly Stack<IMemento> _undoHistory = new();

        internal void Undo(IMemento currentStateMemento)
        {
            if (_history.Count == 0)
                return;

            var memento = _history.Pop();
            _undoHistory.Push(currentStateMemento);

            memento.Restore();
        }

        internal void Redo()
        {
            if (_undoHistory.Count == 0)
                return;

            var memento = _undoHistory.Pop();
            _history.Push(memento);

            memento.Restore();
        }

        internal void TakeSnapshot(IMemento memento)
        {
            _history.Push(memento);
        }
    }
}

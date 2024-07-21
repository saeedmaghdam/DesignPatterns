using State.SUT.Core;

namespace State.SUT
{
    public class Ticket
    {
        public ITicketState State
        {
            get => _state ?? throw new InvalidOperationException("State is not set");
            set => _state = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Message => _state?.Message ?? string.Empty;

        private ITicketState? _state;

        public Ticket()
        {
            _state = new OpenState(this);
        }

        public void Open() => _state!.Open();

        public void StartProgress() => _state!.StartProgress();

        public void Resolve() => _state!.Resolve();

        public void Close() => _state!.Close();
    }
}

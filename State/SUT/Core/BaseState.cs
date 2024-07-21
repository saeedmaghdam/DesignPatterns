namespace State.SUT.Core
{
    public abstract class BaseState : ITicketState
    {
        protected readonly Ticket Ticket;
        public string Message { get; protected set; } = string.Empty;

        protected BaseState(Ticket ticket)
        {
            Ticket = ticket;
        }

        public abstract void Open();

        public abstract void StartProgress();

        public abstract void Resolve();

        public abstract void Close();
    }
}

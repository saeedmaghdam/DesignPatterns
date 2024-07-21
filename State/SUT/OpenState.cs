using State.SUT.Core;

namespace State.SUT
{
    public class OpenState : BaseState
    {
        public OpenState(Ticket ticket, string? message = null) : base(ticket)
        {
            Message = message ?? "Ticket opened";
        }

        public override void Open()
        {
            throw new InvalidOperationException("Ticket is already opened");
        }

        public override void StartProgress()
        {
            Ticket.State = new InProgressState(Ticket);
        }

        public override void Resolve()
        {
            throw new InvalidOperationException("Ticket is not in progress");
        }

        public override void Close()
        {
            throw new InvalidOperationException("Ticket is not in progress");
        }
    }
}

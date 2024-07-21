using State.SUT.Core;

namespace State.SUT
{
    public class CloseState : BaseState
    {
        public CloseState(Ticket ticket) : base(ticket)
        {
            Message = "Ticket closed";
        }

        public override void Open()
        {
            Ticket.State = new OpenState(Ticket, "Ticket reopened");
        }

        public override void Resolve()
        {
            throw new System.InvalidOperationException("Ticket is already closed");
        }

        public override void StartProgress()
        {
            throw new System.InvalidOperationException("Ticket is already closed");
        }

        public override void Close()
        {
            throw new System.InvalidOperationException("Ticket is already closed");
        }
    }
}

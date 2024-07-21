using State.SUT.Core;

namespace State.SUT
{
    public class InProgressState : BaseState
    {
        public InProgressState(Ticket ticket) : base(ticket)
        {
            Message = "Work has started on this ticket";
        }

        public override void Open()
        {
            throw new System.InvalidOperationException("Ticket is already in progress");
        }

        public override void StartProgress()
        {
            throw new System.InvalidOperationException("Ticket is already in progress");
        }

        public override void Resolve()
        {
            Ticket.State = new ResolvedState(Ticket);
        }

        public override void Close()
        {
            throw new System.InvalidOperationException("Ticket is in progress, cannot be closed");
        }
    }
}

using State.SUT.Core;

namespace State.SUT
{
    internal class ResolvedState : BaseState
    {
        public ResolvedState(Ticket ticket) : base(ticket)
        {
            Message = "Ticket resolved, awaiting confirmation";
        }

        public override void Open()
        {
            throw new System.InvalidOperationException("Ticket is already resolved");
        }

        public override void Resolve()
        {
            throw new System.InvalidOperationException("Ticket is already resolved");
        }

        public override void StartProgress()
        {
            throw new System.InvalidOperationException("Ticket is already resolved");
        }

        public override void Close()
        {
            Ticket.State = new CloseState(Ticket);
        }
    }
}

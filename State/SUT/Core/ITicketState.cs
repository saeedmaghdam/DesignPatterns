namespace State.SUT.Core
{
    public interface ITicketState
    {
        string Message { get; }

        void Open();
        void StartProgress();
        void Resolve();
        void Close();
    }
}

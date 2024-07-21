using State.SUT;
using System.Diagnostics.CodeAnalysis;

namespace State.StepDefinitions
{
    [Binding]
    [ExcludeFromCodeCoverage]
    public class TicketStateManagementUsingStatePatternStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        private Ticket? _ticket;

        public TicketStateManagementUsingStatePatternStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [Given("the system is ready to track new tickets")]
        public void GivenTheSystemIsReadyToTrackNewTickets()
        {
            // No action required
        }

        [When("a user opens a new ticket")]
        public void WhenAUserOpensANewTicket()
        {
            _ticket = new Ticket();
        }

        [Then("the ticket should be in the {string} state")]
        public void ThenTheTicketShouldBeInTheState(string state)
        {
            var stateName = _ticket!.State.GetType().Name;

            switch (state)
            {
                case "Open":
                    Assert.Equal(nameof(OpenState), stateName);
                    break;
            }
        }

        [Then("the user should receive confirmation with a {string} message")]
        [Then("the ticket's status should update with a {string} message")]
        public void ThenTheUserShouldReceiveConfirmationWithAMessage(string expectedMessage)
        {
            Assert.Equal(expectedMessage, _ticket!.Message);
        }

        [Given("a ticket is in the {string} state")]
        public void GivenATicketIsInTheState(string initialState)
        {
            _ticket = new Ticket();
            SetTicketState(initialState);
        }

        [When("a user marks the ticket as {string}")]
        public void WhenAUserMarksTheTicketAs(string newState)
        {
            SetTicketState(newState);
        }

        [Then("the ticket should transition to the {string} state")]
        [Then("the ticket should transition back to the {string} state")]
        public void ThenTheTicketShouldTransitionToTheState(string expectedNewState)
        {
            var stateName = _ticket!.State.GetType().Name;

            switch (expectedNewState)
            {
                case "Open":
                    Assert.Equal(nameof(OpenState), stateName);
                    break;
                case "In Progress":
                    Assert.Equal(nameof(InProgressState), stateName);
                    break;
                case "Resolved":
                    Assert.Equal(nameof(ResolvedState), stateName);
                    break;
                case "Closed":
                    Assert.Equal(nameof(CloseState), stateName);
                    break;
            }
        }

        [When("a user closes the ticket")]
        public void WhenAUserClosesTheTicket()
        {
            _ticket!.Close();
        }

        [When("a user reopens the ticket")]
        public void WhenAUserReopensTheTicket()
        {
            _ticket!.Open();
        }

        [When("a user attempts to mark the ticket as {string}")]
        public void WhenAUserAttemptsToMarkTheTicketAs(string newState)
        {
            try
            {
                switch (newState)
                {
                    case "Open":
                        _ticket!.Open();
                        break;
                    case "In Progress":
                        _ticket!.StartProgress();
                        break;
                    case "Resolved":
                        _ticket!.Resolve();
                        break;
                    case "Closed":
                        _ticket!.Close();
                        break;
                }
            }
            catch (InvalidOperationException ex)
            {
                _scenarioContext["exception"] = ex;
            }
        }

        [Then("the state transition should fail")]
        public void ThenTheStateTransitionShouldFail()
        {
            Assert.NotNull(GetException());
        }

        [Then("the system should notify the user with {string} message")]
        public void ThenTheSystemShouldNotifyTheUserWithMessage(string expectedMessage)
        {
            Assert.Equal(expectedMessage, GetException().Message);
        }

        private void SetTicketState(string initialState)
        {
            switch (initialState)
            {
                case "Open":
                    _ticket!.State = new OpenState(_ticket);
                    break;
                case "In Progress":
                    _ticket!.State = new InProgressState(_ticket);
                    break;
                case "Resolved":
                    _ticket!.State = new ResolvedState(_ticket);
                    break;
                case "Closed":
                    _ticket!.State = new CloseState(_ticket);
                    break;
            }
        }

        private InvalidOperationException GetException()
        {
            return (InvalidOperationException)_scenarioContext["exception"];
        }
    }
}

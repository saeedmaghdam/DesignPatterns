Feature: Ticket State Management Using State Pattern

  Scenario: Open a new ticket
    Given the system is ready to track new tickets
    When a user opens a new ticket
    Then the ticket should be in the "Open" state
    And the user should receive confirmation with a "Ticket opened" message

  Scenario: Start working on a ticket
    Given a ticket is in the "Open" state
    When a user marks the ticket as "In Progress"
    Then the ticket should transition to the "In Progress" state
    And the ticket's status should update with a "Work has started on this ticket" message

  Scenario: Resolve a ticket
    Given a ticket is in the "In Progress" state
    When a user marks the ticket as "Resolved"
    Then the ticket should transition to the "Resolved" state
    And the ticket's status should update with a "Ticket resolved, awaiting confirmation" message

  Scenario: Close a ticket
    Given a ticket is in the "Resolved" state
    When a user closes the ticket
    Then the ticket should transition to the "Closed" state
    And the ticket's status should update with a "Ticket closed" message

  Scenario: Reopen a closed ticket
    Given a ticket is in the "Closed" state
    When a user reopens the ticket
    Then the ticket should transition back to the "Open" state
    And the ticket's status should update with a "Ticket reopened" message

  Scenario: Attempt an invalid state transition
    Given a ticket is in the "Open" state
    When a user attempts to mark the ticket as "Closed"
    Then the state transition should fail
    And the system should notify the user with "Ticket is not in progress" message

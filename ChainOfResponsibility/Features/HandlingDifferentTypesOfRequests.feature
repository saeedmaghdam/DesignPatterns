Feature: Handling Requests Using Chain of Responsibility

  Scenario: Handle a request with the first handler in the chain
    Given a chain consisting of a Validator, Authorizer, and Processor
    And the Validator can handle the request
    When the request "Validate data" is received
    Then the request should be handled by the Validator
    And the request should not proceed to the Authorizer
    And the request should not proceed to the Processor

  Scenario: Pass the request to the next handler if the first handler cannot handle it
    Given a chain consisting of a Validator, Authorizer, and Processor
    And the Validator cannot handle the request
    And the Authorizer can handle the request
    When the request "Authorize user" is received
    Then the request should be handled by the Authorizer
    And the request should not proceed to the Processor

  Scenario: Process request if no prior handler can handle it
    Given a chain consisting of a Validator, Authorizer, and Processor
    And the Validator cannot handle the request
    And the Authorizer cannot handle the request
    And the Processor can handle the request
    When the request "Process data" is received
    Then the request should be handled by the Processor

  Scenario: Reject request if no handler can handle it
    Given a chain consisting of a Validator, Authorizer, and Processor
    And no handler can handle the request
    When the request "Unsupported operation" is received
    Then the request should be rejected

  Scenario: Successfully pass through multiple handlers
    Given a chain consisting of a Validator, Authorizer, and Processor
    And the Validator can partially handle the request "Complete transaction"
    And the Authorizer can partially handle the request "Complete transaction"
    And the Processor can fully handle the request "Complete transaction"
    When the request "Complete transaction" is received
    Then the request should be handled first by the Validator
    And then the request should be passed to the Authorizer
    And finally, the request should be handled by the Processor
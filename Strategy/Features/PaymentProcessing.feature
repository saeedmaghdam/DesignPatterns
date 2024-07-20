Feature: Payment Processing Using Strategy Pattern

  Scenario: Process a credit card payment
    Given the user selects "Credit Card" as the payment method
    When the user completes the payment process
    Then the payment should be processed using the "Credit Card Strategy"
    And a receipt should be generated for a credit card transaction

  Scenario: Process a PayPal payment
    Given the user selects "PayPal" as the payment method
    When the user completes the payment process
    Then the payment should be processed using the "PayPal Strategy"
    And a receipt should be generated for a PayPal transaction

  Scenario: Process a bank transfer payment
    Given the user selects "Bank Transfer" as the payment method
    When the user completes the payment process
    Then the payment should be processed using the "Bank Transfer Strategy"
    And a receipt should be generated for a bank transfer transaction

  Scenario: Change payment method after initial selection
    Given the user initially selects "Credit Card" as the payment method
    And then the user changes to "PayPal" as the payment method
    When the user completes the payment process
    Then the payment should be processed using the "PayPal Strategy"
    And a receipt should be generated for a PayPal transaction

  Scenario: Handle an unsupported payment method
    Given the user selects "Cryptocurrency" as the payment method
    When the user attempts to complete the payment process
    Then the payment should not be processed
    And the system should notify the user that the payment method is unsupported

  Scenario: Compare processing fees for different payment methods
    Given the user is considering payment methods
    When the user reviews the fees for "Credit Card", "PayPal", and "Bank Transfer"
    Then the system should display the fees using respective strategies

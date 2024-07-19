Feature: Text Editor Undo and Redo Functionality

  Scenario: Save the initial state of the text
    Given the text editor is open
    When I type "Hello, World!"
    And I save the current state
    Then the current state should be "Hello, World!"

  Scenario: Undo the last change
    Given the text editor is open
    And I type "Hello, World!"
    And I save the current state
    And I type " This is a test."
    And I save the current state
    When I undo the last change
    Then the current state should be "Hello, World!"

  Scenario: Redo the last undone change
    Given the text editor is open
    And I type "Hello, World!"
    And I save the current state
    And I type " This is a test."
    And I save the current state
    And I undo the last change
    When I redo the last undone change
    Then the current state should be "Hello, World! This is a test."

  Scenario: Undo multiple changes
    Given the text editor is open
    And I type "Hello, World!"
    And I save the current state
    And I type " This is a test."
    And I save the current state
    And I type " More text."
    And I save the current state
    When I undo the last change
    And I undo the change before last
    Then the current state should be "Hello, World!"

  Scenario: Redo multiple undone changes
    Given the text editor is open
    And I type "Hello, World!"
    And I save the current state
    And I type " This is a test."
    And I save the current state
    And I type " More text."
    And I save the current state
    And I undo the last change
    And I undo the change before last
    When I redo the change before last
    And I redo the last undone change
    Then the current state should be "Hello, World! This is a test. More text."

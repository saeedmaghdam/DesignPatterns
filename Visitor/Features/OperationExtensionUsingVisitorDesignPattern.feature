Feature: Operation Extension Using Visitor Design Pattern

  Scenario: Apply a specific operation to an element
    Given an object structure with elements NodeA, NodeB, NodeC
    And a Visitor HighlightVisitor that can highlight elements
    When the HighlightVisitor visits element NodeA
    Then element NodeA should perform the highlight operation

  Scenario: Apply different operations to different types of elements
    Given an object structure with elements NodeA, NodeB, NodeC
    And a Visitor RenderVisitor that can render elements differently based on type
    When the RenderVisitor visits element NodeB
    Then element NodeB should perform the render operation specific to its type

  Scenario: Visitor accumulates information from elements
    Given an object structure with elements NodeA, NodeB, NodeC
    And a Visitor StatisticsVisitor that accumulates statistics
    When the StatisticsVisitor visits all elements
    Then the StatisticsVisitor should accumulate statistics from each element
    And provide a sum of the statistics

  Scenario: Elements accept multiple visitors sequentially
    Given an object structure with elements NodeA, NodeB, NodeC
    And a Visitor SaveVisitor that saves element state
    And another Visitor LoadVisitor that loads element state
    When the SaveVisitor visits all elements
    And the LoadVisitor visits all elements sequentially
    Then each element should have its state saved and then reloaded without errors

  Scenario: Visitor modifies elements
    Given an object structure with elements NodeA, NodeB, NodeC
    And a Visitor UpdateVisitor that updates elements
    When the UpdateVisitor visits element NodeC
    Then element NodeC should be updated according to the Visitor's logic
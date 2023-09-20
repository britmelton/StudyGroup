
# [The Most Important TDD Rule](https://enterprisecraftsmanship.com/posts/most-important-tdd-rule/) ~ Vladimir Khorikov

Test Driven Development is exactly what the name says, your _Development_ is _Driven_ by your tests
* tests come first THEN the development of the code

# Why do we test?
* to map the requirements of the system to the code
* to prove that your code base satisfies the specified requirements
* to prevent bugs, errors, defects
* to drive better design(make cleaner code)
* to enable easier refactoring w/o regression

**Unit Test:** Tests a unit of behavior, is highly focused

**Integration Test:** Testing multiple parts of the system working together, or multiple units of behavior working together as designed

# Test Naming Tips
* When naming a test you want to use plain english that a non-tech person could understand.
  * e.g. `WhenAddingALineItem_ThenOrderContainsLineItem`
* your test name should be the action the test will do and the expected result of that action
  * e.g. Action `WhenAddingLineItemToOrder` Result `ThenLineItemExistsInOrder` or `ThenOrderContainsLineItem`
* You should not add the method name in your test name
  * e.g. `WhenCallingOrderAddLineItem_ThenOrderContainsLineItem`
  * this is bad because you are not testing the method you are testing the functionality
  * and refactoring the method name would cause you to have to refactor the test name 
      
## Given is a Precondition
* A precondition is the state of something BEFORE the test is executed
* Given is often used incorrectly in test names
* Given does not mean what is being provided
* **The correct use of Given:**
  * `WhenAddingALineItem_GivenTheLineItemIsArchived_ThenLineItemIsNotAdded`
    * this is stating that there is a precondition that LineItem is Archived
      
  * `WhenWithdrawingMoney_GivenAccountHasNegativeBalance_ThenUnableToWithdraw`
    * this is stating that there is a precondition that Account Balance is negative
      
 * **The incorrect use of Given:**
   * `WhenAddingALineItem_GivenALineItem_ThenOrderContainsLineItem`
     * this is just saying you're providing a line item as the argument, there is no precondition
       
   *  `WhenWithdrawingMoney_GivenOneHundredDollars_ThenAccountBalanceIsUpdated`
      * this is just saying that you're providing $100 as the argument, there is no precondition
        
        

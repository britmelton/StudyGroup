using FluentAssertions;
using FluentAssertions.Execution;
using Test.Driven.Development.Source;

namespace Test.Driven.Development;

public class Tests
{
    /// <summary>
    /// This is the Test Driven Development Process
    /// we started with an empty project
    /// </summary>

    [Fact]
    public void WhenCreatingAnOrderProvidingId_ThenOrderHasId()
    {
        //create this test FIRST and THEN  create an Order class with an Id property to make the test pass
        //Requirement for this test is, when an order is created providing the Id then we want the Order to have that Id

        //create id
        var id = Guid.NewGuid();

        //create order with id
        var order = new Order(id);

        //confirm order id is set as the id created
        order.Id.Should().Be(id);
    }

    [Fact]
    public void WhenCreatingAnOrderNotProvidingId_ThenIdIsNotEmpty()
    {
        //created this test FIRST and THEN add functionality that will create Id if not provided to make the test pass
        //Requirement for this test is, when an order is created without providing an Id then we want the Order to have an Id

        //create order
        var order = new Order();

        //confirm order id is not empty
        order.Id.Should().NotBe(Guid.Empty);
    }

    [Fact]
    public void WhenCreatingALineItem_ThenAllPropertiesAreSet()
    {
        //create this test FIRST and THEN create a LineItem class that has these properties: Id, Price, Quantity to make the test pass
        //Requirement for this test is, when a lineItem is created then it has an id, price, and quantity

        //create lineItem values 
        var id = Guid.NewGuid();
        var price = 5.99m;
        ushort quantity = 15;

        //create new lineItem with values
        var lineItem = new LineItem(id, price, quantity);

        //confirm all properties are set
        using var scope = new AssertionScope();
        lineItem.Id.Should().Be(id);
        lineItem.Price.Should().Be(price);
        lineItem.Quantity.Should().Be(quantity);
    }

    [Fact]
    public void WhenAddingLineItem_ItExistsInOrder()
    {
        //create this test FIRST and THEN add the LineItems list property to Order as well as create the AddLineItem method to make this test pass
        //Requirement for this test is, when a lineItem is added to an order then we want that lineItem to exist in the order

        //create order
        var order = new Order();

        //create lineItem
        var price = 5.47m;
        ushort quantity = 56;
        var lineItem = new LineItem(Guid.NewGuid(), price, quantity);

        //add lineItem to order
        order.AddLineItem(lineItem);

        //confirm lineItem was added to the order
        order.LineItems[0].Should().Be(lineItem);
    }
}
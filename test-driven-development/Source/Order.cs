namespace Test.Driven.Development.Source;

public class Order
{
    public Order(Guid id = default)
    {
        LineItems = new();
        Id = id == Guid.Empty ? Guid.NewGuid() : id;
    }

    public Guid Id { get; set; }
    public List<LineItem> LineItems { get; set; }

    public void AddLineItem(LineItem lineItem)
    {
        LineItems.Add(lineItem);
    }
}
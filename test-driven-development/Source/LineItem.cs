namespace Test.Driven.Development.Source;

public class LineItem
{
    public LineItem(Guid id, decimal price, ushort quantity)
    {
        Price = price;
        Quantity = quantity;
        Id = id == Guid.Empty ? Guid.NewGuid() : id;
    }

    public decimal Price { get; set; }
    public ushort Quantity { get; set; }
    public Guid Id { get; set; }
}
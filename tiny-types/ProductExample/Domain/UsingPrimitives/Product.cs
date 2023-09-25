namespace Tiny.Types.ProductExample.Domain.UsingPrimitives;

public class Product
{
    public Product(string sku, string name, string description)
    {
        Id = Guid.NewGuid();
        Sku = sku;
        Name = name;
        Description = description;
    }

    public Guid Id { get; }
    public string Description { get; private set; }
    public string Name { get; private set; }
    public string Sku { get; }

    /// <remarks>update methods cannot be overloaded</remarks>
    public void UpdateDescription(string description)
    {
        Description = description;
    }

    /// <remarks>update methods cannot be overloaded</remarks>
    public void UpdateName(string name)
    {
        Name = name;
    }
}
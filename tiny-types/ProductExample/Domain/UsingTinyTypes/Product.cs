namespace Tiny.Types.ProductExample.Domain.UsingTinyTypes;

public class Product
{
    public Product(Sku sku, Name name, Description description)
    {
        Id = new ProductId();
        Sku = sku;
        Name = name;
        Description = description;
    }

    public ProductId Id { get; }
    public Description Description { get; private set; }
    public Name Name { get; private set; }
    public Sku Sku { get; }

    public void Update(Description description)
    {
        Description = description;
    }

    public void Update(Name name)
    {
        Name = name;
    }
}

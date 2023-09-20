namespace Mocking.Product.Source;

public record Product(string Sku, string Name, bool IsDeactivated = false)
{
    public Product Deactivate() => this with { IsDeactivated = true };
}
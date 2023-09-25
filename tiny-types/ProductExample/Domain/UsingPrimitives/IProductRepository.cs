namespace Tiny.Types.ProductExample.Domain.UsingPrimitives;

public interface IProductRepository
{
    Product Find(string sku);
    void Update(Product product);
}

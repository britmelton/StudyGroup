using Tiny.Types.ProductExample.Domain.UsingPrimitives;

namespace Tiny.Types.ProductExample.Infrastructure.UsingPrimitives;

public class ProductRepository : IProductRepository
{
    public Product Find(string sku) => throw new NotImplementedException();

    public void Update(Product product)
    {
        throw new NotImplementedException();
    }
}
using Tiny.Types.ProductExample.Domain.UsingTinyTypes;

namespace Tiny.Types.ProductExample.Infrastructure.UsingTinyTypes;

public class ProductRepository : IProductRepository
{
    public Product Find(Sku sku) => throw new NotImplementedException();

    public void Update(Product product)
    {
        throw new NotImplementedException();
    }
}
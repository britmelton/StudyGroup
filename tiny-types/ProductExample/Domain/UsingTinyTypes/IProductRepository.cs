namespace Tiny.Types.ProductExample.Domain.UsingTinyTypes;

public interface IProductRepository
{
    Product Find(Sku sku);
    void Update(Product product);
}
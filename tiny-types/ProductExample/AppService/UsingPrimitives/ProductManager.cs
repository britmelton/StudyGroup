using Tiny.Types.ProductExample.Domain.UsingPrimitives;

namespace Tiny.Types.ProductExample.AppService.UsingPrimitives;

public class ProductManager : IProductManager
{
    private readonly IProductRepository _productRepository;

    public ProductManager(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void Update(UpdateProduct command)
    {
        var (sku, name, description) = command;
        var product = _productRepository.Find(sku);

        product.UpdateName(name);
        product.UpdateDescription(description);

        _productRepository.Update(product);
    }
}
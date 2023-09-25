using Tiny.Types.ProductExample.Domain.UsingTinyTypes;

namespace Tiny.Types.ProductExample.AppService.UsingTinyTypes;

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

        product.Update(name);
        product.Update(description);

        _productRepository.Update(product);
    }
}
namespace Mocking.Product.Source;

public class CatalogService
{
    private readonly IProductRepository _repository;

    public CatalogService(IProductRepository repository)
    {
        _repository = repository;
    }

    public void Deactivate(string sku)
    {
        var product = _repository.Find(sku);

        _repository.Update(product.Deactivate());
    }
}
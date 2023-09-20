namespace Mocking.Product.Source;

public interface IProductRepository
{
    void Create(Product product);
    Product Find(string sku);
    Product Update(Product product);
}
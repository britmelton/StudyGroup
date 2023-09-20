using FluentAssertions;
using Mocking.Product.Source;

namespace Mocking.Product;

    public class WhenDeactivatingProduct
    {
        /// <summary>
        /// this is an integration test
        /// CatalogService has dependency on productRepo
        /// 
        /// what is being tested is CatalogService.Deactivate()
        /// the only way this test works is if the CatalogService is integrated correctly with the IProductRepo
        /// </summary>

        [Fact]
        public void ThenStoredProductIsDeactivated()
        {
            // mock dependency on ProductRepo
            var mockRepository = new MockProductRepository();

            //create catalogService
            var catalogService = new CatalogService(mockRepository);

            //create new Product using MockProductRepo
            var sku = "ABC123";
            var product = new Source.Product(sku, "Shoes");
            mockRepository.Create(product); //this creates and adds Product to storage

            //call Deactivate() using CatalogService
            catalogService.Deactivate(sku);

            //retrieve product from storage
            product = mockRepository.Find(sku);

            //confirm product was deactivated
            product.IsDeactivated.Should().BeTrue();
        }
    }

    #region Mock
    public class MockProductRepository : IProductRepository
    {
        /// <summary>
        /// mock is a test specific implementation of a dependency
        ///
        /// moq library is just so you don't have to do this, you can decide whether or not it's worth using Moq
        /// </summary>

        private readonly Dictionary<string, Source.Product> _products = new();

        public void Create(Source.Product product) => _products.Add(product.Sku, product);

        public Source.Product Find(string sku) => _products[sku];

        public Source.Product Update(Source.Product product) => _products[product.Sku] = product;
    }
    #endregion
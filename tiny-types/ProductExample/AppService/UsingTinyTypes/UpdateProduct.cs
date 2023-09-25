using Tiny.Types.ProductExample.Domain.UsingTinyTypes;

namespace Tiny.Types.ProductExample.AppService.UsingTinyTypes;

public record UpdateProduct(
    Sku Sku, 
    Name Name, 
    Description Description
    );
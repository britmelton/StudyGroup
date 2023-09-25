using Tiny.Types.Source.Base;

namespace Tiny.Types.ProductExample.Domain.UsingTinyTypes;

public class Sku : TinyType<string>
    {
        public Sku(string value) : base(value)
        { }
    }

    public class Name : TinyType<string>
    {
        public Name(string value) : base(value)
        { }
    }

    public class Description : TinyType<string>
    {
        public Description(string value) : base(value)
        { }
    }

    public class ProductId : TinyType<Guid>
    {
        public ProductId(Guid value = default) : base(
            value == Guid.Empty ? Guid.NewGuid() : value
        )
        { }
    }
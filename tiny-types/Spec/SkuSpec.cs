using FluentAssertions;
using Tiny.Types.Source;
using Tiny.Types.Source.Base;
using Tiny.Types.Spec.Base;

namespace Tiny.Types.Spec;

public class SkuSpec
{
    public class WhenEvaluatingEquality : TinyTypeSpec.WhenEvaluatingEquality<string>
    {
        public override TinyType<string> Create()
        {
            return new Sku("abc123");
        }

        public override TinyType<string> CreateOther()
        {
            return new Sku("avf456");
        }
    }

    [Theory]
    [InlineData("abc123")]
    [InlineData("wdg458")]
    public void WhenCreatingSku_WithValidValue_ThenSkuIsReturned(string value)
    {
        var sku = new Sku(value);

        sku.Value.Should().Be(value);
    }

    [Theory]
    [InlineData("ws256")]
    [InlineData("wser256")]
    [InlineData("145")]
    [InlineData("!@#256")]
    [InlineData("wss25")]
    [InlineData("wsr2565")]
    [InlineData("skd")]
    [InlineData("aws!@#")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void WhenCreatingSku_WithInvalidValue_ThenThrowArgumentException(string value)
    {
        Action createInvalidSku = () => new Sku(value);
        createInvalidSku.Should().Throw<ArgumentException>();
    }
}
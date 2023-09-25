using FluentAssertions;
using Tiny.Types.Source.Base;
using Tiny.Types.Spec.Base;

namespace Tiny.Types.Spec;

public class ZipCodeSpec
{
    public class WhenEvaluatingEquality : TinyTypeSpec.WhenEvaluatingEquality<string>
    {
        public override TinyType<string> Create()
        {
            return new ZipCode("23453-5675");
        }

        public override TinyType<string> CreateOther()
        {
            return new ZipCode("45675");
        }
    }

    [Theory]
    [InlineData("34534-4563")]
    [InlineData("45653")]
    public void WhenCreatingZipCode_WithValidValue_ThenZipCodeIsReturned(string value)
    {
        var sku = new ZipCode(value);

        sku.Should().NotBeNull();
        sku.Value.Should().Be(value);
    }

    [Theory]
    [InlineData("345-7654")]
    [InlineData("56764-")]
    [InlineData("4564")]
    [InlineData("45354&3454")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void WhenCreatingZipCode_WithInvalidZipCode_ThenThrowArgumentException(string value)
    {
        Action createInvalidZipCode = () => new ZipCode(value);
        createInvalidZipCode.Should().Throw<ArgumentException>();
    }
}
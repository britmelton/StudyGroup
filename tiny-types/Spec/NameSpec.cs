using FluentAssertions;
using Tiny.Types.Source.Base;
using Tiny.Types.Spec.Base;

namespace Tiny.Types.Spec;

public class NameSpec
{
    public class WhenEvaluatingEquality : TinyTypeSpec.WhenEvaluatingEquality<string>
    {
        public override TinyType<string> Create()
        {
            return new Name("name");
        }

        public override TinyType<string> CreateOther()
        {
            return new Name("otherName");
        }
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void WhenCreatingAnInvalidName_ThenThrowArgumentException(string value)
    {
        Action createInvalidName = () => new Name(value);
        createInvalidName.Should().Throw<ArgumentException>();
    }
}
using FluentAssertions;
using Tiny.Types.Source.Base;

namespace Tiny.Types.Spec.Base;

public class TinyTypeSpec
{
    public abstract class WhenEvaluatingEquality<T>
    {
        public abstract TinyType<T> Create();
        public abstract TinyType<T> CreateOther();

        [Fact]
        public void WithSameReference_ThenReturnTrue()
        {
            var tinyType1 = Create();
            var tinyType2 = tinyType1;

            tinyType2.Should().BeSameAs(tinyType1);

            (tinyType1 == tinyType2).Should().BeTrue();
            (tinyType1 != tinyType2).Should().BeFalse();
        }

        [Fact]
        public void WithSameValues_ThenReturnTrue()
        {
            var tinyType1 = Create();
            var tinyType2 = Create();

            tinyType2.Should().Be(tinyType1);
            tinyType2.Should().NotBeSameAs(tinyType1);

            (tinyType1 == tinyType2).Should().BeTrue();
            (tinyType1 != tinyType2).Should().BeFalse();
        }

        [Fact]
        public void WithDifferentValues_ThenReturnFalse()
        {
            var tinyType1 = Create();
            var tinyType2 = CreateOther();

            tinyType2.Should().NotBe(tinyType1);

            (tinyType1 == tinyType2).Should().BeFalse();
            (tinyType1 != tinyType2).Should().BeTrue();
        }

        [Fact]
        public void WithNullReference_ThenReturnFalse()
        {
            var tinyType1 = Create();
            TinyType<T>? nullObject = null;

            tinyType1.Should().NotBe(nullObject);
            nullObject.Should().NotBe(tinyType1);

            (tinyType1 == null).Should().BeFalse();
            (tinyType1 != null).Should().BeTrue();

            (null == tinyType1).Should().BeFalse();
            (null != tinyType1).Should().BeTrue();
        }

        [Fact]
        public void WithTwoNullReferences_ThenReturnTrue()
        {
            TinyType<T>? nullObject1 = null;
            TinyType<T>? nullObject2 = null;

            nullObject1.Should().Be(nullObject2);

            (nullObject1 == nullObject2).Should().BeTrue();
            (nullObject2 != nullObject1).Should().BeFalse();
        }

        [Fact]
        public void WithOtherType_ThenReturnFalse()
        {
            var tinyType1 = Create();
            var tinyType2 = new Foo(9) as TinyType<T>;

            tinyType1.Should().NotBe(tinyType2);

            (tinyType1 == tinyType2).Should().BeFalse();
            (tinyType1 != tinyType2).Should().BeTrue();
        }
    }
}

internal class Foo : TinyType<int>
{
    public Foo(int value) : base(value)
    { }
}
using FluentAssertions;
using Tiny.Types.Source.Base;
using Tiny.Types.Spec.Base;

namespace Tiny.Types.Spec;

public class DrinkSizeSpec
{
    public class WhenEvaluatingEquality : TinyTypeSpec.WhenEvaluatingEquality<char>
    {
        public override TinyType<char> Create()
        {
            return new DrinkSize('s');
        }

        public override TinyType<char> CreateOther()
        {
            return new DrinkSize('L');
        }
    }

    public static IEnumerable<object[]> GetInvalidSizes()
    {
        var characters = Enumerable.Range('a', 26).Select(x => (char)x).ToList();
        characters.AddRange(Enumerable.Range('A', 26).Select(x => (char)x));

        var validSizes = new List<char> { 's', 'm', 'l', 'S', 'M', 'L' };

        foreach (var c in characters.Except(validSizes))
        {
            yield return new object[] { c };
        }
    }

    [Theory]
    [MemberData(nameof(GetInvalidSizes))]
    public void WhenCreatingDrinkSize_WithInvalidValue_ThenThrowArgumentException(char size)
    {
        var createInvalidDrinkSize = () =>
        {
            var s = new DrinkSize(size);
        };
        createInvalidDrinkSize.Should().Throw<ArgumentException>();
    }
}
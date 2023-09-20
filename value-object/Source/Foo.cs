namespace Value.Object.Source;

public class Foo : ValueObject
{
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return (byte)255;
        yield return (byte)0;
        yield return (byte)0;
    }
}
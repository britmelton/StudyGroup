namespace Tiny.Types.Source.Base;

/// <summary>
/// this is the base TinyType class that we will inherit in our concrete TinyTypes
/// </summary>

public abstract class TinyType<T>
{
    protected TinyType(T value)
    {
        Value = value;
    }

    public T Value { get; }

    public override bool Equals(object? other)
    {
        if (other is null || GetType() != other.GetType())
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return Value.Equals(((TinyType<T>)other).Value);
    }

    public static bool operator ==(TinyType<T>? left, TinyType<T>? right)
    {
        if (left is null && right is null)
        {
            return true;
        }

        if (left is null || right is null)
        {
            return false;
        }

        return left.Equals(right);
    }

    public static bool operator !=(TinyType<T>? left, TinyType<T>? right)
    {
        return !(left == right);
    }
}
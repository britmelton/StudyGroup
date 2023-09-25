using System.Text.RegularExpressions;
using Tiny.Types.Source.Base;

namespace Tiny.Types.Source;


/// <summary>
/// this TinyType is using the 2nd way of implementation I went over
/// using a base TinyType class
/// </summary>
public class Sku : TinyType<string>
{
    public Sku(string value) : base(value)
    {
        if (!Regex.IsMatch(value, "^[a-zA-Z]{3}[0-9]{3}$"))
        {
            throw new ArgumentException("Sku must be 3 letters followed by 3 numbers", nameof(value));
        }
    }
}
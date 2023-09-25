using System.Text.RegularExpressions;

namespace Tiny.Types.Source.Base;

/// <summary>
/// these are the TinyType implementations using the Base TinyType class
/// </summary>

public class Name : TinyType<string>
{
    public Name(string value) : base(value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("cannot be empty", nameof(value));
    }
}

public class DrinkSize : TinyType<char>
{
    public DrinkSize(char value) : base(value)
    {
        switch (value)
        {
            case 's':
            case 'm':
            case 'l':
            case 'S':
            case 'M':
            case 'L':
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), "Not a size");
        }
    }
}

#region AppointmentTinyTypes

public class AppointmentId : TinyType<Guid>
{
    public AppointmentId(Guid value) : base(value)
    { }
}

public class DoctorId : TinyType<Guid>
{
    public DoctorId(Guid value) : base(value)
    { }
}

public class RoomId : TinyType<Guid>
{
    public RoomId(Guid value) : base(value)
    { }
}

public class PatientId : TinyType<Guid>
{
    public PatientId(Guid value) : base(value)
    { }
}

#endregion

#region AddressTinyTypes

public class StreetName : TinyType<string>
{
    public StreetName(string value) : base(value)
    { }
}

public class StreetNumber : TinyType<uint>
{
    public StreetNumber(uint value) : base(value)
    { }
}

public class City : TinyType<string>
{
    public City(string value) : base(value)
    { }
}

public class ZipCode : TinyType<string>
{
    public ZipCode(string value) : base(value)
    {
        if (!Regex.IsMatch(value, "^[0-9]{5}(?:-[0-9]{4})?$|^[0-9]{5}$"))
        {
            throw new ArgumentException("ZipCode must be 5 digits followed by a hyphen and another 4 digits or 5 digits", nameof(value));
        }
    }
}
#endregion

using System.Text.RegularExpressions;

namespace Tiny.Types.Source.TinyTypeExamples;

/// <summary>
/// These TinyTypes are implemented individually, not using the base TinyType class
/// this is the first way of implementation I went over
/// </summary>

#region Name Example

/// <summary>
/// showing the benefit 
/// "TinyTypes help to more clearly communicate valid values for an object"
/// e.g. Name is not adequately described by the string primitive type
///     Name can't be empty which is not true of strings
/// </summary>

public class Person
{
    public Person(Name name)
    {
        Name = name;
    }

    public Name Name { get; set; }
}

public class Name
{
    public Name(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("cannot be empty, null, or whitespace", nameof(value));
        Value = value;
    }

    public string Value { get; }

    public override bool Equals(object? other)
    {
        if (other is null)
            return false;

        if (other.GetType() != typeof(Name))
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return ((Name)other).Value == Value;
    }
}

#endregion

#region Drink Size Example

/// <summary>
/// showing the benefit
/// "TinyTypes help you narrow down the set of all possible values"
/// in this example DrinkSize can only be a letter, and it can only be s,m,l or S,M,L
/// so the size of a drink is more narrow that just the char primitive type
/// </summary>

public class Drink
{
    public Drink(DrinkSize size)
    {
        Size = size;
    }

    public DrinkSize Size { get; set; }
}

public class DrinkSize
{
    public DrinkSize(char value)
    {
        switch (value)
        {
            case 's':
            case 'm':
            case 'l':
            case 'S':
            case 'M':
            case 'L':
                Value = value;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), "Not a valid size");
        }
    }

    public char Value { get; }

    public override bool Equals(object? other)
    {

        if (other is null)
            return false;

        if (other.GetType() != typeof(DrinkSize))
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return ((DrinkSize)other).Value == Value;
    }
}
#endregion

#region Receipt Example

/// <summary>
/// showing the benefit
/// "TinyTypes help make your code more readable"
/// this is harder to show the value of on a small scale
/// but in this example it's more clear and readable for the decimal to be a tinytype since it represents a specific type of decimal
/// in this case it's usd
/// </summary>

public class Receipt
{
    public Receipt(Usd dollars)
    {
        Amount = dollars;
    }

    public Usd Amount { get; set; }
}

public class Usd
{
    public Usd(decimal value)
    {
        Value = value;
    }
    public decimal Value { get; }

    public override bool Equals(object? other)
    {
        if (other is null)
            return false;

        if (other.GetType() != typeof(Usd))
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return ((Usd)other).Value == Value;
    }
}
#endregion

#region Appointment Example

/// <summary>
/// Appointment Example and Address Example show the benefits
/// "TinyTypes make your code easier to use correctly and more difficult to us incorrectly"
/// "TinyTypes give you type safetly by distinguishing between similar types"
/// "TinyTypes give you validation when modeling an always valid Domain. You can't create one that isn't valid,
/// so if you have one you know it's valid"
/// </summary>

public class Appointment
{
    public Appointment(AppointmentId id, DoctorId doctorId, PatientId patientId, RoomId? roomId)
    {
        Id = id;
        DoctorId = doctorId;
        PatientId = patientId;
        RoomId = roomId;
    }

    public AppointmentId Id { get; set; }
    public DoctorId DoctorId { get; set; }
    public PatientId PatientId { get; set; }
    public RoomId? RoomId { get; set; }

    public void ReSchedule(AppointmentId appointmentId, DoctorId doctorId, PatientId patientId)
    {
        Id = appointmentId;
        DoctorId = doctorId;
        PatientId = patientId;
    }

    public void AssignRoom(RoomId roomId)
    {
        RoomId = roomId;
    }
}
#region TinyTypes
public class AppointmentId
{
    public AppointmentId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public override bool Equals(object? other)
    {
        if (other is null)
            return false;

        if (other.GetType() != typeof(AppointmentId))
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return ((AppointmentId)other).Value == Value;
    }
}

public class DoctorId
{
    public DoctorId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public override bool Equals(object? other)
    {
        if (other is null)
            return false;

        if (other.GetType() != typeof(DoctorId))
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return ((DoctorId)other).Value == Value;
    }
}

public class RoomId
{
    public RoomId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public override bool Equals(object? other)
    {
        if (other is null)
            return false;

        if (other.GetType() != typeof(RoomId))
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return ((RoomId)other).Value == Value;
    }
}

public class PatientId
{
    public PatientId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public override bool Equals(object? other)
    {
        if (other is null)
            return false;

        if (other.GetType() != typeof(PatientId))
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return ((PatientId)other).Value == Value;
    }
}
#endregion
#endregion

#region Address Example
public class Address
{
    public Address(StreetNumber streetNumber, StreetName streetName, City city, ZipCode zipCode)
    {
        StreetNumber = streetNumber;
        StreetName = streetName;
        City = city;
        ZipCode = zipCode;
    }

    public City City { get; }
    public StreetName StreetName { get; }
    public StreetNumber StreetNumber { get; }
    public ZipCode ZipCode { get; }
}

#region TinyTypes
public class StreetName
{
    public StreetName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public override bool Equals(object? other)
    {
        if (other is null)
            return false;

        if (other.GetType() != typeof(StreetName))
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return ((StreetName)other).Value == Value;
    }
}

public class StreetNumber
{
    public StreetNumber(uint value)
    {
        Value = value;
    }

    public uint Value { get; }

    public override bool Equals(object? other)
    {
        if (other is null)
            return false;

        if (other.GetType() != typeof(StreetNumber))
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return ((StreetNumber)other).Value == Value;
    }
}

public class City
{
    public City(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public override bool Equals(object? other)
    {
        if (other is null)
            return false;

        if (other.GetType() != typeof(City))
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return ((City)other).Value == Value;
    }
}

public class ZipCode
{
    public ZipCode(string value)
    {
        if (!Regex.IsMatch(value, "^[0-9]{5}(?:-[0-9]{4})?$|^[0-9]{5}$"))
        {
            throw new ArgumentException("ZipCode must be 5 digits followed by a hyphen and another 4 digits or 5 digits", nameof(value));
        }
        Value = value;
    }

    public string Value { get; }

    public override bool Equals(object? other)
    {
        if (other is null)
            return false;

        if (other.GetType() != typeof(ZipCode))
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return ((ZipCode)other).Value == Value;
    }
}
#endregion
#endregion
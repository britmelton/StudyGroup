namespace Tiny.Types.Source.PrimitiveExamples;

/// <summary>
/// these are the examples for using only the primitive types 
/// these match to the examples in <see cref="TinyTypeExamples"/>
/// </summary>

#region Name Example
public class Person
{
    public Person(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
#endregion

#region DrinkSize Example
public class Drink
{
    public Drink(char size)
    {
        Size = size;
    }
    public char Size { get; set; }
}
#endregion

#region Receipt Example
public class Receipt
{
    public Receipt(decimal amountInDollars)
    {
        AmountInDollars = amountInDollars;
    }

    public decimal AmountInDollars { get; set; }
}
#endregion

#region Appointment Example
public class Appointment
{
    public Appointment(Guid id, Guid doctorId, Guid patientId, Guid? roomId)
    {
        Id = id;
        DoctorId = doctorId;
        PatientId = patientId;
        RoomId = roomId;
    }
    public Guid Id { get; set; }
    public Guid DoctorId { get; set; }
    public Guid PatientId { get; set; }
    public Guid? RoomId { get; set; }

    public void ReSchedule(Guid appointmentId, Guid doctorId, Guid patientId)
    {
        Id = appointmentId;
        DoctorId = doctorId;
        PatientId = patientId;
    }

    public void AssignRoom(Guid roomId)
    {
        RoomId = roomId;
    }
}
#endregion

#region Address Example
public class Address
{
    public Address(uint streetNumber, string streetName, string city, string zipCode)
    {
        StreetNumber = streetNumber;
        StreetName = streetName;
        City = city;
        ZipCode = zipCode;
    }

    public uint StreetNumber { get; }
    public string StreetName { get; }
    public string City { get; }
    public string ZipCode { get; }
}
#endregion
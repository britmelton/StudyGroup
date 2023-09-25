
//using Tiny.Types.Source.PrimitiveExamples;
//using Tiny.Types.Source.TinyTypeExamples;

namespace Example.Sandbox;

internal class Program
{
    static void Main(string[] args)
    {

        #region Name/Person Example

        /// <summary>
        /// primitive types 
        /// uncomment this using statement at the top
        /// using Tiny.Types.Source.PrimitiveExamples;
        /// </summary>

        //var person = new Person(" ");

        //Console.WriteLine($"this is a persons name: {person.Name}");
        //Console.ReadLine();


        /// <summary>
        /// tinytypes
        /// uncomment this using statement at the top
        /// using Tiny.Types.Source.TinyTypeExamples;
        /// </summary>

        //var name = new Name(" ");
        //Person person = new(name);

        //Console.WriteLine($"this is a persons name: {person.Name}");
        //Console.ReadLine();

        #endregion


        #region DrinkSize Example

        /// <summary>
        /// tinytypes
        /// uncomment this using statement at the top
        /// using Tiny.Types.Source.TinyTypeExamples;
        /// </summary>

        //var invalidDrinkSize = new DrinkSize('R');
        //Console.WriteLine($"{invalidDrinkSize.Value}");

        //var drinkSize = new DrinkSize('S');
        //Console.WriteLine($"{drinkSize.Value}");

        #endregion


        #region Appointment Example

        /// <summary>
        /// primitive types 
        /// uncomment this using statement at the top
        /// using Tiny.Types.Source.PrimitiveExamples;
        /// </summary>

        //var appointmentId = Guid.NewGuid();
        //var doctorId = Guid.NewGuid();
        //var patientId = Guid.NewGuid();
        //var roomId = Guid.NewGuid();

        //var appointment = new Appointment(appointmentId, roomId, doctorId, patientId);

        //appointment.AssignRoom(appointmentId);


        /// <summary>
        /// tinytypes
        /// uncomment this using statement at the top
        /// using Tiny.Types.Source.TinyTypeExamples;
        /// </summary>

        //// var id = new AppointmentId(Guid.NewGuid());
        // var doctorId = new DoctorId(Guid.NewGuid());
        // var patientId = new PatientId(Guid.NewGuid());
        // var id = new AppointmentId(patientId);
        // var roomId = new RoomId(Guid.NewGuid());

        // var appointment = new Appointment(id, roomId, doctorId, patientId);

        // appointment.AssignRoom(id);

        #endregion


        #region Address Example

        /// <summary>
        /// primitive types 
        /// uncomment this using statement at the top
        /// using Tiny.Types.Source.PrimitiveExamples;
        /// </summary>

        //var streetNumber = 453u;
        //var streetName = "main st";
        //var city = "city name";
        //var zipcode = "453-565";

        //var address = new Address(streetNumber, city, streetName, zipcode);

        //Console.WriteLine($" streetNumber: {address.StreetNumber},"
        //                + $"\n streetName: {address.StreetName},"
        //                + $"\n city: {address.City},"
        //                + $"\n zipcode: {address.ZipCode}");
        //Console.ReadLine();


        /// <summary>
        /// tinytypes
        /// uncomment this using statement at the top
        /// using Tiny.Types.Source.TinyTypeExamples;
        /// </summary>

        //var streetNumber = new StreetNumber(345u);
        //var streetName = new StreetName("main st");
        //var city = new City("city name");
        //var zipcode = new ZipCode("14535-344");

        //var address = new Address(streetNumber, streetName, city, zipcode);

        //Console.WriteLine($"streetNumber: {address.StreetNumber},"
        //                + $"\n streetName: {address.StreetName},"
        //                + $"\n city: {address.City},"
        //                + $"\n zipcode: {address.ZipCode}");
        //Console.ReadLine();

        #endregion

    }
}
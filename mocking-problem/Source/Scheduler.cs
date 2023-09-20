namespace Mocking.Problem.Source;

public class Scheduler : IScheduler
{
    public Schedule Schedule(DateTime date, Employee[] employees)
    {
        return new(date, employees);

        //return new(date, new Employee[3]);
    }
}

public interface IScheduler
{
    Schedule Schedule(DateTime date, Employee[] employees);
}

#region Schedule class
public class Schedule
{
    public Schedule(DateTime date, Employee[] employees)
    {
        Date = date;

        var currentShift = Shift.First;

        foreach (var employee in employees)
        {
            _assignments.Add(currentShift, employee);
            currentShift = currentShift.Next();
        }
    }

    private readonly Dictionary<Shift, Employee> _assignments = new();

    public Employee this[Shift shift] => _assignments[shift];

    public DateTime Date { get; }
}
#endregion

#region Shift enum and extensions

public enum Shift
{
    First,
    Second,
    Third
}

public static class ShiftExtensions
{
    public static Shift Next(this Shift shift) =>
        shift switch
        {
            Shift.First => Shift.Second,
            Shift.Second => Shift.Third,
            Shift.Third => Shift.First
        };
}

#endregion
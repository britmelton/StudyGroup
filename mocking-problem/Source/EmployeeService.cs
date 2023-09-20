namespace Mocking.Problem.Source;

public class EmployeeService
{
    public EmployeeService(IScheduler scheduler)
    {
        _scheduler = scheduler;
    }

    private readonly IScheduler _scheduler;

    public Schedule Schedule(DateTime date, Employee[] employees)
    {
        return _scheduler.Schedule(date, employees);

        //return new(date, employees);
    }
}

#region Employee class

public class Employee
{
    public Employee(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public static implicit operator Employee(string name) => new(name);
}

#endregion
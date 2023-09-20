namespace Mocking.Enrollment.Source;

/// <remarks>
///     This is a domain service, not an application service.
///     It does not have any dependencies outside of the domain.
/// </remarks>
public class EnrollmentService
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public EnrollmentService(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public Enrollment Register(Student student, Class @class)
    {
        @class.Add(student);
        return CreateEnrollment(student, @class, _dateTimeProvider.Now);
    }

    private static Enrollment CreateEnrollment(Student student, Class @class, DateTime enrolledOn) =>
        new(@class.Id, student.Id, enrolledOn);
}

#region classes
public class Enrollment : Entity
{
    public Enrollment(Guid classId, Guid studentId, DateTime enrolledOn)
    {
        ClassId = classId;
        StudentId = studentId;
        EnrolledOn = enrolledOn;
    }

    public Enrollment(Guid id, Guid classId, Guid studentId, DateTime enrolledOn) : base(id)
    {
        ClassId = classId;
        StudentId = studentId;
        EnrolledOn = enrolledOn;
    }

    public Guid ClassId { get; }
    public Guid StudentId { get; }
    public DateTime EnrolledOn { get; }

}

public class Class : Entity
{
    private readonly HashSet<Student> _students = new();

    public IReadOnlyList<Student> Students => _students.ToList().AsReadOnly();

    public Class Add(Student student)
    {
        _students.Add(student);
        return this;
    }
}

public class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }

    public Entity(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }

}

public class Student : Entity
{ }
#endregion
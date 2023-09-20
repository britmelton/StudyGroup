using FluentAssertions;
using FluentAssertions.Execution;
using Mocking.Enrollment.Source;
using Moq;

namespace Mocking.Enrollment;

public class WhenRegisteringAStudentToAClass
{
    #region Setup

    private readonly Class _class = new();
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly Source.Enrollment _enrollment;
    private readonly Student _student = new();

    public WhenRegisteringAStudentToAClass()
    {
        var service = new EnrollmentService(_dateTimeProvider = new MockDateTimeProvider());

        _enrollment = service.Register(_student, _class);
    }
    #endregion

    [Fact]
    public void ThenStudentWasAddedToClass()
    {
        _class.Students.Should().Contain(_student);
    }

    [Fact]
    public void ThenEnrollmentIsExpected()
    {
        using var scope = new AssertionScope();
        _enrollment.ClassId.Should().Be(_class.Id);
        _enrollment.StudentId.Should().Be(_student.Id);
        _enrollment.EnrolledOn.Should().Be(_dateTimeProvider.Now);
    }

    //same test using Moq
    [Fact]
    public void ThenEnrollmentIsExpected2()
    {
        var dateTimeProvider = new Mock<IDateTimeProvider>();
        dateTimeProvider.Setup(dt => dt.Now).Returns(new DateTime(2023, 12, 05));

        var service = new EnrollmentService(dateTimeProvider.Object);

        var enrollment = service.Register(_student, _class);

        using var scope = new AssertionScope();
        enrollment.ClassId.Should().Be(_class.Id);
        enrollment.StudentId.Should().Be(_student.Id);
        enrollment.EnrolledOn.Should().Be(new DateTime(2023, 12, 05));
    }
}

public class MockDateTimeProvider : IDateTimeProvider
{
    //mock is a test specific implementation of a dependency
    //moq library is just so you don't have to do this, you can decide whether or not it's worth using Moq

    public DateTime Now => new(2023, 01, 01);
}
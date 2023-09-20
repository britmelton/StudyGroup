namespace Mocking.Enrollment.Source;

public interface IDateTimeProvider
{
    DateTime Now { get; }
}
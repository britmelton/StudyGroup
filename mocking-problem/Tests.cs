using FluentAssertions;
using FluentAssertions.Execution;
using Mocking.Problem.Source;

namespace Mocking.Problem;

public class Tests
{
    /// <summary>
    /// See <see cref="EmployeeService.Schedule"/>
    /// </summary>
    public class WhenSchedulingEmployees
    {
        #region goodScheduleTest
        /// <summary>
        /// this is a test for the EmployeeService Schedule() method, to confirm that scheduling employees works.
        ///  Using the actual Scheduler
        ///     this test is testing the output of the Schedule() method
        ///
        /// The EmployeeService has a dependency on an IScheduler
        /// </summary>
        [Fact]
        public void ThenReturnSchedule()
        {
            //setup
            var scheduler = new Scheduler();
            var service = new EmployeeService(scheduler);
            var employees = new Employee[] { "Bob", "Susan", "John" };

            //take employees and assign them to a shift
            var schedule = service.Schedule(new DateTime(2023, 9, 9), employees);

            //confirm employees are assigned to the correct shift
            using var scope = new AssertionScope();
            schedule[Shift.First].Name.Should().Be("Bob");
            schedule[Shift.Second].Name.Should().Be("Susan");
            schedule[Shift.Third].Name.Should().Be("John");
        }
        #endregion

        #region badMockScheduleTest
        /// <summary>
        ///   Mocked the actual functionality. View the mock in region MockScheduler below
        ///   this is where unnecessary mocking can get you into trouble
        ///
        /// this test passes even when we break the real Scheduler.
        /// goto <see cref= "Scheduler.Schedule"/> in Source folder and comment line 7 and uncomment line 9
        /// because this test still passes it is giving us incorrect information about the state of the code
        /// you will see that the good test above fails as it should
        /// </summary>
        [Fact]
        public void ThenScheduleIsExpected()
        {
            //setup
            var scheduler = new MockScheduler();
            var service = new EmployeeService(scheduler);
            var employees = new Employee[] { "Bob", "Susan", "John" };

            //take employees and assign them to a shift
            var schedule = service.Schedule(new DateTime(2023, 9, 9), employees);

            //confirm employees are assigned to the correct shift
            using var scope = new AssertionScope();
            schedule[Shift.First].Name.Should().Be("Bob");
            schedule[Shift.Second].Name.Should().Be("Susan");
            schedule[Shift.Third].Name.Should().Be("John");
        }
        #endregion

        #region tests implementation = bad
        /// <summary>
        ///     Tests the implementation details of EmployeeService.Schedule
        /// this test is unnecessary but it's something many people do
        /// it is brittle and breaks even if the EmployeeService is still working
        ///
        /// say we no longer want to use Scheduler.
        /// Schedule() still works accurately, but this test fails which would show that something is broken when really nothing is.
        /// There are many ways for the Schedule() method to be implemented therefore we don't care HOW it does it we only care that the employees were scheduled correctly
        /// 
        /// goto <see cref="EmployeeService.Schedule"/> in Source folder and comment out line 14 and uncomment line 16.
        /// All this does is change the EmployeeService to no longer use Scheduler BUT the functionality still remains correct
        /// when you run the test explorer this will fail even though EmployeeService is not actually broken
        /// you will see the first correct test still passes
        /// </summary>

        [Fact]
        public void ThenSchedulerWasCalled()
        {
            //setup (view SpyScheduler() in the region below
            var scheduler = new SpyScheduler();
            var service = new EmployeeService(scheduler);
            var employees = new Employee[] { "Bob", "Susan", "John" };

            //assign employees to a shift
            var schedule = service.Schedule(new DateTime(2023, 9, 9), employees);

            //confirm that Schedule() method was called
            using var scope = new AssertionScope();
            scheduler.TimesCalled.Should().Be(1);
        }
        #endregion
    }

    #region MockScheduler
    public class MockScheduler : IScheduler
    {
        public Schedule Schedule(DateTime date, Employee[] employees) =>
            new(date, new Employee[] { "Bob", "Susan", "John" });
    }
    #endregion

    #region SpySchduler
    public class SpyScheduler : IScheduler
    {
        /// <summary>
        ///    a spy is a type of mock where you track information about what happened
        /// e.g. this spy makes sure/keeps track that the Schedule() method was called
        /// 
        ///     because this keeps track that the Schedule() method was called it is telling implementation details
        ///     we don't care that the Schedule() method was called we only care if the output from EmployeeService is correct
        /// </summary>
        public int TimesCalled { get; private set; }

        public Schedule Schedule(DateTime date, Employee[] employees)
        {
            TimesCalled++;
            return new(date, employees);
        }
    }
    #endregion
}
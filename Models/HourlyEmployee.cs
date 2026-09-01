using EmployeeSystem.Helpers;

namespace EmployeeSystem.Models
{
    /// <summary>
    /// Represents an hourly employee with a fixed hourly rate and hours worked.
    /// </summary>
    internal class HourlyEmployee : Employee
    {
        /// <summary>
        /// The hourly rate for the employee, representing the amount earned per hour of work.
        /// </summary>
        internal decimal HourlyRate { get; private set; }

        /// <summary>
        /// The total number of hours worked by the employee, used to calculate the total salary based on the hourly rate.
        /// </summary>
        internal int HoursWorked { get; private set; }
        public HourlyEmployee(string employeeId, string name, DateTime hireDate, decimal hourlyRate, int hoursWorked)
            : base(employeeId, name, hireDate)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }
        /// <summary>
        /// Calculates the total salary for the hourly employee by multiplying the hourly rate by the hours worked.
        /// </summary>
        /// <returns>The total salary.</returns>
        public override decimal CalculateSalary() => HourlyRate * HoursWorked;
        /// <summary>
        /// Provides a description of the hourly employee, including their name, monthly salary, hourly rate, and hours worked.
        /// </summary>
        /// <returns>A string describing the employee's salary information.</returns>
        public override string Description() => $"{base.Description()}\n" +
                $"{Output.FormatText(Label.HourlyRate, $"{HourlyRate:F2}")}\n" +
                $"{Output.FormatText(Label.HoursWorked, $"{HoursWorked:N2}")}";
    }

}


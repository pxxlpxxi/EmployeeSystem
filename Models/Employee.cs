using EmployeeSystem.Helpers;

namespace EmployeeSystem.Models
{
    /// <summary>
    /// Represents an employee with basic information such as employee ID, name, and hire date.
    /// </summary>
    internal class Employee
    {
        /// <summary>
        /// Gets the unique identifier for the employee, which is used to distinguish between different employees in the system.
        /// </summary>
        internal string EmployeeId { get; private set; }

        /// <summary>
        /// Gets the name of the employee, which is used for display purposes and to identify the employee in reports and outputs.
        /// </summary>
        internal string Name { get; private set; }

        internal DateTime HireDate { get; private set; }

        public Employee(string employeeId, string name, DateTime hireDate)
        {
            EmployeeId = employeeId;
            Name = name;
            HireDate = hireDate;
        }
        /// <summary>
        /// Calculates the total salary for the employee. This method is intended to be overridden in 
        /// derived classes to provide specific salary calculations based on the employee type (e.g., hourly or salaried).
        /// </summary>
        /// <returns>The total salary which is zero by default.</returns>
        public virtual decimal CalculateSalary() => 0;

        /// <summary>
        /// Provides a description of the employee, including their name and monthly salary. 
        /// This method is intended to be overridden in derived classes to provide specific descriptions based on the employee type.
        /// </summary>
        /// <returns>A string describing the employee's name and monthly salary information.</returns>
        public virtual string Description() => $"{Name}\n" +
            $"{Output.FormatText(Label.MonthlySalary, $"{CalculateSalary():F2}")}";
    }
}

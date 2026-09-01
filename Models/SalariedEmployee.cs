using EmployeeSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeSystem.Models
{
    /// <summary>
    /// Represents a salaried employee with a fixed base salary and bonus.
    /// </summary>
    internal class SalariedEmployee : Employee
    {
        internal decimal BaseSalary { get; private set; }
        internal decimal Bonus { get; private set; }
        public SalariedEmployee(string employeeId, string name, DateTime hireDate, decimal baseSalary, decimal bonus)
            : base(employeeId, name, hireDate)
        {
            BaseSalary = baseSalary;
            Bonus = bonus;
        }

        /// <summary>
        /// Calculates the total salary for the salaried employee by summing the base salary and bonus.
        /// </summary>
        /// <returns>The total salary.</returns>
        public override decimal CalculateSalary() => BaseSalary + Bonus;

        /// <summary>
        /// Provides a description of the salaried employee, including their name, monthly salary, base salary, and bonus.
        /// </summary>
        /// <returns>A string describing the employee's salary information.</returns>
        public override string Description()
        { 
            return $"{base.Description()}\n" +
                $"{Output.FormatText(Label.BaseSalary, $"{BaseSalary:F2}")}\n" +
                $"{Output.FormatText(Label.Bonus, $"{Bonus:F2}")}";
        }
    }

}


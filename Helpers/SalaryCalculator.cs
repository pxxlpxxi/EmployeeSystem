using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeSystem.Helpers
{
    internal class SalaryCalculator
    {
        /// <summary>
        /// Calculates the bonus based on the base salary using a default percentage of 5%.
        /// </summary>
        /// <param name="baseSalary">The base salary of the employee.</param>
        /// <returns>The calculated bonus.</returns>
        public decimal CalculateBonus(decimal baseSalary) => baseSalary * 0.05m;

        /// <summary>
        /// Calculates the bonus based on the base salary and percentage.
        /// </summary>
        /// <param name="baseSalary">The base salary of the employee.</param>
        /// <param name="percentage">The percentage to calculate the bonus.</param>
        /// <returns>The calculated bonus.</returns>
        public decimal CalculateBonus(decimal baseSalary, decimal percentage) => baseSalary * (percentage / 100);

        /// <summary>
        /// Calculates the bonus based on the base salary, percentage, and years of seniority.
        /// </summary>
        /// <param name="baseSalary">The base salary of the employee.</param>
        /// <param name="percentage">The percentage to calculate the bonus.</param>
        /// <param name="yearsOfSeniority">The number of years of seniority.</param>
        /// <returns>The calculated bonus with one percent added per year of seniority.</returns>
        public decimal CalculateBonus(decimal baseSalary, decimal percentage, int yearsOfSeniority) => baseSalary * ((percentage + yearsOfSeniority) / 100);
    }
}

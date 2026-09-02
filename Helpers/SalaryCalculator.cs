using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeSystem.Helpers
{
    internal class SalaryCalculator
    {
        public decimal CalculateBonus(decimal baseSalary) => baseSalary * 0.05m;

        public decimal CalculateBonus(decimal baseSalary, decimal percentage) => baseSalary * (percentage / 100);

        public decimal CalculateBonus(decimal baseSalary, decimal percentage, int yearsOfSeniority) => baseSalary * ((percentage + yearsOfSeniority) / 100);
    }
}

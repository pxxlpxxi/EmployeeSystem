using EmployeeSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeSystem.Data
{

    internal static class Init
    {
        /// <summary>
        /// A list of employees that will be created and initialized with sample data.
        /// </summary>
        internal static List<Employee> Employees { get; private set; } = new();
        /// <summary>
        /// Creates a list of employees with sample data. 
        /// This method initializes the Employees list with two instances of HourlyEmployee and two SalariedEmployee,
        /// each with specific attributes such as employee ID, name, hire date, hourly rate, hours worked, base salary, and bonus. 
        /// The created employees are added to the Employees list for further processing or display in the application.
        /// </summary>
        internal static void CreateEmployees()
        {
            Employees.Add(new HourlyEmployee("E001", "Alice", new DateTime(2020, 1, 15), 160m, 120));
            Employees.Add(new SalariedEmployee("E002", "Bob", new DateTime(2019, 3, 10), 40000m, 2500m));
            Employees.Add(new HourlyEmployee("E003", "Charlie", new DateTime(2021, 6, 5), 403.5m, 150));
            Employees.Add(new SalariedEmployee("E004", "Diana", new DateTime(2018, 11, 20), 45000m, 6000m));
        }
    }
}

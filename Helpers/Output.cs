using EmployeeSystem.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text;

namespace EmployeeSystem.Helpers
{
    /// <summary>
    /// An enumeration representing various labels used for formatting output in the console.
    /// </summary>
    enum Label
    {
        MonthlySalary,
        BaseSalary,
        Bonus,
        HourlyRate,
        HoursWorked,
        SalariesTotal
    }

    /// <summary>
    /// A static class that provides helper methods for formatting and outputting text to the console.
    /// </summary>
    internal class Output
    {
        /// <summary>
        /// The width of the padding used for formatting output in the console.
        /// </summary>
        internal static readonly int PadWidth = 40;

        /// <summary> 
        /// Prints a horizontal line to the console in the specified width of <see cref="Output.PadWidth"/>.
        /// </summary>
        internal static void PrintPadLine()
        {
            Console.WriteLine(new string('─', PadWidth));
        }

        /// <summary>
        /// Formats a label and value pair for output, aligning the value to the right within 
        /// a width of <see cref="Output.PadWidth"/>.
        /// </summary>
        /// <param name="label">The label for which to get the text representation.</param>
        /// <param name="value">The value to display.</param>
        /// <returns>The formatted string.</returns>
        internal static string FormatText(Enum label, string value)
        {
            return ($"{GetLabelText(label)}" +
                $"{value}".PadLeft(PadWidth - GetLabelLength(label)));
        }
        /// <summary>
        /// Gets the text representation of a label based on the provided enumeration value.
        /// </summary>
        /// <param name="label">The label for which to get the text representation.</param>
        /// <returns>The text representation of the label.</returns>
        /// <exception cref="UnreachableException"></exception>
        internal static string GetLabelText(Enum label)
        {
            return label switch
            {
                Label.MonthlySalary => "Monthly salary: ",
                Label.Bonus => "Monthly bonus: ",
                Label.BaseSalary => "Base salary: ",
                Label.HourlyRate => "Hourly rate: ",
                Label.HoursWorked => "Hours worked: ",
                Label.SalariesTotal => "Salaries total: ",
                _ => throw new UnreachableException("Unhandled label")
            };
        }

        /// <summary>
        /// Gets the length of the text representation of a label based on the provided enumeration value.
        /// </summary>
        /// <param name="label">The label for which to get the length.</param>
        /// <returns>The length of the text representation of the label.</returns>
        /// <exception cref="UnreachableException"></exception>
        internal static int GetLabelLength(Enum label)
        {
            return label switch
            {
                Label.MonthlySalary => GetLabelText(label).Length,
                Label.Bonus => GetLabelText(label).Length,
                Label.BaseSalary => GetLabelText(label).Length,
                Label.HourlyRate => GetLabelText(label).Length,
                Label.HoursWorked => GetLabelText(label).Length,
                Label.SalariesTotal => GetLabelText(label).Length,
                _ => throw new UnreachableException("Unhandled label")

            };
        }
        /// <summary>
        /// Writes a headline message to the console, centered to <see cref="Output.PadWidth"/> and 
        /// bordered with a line of dashes above and below.
        /// </summary>
        /// <param name="message">The message to display as the headline.</param>
        internal static void PrintPadHeadline(string message)
        {
            PrintPadLine();
            Console.WriteLine(message.PadLeft((PadWidth + message.Length) / 2));
            PrintPadLine();
        }
        /// <summary>
        /// Prints an overview of the monthly salaries of all employees in the <see cref="Init.Employees"/> list, 
        /// including their individual descriptions and the total salary.
        /// </summary>
        internal static void PrintMonthlySalaryOverwiew()
        {
            decimal totalSalary = 0;

            PrintPadHeadline("Employee Salaries");
            foreach (var employee in Init.Employees)
            {
                totalSalary += employee.CalculateSalary();
                Console.WriteLine(employee.Description());
                PrintPadLine();
            }
            Console.WriteLine();
            Console.WriteLine(FormatText(Label.SalariesTotal, $"{totalSalary:F2}"));
            PrintPadLine();
        }
    }
}

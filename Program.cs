using EmployeeSystem.Data;
using EmployeeSystem.Helpers;
namespace EmployeeSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Init.CreateEmployees();

            Output.PrintMonthlySalaryOverview();



            var salaryCalculator = new SalaryCalculator();


            Output.PrintPadHeadline("CalculateBonus();");

            Console.WriteLine(Output.FormatText(Label.Bonus, $"{salaryCalculator.CalculateBonus(10000):F2}"));

            Console.WriteLine(Output.FormatText(Label.Bonus, $"{salaryCalculator.CalculateBonus(10000, 10):F2}"));

            Console.WriteLine(Output.FormatText(Label.Bonus, $"{salaryCalculator.CalculateBonus(10000, 10, 5):F2}"));

            Output.PrintPadLine();
            Console.ReadKey();
        }
    }
}

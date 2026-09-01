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
            
            Console.ReadKey();
        }
    }
}

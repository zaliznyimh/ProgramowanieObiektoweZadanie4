using HRHub.Enums;
using HRHub.Data;

namespace HRHub.Gui;

public class ManagerScreen
{
    #region Properties and Ctor

    /// <summary>
    /// Private fields
    /// Company 
    /// </summary>
    private readonly Company _company;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="company"></param>
    public ManagerScreen(Company company)
    {
        _company = company;
    }

    #endregion // Properties and Ctor

    #region Public Methods

    public void Show()
    {
        while (true)
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("You are on the manager page. Make your choise");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Show info about employee");
                Console.WriteLine("2. Add new employee");
                Console.WriteLine("3. Modify info about employee");
                Console.WriteLine("4. Fire the employee");
                Console.WriteLine("5. Calculate salary");
                Console.Write("Enter your choise: ");

                string? userChoise = Console.ReadLine();

                if (userChoise == null)
                {
                    throw new ArgumentNullException(nameof(userChoise));
                }

                ManagerScreenEnum choise = (ManagerScreenEnum)Int32.Parse(userChoise);

                switch (choise)
                {
                    case ManagerScreenEnum.Info:
                        _company.ShowEmployeeInfo();
                        break;

                    case ManagerScreenEnum.Add:
                        _company.AddEmployee();
                        break;

                    case ManagerScreenEnum.Modify:
                        _company.ModifyEmployeeInfo();
                        break;

                    case ManagerScreenEnum.Fire:
                        _company.RemoveEmployee();
                        break;

                    case ManagerScreenEnum.Salary:
                        _company.CalculateSalary();
                        break;

                    case ManagerScreenEnum.Exit:
                        Console.WriteLine("Going back to main menu.");
                        return;

                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }
    }

    #endregion // Public Methods
}
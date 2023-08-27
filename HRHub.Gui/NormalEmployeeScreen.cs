using HRHub.Data;
using HRHub.Enums;

namespace HRHub.Gui;

public class NormalEmployeeScreen
{
    #region Properties and Ctor

    /// <summary>
    /// Private fields:
    /// Company.
    /// </summary>
    private readonly Company _company;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="company"></param>
    public NormalEmployeeScreen(Company company)
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
                Console.WriteLine("Welcome to Employee screen");
                Console.WriteLine("Your available choices are:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Show info about employee");
                Console.WriteLine("2. Calculate salary");
                Console.Write("Enter your choise: ");

                string? userChoise = Console.ReadLine();

                if (userChoise == null)
                {
                    throw new ArgumentNullException(nameof(userChoise));
                }

                NormalEmployeeScreenEnum choise = (NormalEmployeeScreenEnum)Int32.Parse(userChoise);

                switch (choise)
                {
                    case NormalEmployeeScreenEnum.Info:
                        _company.ShowEmployeeInfo();
                        break;

                    case NormalEmployeeScreenEnum.Salary:
                        _company.CalculateSalary();
                        break;

                    case NormalEmployeeScreenEnum.Exit:
                        Console.WriteLine("Going back to main menu");
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
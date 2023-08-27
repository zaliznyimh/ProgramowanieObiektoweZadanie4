using HRHub.Enums;

namespace HRHub.Gui;

public class MainScreen
{

    #region Properties and Ctor

    /// <summary>
    /// Private fields:
    /// ManagerScreen,
    /// NormalEployeeScreen.
    /// </summary>
    private readonly ManagerScreen _managerScreen;
    private readonly NormalEmployeeScreen _normalEmployeeScreen;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="managerScreen"></param>
    /// <param name="normalEmployee"></param>
    public MainScreen(ManagerScreen managerScreen,
                      NormalEmployeeScreen normalEmployee)
    {
        _managerScreen = managerScreen;
        _normalEmployeeScreen = normalEmployee;
    }

    #endregion // Properties and Ctor

    #region Public Methods

    public void Show()
    {
        Console.WriteLine("Welcome to HRHub programm");

        while (true)
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Your available choises are:");
                Console.WriteLine("1. I'm manager");
                Console.WriteLine("2. I'm a normal employee");
                Console.WriteLine("3. Exit");
                Console.Write("Please enter your choise: ");

                string? userChoise = Console.ReadLine();

                if (userChoise == null)
                {
                    throw new ArgumentNullException(nameof(userChoise));
                }

                MainScreenEnum choise = (MainScreenEnum)Int32.Parse(userChoise);

                switch (choise)
                {
                    case MainScreenEnum.Manager:
                         CheckAndShow();
                         break;

                    case MainScreenEnum.NormalEmployee:
                         _normalEmployeeScreen.Show();
                         Console.Clear();
                         break;

                    case MainScreenEnum.Exit:
                         Console.WriteLine("Goodbye. Thanks for using HRHub app.");
                         return;
                    default: 
                        Console.WriteLine("Invalid input.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid input. {ex.Message} ");
            }
        }
    }

    #endregion // Public Methods

    #region Private Methods

    /// <summary>
    /// Method which check Password&&Login and Goes to 
    /// </summary>
    private void CheckAndShow()
    {
        string correctLogin = "ManagerWSB";
        string correctPassword = "qwerty123";

        Console.Write("Enter login: ");
        string? userLogin = Console.ReadLine();

        Console.Write("Enter password: ");
        string? userPassword = Console.ReadLine();
        if (correctLogin == userLogin && correctPassword == userPassword) { _managerScreen.Show(); }
        else { Console.WriteLine("Invalid Login or Password"); }

    }

    #endregion // Private Methods
}
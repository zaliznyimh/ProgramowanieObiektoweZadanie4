using HRHub.Interfaces;

namespace HRHub.Data;

public class Employee : IEmployee
{
    #region Interface Members

    /// <summary>
    /// IEmployee interface implementation.
    /// </summary>
    public int EmployeeID { get; set; }
    public string? Name { get; set; }
    public string? Position { get; set; }
    public float HourlyRate { get; set; }

    #endregion // Interface Members

    #region Ctor

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="employeeID"></param>
    /// <param name="name"></param>
    /// <param name="position"></param>
    /// <param name="hourlyRate"></param>
    public Employee(int employeeID, string name, string position, float hourlyRate)
    {
        EmployeeID = employeeID;
        Name = name;
        Position = position;
        HourlyRate = hourlyRate;
    }

    #endregion // Ctor
}
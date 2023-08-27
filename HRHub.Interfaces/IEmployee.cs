namespace HRHub.Interfaces;

public interface IEmployee
{
    #region Interface Members

    /// <summary>
    /// IEmployee interface members
    /// </summary>
    public int EmployeeID { get; set; }
    public string? Name { get; set; }
    public string? Position { get; set; }
    public float HourlyRate { get; set; }

    #endregion // Interface Members
}
using Newtonsoft.Json;

namespace HRHub.Data;

public class Company
{
    #region Properties and Ctor 

    /// <summary>
    /// List of all Employeers
    /// </summary>
    List<Employee>? Employees { get; set; } = new List<Employee>();

    #endregion // Properties and Ctor 

    #region Public Methods

    /// <summary>
    /// Method for adding employyes
    /// </summary>
    public void AddEmployee()
    {
        try
        {
            Console.Write("Enter Employee ID: ");
            string? employeeIDasString = Console.ReadLine();

            Console.Write("Enter Employee Name: ");
            string? nameAsString = Console.ReadLine();

            Console.Write("Enter Employee Position: ");
            string? position = Console.ReadLine();

            Console.Write("Enter Employee Hourly Rate: ");
            string? hourlyRateAsString = Console.ReadLine();

            if (employeeIDasString == null) { throw new NotImplementedException(nameof(employeeIDasString)); }
            if (nameAsString == null) { throw new NotImplementedException(nameof(nameAsString)); }
            if (position == null) { throw new NotImplementedException(nameof(position)); }
            if (hourlyRateAsString == null) { throw new NotImplementedException(nameof(hourlyRateAsString)); }

            int employeeID = int.Parse(employeeIDasString);
            float hourlyRate = float.Parse(hourlyRateAsString);

            Employee addedEmployee;

            if (position.Equals("Manager", StringComparison.OrdinalIgnoreCase))
            {
                int bonus = 300;
                addedEmployee = new Manager(employeeID, nameAsString, position, hourlyRate, bonus);
            }
            else
            {
                addedEmployee = new Employee(employeeID, nameAsString, position, hourlyRate);
            }

            if (File.Exists("EmployeeJson.json"))
            {
                string existingJson = File.ReadAllText("EmployeeJson.json");
                Employees = JsonConvert.DeserializeObject<List<Employee>>(existingJson);
            }

            if (Employees != null)
            {
                Employees.Add(addedEmployee);
            }

            string json = JsonConvert.SerializeObject(Employees, Formatting.Indented);

            File.WriteAllText("EmployeeJson.json", json);

            Console.WriteLine($"{addedEmployee.Name} added successfully.");

        }
        catch
        {
            Console.WriteLine("Error while adding employee.");
        }
    }

    /// <summary>
    /// Method for removing emplooyes 
    /// </summary>
    public void RemoveEmployee()
    {
        try
        {
            Console.Write("Write the employee's ID: ");
            string? employeeIDAsString = Console.ReadLine();

            if (employeeIDAsString == null) { throw new NotImplementedException(nameof(employeeIDAsString)); }
            int employeeID = Int32.Parse(employeeIDAsString);

            if (File.Exists("EmployeeJson.json"))
            {
                string existingJson = File.ReadAllText("EmployeeJson.json");
                Employees = JsonConvert.DeserializeObject<List<Employee>>(existingJson);
            }

            // LINQ method for searching employee by ID
            if (Employees != null)
            {
                Employee? employeeToRemove = Employees.FirstOrDefault(e => e.EmployeeID == employeeID);

                if (employeeToRemove != null)
                {
                    Employees.Remove(employeeToRemove);
                }
            }

            string json = JsonConvert.SerializeObject(Employees, Formatting.Indented);

            File.WriteAllText("EmployeeJson.json", json);

            Console.WriteLine("Employee removed successfully.");
        }
        catch
        {
            Console.WriteLine("Error during removing employee");
        }
    }

    /// <summary>
    /// Method for show info about the employee
    /// </summary>
    public void ShowEmployeeInfo()
    {
        try
        {
            Console.WriteLine();
            Console.Write("Write the employee's ID: ");
            string? employeeIDAsString = Console.ReadLine();

            if (employeeIDAsString == null) { throw new NotImplementedException(nameof(employeeIDAsString)); }
            int employeeID = Int32.Parse(employeeIDAsString);

            if (File.Exists("EmployeeJson.json"))
            {
                string existingJson = File.ReadAllText("EmployeeJson.json");
                Employees = JsonConvert.DeserializeObject<List<Employee>>(existingJson);
            }

            if (Employees != null)
            {
                // LINQ Method for searching eployee by ID 
                Employee? employeeShow = Employees.FirstOrDefault(e => e.EmployeeID == employeeID);

                if (employeeShow != null)
                {
                    Console.WriteLine($"Employee ID: {employeeShow.EmployeeID}");
                    Console.WriteLine($"Name: {employeeShow.Name}");
                    Console.WriteLine($"Position: {employeeShow.Position}");
                    Console.WriteLine($"Hourly Rate: {employeeShow.HourlyRate}");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
        }
        catch
        {
            Console.WriteLine("Error while showing employee info");
        }
    }

    /// <summary>
    /// Method for editing info about the employee
    /// </summary>
    public void ModifyEmployeeInfo()
    {
        try
        {
            Console.WriteLine();
            Console.Write("Write the employee's ID: ");
            string? employeeIDAsString = Console.ReadLine();

            if (employeeIDAsString == null) { throw new NotImplementedException(nameof(employeeIDAsString)); }
            int employeeID = Int32.Parse(employeeIDAsString);

            if (File.Exists("EmployeeJson.json"))
            {
                string existingJson = File.ReadAllText("EmployeeJson.json");
                Employees = JsonConvert.DeserializeObject<List<Employee>>(existingJson);
            }

            if (Employees != null)
            {
                Employee? modifiedEmployee = Employees.FirstOrDefault(e => e.EmployeeID == employeeID);

                if (modifiedEmployee != null)
                {
                    Console.WriteLine($"Modifying information for Employee ID: {modifiedEmployee.EmployeeID}");

                    Console.Write("Enter new Name: ");
                    string? newName = Console.ReadLine();
                    modifiedEmployee.Name = newName;

                    Console.Write("Enter new Position: ");
                    string? newPosition = Console.ReadLine();
                    modifiedEmployee.Position = newPosition;

                    Console.Write("Enter new Hourly Rate: ");
                    string? newHourlyRateAsString = Console.ReadLine();

                    if (newHourlyRateAsString == null) { throw new NotImplementedException(nameof(newHourlyRateAsString)); }

                    int newHourlyRate = Int32.Parse(newHourlyRateAsString);
                    modifiedEmployee.HourlyRate = newHourlyRate;

                    string json = JsonConvert.SerializeObject(Employees, Formatting.Indented);

                    File.WriteAllText("EmployeeJson.json", json);
                    Console.WriteLine("Employee information modified successfully.");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
        }
        catch
        {
            Console.WriteLine("Error while modifying employee info.");
        }
    }

    /// <summary>
    /// Method which calculate salary 
    /// </summary>
    public void CalculateSalary()
    {
        try
        {
            Console.WriteLine();
            Console.Write("Enter Employee ID: ");
            string? employeeIDAsString = Console.ReadLine();

            if (employeeIDAsString == null) { throw new NotImplementedException(nameof(employeeIDAsString)); }

            int employeeID = Int32.Parse(employeeIDAsString);

            if (File.Exists("EmployeeJson.json"))
            {
                string existingJson = File.ReadAllText("EmployeeJson.json");
                Employees = JsonConvert.DeserializeObject<List<Employee>>(existingJson);
            }

            // LINQ method for searching
            if (Employees != null)
            {
                Employee? employeeForSalary = Employees.FirstOrDefault(e => e.EmployeeID == employeeID);

                if (employeeForSalary != null)
                {
                    float salary;
                    Console.Write($"Enter hours worked by {employeeForSalary.Name} in the month: ");

                    string? hoursAsString = Console.ReadLine();

                    if (hoursAsString == null) { throw new NotImplementedException(nameof(hoursAsString)); }
                    int hours = Int32.Parse(hoursAsString);

                    if (employeeForSalary.Position != null)
                    {

                        if (employeeForSalary.Position.Equals("Manager"))
                        {
                            salary = employeeForSalary.HourlyRate * hours + 300;
                        }
                        else
                        {
                            salary = employeeForSalary.HourlyRate * hours;
                        }

                        Console.WriteLine($"{employeeForSalary.Name}'s salary is {salary}");
                    }
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
        }
        catch
        {
            Console.WriteLine("Error while calculating salary.");
        }
    }

    #endregion // Public Methods
}
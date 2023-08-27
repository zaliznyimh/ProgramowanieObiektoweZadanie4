using HRHub.Interfaces;

namespace HRHub.Data
{
    public class Manager : Employee, IManager
    {
        #region Properties and Ctor
        
        /// <summary>
        /// IManager interface implementation
        /// </summary>
        public int Bonus { get; set; }
        
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="name"></param>
        /// <param name="position"></param>
        /// <param name="hourlyRate"></param>
        /// <param name="bonus"></param>
        public Manager(int employeeID, string name, string position, float hourlyRate, int bonus) : base(employeeID, name, position, hourlyRate) 
        {
            Bonus = bonus;
        }

        #endregion // Properties and Ctor
    }
}
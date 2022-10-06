using System;

using Aspose.StaffManagement.Properties;

namespace Aspose.StaffManagement.Model
{
    /// <summary>
    /// Presents the Base Staff model data
    /// 
    /// 2019/07/03 - created, VTyagunov
    /// </summary>
    public abstract class BaseStaff
    {
        /// <summary>
        /// ID of the Staff
        /// </summary>
        public int ID { get; }
        /// <summary>
        /// Name of the Staff
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Date of the Staff joined to the company
        /// </summary>
        public DateTime JoinDate { get; set; }
        /// <summary>
        /// Base Salary of the Staff
        /// </summary>
        public decimal BaseSalary { get; }
        /// <summary>
        /// Supervisor of the Staff
        /// </summary>
        public BaseStaff Supervisor { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">ID of the Staff</param>
        /// <param name="name">Name of the Staff</param>
        /// <param name="joinDate">Date of the Staff joined to the company</param>
        /// <param name="supervisor">Supervisor of the Staff</param>
        public BaseStaff(int id, string name, DateTime joinDate, BaseStaff supervisor = null)
        {
            ID = id;
            Name = name;
            JoinDate = joinDate;
            Supervisor = supervisor;

            decimal baseSalary = decimal.Parse(Resources.BaseSalary);
            BaseSalary = baseSalary; 
        }
    }
}
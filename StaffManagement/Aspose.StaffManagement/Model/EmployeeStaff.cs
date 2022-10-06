using System;

namespace Aspose.StaffManagement.Model
{
    /// <summary>
    /// Implements the Employee Staff model data
    /// 
    /// 2019/07/03 - created, VTyagunov
    /// </summary>
    public class EmployeeStaff : BaseStaff
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">ID of the Staff</param>
        /// <param name="name">Name of the Staff</param>
        /// <param name="joinDate">Date of the Staff joined to the company</param>
        /// <param name="supervisor">Supervisor of the Staff</param>
        public EmployeeStaff(int id, string name, DateTime joinDate, BaseStaff supervisor = null) :
            base(id, name, joinDate, supervisor)
        {

        }
    }
}
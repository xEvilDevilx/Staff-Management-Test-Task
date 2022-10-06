using System;
using System.Collections.Generic;

namespace Aspose.StaffManagement.Model
{
    /// <summary>
    /// Implements the Manager Staff model data
    /// 
    /// 2019/07/03 - created, VTyagunov
    /// </summary>
    public class ManagerStaff : BaseStaff
    {
        /// <summary>
        /// All Subordinates of the manager staff
        /// </summary>
        public List<BaseStaff> Subordinates { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">ID of the Staff</param>
        /// <param name="name">Name of the Staff</param>
        /// <param name="joinDate">Date of the Staff joined to the company</param>
        /// <param name="supervisor">Supervisor of the Staff</param>
        /// <param name="subordinates">All Subordinates of the manager staff</param>
        public ManagerStaff(int id, string name, DateTime joinDate, BaseStaff supervisor = null, 
            List<BaseStaff> subordinates = null) : base(id, name, joinDate, supervisor)
        {
            Subordinates = subordinates;
        }
    }
}
using System.Collections.Generic;

using Aspose.StaffManagement.Model;

namespace Aspose.StaffManagement.Interfaces
{
    /// <summary>
    /// Presents the Calculation Service functionality interface
    /// 
    /// 2019/07/03 - created, VTyagunov
    /// </summary>
    public interface ICalculationService
    {
        /// <summary>
        /// Use to calculate a Salary for the Staff member
        /// </summary>
        /// <param name="baseStaff">Staff member</param>
        /// <returns>Salary of the Staff member</returns>
        decimal CalculateSalary(BaseStaff baseStaff);

        /// <summary>
        /// Use to calculate all Salaries of the company Staff members
        /// </summary>
        /// <param name="baseStaffs">Collection of Staff members</param>
        /// <returns>Salaries amount of all Staff members</returns>
        decimal CalculateAllSalaries(List<BaseStaff> baseStaffs);
    }
}
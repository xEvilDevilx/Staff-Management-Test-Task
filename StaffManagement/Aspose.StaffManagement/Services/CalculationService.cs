using System;
using System.Collections.Generic;
using System.Globalization;

using Aspose.StaffManagement.Exceptions;
using Aspose.StaffManagement.Interfaces;
using Aspose.StaffManagement.Model;
using Aspose.StaffManagement.Properties;

namespace Aspose.StaffManagement.Services
{
    /// <summary>
    /// Implements Calculation Service functionality
    /// 
    /// 2019/07/03 - created, VTyagunov
    /// </summary>
    public class CalculationService : ICalculationService
    {
        /// <summary>
        /// Use to calculate all Salaries of the company Staff members
        /// </summary>
        /// <param name="baseStaffs">Collection of Staff members</param>
        /// <returns>Salaries amount of all Staff members</returns>
        public decimal CalculateAllSalaries(List<BaseStaff> baseStaffs)
        {
            try
            {
                decimal allSalariesAmount = 0m;

                foreach (BaseStaff staff in baseStaffs)
                {
                    allSalariesAmount += CalculateSalary(staff);
                }

                return allSalariesAmount;
            }
            catch (CalculateException)
            {
                throw;
            }
            catch(UnknownBaseStaffException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Use to calculate a Salary for the Staff member
        /// </summary>
        /// <param name="baseStaff">Staff member</param>
        /// <returns>Salary of the Staff member</returns>
        public decimal CalculateSalary(BaseStaff baseStaff)
        {
            try
            {
                EmployeeStaff employeeStaff = baseStaff as EmployeeStaff;
                if(employeeStaff != null)
                    return CalculateEmployeeSalary(employeeStaff);

                ManagerStaff managerStaff = baseStaff as ManagerStaff;
                if (managerStaff != null)
                    return CalculateManagerSalary(managerStaff);

                SalesStaff salesStaff = baseStaff as SalesStaff;
                if (salesStaff != null)
                    return CalculateSalesSalary(salesStaff);
            }
            catch (CalculateException)
            {
                throw;
            }
            catch (UnknownBaseStaffException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

            throw new UnknownBaseStaffException(baseStaff.GetType());
        }

        /// <summary>
        /// Use to calculate a Salary for the Employee Staff member
        /// </summary>
        /// <param name="staff">Employee Staff member</param>
        /// <returns>Salary of the Employee Staff member</returns>
        private decimal CalculateEmployeeSalary(EmployeeStaff staff)
        {
            try
            {
                decimal employeeSalaryPerYearPercent = decimal.Parse(Resources.EmployeeSalaryPerYearPercent, CultureInfo.InvariantCulture);
                decimal employeeMaxSalaryPercent = decimal.Parse(Resources.EmployeeMaxSalaryPercent, CultureInfo.InvariantCulture);

                decimal employeeSalary = CalculateBaseSalary(staff, employeeSalaryPerYearPercent, employeeMaxSalaryPercent);
                return employeeSalary;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Use to calculate a Salary for the Manager Staff member
        /// </summary>
        /// <param name="staff">Manager Staff member</param>
        /// <returns>Salary of the Manager Staff member</returns>
        private decimal CalculateManagerSalary(ManagerStaff staff)
        {
            try
            {
                decimal managerSalaryPerYearPercent = decimal.Parse(Resources.ManagerSalaryPerYearPercent, CultureInfo.InvariantCulture);
                decimal managerMaxSalaryPercent = decimal.Parse(Resources.ManagerMaxSalaryPercent, CultureInfo.InvariantCulture);
                decimal managerSubordinatesSalaryPercent = decimal.Parse(Resources.ManagerSubordinatesSalaryPercent, CultureInfo.InvariantCulture);

                decimal baseSalary = CalculateBaseSalary(staff, managerSalaryPerYearPercent, managerMaxSalaryPercent);                
                decimal subordinatesSalary = CalculateAllSalaries(staff.Subordinates);
                decimal employeeSalary = baseSalary + (subordinatesSalary * (managerSubordinatesSalaryPercent / 100));

                return employeeSalary;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Use to calculate a Salary for the Sales Staff member
        /// </summary>
        /// <param name="staff">Sales Staff member</param>
        /// <returns>Salary of the Sales Staff member</returns>
        private decimal CalculateSalesSalary(SalesStaff staff)
        {
            try
            {
                decimal salesSalaryPerYearPercent = decimal.Parse(Resources.SalesSalaryPerYearPercent, CultureInfo.InvariantCulture);
                decimal salesMaxSalaryPercent = decimal.Parse(Resources.SalesMaxSalaryPercent, CultureInfo.InvariantCulture);
                decimal salesSubordinatesSalaryPercent = decimal.Parse(Resources.SalesSubordinatesSalaryPercent, CultureInfo.InvariantCulture);

                decimal baseSalary = CalculateBaseSalary(staff, salesSalaryPerYearPercent, salesMaxSalaryPercent);
                decimal subordinatesSalary = CalculateAllSalaries(staff.Subordinates);
                decimal salesSalary = baseSalary + (subordinatesSalary * (salesSubordinatesSalaryPercent / 100));

                return salesSalary;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Use to calculate a Salary for the Base Staff member
        /// </summary>
        /// <param name="staff">Base Staff member</param>
        /// <returns>Salary of the Base Staff member</returns>
        private decimal CalculateBaseSalary(BaseStaff staff, decimal salaryPerYearPercent, decimal maxSalaryPercent)
        {
            try
            {
                DateTime joinDate = staff.JoinDate;
                DateTime currentDate = DateTime.Now;
                DateTime diffDate = new DateTime((currentDate - joinDate).Ticks);
                int workedYearsCount = diffDate.Year - 1;

                decimal baseSalary = decimal.Parse(Resources.BaseSalary, CultureInfo.InvariantCulture);
                decimal plusToSalaryPerYear = baseSalary * (salaryPerYearPercent / 100);
                decimal plusToSalaryPerYears = plusToSalaryPerYear * workedYearsCount;

                decimal maxPlusToSalary = baseSalary * (maxSalaryPercent / 100);

                decimal resultSalary = baseSalary + (plusToSalaryPerYears < maxPlusToSalary ? plusToSalaryPerYears : maxPlusToSalary);

                return resultSalary;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
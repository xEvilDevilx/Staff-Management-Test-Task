using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Aspose.StaffManagement.Model;
using Aspose.StaffManagement.Interfaces;
using Aspose.StaffManagement.Services;

namespace Aspose.StaffManagement.Tests
{
    /// <summary>
    /// Implements functionality for test Calculate Service
    /// 
    /// 2019/07/03 - created, VTyagunov
    /// </summary>
    [TestClass]
    public class CalculateServiceTest
    {
        private List<BaseStaff> _managerStaffs;
        private List<BaseStaff> _salesStaffs;
        private List<BaseStaff> _allStaffs;
        private BaseStaff _employeeStaff;
        private BaseStaff _managerStaff;
        private BaseStaff _salesStaff;
        private decimal _expectedAllSalaries;
        private decimal _expectedEmployeeStaffSalary;
        private decimal _expectedManagerStaffSalary;
        private decimal _expectedSalesStaffSalary;
        private ICalculationService _calculationService;

        /// <summary>
        /// Use for Initialize primary data for tests
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            // Prepare
            _managerStaffs = new List<BaseStaff>();
            _salesStaffs = new List<BaseStaff>();
            _allStaffs = new List<BaseStaff>();

            _employeeStaff = new EmployeeStaff(0, "Steve Vai", new DateTime(2007, 02, 21));
            _managerStaffs.Add(_employeeStaff);

            _managerStaff = new ManagerStaff(1, "Gary Moore", new DateTime(2003, 09, 13), null, _managerStaffs);
            _salesStaffs.Add(_employeeStaff);
            _salesStaffs.Add(_managerStaff);

            _salesStaff = new SalesStaff(2, "Ozielzinho", new DateTime(2016, 11, 04), null, _salesStaffs);
            _allStaffs.Add(_employeeStaff);
            _allStaffs.Add(_managerStaff);
            _allStaffs.Add(_salesStaff);

            _calculationService = new CalculationService();

            _expectedEmployeeStaffSalary = 2990m;
            _expectedManagerStaffSalary = 3234.95m;
            _expectedSalesStaffSalary = 2364.67485m;
            _expectedAllSalaries = _expectedEmployeeStaffSalary + _expectedManagerStaffSalary + _expectedSalesStaffSalary;
        }

        /// <summary>
        /// Use for Test a CalculateAllSalaries method
        /// </summary>
        [TestMethod]
        public void CalculateAllSalariesTest()
        {
            // Execution
            decimal allSalaries = _calculationService.CalculateAllSalaries(_allStaffs);

            // Check
            Assert.AreEqual(allSalaries, _expectedAllSalaries);
        }

        /// <summary>
        /// Use for test a CalculateSalary method
        /// </summary>
        [TestMethod]
        public void CalculateSalaryTest()
        {
            // Execution
            decimal employeeSalary = _calculationService.CalculateSalary(_employeeStaff);
            decimal managerSalary = _calculationService.CalculateSalary(_managerStaff);
            decimal salesSalary = _calculationService.CalculateSalary(_salesStaff);

            // Check
            Assert.AreEqual(employeeSalary, _expectedEmployeeStaffSalary);
            Assert.AreEqual(managerSalary, _expectedManagerStaffSalary);
            Assert.AreEqual(salesSalary, _expectedSalesStaffSalary);
        }
    }
}
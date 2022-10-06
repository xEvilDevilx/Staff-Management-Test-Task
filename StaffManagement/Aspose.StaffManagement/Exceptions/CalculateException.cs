using System;

namespace Aspose.StaffManagement.Exceptions
{
    /// <summary>
    /// Implements Calculate Exception functionality
    /// 
    /// 2019/07/03 - created, VTyagunov
    /// </summary>
    public class CalculateException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="exception">Base exception</param>
        public CalculateException(Exception exception) : base("Error occurred during calculation!", exception)
        {

        }
    }
}
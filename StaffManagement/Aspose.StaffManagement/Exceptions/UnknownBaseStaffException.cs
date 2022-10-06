using System;

namespace Aspose.StaffManagement.Exceptions
{
    /// <summary>
    /// Implements 'Unknown BaseStaff implementation type' Exception functionality
    /// 
    /// 2019/07/03 - created, VTyagunov
    /// </summary>
    public class UnknownBaseStaffException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Unknown BaseStaff implementation type</param>
        public UnknownBaseStaffException(Type type) : base(string.Format("{0} is an unknown BaseStaff implementation type!", type.Name))
        {

        }
    }
}
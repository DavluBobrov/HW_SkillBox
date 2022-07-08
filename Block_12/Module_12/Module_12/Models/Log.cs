using System;

namespace Module_12.Models
{
    internal class Log
    {
        public EnumTypes.TypeEmployee TypeEmployee;
        public EnumTypes.TypeEdit TypeEdit;
        public DateTime DateTime;

        public Log(EnumTypes.TypeEmployee typeEmployee, EnumTypes.TypeEdit typeEdit)
        {
            TypeEmployee = typeEmployee;
            TypeEdit = typeEdit;
            DateTime = DateTime.Now;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_12.Models.Employees
{
    internal interface IEmployee
    {
        public bool IsManager { get; set; }
    }
}
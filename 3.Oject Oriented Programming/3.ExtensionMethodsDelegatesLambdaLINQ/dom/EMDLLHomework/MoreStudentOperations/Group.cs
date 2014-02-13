using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MoreStudentOperations.DepartmentNames;

namespace MoreStudentOperations
{
    internal class Group
    {
        private int? groupNumber;
        public DepartmentName Department { get; private set; }
        public Group(DepartmentName name)
        {
            this.Department = name;
        }

        public Group(DepartmentName depName, int groupNumber)
        {
            this.groupNumber = groupNumber;
            this.Department = depName;
        }

        public int? GroupNumber
        {
            get
            {
                if (!groupNumber.HasValue)
                {
                    return -1;
                }
                return groupNumber;
            }
            set { groupNumber = value; }
        }
    }
}
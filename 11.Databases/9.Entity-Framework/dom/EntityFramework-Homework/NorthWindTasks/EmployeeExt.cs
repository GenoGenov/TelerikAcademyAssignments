using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NorthWindTasks
{
    using System.Data.Linq;

    public class EmployeeExt:Employee
    {
        private EntitySet<Territory> territoriesSet=new EntitySet<Territory>(); 
        public EntitySet<Territory> TerritoriesSet
        {
            get
            {
                this.territoriesSet.AddRange(this.Territories);
                return territoriesSet;
            }
        }
    }
}

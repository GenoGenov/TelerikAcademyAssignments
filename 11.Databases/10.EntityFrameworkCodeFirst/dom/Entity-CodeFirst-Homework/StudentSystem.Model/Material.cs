using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Model
{
    public class Material
    {
        public int MaterialId { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public string Description { get; set; }
    }
}

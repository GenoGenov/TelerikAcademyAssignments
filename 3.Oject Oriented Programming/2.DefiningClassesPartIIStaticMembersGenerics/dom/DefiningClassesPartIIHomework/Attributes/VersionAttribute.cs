using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    [AttributeUsage(
        AttributeTargets.Struct
        | AttributeTargets.Class
        | AttributeTargets.Interface
        | AttributeTargets.Method
        | AttributeTargets.Enum,
        AllowMultiple = false)]
    public class VersionAttribute : Attribute
    {
        private const string DEFAULT_VER = "1.0";

        private string version;

        public VersionAttribute(string version)
        {
            this.Version = version;
        }

        public VersionAttribute() : this(DEFAULT_VER)
        {
        }

        public string Version
        {
            get { return version; }
            private set
            {
                int d;
                if (value.Contains(".") && value.Split('.').All(x => int.TryParse(x, out d)))
                    version = value;
                else
                {
                    throw new FormatException("string was not in the correct format");
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2.DisplayAssemblyLocation
{
    using System.Reflection;

    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fromcode.InnerText = "Hello, ASP.NET - From Code";
            location.InnerText = Assembly.GetExecutingAssembly().Location;
        }
    }
}
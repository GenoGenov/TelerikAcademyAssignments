using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1.NorthwindData
{
    using System.Threading;

    public partial class NorthwindData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void GV_Employees_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
        }
    }
}
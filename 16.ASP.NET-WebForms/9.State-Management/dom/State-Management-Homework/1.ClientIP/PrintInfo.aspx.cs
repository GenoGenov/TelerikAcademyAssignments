using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1.ClientIP
{
    public partial class PrintInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Browser - "+Request.Browser.Type +"<br/>");
            Response.Write("IP - " + Request.UserHostAddress + "<br/>");
        }
    }
}
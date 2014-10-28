using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3.SetCookie
{
    public partial class SecondPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["customUsr"] != null)
            {
                msg.Text = "Success! You got the cookie!";
            }
            else
            {
                msg.Text = "Cookie missing! You will be automatically redirected in 5 seconds.";
                Response.AddHeader("REFRESH", "5;URL=FirstPage.aspx");
            }
        }
    }
}
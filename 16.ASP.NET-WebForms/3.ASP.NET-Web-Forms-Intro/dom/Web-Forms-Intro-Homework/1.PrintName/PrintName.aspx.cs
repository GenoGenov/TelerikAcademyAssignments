using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1.PrintName
{
    public partial class PrintName : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GenerateName_Click(object sender, EventArgs e)
        {
            var name = inputName.Text;
            greeting.Text = "Hello, " + name+"!";
            greeting.Visible = true;
        }
    }
}
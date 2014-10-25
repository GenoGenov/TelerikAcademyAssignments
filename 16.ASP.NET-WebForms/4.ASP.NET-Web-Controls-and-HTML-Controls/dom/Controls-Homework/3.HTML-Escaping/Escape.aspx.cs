using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3.HTML_Escaping
{
    public partial class Escape : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void showText_OnClick(object sender, EventArgs e)
        {
            escaped.Text = Server.HtmlEncode(input.Text);
            nonEscaped.Text = input.Text;
            results.Visible = true;
        }
    }
}
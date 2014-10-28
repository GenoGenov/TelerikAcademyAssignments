using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2.AppendLines
{
    public partial class Lines : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["lines"]==null)
            {
                Session["lines"] = new List<string>();
            }
            if (!IsPostBack)
            {
                var list = ((List<string>)Session["lines"]);
                if (string.IsNullOrEmpty(lines.Text))
                {
                    foreach (var l in list)
                    {
                        lines.Text += "<br/>" + l;
                    }
                }
            }
            
            
        }

        protected void appendLine_OnClick(object sender, EventArgs e)
        {
            var text = line.Text;
            var list = ((List<string>)Session["lines"]);
            list.Add(text);
            foreach (var l in list)
            {
                lines.Text += "<br/>" + l;
            }
        }
    }
}
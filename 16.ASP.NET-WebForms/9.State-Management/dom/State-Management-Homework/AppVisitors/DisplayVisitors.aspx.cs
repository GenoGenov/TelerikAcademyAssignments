using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppVisitors
{
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;

    public partial class DisplayVisitors : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Application["Visitors"]==null)
            {
                Application["Visitors"] = 1;
            }
            else
            {
                var currentVisitors = (int)Application["Visitors"];
                currentVisitors = currentVisitors + 1;
                Application["Visitors"] = currentVisitors;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            visitors.ImageUrl = "CreateImageText.img?text=" + HttpContext.Current.Server.UrlEncode(Application["Visitors"].ToString());
            visitors.Style.Add("width","100%");
            visitors.Style.Add("height","100%");
        }
    }
}
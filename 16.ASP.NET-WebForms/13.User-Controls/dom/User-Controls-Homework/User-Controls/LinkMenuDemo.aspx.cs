using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace User_Controls
{
    using System.Drawing;

    public partial class LinkMenuDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MyLinkMenu.MenuItems=new List<LinkMenuItem>
            {
                new LinkMenuItem(){Title = "Test",Url = "~/"},
                new LinkMenuItem(){Title = "Another Test",Url = "~/"},
                new LinkMenuItem(){Title = "Last Test",Url = "~/"}
            };

            MyLinkMenu.FontColor = "#333";
            MyLinkMenu.Font="SegoeUI";
        }
    }
}
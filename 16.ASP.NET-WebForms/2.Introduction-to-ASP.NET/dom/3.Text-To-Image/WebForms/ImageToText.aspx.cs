using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms
{
    public partial class ImageToText : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RenderImageButtonClicked(object sender, EventArgs e)
        {
            MyTextImage.ImageUrl = "CreateImageText.img?text=" + HttpContext.Current.Server.UrlEncode(MyTextBox.Text);
        }
    }
}
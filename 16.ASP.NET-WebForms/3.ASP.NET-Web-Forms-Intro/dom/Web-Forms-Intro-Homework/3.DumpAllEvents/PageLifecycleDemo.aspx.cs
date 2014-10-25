using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Page_Lifecycle_Demo
{
	public partial class PageLifecycleDemo : System.Web.UI.Page
	{
		protected void Page_PreInit(object sender, EventArgs e)
		{
		    events.Controls.Add(new Label(){Text = "Page_PreInit Invoked. <br/>",CssClass = "text-info"});
		}

		protected void Page_Init(object sender, EventArgs e)
		{
            events.Controls.Add(new Label() { Text = "Page_Init Invoked. <br/>", CssClass = "text-info" });
		}

		protected void Page_Load(object sender, EventArgs e)
		{
            events.Controls.Add(new Label() { Text = "Page_Load Invoked. <br/>", CssClass = "text-info" });
		}

		protected void Page_PreRender(object sender, EventArgs e)
		{
            events.Controls.Add(new Label() { Text = "Page_PreRender Invoked. <br/>", CssClass = "text-info" });
		}

		protected void Page_InitComplete(object sender, EventArgs e)
		{
            events.Controls.Add(new Label() { Text = "Page_InitComplete Invoked. <br/>", CssClass = "text-info" });
		}

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            events.Controls.Add(new Label() { Text = "Page_OnPreLoad Invoked. <br/>", CssClass = "text-info" });
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            events.Controls.Add(new Label() { Text = "Page_LoadComplete Invoked. <br/>", CssClass = "text-info" });
        }

        protected void Page_SaveStateComplete(object sender, EventArgs e)
        {
            events.Controls.Add(new Label() { Text = "Page_OnSaveState Invoked. <br/>", CssClass = "text-info" });
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            events.Controls.Add(new Label() { Text = "Page_Unload Invoked. <br/>", CssClass = "text-info" });
        }
	}
}
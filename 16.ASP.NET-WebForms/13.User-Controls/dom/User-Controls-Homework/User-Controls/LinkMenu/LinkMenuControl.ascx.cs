using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace User_Controls
{
    using System.Drawing;

    public partial class LinkMenuControl : System.Web.UI.UserControl
    {

        private string color;

        private string font;

        public List<LinkMenuItem> MenuItems
        {
            set
            {
                this.LinkMenu.DataSource = value;
            }
        }

        public string FontColor
        {
            set
            {
                this.color = value;
            }
        }

        public string Font
        {
            set
            {
                this.font = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.IncludeTheCssAndJavaScript();
            this.ApplyStyles();
            this.LinkMenu.DataBind();
        }

        private void ApplyStyles()
        {
            this.LinkMenu.Style.Clear();
            this.LinkMenu.CssClass += " LinkMenu";
            this.LinkMenu.Style["color"] = this.color;
            this.LinkMenu.Style["font-family"] = this.font;
        }

        private void IncludeTheCssAndJavaScript()
        {
            ClientScriptManager cs = Page.ClientScript;

            string jqueryURL = this.TemplateSourceDirectory +
                "/Scripts/jquery-1.9.0.min.js";
            string bootstrapURL = this.TemplateSourceDirectory +
                "/Scripts/bootstrap.min.js";
            if (!cs.IsStartupScriptRegistered(jqueryURL))
            {
                cs.RegisterClientScriptInclude(jqueryURL, jqueryURL);
            }

            if (!cs.IsStartupScriptRegistered(bootstrapURL))
            {
                cs.RegisterClientScriptInclude(bootstrapURL, bootstrapURL);
            }

           

            string bootstrapRelativeURL = this.TemplateSourceDirectory +
                "/Styles/bootstrap.min.css";
            if (!cs.IsClientScriptBlockRegistered(bootstrapRelativeURL))
            {
                string cssLinkCode = string.Format(
                    @"<link href='{0}' rel='stylesheet' type='text/css' />",
                    bootstrapRelativeURL);
                cs.RegisterClientScriptBlock(this.GetType(), bootstrapRelativeURL, cssLinkCode);
            }

            string myStylesRelativeURL = this.TemplateSourceDirectory +
               "/Styles/LinkMenuStyles.css";
            if (!cs.IsClientScriptBlockRegistered(myStylesRelativeURL))
            {
                string cssLinkCode = string.Format(
                    @"<link href='{0}' rel='stylesheet' type='text/css' />",
                    myStylesRelativeURL);
                cs.RegisterClientScriptBlock(this.GetType(), myStylesRelativeURL, cssLinkCode);
            }
        }
    }
}
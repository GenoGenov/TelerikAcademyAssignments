namespace _3.SetCookie
{
    using System;
    using System.Web;

    public partial class FirstPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (this.Request.Cookies["customUsr"] != null)
            {
                this.setCookie.Visible = false;
                this.msg.Visible = true;
                this.delCookie.Visible = true;
            }
            else
            {
                this.setCookie.Visible = true;
                this.msg.Visible = false;
                this.delCookie.Visible = false;
            }
        }

        protected void delCookie_OnClick(object sender, EventArgs e)
        {
            if (this.Request.Cookies["customUsr"] != null)
            {
                var mCookie = new HttpCookie("customUsr") { Expires = DateTime.Now.AddDays(-1) };
                this.Response.Cookies.Add(mCookie);
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void setCookie_OnClick(object sender, EventArgs e)
        {
            this.Response.Cookies.Add(new HttpCookie("customUsr", "loggedIn") { Expires = DateTime.Now.AddMinutes(1) });
        }
    }
}
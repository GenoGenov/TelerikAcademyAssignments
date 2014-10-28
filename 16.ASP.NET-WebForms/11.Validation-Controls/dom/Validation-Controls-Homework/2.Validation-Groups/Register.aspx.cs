using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1.Register_Form
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CheckBoxRequired_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            e.IsValid = accept.Checked;
        }

        protected void checkAddress_OnClick(object sender, EventArgs e)
        {
            Page.Validate("address");
            if (Page.IsValid)
            {
                msg.Visible = true;
                msg.InnerText = "Address info is valid!";
            }
        }

        protected void checkPersonal_OnClick(object sender, EventArgs e)
        {
            Page.Validate("personal");
            if (Page.IsValid)
            {
                msg.Visible = true;
                msg.InnerText = "Personal info is valid!";
            }
        }

        protected void checkLogon_OnClick(object sender, EventArgs e)
        {
            Page.Validate("logon");
            if (Page.IsValid)
            {
                msg.Visible = true;
                msg.InnerText = "Logon info is valid!";
            }
        }
    }
}
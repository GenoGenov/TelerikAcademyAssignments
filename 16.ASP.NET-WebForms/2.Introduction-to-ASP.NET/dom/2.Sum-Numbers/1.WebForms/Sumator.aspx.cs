using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1.WebForms
{
    public partial class Sumator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonCalculateSum_Click(object sender, EventArgs e)
        {
            try
            {
                decimal firstNum = Decimal.Parse(this.TextBoxFirstNum.Text);
                decimal secondNum = Decimal.Parse(this.TextBoxSecondNum.Text);
                decimal sum = firstNum + secondNum;
                this.TextBoxSum.Text = sum.ToString();
            }
            catch (Exception)
            {
                this.TextBoxSum.Text = "Invalid.";
            }
        }
    }
}
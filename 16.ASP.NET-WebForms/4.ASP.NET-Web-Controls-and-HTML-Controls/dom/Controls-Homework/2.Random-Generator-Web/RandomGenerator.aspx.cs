using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2.Random_Generator_Web
{
    public partial class RandomGenerator : System.Web.UI.Page
    {
        static Random rnd = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (err.Visible)
            {
                err.Visible = false;
            }
        }

        protected void generate_OnClick(object sender, EventArgs e)
        {
            try
            {
                var minVal = int.Parse(min.Text);
                var maxVal = int.Parse(max.Text);

                generated.Text = rnd.Next(minVal, maxVal + 1).ToString();
                generated.Visible = true;
            }
            catch (Exception ex)
            {
                err.Text = ex.Message;
                err.Visible = true;
            }
        }
    }
}
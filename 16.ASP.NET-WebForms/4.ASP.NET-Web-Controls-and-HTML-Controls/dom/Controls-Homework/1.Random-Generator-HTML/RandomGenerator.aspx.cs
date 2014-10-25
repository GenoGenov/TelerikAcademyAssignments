using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1.Random_Generator_HTML
{
    public partial class RandomGenerator : System.Web.UI.Page
    {
        static Random rnd=new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (err.Visible)
            {
                err.Visible = false;
            }
        }

        protected void generate_OnServerClick(object sender, EventArgs e)
        {

            try
            {
                var minVal = int.Parse(min.Value);
                var maxVal = int.Parse(max.Value);

                generated.InnerText = rnd.Next(minVal, maxVal + 1).ToString();
                generated.Visible = true;
            }
            catch (Exception)
            {
                err.InnerText = "Min and Max values must be integer numbers !";
                err.Visible = true;
            }
           
        }
    }
}
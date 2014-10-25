namespace _4.Students
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public partial class RegStudent : System.Web.UI.Page
    {
        private void InflateCourses()
        {
            this.courses.Items.Clear();

            switch (this.uni.SelectedItem.Value)
            {
                case "FMI":
                    {
                        this.courses.Items.Add(new ListItem("Software Engineering", "SE"));
                        this.courses.Items.Add(new ListItem("Computer Science", "CS"));
                        this.courses.Items.Add(new ListItem("Informatics", "Is"));
                        break;
                    }
                case "UNSS":
                    {
                        this.courses.Items.Add(new ListItem("Economy and Business", "EB"));
                        this.courses.Items.Add(new ListItem("Accountancy", "AY"));
                        this.courses.Items.Add(new ListItem("Public Relations", "PuR"));
                        break;
                    }
                case "TU":
                    {
                        this.courses.Items.Add(new ListItem("Computer Systems", "CSy"));
                        this.courses.Items.Add(new ListItem("Electronics", "Es"));
                        this.courses.Items.Add(new ListItem("Aviation Systems", "ASy"));
                        break;
                    }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.InflateCourses();
            }
          
        }

        protected void uni_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.InflateCourses();
        }

        protected void btnsubmit_OnClick(object sender, EventArgs e)
        {
            var h1 = new HtmlGenericControl("h1") { InnerText = "Student Info:" };
            info.Controls.Add(h1);
            info.Controls.Add(new HtmlGenericControl("strong"){InnerText = "First Name:"});
            info.Controls.Add(new HtmlGenericControl("span") { InnerText = fName.Text });
            info.Controls.Add(new LiteralControl("<br/>"));
            info.Controls.Add(new HtmlGenericControl("strong") { InnerText = "Last Name:" });
            info.Controls.Add(new HtmlGenericControl("span") { InnerText = lName.Text });
            info.Controls.Add(new LiteralControl("<br/>"));
            info.Controls.Add(new HtmlGenericControl("strong") { InnerText = "Facoulty Number:" });
            info.Controls.Add(new HtmlGenericControl("span") { InnerText = fNum.Text });
            info.Controls.Add(new LiteralControl("<br/>"));
            info.Controls.Add(new HtmlGenericControl("strong") { InnerText = "University:" });
            info.Controls.Add(new HtmlGenericControl("span") { InnerText = uni.SelectedItem.Value });
            info.Controls.Add(new LiteralControl("<br/>"));

            info.Controls.Add(new HtmlGenericControl("h2"){InnerText = "Courses:"});
            var coursesList = new HtmlGenericControl("ul");
            var indeces = courses.GetSelectedIndices();
            foreach (var selectedIndex in courses.GetSelectedIndices())
            {
                coursesList.Controls.Add(new HtmlGenericControl("li"){InnerText = courses.Items[selectedIndex].Text});
            }
            info.Controls.Add(coursesList);
        }
    }
}
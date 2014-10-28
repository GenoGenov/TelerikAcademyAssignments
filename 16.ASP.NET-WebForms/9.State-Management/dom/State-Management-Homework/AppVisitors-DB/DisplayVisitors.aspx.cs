namespace AppVisitors_DB
{
    using System;
    using System.Linq;
    using System.Web;

    using AppVisitors_DB.data;
    using AppVisitors_DB.models;

    public partial class DisplayVisitors : System.Web.UI.Page
    {
        static VisitorsDbContext Db=new VisitorsDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            var visitorsCounter = Db.Visitors.FirstOrDefault();
            if (visitorsCounter==null)
            {
                visitorsCounter = new VisitorsCount() { Value = 0 };
                Db.Visitors.Add(visitorsCounter);
            }

            visitorsCounter.Value += 1;
            Db.SaveChanges();

            this.visitors.ImageUrl = "CreateImageText.img?text=" + HttpContext.Current.Server.UrlEncode(visitorsCounter.Value.ToString());
            this.visitors.Style.Add("width","100%");
            this.visitors.Style.Add("height","100%");
        }
    }
}
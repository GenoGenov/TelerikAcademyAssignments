using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2.SimpleChat
{
    using System.Collections;

    using _2.SimpleChat.data;
    using _2.SimpleChat.models;

    public partial class Chat : System.Web.UI.Page
    {
        private ChatDbContext db;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new ChatDbContext();
            if (IsPostBack)
            {
                LV_Messages.DataBind();
            }
        }

        public IEnumerable<Message> Select()
        {
            
            return db.Messages.OrderBy(x => x.Created).Take(100);
        }

        protected void CreateMsg_OnClick(object sender, EventArgs e)
        {
            db.Messages.Add(new Message() { Text = MsgContent.Text });
            db.SaveChanges();
        }
    }
}
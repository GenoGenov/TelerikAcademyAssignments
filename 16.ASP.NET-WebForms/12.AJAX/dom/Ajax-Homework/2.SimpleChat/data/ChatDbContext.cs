using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2.SimpleChat.data
{
    using System.Data.Entity;

    using _2.SimpleChat.Migrations;
    using _2.SimpleChat.models;

    public class ChatDbContext:DbContext
    {
        public ChatDbContext():base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ChatDbContext,Configuration>());
        }

        public IDbSet<Message> Messages { get; set; }
    }
}
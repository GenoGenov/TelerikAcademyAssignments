using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Data
{
    using MongoChat.Model;

    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using MongoDB.Driver.Linq;

    public static class ChatSystemData
    {
        private static MongoClient client;

        private static MongoServer server;

        private static MongoDatabase db;

        private static User currentUser;

        public static void InitializeConnection()
        {
            client =
                new MongoClient("mongodb://chatuser:tralala123@ds063779.mongolab.com:63779/mongochat");
            server = client.GetServer();
            db = server.GetDatabase("mongochat");
        }

        public static bool AssignCurrentUser(string username)
        {
            if (currentUser!=null)
            {
                throw new InvalidOperationException("There is already a logged in user!");
            }
            var users = db.GetCollection<User>("chatusers");
            var userExists = users.Find(Query<User>.Where(x => x.Username == username)).FirstOrDefault();
            if (userExists!=null)
            {
                throw new ArgumentException("User with the same username already exists!");
            }
            var user = new User() { Username = username };
            users.Insert(user);
            currentUser = user;
            return true;
        }

        public static bool IsLoggedIn
        {
            get
            {
                return currentUser != null;
            }
        }

        public static List<Message> GetMessagesSince(DateTime since)
        {
            var messages = db.GetCollection<Message>("messages").Find(Query<Message>.Where(x => x.DateSent >= since));
            return messages.ToList();
        }

        public static void DisposeConnection()
        {
            db.GetCollection<User>("chatusers").Remove(Query<User>.Where(x => x.Id == currentUser.Id));
        }

        public static bool SendMessage(string text)
        {
            if (currentUser==null)
            {
                throw new InvalidOperationException("There is no logged in user!");
            }
            var message = new Message() { User = currentUser, DateSent = DateTime.Now, Text = text };
            db.GetCollection<Message>("messages").Insert(message);
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe.Web.DataModels
{
    using System.Linq.Expressions;

    using TicTacToe.Models;

    public class UserDataModel
    {
        public static Expression<Func<User, UserDataModel>> FromUser
        {
            get
            {
                return u => new UserDataModel() { Username = u.UserName, Losses = u.Losses, Wins = u.Wins };
            }
        } 

        public string Username { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as UserDataModel;
            return this.Losses == other.Losses && this.Wins == other.Wins && this.Username == other.Username;
        }
    }
}
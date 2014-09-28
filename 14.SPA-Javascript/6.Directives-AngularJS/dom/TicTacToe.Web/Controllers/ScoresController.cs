using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TicTacToe.Web.Controllers
{
    using TicTacToe.Data;
    using TicTacToe.Web.DataModels;

    public class ScoresController : ApiController
    {
        private ITicTacToeData data;
        public ScoresController(ITicTacToeData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult HighScores()
        {
            var users = this.data.Users.All().Select(UserDataModel.FromUser).OrderByDescending(x => x.Wins);
            return this.Ok(users);
        }
    }
}

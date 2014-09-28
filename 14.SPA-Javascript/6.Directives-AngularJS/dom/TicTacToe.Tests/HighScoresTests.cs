using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Tests
{
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using System.Web.Http.Routing;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Telerik.JustMock;
    using Telerik.JustMock.Helpers;

    using TicTacToe.Data;
    using TicTacToe.Data.Repositories;
    using TicTacToe.Models;
    using TicTacToe.Web.Controllers;
    using TicTacToe.Web.DataModels;

    using Mock = Telerik.JustMock.Mock;

    [TestClass]
    public class HighScoresTests
    {
        [TestMethod]
        public void WhenGETScores_ShouldReturnUserWinsAndLossesProperly()
        {
            var usersRepo = Mock.Create<IRepository<User>>();

            User[] users =
                {
                    new User() { UserName = "user1", Id = "123456", Wins = 3, Losses = 1 },
                    new User() { UserName = "user2", Id = "654321", Wins = 2, Losses = 1 }
                };

            Mock.Arrange(() => usersRepo.All()).Returns(() => users.AsQueryable());

            var uow = Mock.Create<ITicTacToeData>();
            Mock.Arrange(() => uow.Users).Returns(() => usersRepo);

            var scoresController = new ScoresController(uow);
            this.SetupController(scoresController);
            var result = scoresController.HighScores();
            //act
            var expected = users.OrderByDescending(x => x.Wins).AsQueryable().Select(UserDataModel.FromUser).ToArray();
            var actual =
                result.ExecuteAsync(new CancellationToken(false))
                      .Result.Content.ReadAsAsync<IEnumerable<UserDataModel>>()
                      .Result.ToArray();
            //assert
            CollectionAssert.AreEquivalent(actual, expected);
        }

        private void SetupController(ApiController controller)
        {
            string serverUrl = "http://test-url.com";

            //Setup the Request object of the controller
            var request = new HttpRequestMessage() { RequestUri = new Uri(serverUrl) };
            controller.Request = request;

            //Setup the configuration of the controller
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                                       name: "DefaultApi",
                                       routeTemplate: "api/{controller}/{action}/{id}",
                                       defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            //Apply the routes of the controller
            controller.RequestContext.RouteData = new HttpRouteData(
                route: new HttpRoute(),
                values: new HttpRouteValueDictionary { { "controller", "scores" } });
        }
    }
}

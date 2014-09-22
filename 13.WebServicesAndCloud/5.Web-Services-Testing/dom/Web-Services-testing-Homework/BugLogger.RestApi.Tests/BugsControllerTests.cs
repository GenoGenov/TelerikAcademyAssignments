namespace BugLogger.RestApi.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Results;
    using System.Web.Http.Routing;

    using BugLogger.DataLayer;
    using BugLogger.Repositories;
    using BugLogger.RestApi.Controllers;
    using BugLogger.RestApi.Tests.Fakes;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Telerik.JustMock;

    [TestClass]
    public class BugsControllerTests
    {
        [TestMethod]
        public void GetAll_WhenValid_ShouldReturnBugsCollection()
        {
            //arrange
            FakeRepository<Bug> fakeRepo = new FakeRepository<Bug>();

            var bugs = new List<Bug>()
                           {
                               new Bug() { Text = "TEST NEW BUG 1" },
                               new Bug() { Text = "TEST NEW BUG 2" },
                               new Bug() { Text = "TEST NEW BUG 3" }
                           };

            fakeRepo.Entities = bugs;

            var controller = new BugsController(fakeRepo as IRepository<Bug>);

            //act

            var result = controller.GetAll();

            //assert

            CollectionAssert.AreEquivalent(bugs, result.ToList<Bug>());
        }

        [TestMethod]
        public void AddBug_WhenBugTextIsValid_ShouldBeAddedToRepoWithLogDateAndStatusPending()
        {
            //arrange
            var repo = new FakeRepository<Bug>();
            repo.IsSaveCalled = false;
            repo.Entities = new List<Bug>();
            var bug = new Bug() { Text = "NEW TEST BUG" };
            var controller = new BugsController(repo);
            this.SetupController(controller);

            //act
            controller.PostBug(bug);

            //assert
            Assert.AreEqual(repo.Entities.Count, 1);
            var bugInDb = repo.Entities.First();
            Assert.AreEqual(bug.Text, bugInDb.Text);
            Assert.IsNotNull(bugInDb.LogDate);
            Assert.AreEqual(Status.Pending, bugInDb.Status);
            Assert.IsTrue(repo.IsSaveCalled);
        }

        [TestMethod]
        public void GetAll_WhenValid_ShouldReturnBugsCollection_WithMocks()
        {
            //arrange
            var repo = Mock.Create<IRepository<Bug>>();

            Bug[] bugs = { new Bug() { Text = "Bug1" }, new Bug() { Text = "Bug2" } };

            Mock.Arrange(() => repo.All()).Returns(() => bugs.AsQueryable());

            var controller = new BugsController(repo);
            //act
            var result = controller.GetAll();

            //assert
            CollectionAssert.AreEquivalent(bugs, result.ToArray<Bug>());
        }

        [TestMethod]
        public void GetAllByDate_WhenValid_ShouldReturnBugsCollection()
        {
            var repo = Mock.Create<IRepository<Bug>>();
            var bugs =
                new List<Bug> { new Bug() { LogDate = DateTime.Now, Status = Status.Pending, Text = "Tralala 1" } }
                    .AsQueryable();

            Mock.Arrange(() => repo.All()).Returns(() => bugs);

            var controller = new BugsController(repo);
            var result = controller.GetAfterDate("20-02-2014");
            CollectionAssert.AreEqual(
                                      bugs.ToList(),
                                      (result as OkNegotiatedContentResult<IQueryable<Bug>>).Content.ToList());
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
                                       routeTemplate: "api/{controller}/{id}",
                                       defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            //Apply the routes of the controller
            controller.RequestContext.RouteData = new HttpRouteData(
                route: new HttpRoute(),
                values: new HttpRouteValueDictionary { { "controller", "bugs" } });
        }
    }
}
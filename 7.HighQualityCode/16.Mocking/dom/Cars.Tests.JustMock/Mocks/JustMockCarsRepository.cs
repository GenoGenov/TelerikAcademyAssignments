namespace Cars.Tests.JustMock.Mocks
{
    using Cars.Contracts;
    using Cars.Models;
    using System.Linq;
    using Telerik.JustMock;

    public class JustMockCarsRepository : CarRepositoryMock, ICarsRepositoryMock
    {
        protected override void ArrangeCarsRepositoryMock()
        {
            this.CarsData = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => this.CarsData.Add(Arg.IsAny<Car>())).DoNothing();
            Mock.Arrange(() => this.CarsData.All()).Returns(this.FakeCarCollection);
            Mock.Arrange(() => this.CarsData.Search(Arg.AnyString)).Returns(this.FakeCarCollection.Where(c => c.Make == "BMW").ToList());
            Mock.Arrange(() => this.CarsData.GetById(Arg.AnyInt)).Returns(this.FakeCarCollection.First());

            //Homework Mocks here !
            Mock.Arrange(() => this.CarsData.GetById(Arg.IsInRange(0,5,RangeKind.Inclusive)))
                .Returns((int id) => this.FakeCarCollection.FirstOrDefault(c => c.Id == id));
            Mock.Arrange(() => this.CarsData.SortedByMake()).Returns(this.FakeCarCollection.OrderBy(x=>x.Make).ToList());
            Mock.Arrange(() => this.CarsData.SortedByYear()).Returns(this.FakeCarCollection.OrderBy(x => x.Year).ToList());
        }
    }
}

using Academy.Commands.Creating;
using Academy.Core.Contracts;
using Academy.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Academy.UnitTests.Commands.Creating.CreateCourseCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CreateCourseAndAddItToSeason_WhenParametersAreCorrect()
        {
            // Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var dataBaseMock = new Mock<IDataBase>();
            var firstSeasonMock = new Mock<ISeason>();
            var secondSeasonMock = new Mock<ISeason>();
            var courseMock = new Mock<ICourse>();

            List<ISeason> seasons = new List<ISeason>()
            {
                firstSeasonMock.Object,
                secondSeasonMock.Object
            };

            var seasonId = "1";
            var name = "JavaScriptOOP";
            var lecturesPerWeek = "2";
            var startingDate = "2017-01-24";

            List<string> parameters = new List<string>()
            {
                seasonId,
                name,
                lecturesPerWeek,
                startingDate
            };

            List<ICourse> courses = new List<ICourse>();
            secondSeasonMock.SetupGet(m => m.Courses).Returns(courses);

            factoryMock.Setup(m => m.CreateCourse(name, lecturesPerWeek, startingDate)).Returns(courseMock.Object);
            dataBaseMock.SetupGet(m => m.Seasons).Returns(seasons);


            CreateCourseCommand command = new CreateCourseCommand(factoryMock.Object, dataBaseMock.Object);

            // Act
            command.Execute(parameters);

            // Assert
            Assert.AreEqual(1, secondSeasonMock.Object.Courses.Count); // should be one; no need to look in teh databaseMock
            Assert.AreSame(courseMock, secondSeasonMock.Object.Courses.First()); //don't forget to add Linq

        }
    }
}

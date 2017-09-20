using Academy.Commands.Contracts;
using Academy.Core;
using Academy.Core.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.UnitTests.Core.EngineTests
{
    [TestClass]
    public class Start_Should
    {
        [TestMethod]
        public void CallWriterMethodWithExceptionMessage_WhenExceptionIsThrown()
        {
            //Arrange 
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<IParser>();
            var commandMock = new Mock<ICommand>();
            string messageToWrite = "Invalid command parameters supplied or the entity with that ID for does not exist.";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(messageToWrite);
            string result = sb.ToString();

            readerMock.SetupSequence(m => m.ReadLine())
                .Returns("Some command")
                .Returns("Exit");

            parserMock
                .Setup(m => m.ParseCommand(It.IsAny<string>()))
                .Returns(commandMock.Object);

            parserMock
                .Setup(m => m.ParseParameters(It.IsAny<string>()))
                .Throws(new Exception(messageToWrite));

            var engine = new Engine(readerMock.Object,
                writerMock.Object, 
                parserMock.Object);

            //Act
            engine.Start();

            //Assert
            writerMock.Verify(m => m.Write(result));

        }


        [TestMethod]
        public void CallWriterWriteMethodWithCommandsResult_WhenInputIsCorrect()
        {
            // Arrange 
            string commandInput = "CreateSeason 2016 2017 SoftwareAcademy";
            string exitCommand = "Exit";
            string commandResult = "command result";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(commandResult);
            string expectedResult = sb.ToString();


            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<IParser>();
            var commandMock = new Mock<ICommand>();

            readerMock.SetupSequence(m => m.ReadLine()).Returns(commandInput).Returns(exitCommand);
            parserMock.Setup(m => m.ParseCommand(commandInput)).Returns(commandMock.Object);
            commandMock.Setup(m => m.Execute(It.IsAny<IList<string>>())).Returns(commandResult);

            Engine engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object);


            // Act
            engine.Start();


            // Assert
            writerMock.Verify(m => m.Write(expectedResult), Times.Once());


        }

        [TestMethod]
        public void ThrowsExceptionWithSpecificText_WhenParserThrowsAnArgumentOutOfRangeException()
        {
            // Arrange 
            string exceptionMessageToWrite = "Invalid command parameters supplied or the entity with that ID for does not exist.";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(exceptionMessageToWrite);
            string expectedResult = sb.ToString();
            string someCommand = "Some Command";
            string terminationCommand = "Exit";

            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<IParser>();
            var commandMock = new Mock<ICommand>();

            readerMock.SetupSequence(m => m.ReadLine()).Returns(someCommand).Returns(terminationCommand);
            parserMock.Setup(m => m.ParseCommand(someCommand)).Throws(new ArgumentOutOfRangeException());

            Engine engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object);

            // Act
            engine.Start();

            // Assert
            writerMock.Verify(m => m.Write(expectedResult));

        }

    }
}

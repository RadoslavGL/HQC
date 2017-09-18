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

namespace Academy.UnitTests.Code.EngineTests
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
            string exceptionMessage = "testException";
            string messageToWrite = "Invalid command parameters supplied or the entity with that ID for does not exist.";

            readerMock.SetupSequence(m => m.ReadLine())
                .Returns("Some command")
                .Returns("Exit");

            parserMock.Setup(m => m.ParseCommand(It.IsAny<string>())).Returns(commandMock.Object);

            parserMock.Setup(m => m.ParseParameters(It.IsAny<string>())).Throws(new Exception(messageToWrite));

            var engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object);

            //Act
            engine.Start();

            //Assert
            writerMock.Verify(m => m.WriteLine(messageToWrite));

        }
    }
}

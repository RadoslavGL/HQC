using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.UnitTest
{
    [TestClass]
    public class Student_Should
    {
        [TestMethod]
        [DataRow(2, "Tashko")]
        public void ThrowArgumentOutOfRangeException_WhenParameteredAreOutOfRange(int id, string name)
        {
            //Arrange
            Student student = new Student(id, name);

            //Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => student);
        }

    }
}

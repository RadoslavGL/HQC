using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{

    public class Student
    {
        public const int minID = 10000;
        public const int maxID = 99999;

        #region Fields
        private int uniqueNumber;
        private string name;
        #endregion

        public Student(int uniqueNumber, string name)
        {
            this.UniqueNumber = uniqueNumber;
            this.Name = name;
        }

        #region Props

        public int UniqueNumber
        {
            get
            {
                return this.uniqueNumber;
            }
            set
            {
                if (value < minID || value > maxID)
                {
                    throw new ArgumentOutOfRangeException(
                        "The student's unique number must be between 10000 and 99999 inclusively!");
                }
                this.uniqueNumber = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name must not be null or empty!");
                }

                this.name = value;
            }
        }

        #endregion


    }
}

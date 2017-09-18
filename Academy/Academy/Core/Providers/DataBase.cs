using Academy.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Contracts;

namespace Academy.Core.Providers
{
    public class DataBase : IDataBase
    {
        public DataBase()
        {
            this.Seasons = new List<ISeason>();
            this.Students = new List<IStudent>();
            this.Trainers = new List<ITrainer>();
        }

        public IList<ISeason> Seasons
        {
            get;
            private set;
        }

        public IList<IStudent> Students
        {
            get;
            private set;
        }

        public IList<ITrainer> Trainers
        {
            get;
            private set;
        }
    }
}

using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Contracts
{
    public interface IDataBase
    {
        IList<ISeason> Seasons
        {
            get;
        }

        IList<IStudent> Students
        {
            get;
        }

        IList<ITrainer> Trainers
        {
            get;
        }

    }
}

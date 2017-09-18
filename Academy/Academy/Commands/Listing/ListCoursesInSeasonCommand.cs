using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using System.Collections.Generic;

namespace Academy.Commands.Listing
{
    public class ListCoursesInSeasonCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IDataBase dataBase;
        //private readonly IEngine engine;

        public ListCoursesInSeasonCommand(IAcademyFactory factory, IDataBase dataBase)
        {
            this.factory = factory;
            this.dataBase = dataBase;
        }

        public string Execute(IList<string> parameters)
        {
            var seasonId = parameters[0];
            var season = this.dataBase.Seasons[int.Parse(seasonId)];

            return season.ListCourses();
        }
    }
}

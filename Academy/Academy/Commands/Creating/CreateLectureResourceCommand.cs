﻿using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using System.Collections.Generic;

namespace Academy.Commands.Creating
{
    public class CreateLectureResourceCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IDataBase dataBase;

        //private readonly IEngine engine;

        public CreateLectureResourceCommand(IAcademyFactory factory, IDataBase dataBase)
        {
            this.factory = factory;
            this.dataBase = dataBase;
        }

        public string Execute(IList<string> parameters)
        {
            var seasonId = parameters[0];
            var courseId = parameters[1];
            var lectureId = parameters[2];
            var type = parameters[3];
            var name = parameters[4];
            var url = parameters[5];

            var course = this.dataBase
                .Seasons[int.Parse(seasonId)]
                .Courses[int.Parse(courseId)];

            var lecture = course
                .Lectures[int.Parse(lectureId)];

            var lectureResource = this.factory.CreateLectureResource(type, name, url);
            lecture.Resources.Add(lectureResource);

            return $"Lecture resource with ID {lecture.Resources.Count - 1} was created in Lecture {seasonId}.{course.Name}.{lecture.Name}.";
        }
    }
}
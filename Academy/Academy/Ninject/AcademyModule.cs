using Academy.Commands.Adding;
using Academy.Commands.Contracts;
using Academy.Commands.Creating;
using Academy.Commands.Listing;
using Academy.Core;
using Academy.Core.Contracts;
using Academy.Core.Factories;
using Academy.Core.Providers;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Ninject
{
    public class AcademyModule : NinjectModule
    {
        public override void Load()
        {
            //Providers Bindings - all as singleton

            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();
            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IParser>().To<CommandParser>().InSingletonScope();
            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<IDataBase>().To<DataBase>().InSingletonScope();
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();
            this.Bind<IAcademyFactory>().To<AcademyFactory>().InSingletonScope();


            //Commands Bindings - all with named bindings

            this.Bind<ICommand>().To<AddStudentToCourseCommand>().Named("AddStudentToCourse");
            this.Bind<ICommand>().To<AddStudentToSeasonCommand>().Named("AddStudentToSeason");
            this.Bind<ICommand>().To<AddTrainerToSeasonCommand>().Named("AddTrainerToSeason");

            this.Bind<ICommand>().To<CreateCourseCommand>().Named("CreateCourse");
            this.Bind<ICommand>().To<CreateCourseResultCommand>().Named("CreateCourseResult");
            this.Bind<ICommand>().To<CreateLectureCommand>().Named("CreateLecture");
            this.Bind<ICommand>().To<CreateSeasonCommand>().Named("CreateSeason");
            this.Bind<ICommand>().To<CreateStudentCommand>().Named("CreateStudent");
            this.Bind<ICommand>().To<CreateTrainerCommand>().Named("CreateTrainer");
            this.Bind<ICommand>().To<CreateLectureResourceCommand>().Named("CreateLectureResource");

            this.Bind<ICommand>().To<ListCoursesInSeasonCommand>().Named("ListCoursesInSeason");
            this.Bind<ICommand>().To<ListUsersCommand>().Named("ListUsers");
            this.Bind<ICommand>().To<ListUsersInSeasonCommand>().Named("ListUsersInSeason");

        }
    }
}

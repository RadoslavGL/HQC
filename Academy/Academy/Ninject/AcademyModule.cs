using Academy.Commands.Adding;
using Academy.Commands.Contracts;
using Academy.Commands.Creating;
using Academy.Commands.Listing;
using Academy.Core;
using Academy.Core.Contracts;
using Academy.Core.Factories;
using Academy.Core.Providers;
using Academy.Decorators;
using Ninject;
using Ninject.Modules;
using System.Configuration;

namespace Academy.Ninject
{
    public class AcademyModule : NinjectModule
    {
        public override void Load()
        {
            //Providers Bindings - all as singleton

            this.Bind<IWriter>().To<ConsoleWriter>();
            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IParser>().To<CommandParser>().InSingletonScope();
            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<IDataBase>().To<DataBase>().InSingletonScope();
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();
            this.Bind<IAcademyFactory>().To<AcademyFactory>().InSingletonScope();


            //Commands Bindings - all with named bindings

            this.Bind<ICommand>().To<AddStudentToCourseCommand>().Named("AddStudentToCourse");
            this.Bind<ICommand>().To<AddStudentToSeasonCommand>().Named("AddStudentToSeason");
            this.Bind<ICommand>().To<AddTrainerToSeasonCommand>().Named("AddTrainerToSeason");


            bool isTestEnvironment = bool.Parse(ConfigurationManager.AppSettings["IsTestEnvironment"]);

            if (isTestEnvironment)
            {
                this.Bind<ICommand>().To<CreateCourseCommand>().Named("InternalCreateCourse");

                this.Bind<ICommand>()
                    .To<AnnouncerCommandDecorator>()
                    .Named("CreateCourse")
                    .WithConstructorArgument(this.Kernel.Get<ICommand>("InternalCreateCourse"));


                this.Bind<ICommand>().To<CreateCourseResultCommand>().Named("InternalCreateCourseResult");

                this.Bind<ICommand>()
                    .To<AnnouncerCommandDecorator>()
                    .Named("CreateCourseResult")
                    .WithConstructorArgument(this.Kernel.Get<ICommand>("InternalCreateCourseResult"));


                this.Bind<ICommand>().To<CreateLectureCommand>().Named("InternalCreateLecture");

                this.Bind<ICommand>()
                    .To<AnnouncerCommandDecorator>()
                    .Named("CreateLecture")
                    .WithConstructorArgument(this.Kernel.Get<ICommand>("InternalCreateLecture"));


                this.Bind<ICommand>().To<CreateSeasonCommand>().Named("InternalCreateSeason");

                this.Bind<ICommand>()
                    .To<AnnouncerCommandDecorator>()
                    .Named("CreateSeason")
                    .WithConstructorArgument(this.Kernel.Get<ICommand>("InternalCreateSeason"));


                this.Bind<ICommand>().To<CreateStudentCommand>().Named("InternalCreateStudent");

                this.Bind<ICommand>()
                    .To<AnnouncerCommandDecorator>()
                    .Named("CreateStudent")
                    .WithConstructorArgument(this.Kernel.Get<ICommand>("InternalCreateStudent"));


                this.Bind<ICommand>().To<CreateTrainerCommand>().Named("InternalCreateTrainer");

                this.Bind<ICommand>()
                    .To<AnnouncerCommandDecorator>()
                    .Named("CreateTrainer")
                    .WithConstructorArgument(this.Kernel.Get<ICommand>("InternalCreateTrainer"));


                this.Bind<ICommand>().To<CreateLectureResourceCommand>().Named("InternalCreateLectureResource");

                this.Bind<ICommand>()
                    .To<AnnouncerCommandDecorator>()
                    .Named("CreateLectureResource")
                    .WithConstructorArgument(this.Kernel.Get<ICommand>("InternalCreateLectureResource"));
            }
            else
            {
                this.Bind<ICommand>().To<CreateCourseCommand>().Named("CreateCourse");

                this.Bind<ICommand>().To<CreateCourseResultCommand>().Named("CreateCourseResult");

                this.Bind<ICommand>().To<CreateLectureCommand>().Named("CreateLecture");

                this.Bind<ICommand>().To<CreateSeasonCommand>().Named("CreateSeason");

                this.Bind<ICommand>().To<CreateStudentCommand>().Named("CreateStudent");

                this.Bind<ICommand>().To<CreateTrainerCommand>().Named("CreateTrainer");

                this.Bind<ICommand>().To<CreateLectureResourceCommand>().Named("CreateLectureResource");
            }


            this.Bind<ICommand>().To<ListCoursesInSeasonCommand>().Named("ListCoursesInSeason");
            this.Bind<ICommand>().To<ListUsersCommand>().Named("ListUsers");
            this.Bind<ICommand>().To<ListUsersInSeasonCommand>().Named("ListUsersInSeason");



        }
    }
}

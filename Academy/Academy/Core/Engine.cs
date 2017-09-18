using Academy.Core.Contracts;
using Bytes2you.Validation;
using System;
using System.Text;

namespace Academy.Core
{
    public class Engine : IEngine
    {
        //private static IEngine instanceHolder = new Engine(new ConsoleReader(), new ConsoleWriter());

        private const string TerminationCommand = "Exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";

        private readonly StringBuilder builder = new StringBuilder();
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IParser parser;


        public Engine(IReader reader, IWriter writer, IParser parser)
        {
            Guard.WhenArgument(reader, "reader").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(parser, "parser").IsNull().Throw();

            this.reader = reader;
            this.writer = writer;
            this.parser = parser;

            //this.Reader = new ConsoleReader(); 
            //this.Writer = new ConsoleWriter();
            //this.Parser = new CommandParser();

            //this.Seasons = new List<ISeason>();
            //this.Students = new List<IStudent>();
            //this.Trainers = new List<ITrainer>();
        }

        //public static IEngine Instance
        //{
        //    get
        //    {
        //        return instanceHolder;
        //    }
        //}

        // Property dependencty injection not validated for simplicity
        //public IReader Reader { get; set; }

        //public IWriter Writer { get; set; }

        //public IParser Parser { get; set; }


        //public IList<ISeason> Seasons { get; private set; }

        //public IList<IStudent> Students { get; private set; }

        //public IList<ITrainer> Trainers { get; private set; }


        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();

                    if (commandAsString == TerminationCommand)
                    {
                        this.writer.Write(this.builder.ToString());
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    this.builder.AppendLine("Invalid command parameters supplied or the entity with that ID for does not exist.");
                }
                catch (Exception ex)
                {
                    this.builder.AppendLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.parser.ParseCommand(commandAsString);
            var parameters = this.parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            this.builder.AppendLine(executionResult);
        }
    }
}

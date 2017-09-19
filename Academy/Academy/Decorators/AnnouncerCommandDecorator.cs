using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;

namespace Academy.Decorators
{
    public class AnnouncerCommandDecorator : ICommand
    {
        private readonly ICommand command;
        private readonly IWriter writer;

        public AnnouncerCommandDecorator(ICommand command, IWriter writer)
        {
            Guard.WhenArgument(command, "command").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();

            this.writer = writer;
        }

        public string Execute(IList<string> parameters)
        {
            string result = this.command.Execute(parameters);

            this.writer.WriteLine($"Command is called at {DateTime.Now}!");

            return result;

        }
    }
}

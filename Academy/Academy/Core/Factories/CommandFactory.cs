using Academy.Commands.Contracts;
using Bytes2you.Validation;
using Ninject;
using System;

namespace Academy.Core.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IKernel kernel;

        public CommandFactory(IKernel kernel)
        {
            Guard.WhenArgument(kernel, "kernel").IsNull().Throw();
            this.kernel = kernel;
        }

        public ICommand ReturnValidCommand(string commandName)
        {
            return this.kernel.Get<ICommand>(commandName);
        }
    }
}

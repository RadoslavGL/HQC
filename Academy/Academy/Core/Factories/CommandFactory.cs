using Academy.Commands.Contracts;
using Ninject;
using System;

namespace Academy.Core.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IKernel kernel;

        public CommandFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public ICommand ReturnValidCommand(string commandName)
        {
            return this.kernel.Get<ICommand>(commandName);
        }
    }
}

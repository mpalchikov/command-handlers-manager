using System;
using System.Collections.Generic;
using System.Text;

namespace CHM.Commands
{
    public interface ICommandsHandlerManager
    {
        public bool IsExecuted(Type handlerType);
        public void Start(Type handlerType);
        public void Finish(Type handlerType);
    }
}

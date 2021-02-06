using CHM.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CHM.Data
{
    public class InMemoryManager : ICommandsHandlerManager
    {
        private List<string> _executedHandlers = new List<string>();

        public bool IsExecuted(Type handlerType)
        {
            return _executedHandlers.Contains(handlerType.ToString());
        }

        public void Start(Type handlerType)
        {
            _executedHandlers.Add(handlerType.ToString());
        }

        public void Finish(Type handlerType)
        {
            _executedHandlers.Remove(handlerType.ToString());
        }                        
    }
}

using System;

namespace SimpleEventSourcing
{
    public class NoHandlerException : Exception
    {
        private readonly Type _missingHandlerType;

        public NoHandlerException(Type missingHandlerType)
        {
            _missingHandlerType = missingHandlerType;
        }

        public override string Message
        {
            get { return string.Format("No handler for event type: {0}", _missingHandlerType.Name); }
        }
    }
}
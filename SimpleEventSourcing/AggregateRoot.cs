using System;
using System.Collections.Generic;

namespace SimpleEventSourcing
{
    public class AggregateRoot
    {
        private readonly List<IEvent> _uncommittedChanges; 
        private static readonly Dictionary<Type, Action<object>> Handlers;

        public void LoadFromEventStream(IEnumerable<IEvent> events)
        {
            foreach (var e in events)
                ApplyStateChange(e);
        }

        static AggregateRoot()
        {
            Handlers = new Dictionary<Type, Action<object>>();
        }

        protected static void AddHandler<T>(Action<T> handler) where T : IEvent
        {
            Handlers.Add(typeof (T), e => handler((T)e));
        }

        protected AggregateRoot()
        {
            _uncommittedChanges = new List<IEvent>();
        }

        public IEnumerable<IEvent> GetUncommittedChanges()
        {
            return _uncommittedChanges;
        }

        protected void ApplyChange(IEvent e)
        {
            ApplyStateChange(e);
            _uncommittedChanges.Add(e);
        }

        private void ApplyStateChange(IEvent e)
        {
            Action<object> handler;
            if (!Handlers.TryGetValue(e.GetType(), out handler))
                throw new NoHandlerException(e.GetType());
            handler(e);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Z3.Model;

namespace Z3
{
    public interface ISubscriber<T>
    {
        void Handle();
    }

    public class EventAggregator 
    {
        public static readonly EventAggregator Instance = new();

        readonly Dictionary<Type, List<object>> _subscribers = new();

        #region IEventAggregator Members

        public void AddSubscriber<T>(ISubscriber<T> subscriber)
        {
            if (!_subscribers.ContainsKey(typeof(T)))
                _subscribers.Add(typeof(T), new List<object>());

            _subscribers[typeof(T)].Add(subscriber);
        }

        public void RemoveSubscriber<T>(ISubscriber<T> subscriber)
        {
            if (_subscribers.ContainsKey(typeof(T)))
                _subscribers[typeof(T)].Remove(subscriber);
        }

      
        public void Publish<T>()
        {
            if (!_subscribers.ContainsKey(typeof(T))) return;
            foreach (var subscriber in
                _subscribers[typeof(T)].OfType<ISubscriber<T>>())
                subscriber.Handle();
        }

        #endregion
    }

    public abstract class PersonAddedNotification
    {
        protected PersonAddedNotification(Person newPerson)
        {
            NewPerson = newPerson;
        }

        public Person NewPerson { get; set; }
    }
}

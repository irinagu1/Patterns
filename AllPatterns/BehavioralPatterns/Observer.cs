using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns
{
    public class Publisher
    {
        private List<ISubscriber> _subscribers 
            = new List<ISubscriber>();

        private string _state = string.Empty;

        public void Subscribe(ISubscriber subscriber)
            => _subscribers.Add(subscriber);
        
        public void Unsubscribe(ISubscriber subscriber)
            => _subscribers.Remove(subscriber);    

        void NotifySubscribers()
        {
            foreach (var subscriber in _subscribers)
                subscriber.Update(_state);
        }  
        
        public void Logic(string state)
        {
            _state = state;
            NotifySubscribers();
        }
    }

    public interface ISubscriber
    {
        void Update(string newState);
    }

    class Customer : ISubscriber
    {
        private List<string> _states
            = new List<string>();

        public void Update(string newState)
            => _states.Add(newState);
    }
}

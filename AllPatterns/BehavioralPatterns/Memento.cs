using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BehavioralPatterns.Originator;

namespace BehavioralPatterns
{

    // variant 1
    class Originator
    {
        private string _state;
        public Originator(string state) => 
            _state = state;
        
        public void RandomChangeState()
        {
            _state = new Random().Next(0,1000).ToString();
            Console.WriteLine($"Random change state: {_state}");
        }

        //сделать снимок состояния
        public IMemento Save() 
            => new Memento(_state);

        public void Restore(IMemento memento)
        {
            _state = memento.GetInfo();
            Console.WriteLine("Restored state");
        }
    
    }

    public interface IMemento
    {
        string GetInfo();
    }

    class Memento : IMemento
    {
        private string _mementoState;
        public Memento(string mementoState)
        {
            _mementoState= mementoState;
        }

        public string GetInfo()
            => _mementoState;
    }

    class Caretaker
    {
        private Originator _originator;
        private List<IMemento> _history;
        public Caretaker(Originator originator)
        {
            _originator = originator;
            _history = new List<IMemento>();
        }

        public void Backup()
        {
            _history.Add(_originator.Save());
        }

        public void Undo()
        {
            if (_history.Count() == 0)
                return;

            var m = _history.Last();
            _history.Remove(m);
            _originator.Restore(m);
        }

        public void ShowHistory()
        {
            foreach(var m in _history)
                Console.WriteLine(m.GetInfo());
        }
    }

    //variant 2. Nested class
    public class OuterOriginator
    {
        private string _state;
        public void set(string state)
        {
            _state = state;
            Console.WriteLine($"Originator: set state to {_state}");
        }

        public IMementoForNested saveToMemento()
            => new Memento(_state);

        public void restoreFromMemento(IMementoForNested memento)
        {
            Memento m = (Memento)memento;
            _state = m.getState();
        }
        
        private class Memento : IMementoForNested
        {
            private string _mementoState;
            public string getState()
                => _mementoState;

            public Memento(string mementoState)
                => _mementoState = mementoState;
        }
    }

    public interface IMementoForNested;

    public class CaretakerForNested
    {
        private List<IMementoForNested> _history;
        private OuterOriginator _originator;
        public CaretakerForNested(OuterOriginator originator)
        {
            _history = new List<IMementoForNested>();
            _originator = originator;
        }
        public void Do()
        {
            _originator.set("1");
            _originator.set("2");
            _history.Add(_originator.saveToMemento());
            _originator.set("3");

            var m = _history.Last();
            _history.Remove(m);
            _originator.restoreFromMemento(m);
        }
    }
}

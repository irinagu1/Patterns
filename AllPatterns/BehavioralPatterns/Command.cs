using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace BehavioralPatterns
{
    public interface ICommand
    {
        void Execute();
    }
    class SimpleCommand : ICommand
    {
        private string _payyload = string.Empty;
        public SimpleCommand(string payload) 
        {
            _payyload = payload;
        }
        public void Execute()
        {
            Console.WriteLine("Simple command");
        }
    }

    class ComplexCommand : ICommand
    {
        private Receiver _receiver;
        private string _a;
        private string _b;

        public ComplexCommand(Receiver receiver, string a, string b)
        {
            _receiver = receiver;
            _a = a;
            _b = b;
        }

        public void Execute()
        {
            Console.WriteLine("Complex: execute");
            _receiver.Do1(_a);
            _receiver.Do2(_b);
        }

    }

    class Receiver
    {
        public void Do1(string a)
            => Console.WriteLine($"receiver 1: {a}");

        public void Do2(string b)
            => Console.WriteLine($"receiver 1: {b}");
    }
    class Invoker
    {
        private ICommand _onStart;

        public void SetOnStart(ICommand c)
            => _onStart = c;

        public void DoSth()
        {
            _onStart.Execute();
        }
    }

    //real example

    //invoker - remote-conrol
    public class RemoteControl
    {
        private ICommandLight _command;
        private readonly Stack<ICommandLight> _history = 
            new Stack<ICommandLight>();
        public void SetCommand(ICommandLight command)
        {
            _command = command;
        }

        public void PressDo()
        {
            _command.Execute();
            _history.Push(_command);
        }

        public void PressUndo()
        {
            var c = _history.Pop();
            _command.Undo();
        }
    }

    //command itnerface
    public interface ICommandLight
    {
        void Execute();
        void Undo();
    }

    public class LightOn : ICommandLight
    {
        private readonly Light _light;
        public LightOn(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOn();
        }

        public void Undo()
        {
            _light.TurnOff();
        }
    }

    public class LightOff : ICommandLight
    {
        private readonly Light _light;
        public LightOff(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOff();
        }

        public void Undo()
        {
            _light.TurnOn();
        }
    }

    public class Light
    {
        public bool IsOn { get; private set; }

        public void TurnOn()
        {
            IsOn = true;
            Console.WriteLine("Light is on");
        }

        public void TurnOff()
        {
            IsOn = false;
            Console.WriteLine("Light is off");
        }
    }
}

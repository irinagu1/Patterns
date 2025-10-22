using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns
{
    public interface IMediator
    {
        void Notify(Component initiator, string message);
    }
    public class Mediator : IMediator
    {
        public ComponentTextBox textBox {  get; set; }
        public ComponentButton button { get; set; }

        public void Notify(Component initiator, string message)
        {
            if (initiator is ComponentTextBox)
            {
                Console.WriteLine("Business logic text box changed");
            }
            else if (initiator is ComponentButton)
            {
                Console.WriteLine("Business logic button pushed");
            }
        }
    }

    public abstract class Component 
    {
        public IMediator Mediator;
        public Component(IMediator mediator)
        {
            Mediator = mediator;
        }
    }

    public class ComponentTextBox : Component
    {
        public ComponentTextBox(IMediator mediator) : base(mediator)
        {
        }

        public void ChangeText()
        {
                Mediator.Notify(this, "Changed text in TextBox");
        }
    }
    public class ComponentButton : Component
    {
        public ComponentButton(IMediator mediator) : base(mediator)
        {
        }

        public void Push()
        {
            Mediator.Notify(this, "Pushed the button");
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns
{
    class Context
    {
        //объект текущего состояния
        private State _state = null;

        public void ChangeStateTo(State state)
        {
            Console.WriteLine
                ($"State changed to {state.GetType().Name}");
            _state = state;
            _state.SetContext(this);
        }
        public void BusinessLogic1()
        {
            _state.Void1();
        }
        public void BusinessLogic2()
        {
            _state.Void2();
        }
    }

    abstract class State
    {
        protected Context _context;
        public void SetContext(Context context)
            => _context = context;
        public abstract void Void1();
        public abstract void Void2();
    }

    class State1 : State
    {
        public override void Void1()
        {
            Console.WriteLine("Void1 state1");
            _context.ChangeStateTo(new State2());
        }

        public override void Void2()
        {
            Console.WriteLine("Void2 state1");
        }
    }

    class State2 : State
    {
        public override void Void1()
        {
            Console.WriteLine("Void1 state2");
        }

        public override void Void2()
        {
            Console.WriteLine("Void2 state2");
            _context.ChangeStateTo(new State1());
        }
    }
    
    //example with smartphone
    class Smartphone
    {
        private SmartphoneState _state;

        public void ChangeState(SmartphoneState state)
        {
            Console.WriteLine
                ($"Smartphone changed state to {state.GetType().Name}");
            _state = state;
            _state.SetSmartphone(this);
        }

        void PressLeft()
        {
            _state.PressLeftButton();
        }
        void PressRight()
        {
            _state.PressRightButton();
        }

        public void ShowLogic()
        {
            //first locked
            Console.WriteLine("State - locked");
            ChangeState(new LockedSmartphoneState());
            PressRight();
            PressLeft();

            Console.WriteLine("State - unlocked");
            PressRight();
            PressLeft();

            Console.WriteLine("State - uncharged");
            ChangeState(new UnchargedSmartphoneState());
            PressLeft();
            PressRight();
        }

    }

    abstract class SmartphoneState
    {
       private protected Smartphone smartphone;
       public void SetSmartphone(Smartphone smartphone)
       {
           this.smartphone = smartphone;
       }
       public abstract void PressLeftButton(); //switch on off
       public abstract void PressRightButton(); // audio on off
    }

    class UnlockedSmartphoneState : SmartphoneState
    {
        public override void PressLeftButton()
        {
            Console.WriteLine("State from unlocked");
            smartphone.ChangeState(new LockedSmartphoneState());
        }

        public override void PressRightButton()
        {
            Console.WriteLine("Audio was highed.");
        }
    }

    class LockedSmartphoneState : SmartphoneState
    {
        public override void PressLeftButton() //switch
        {
            Console.WriteLine("State from locked");
            smartphone.ChangeState(new UnlockedSmartphoneState());
        }

        public override void PressRightButton() //audio
        {
            Console.WriteLine("Nothing happened, smarthone locked.");
        }
    }

    class UnchargedSmartphoneState : SmartphoneState
    {
        public override void PressLeftButton()
        {
            Console.WriteLine("Smarphone uncharged. Please charge");
        }

        public override void PressRightButton()
        {
            Console.WriteLine("Smarphone uncharged. Please charge");
        }
    }

}

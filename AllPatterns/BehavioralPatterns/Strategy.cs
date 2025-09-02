using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns
{
    interface IMove //Strategy
    {
        void Move();
    }

    class ElectroMove : IMove //Concrete strategy
    {
        public void Move()
            => Console.WriteLine("Electic move");
    }
    class PetrolMove : IMove //Concrete strategy
    {
        public void Move()
            => Console.WriteLine("Petrol move");
    }

    class Car //Context
    {
        public IMove Move { get; set; }
        public Move move;
    }

    public delegate void Move();
    public static class VoidsForDelegates
    {
        public static void ElectroMove()
            => Console.WriteLine("Delegate electro move");
        public static void PetrolMove()
            => Console.WriteLine("Delegate petrol move");
    }
}

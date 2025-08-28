using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerativePatterns
{
    abstract class Coffee
    {
        protected string _name;
        
        internal string Name 
        { 
            get 
            { 
                return _name; 
            } 
        }
        
        protected Coffee(string name) => _name = name;
    }

    class Latte : Coffee 
    {
        internal Latte(string name) : base(name) { }
    }

    class Cappucino : Coffee 
    {
        internal Cappucino(string name) : base(name) { }
    }

    abstract class CoffeeMaker
    {
        internal abstract Coffee GetCoffee(string name);
    }

    class CapuccinoMaker : CoffeeMaker
    {
        internal override Coffee GetCoffee(string name)
            => new Cappucino(name);
    }
    class LatteMaker : CoffeeMaker
    {
        internal override Coffee GetCoffee(string name)
            => new Latte(name);
    }

    internal class FactoryMethod
    {
        internal void ShowLogic()
        {
            CoffeeMaker maker = new CapuccinoMaker();
            Coffee coffee = maker.GetCoffee("capuccino");
            Console.WriteLine(coffee.Name);
            maker = new LatteMaker();
            coffee = maker.GetCoffee("latte");
            Console.WriteLine(coffee.Name);
        }

    }
}

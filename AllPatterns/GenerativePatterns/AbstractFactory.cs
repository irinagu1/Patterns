using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerativePatterns
{
    //product 1
    abstract class Drink { }
    class Tea : Drink { }
    class Juice : Drink { }

    //product 2
    abstract class MainDish { }
    class Meat : MainDish { }
    class Fish : MainDish { }

    abstract class LunchComboAbstractFactory
    {
        internal abstract Drink GetDrink();
        internal abstract MainDish GetMainDish();
    }

    class SimpleComboFactory : LunchComboAbstractFactory
    {
        internal override Drink GetDrink()
            => new Tea();
        internal override MainDish GetMainDish()
            => new Meat();
    }

    class VegetarianComboFactory : LunchComboAbstractFactory
    {
        internal override Drink GetDrink()
            => new Juice();
        internal override MainDish GetMainDish()
            => new Fish();
    }


    internal class AbstractFactoryClient
    {
        Drink myDrink;
        MainDish myMainDish;
        internal void GetCombo(LunchComboAbstractFactory combo)
        {
            myDrink = combo.GetDrink();
            myMainDish = combo.GetMainDish();
            Console.WriteLine("Drink "+ myDrink.GetType().ToString() +" main dish " + myMainDish.GetType().ToString());
        }

    }
}

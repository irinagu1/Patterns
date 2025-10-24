using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns
{
    //общий интерфейс обработчиков
    //1) установка след 2) выполнение работы
   public interface IHandler
   {
        IHandler SetNext(IHandler h);
        object Do(object request);
   }

    //базовый обработчик, содержит ссылку на следующи   
    //и по желанию можно реализовать базовый метод обработки
    // - просто переход на следующий обработчик
    abstract class BaseHandler : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler next)
        {
            _nextHandler = next;
            return next;
        }

        public virtual object Do(object request)
        {
            if (_nextHandler is not null)
                return _nextHandler.Do(request);
            else
                return null;
        }
    }

    class MonkeyHandler : BaseHandler
    {
        public override object Do(object request)
        {
            if ((request as string) == "Banana")
                return "Monkey will eat banana";
            else 
                return base.Do(request);
        }
    }

    class SquirrelHandler : BaseHandler
    {
        public override object Do(object request)
        {
            if ((request as string) == "Nut")
                return "Squirrel will eat nut";
            else
                return base.Do(request);
        }
    }

    class ChainOfResponsibilityClient
    {
        public static void Logic(BaseHandler handler)
        {
            string s1 = "Nut";
            string s2 = "Banana";
            var res = handler.Do(s1);
            Console.WriteLine(res);
            res = handler.Do(s2);
            Console.WriteLine(res);
        }
    }
}

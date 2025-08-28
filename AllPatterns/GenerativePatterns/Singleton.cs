using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerativePatterns
{
    public sealed class LazySingleton
    {
        private static readonly Lazy<LazySingleton> _instance 
            = new Lazy<LazySingleton>(()=> new LazySingleton());
        public LazySingleton() { }
        public static LazySingleton Instance { get { return _instance.Value; } }
    }

    public sealed class DoubleCheckSingleton
    {
        private volatile DoubleCheckSingleton _instance;
        private object _locker = new object();
        public DoubleCheckSingleton() { }
        public DoubleCheckSingleton Instance 
        { 
            get 
            { 
                if(_instance == null)
                {
                    lock (_locker)
                    {
                        if(_instance == null)
                            _instance = new DoubleCheckSingleton();
                    }
                }
               return _instance;
            } 
        }
    }

    public sealed class StaticFiledSingleton
    {
        public static readonly StaticFiledSingleton Instance 
            = new StaticFiledSingleton();
       
    }
    
    internal class Singleton
    {
        public void ShowLogic()
        {
            var singleton = LazySingleton.Instance;
            Console.WriteLine(singleton.GetHashCode());
            var singleton2 = LazySingleton.Instance;
            Console.WriteLine(singleton2.GetHashCode());

        }
    }
}

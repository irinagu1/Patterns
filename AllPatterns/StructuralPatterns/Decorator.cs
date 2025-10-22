using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns
{
   abstract class LogSaverDecorator : ILogSaver
   {
        protected readonly ILogSaver _decoratee;
        protected LogSaverDecorator(ILogSaver decoratee)
        {
            _decoratee = decoratee;
        }
        public abstract void Save(LogEntry LogEntry);
   }

    class SomeLogSaverDecorator : LogSaverDecorator
    {
        public SomeLogSaverDecorator(ILogSaver decoratee)
            : base(decoratee) { }
        public override void Save(LogEntry LogEntry)
        {
            //added some extra logic to ordinary save method
        }
    }
}


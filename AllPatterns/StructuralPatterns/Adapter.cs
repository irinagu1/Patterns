using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns
{
    class SqlServerLogSaver
    {
        public void Save
            (DateTime dateTime, string severity, string message)
        {
        }

        public void SaveException
            (DateTime dateTime, string severity, string message)
        {
        }
    }
    class LogEntry { public string Info { get; set; } }
    class SimpleLogEntry : LogEntry {}
    class ExceptionLogEntry : LogEntry {}
    class ElasticsearchLogSaver
    {
        public void Save
          (SimpleLogEntry simpleLogEntry)
        {
        }

        public void SaveException
            (ExceptionLogEntry exceptionLogEntry)
        {
        }
    }

    interface ILogSaver
    {
        void Save(LogEntry LogEntry);
    }
    class SqlServerLogSaverAdapter : ILogSaver
    {
        private readonly SqlServerLogSaver _logSaver;
        public SqlServerLogSaverAdapter()
           => _logSaver = new SqlServerLogSaver();
        
        public void Save(LogEntry LogEntry)
        {
            //logic using _logSaver
        }
    }
    class ElasticsearchLogSaverAdapter : ILogSaver
    {
        private readonly ElasticsearchLogSaver _logSaver;
        public ElasticsearchLogSaverAdapter()
            => _logSaver = new ElasticsearchLogSaver();

        public void Save(LogEntry LogEntry)
        {
            //logic using _logSaver
        }
    }
}

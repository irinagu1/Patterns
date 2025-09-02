using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns
{
    public abstract class DocumentProcessor
    {
        public void Process()
        {
            Open();
            Parse();
            Close();
        }

        protected abstract void Open();
        protected abstract void Parse();
        protected abstract void Close();
    }
    public class PdfProcessor : DocumentProcessor
    {
        protected override void Close()
        {
            Console.WriteLine("Close pdf");
        }

        protected override void Open()
        {
            Console.WriteLine("Open pdf");
        }

        protected override void Parse()
        {
            Console.WriteLine("Parse pdf");
        }
    }

    public class ExcelProcessor : DocumentProcessor
    {
        protected override void Close()
        {
            Console.WriteLine("Close excel");
        }

        protected override void Open()
        {
            Console.WriteLine("Open excel");
        }

        protected override void Parse()
        {
            Console.WriteLine("Parse excel");
        }
    }
}

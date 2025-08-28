using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GenerativePatterns
{
    interface IPrototype
    {
        string Type { get; set; }
        int X_start { get; set; }
        int Y_start { get; set; }
        void ShowInfo() 
            => Console.WriteLine($"Type{Type}, x: {X_start}, y: {Y_start}");
        IPrototype Clone();
    }
    class Circle : IPrototype
    {
        public string Type { get; set; }
        public int X_start { get; set; }
        public int Y_start { get; set; }
        int Radius { get; set; }
        public Circle(string type, int start, int end, int radius)
        {
            Type = type;
            X_start = start;
            Y_start = end;
            Radius = radius;
        }

        public IPrototype Clone()
        {
            return new Circle(this.Type, this.X_start, this.Y_start, this.Radius);
        }
    }
    class Rectangle : IPrototype
    {
        public string Type { get; set; }
        public int X_start { get; set; }
        public int Y_start { get; set; }
        public Rectangle(string type, int start, int end)
        {
            Type = type;
            X_start = start;
            Y_start = end;
        }
        private Rectangle(Rectangle old)
        {
            Type = old.Type;
            X_start = old.X_start;
            Y_start = old.Y_start;
        }

        public IPrototype Clone()
        {
            return new Rectangle(this);
        }
    }

}

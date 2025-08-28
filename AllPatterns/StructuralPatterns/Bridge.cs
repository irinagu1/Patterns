using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns
{
    public abstract class Figure
    {
        public Color Color { get; set; }

    }
    public class Circle : Figure
    {

    }
    public abstract class Color
    {
        public abstract string Name { get; set; }
    }
    public class Green : Color
    {
        private string _name;
        public override string Name { get => _name; set =>_name= value; }
    }
    public class White : Color
    {
        private string _name;
        public override string Name { get => _name; set => _name = value; }
    }
    internal class Bridge
    {
        public void Show()
        {
            Figure figure = new Circle();
            figure.Color = new White() { Name="White"};
            Console.WriteLine(figure.Color.Name);
            figure.Color = new Green() { Name = "Green" };
            Console.WriteLine(figure.Color.Name);
        }

    }
}

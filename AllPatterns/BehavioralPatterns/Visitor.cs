namespace BehavioralPatterns
{
    public interface Visitor
    {
        void visit(ElementA a);
        void visit(ElementB b);
    }

    public class ConcreteVisitor : Visitor
    {
        public void visit(ElementA a) 
            => Console.WriteLine("Concrete visitor A");
        public void visit(ElementB b)
            => Console.WriteLine("Concrete visitor B");
    }

    public interface Element
    {
        void accept(Visitor visitor);
    }

    public class ElementA : Element
    {
        public void accept(Visitor visitor)
            => visitor.visit(this);
    }

    public class ElementB : Element
    {
        public void accept(Visitor visitor)
            => visitor.visit(this);
    }

    //example
    public interface VisitorEx
    {
        void visit(Building b);
        void visit(Park p);
    }

    public class VisitorExport : VisitorEx
    {
        public void visit(Building b)
            => Console.WriteLine("Export object building");

        public void visit(Park p)
            => Console.WriteLine("Export object park");
    }

    public interface ElementMap
    {
        void accept(VisitorEx visitor);
    }

    public class Building : ElementMap
    {
        public void accept(VisitorEx visitor)
            => visitor.visit(this);
    }

    public class Park : ElementMap
    {
        public void accept(VisitorEx visitor)
            => visitor.visit(this);
    }

    public static class ClientVisitor
    {
        public static void Logic()
        {
            List<ElementMap> elements = new List<ElementMap>()
            {
                new Building(),
                new Park(), 
                new Park(),
                new Building()
            };

            VisitorEx exportVisitor = new VisitorExport();
            foreach (var el in elements)
                el.accept(exportVisitor);
        }
    }
}

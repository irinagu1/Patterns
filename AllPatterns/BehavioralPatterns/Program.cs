using BehavioralPatterns;
using System.Reflection.Metadata;

//strategy
//interfaces
Console.WriteLine("Stategy: ");
Car car = new Car();
car.Move = new ElectroMove();
car.Move.Move();

car.Move = new PetrolMove();
car.Move.Move();
//delegates
car.move += VoidsForDelegates.PetrolMove;
car.move();
car.move -= VoidsForDelegates.PetrolMove;
car.move += VoidsForDelegates.ElectroMove;
car.move();

//templateMethod
DocumentProcessor processor = new PdfProcessor();
processor.Process();

processor = new ExcelProcessor();
processor.Process();

//mediator
Mediator m = new Mediator();
ComponentButton b = new ComponentButton(m);
ComponentTextBox tb = new ComponentTextBox(m);
b.Push();
tb.ChangeText();

//memento
OuterOriginator originator = new();
CaretakerForNested ct =
    new CaretakerForNested(originator);
ct.Do();

//state
Smartphone smartphone = new Smartphone();
smartphone.ShowLogic();

//command

//observer
Customer c1 = new Customer();
Customer c2 = new Customer();

Publisher p = new Publisher();
p.Subscribe(c1);
p.Subscribe(c2);
p.Logic("newState");
p.Logic("newState2");

//chain of resp
var monkey = new MonkeyHandler();
var sqirrel = new SquirrelHandler();

monkey.SetNext(sqirrel);
ChainOfResponsibilityClient.Logic(monkey);

Console.ReadLine();
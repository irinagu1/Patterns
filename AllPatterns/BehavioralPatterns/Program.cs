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

Console.ReadLine();
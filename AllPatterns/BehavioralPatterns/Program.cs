using BehavioralPatterns;

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
Console.ReadLine();

//templateMethod
DocumentProcessor processor = new PdfProcessor();
processor.Process();

processor = new ExcelProcessor();
processor.Process();
Console.ReadLine();

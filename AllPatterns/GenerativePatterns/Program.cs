using GenerativePatterns;

//generative 
//factory method
FactoryMethod factoryMethod = new FactoryMethod();
factoryMethod.ShowLogic();

//abstract factory
AbstractFactoryClient abstractFactory = new AbstractFactoryClient();
abstractFactory.GetCombo(new VegetarianComboFactory());
abstractFactory.GetCombo(new SimpleComboFactory());

//singleton
Singleton singleton = new Singleton();
singleton.ShowLogic();

//prototype
Rectangle rectangle = new Rectangle("rectangle", 1, 1);
IPrototype newRectangle = rectangle.Clone();
newRectangle.ShowInfo();
Circle circle= new Circle("circle", 1, 1,2);
IPrototype newCircle = circle.Clone();
newCircle.ShowInfo();

//builder
BuilderClient.Demonstrate();

Console.ReadLine();
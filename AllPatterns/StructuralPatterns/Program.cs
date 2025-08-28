using StructuralPatterns;

CompositeExample compositeExample = new();
compositeExample.Show();

Console.WriteLine("_______________________________________");

ProxyClient proxyClient = new();
proxyClient.Show();

Console.WriteLine("_______________________________________");

Bridge bridge = new Bridge();   
bridge.Show();

Console.WriteLine("_______________________________________");

FlyweightTreeFactory factory = new FlyweightTreeFactory();
factory.Show();

Console.ReadLine();

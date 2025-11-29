public class MyAttribute : Attribute { }

public class MyClass
{
    public int Id { get; set; }

    [MyAttribute]
    public string Name { get; set; }

    [MyAttribute]
    public double Value { get; set; }

    public MyClass() { }

    public MyClass(int id, string name, double value)
    {
        Id = id;
        Name = name;
        Value = value;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name}, Value: {Value}");
    }

    public int Add(int a, int b)
    {
        return a + b;
    }
}

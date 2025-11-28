using System;
using System.Reflection;

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

class Program
{
    public delegate string GameInfoDel(string gameName, int gameReleaseYear);

    static string GameInfo(string gameName, int gameReleaseYear)
    {
        string result;
        if (gameReleaseYear == 2014 || gameReleaseYear == 1998 || gameReleaseYear == 2025 || gameReleaseYear == 2007)
        {
            result = $"{gameName} released in good time";
        }
        else
        {
            result = $"{gameName} released in bad time";
        }

        return result;
    }

    static void AskGame(string gameName, int gameReleaseYear, GameInfoDel game)
    {
        string result = game(gameName, gameReleaseYear);
        System.Console.WriteLine(result);
    }

    static void AskGameFunc5(string gameName, int gameReleaseYear, Func<string, int, string> game)
    {
        string result = game(gameName, gameReleaseYear);
        System.Console.WriteLine(result);
    }

    static void AskGameFunc(string gameName, int gameReleaseYear, GameInfoDel game)
    {
        string result = game(gameName, gameReleaseYear);
        System.Console.WriteLine(result);
    }

    static void Main()
    {
        System.Console.WriteLine("Введите название игры и год её релиза");
        string gameName = Console.ReadLine();
        int gameReleaseYear = Int32.Parse(Console.ReadLine());

        System.Console.WriteLine("\nРезультат с использованием метода GameInfo:");
        GameInfoDel game = GameInfo;
        AskGame(gameName, gameReleaseYear, game);

        System.Console.WriteLine("\nРезультат с использованием лямбда-выражения:");
        AskGame(gameName, gameReleaseYear, (name, year) =>
        {
            if (year % 2 == 0) return $"{name} released in even year!";
            else return $"{name} released in odd year!";
        });

        System.Console.WriteLine("\nРезультат с использованием метода GameInfo (через Func<>):");
        AskGameFunc5(gameName, gameReleaseYear, GameInfo);

        System.Console.WriteLine("\nРезультат с использованием лямбда-выражения (через Func<>):");
        AskGameFunc5(gameName, gameReleaseYear, (name, year) =>
        {
            if (year % 2 == 0) return $"{name} released in even year!";
            else return $"{name} released in odd year!";
        });

        MyClass obj = new MyClass(1, "Example", 42.5);

        Type type = typeof(MyClass);

        for (int i = 0; i < 150; i++) System.Console.Write('=');
        System.Console.WriteLine("\nКонструкторы:");

        foreach (var ctor in type.GetConstructors())
        {
            System.Console.WriteLine(ctor);
        }

        System.Console.WriteLine("\nСвойства:");
        foreach (var prop in type.GetProperties())
        {
            System.Console.WriteLine(prop);
        }

        System.Console.WriteLine("\nМетоды:");
        foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
        {
            System.Console.WriteLine(method);
        }

        System.Console.WriteLine("\nСвойства с атрибутом MyAttribute:");
        foreach (var prop in type.GetProperties())
        {
            if (prop.GetCustomAttribute<MyAttribute>() != null)
            {
                System.Console.WriteLine(prop);
            }
        }

        System.Console.WriteLine("\nВызов метода PrintInfo с использованием рефлексии:");
        MethodInfo printMethod = type.GetMethod("PrintInfo");
        printMethod.Invoke(obj, null);

        System.Console.WriteLine("\nВызов метода Add с использованием рефлексии:");
        MethodInfo addMethod = type.GetMethod("Add");
        object result = addMethod.Invoke(obj, new object[] { 5, 3 });
        System.Console.WriteLine($"Результат: {result}");
    }
}

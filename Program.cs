using System;

public interface IPrint
{
    void Print();
}

public abstract class GeometrFigure : IPrint
{
    public abstract double Area();
    public override string ToString() => "Такой фигуры нет в программе";

    public virtual double Length
    {
        get => 0;
        set { }
    }

    public virtual double Width
    {
        get => 0;
        set { }
    }

    public virtual double Radius
    {
        get => 0;
        set { }
    }

    public virtual void Print() => System.Console.WriteLine(ToString());

    protected void Check(double val) { if (val < 0) throw new ArgumentException("Значение не может быть меньше 0"); }
}

class Rect : GeometrFigure
{

    public override double Length { get; set; }

    public override double Width { get; set; }

    public Rect(double length = 0, double width = 0)
    {
        Check(length);  Check(width);
        Length = length;
        Width = width;
    }

    public override double Area() => Length * Width;

    public override string ToString() => $"Прямоугольник: Длина = {Length}, высота = {Width}, площадь = {Area()}";

    public override void Print() => System.Console.WriteLine(ToString());
}

class Square : Rect
{
    public Square(double side = 0) : base(side, side) { }
    public override string ToString() => $"Квадрат: Сторона = {Length}, площадь = {Area()}";
}

class Circle : GeometrFigure
{
    public override double Radius { get; set; }

    public Circle(double rad = 0)
    {
        Check(rad);
        Radius = rad;
    }

    public override double Area() => Math.PI * Radius * Radius;

    public override string ToString() => $"Круг: Радиус = {Radius}, площадь = {Area()}";
}

class Program
{
    static void Main()
    {
        string next = "y";
        while (next == "y")
        {
            System.Console.WriteLine("Выберите фигуру для подсчёта площади: 1 - Прямоугольник, 2 - Квадрат, 3 - Круг");
            if (int.TryParse(Console.ReadLine(), out int choose))
            {
                switch (choose)
                {
                    case 1:
                        System.Console.Write("Длина - ");
                        double length = Convert.ToDouble(Console.ReadLine());
                        System.Console.Write("Высота - ");
                        double width = Convert.ToDouble(Console.ReadLine());
                        Rect rect = new Rect(length, width);
                        rect.Print();
                        break;
                    case 2:
                        System.Console.Write("Сторона - ");
                        double side = Convert.ToDouble(Console.ReadLine());
                        Square square = new Square(side);
                        square.Print();
                        break;
                    case 3:
                        System.Console.Write("Радиус - ");
                        double radius = Convert.ToDouble(Console.ReadLine());
                        Circle circle = new Circle(radius);
                        circle.Print();
                        break;
                }
            }
            System.Console.WriteLine("Повторим? (y/n)");
            next = Console.ReadLine();
        }
    }
}

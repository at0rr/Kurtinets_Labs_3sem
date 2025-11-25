using System;
using System.Collections;

public interface IPrint
{
    void Print();
}

class Program
{
    static void Main()
    {
        SimpleStack<double> stack = new SimpleStack<double>();
        ArrayList figures = new ArrayList();
        List<GeometrFigure> figs = new List<GeometrFigure>();
        var matrix = new SparseTensor<double>(5, 5, 5);
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
                        figures.Add(new Rect(length, width));
                        figs.Add(new Rect(length, width));
                        matrix.FillMatrix(rect.Area());
                        stack.Push(rect.Area());
                        break;
                    case 2:
                        System.Console.Write("Сторона - ");
                        double side = Convert.ToDouble(Console.ReadLine());
                        Square square = new Square(side);
                        square.Print();
                        figures.Add(new Square(side));
                        figs.Add(new Square(side));
                        matrix.FillMatrix(square.Area());
                        stack.Push(square.Area());
                        break;
                    case 3:
                        System.Console.Write("Радиус - ");
                        double radius = Convert.ToDouble(Console.ReadLine());
                        Circle circle = new Circle(radius);
                        circle.Print();
                        figures.Add(new Circle(radius));
                        figs.Add(new Circle(radius));
                        matrix.FillMatrix(circle.Area());
                        stack.Push(circle.Area());
                        break;
                }
            }
            System.Console.WriteLine("Повторим? (y/n)");
            next = Console.ReadLine();
        }

        figures.Sort();
        System.Console.WriteLine("Отсортированная коллекция ArrayList фигур: ");
        foreach (GeometrFigure i in figures)
        {
            i.Print();
        }
        figs.Sort();
        System.Console.WriteLine("Отсортированная коллекция List<Figure> фигур: ");
        foreach (GeometrFigure i in figs)
        {
            i.Print();
        }

        matrix.Print();
        stack.Print();
    }
}

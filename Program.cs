using System;

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

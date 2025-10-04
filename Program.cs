using System;

namespace project{

    class Program{

        static double IsNum()
        {
            double value;
            while (!double.TryParse(Console.ReadLine(), out value))
            {
                System.Console.WriteLine("Ошибка ввода! Введите значение заново");
            }
            return value;
        }

        static void NoSolutions()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("Решений нет");
            Console.ResetColor();
        }

        static void Main()
        {
            string repeat = "y";
            while (repeat == "y")
            {
                double a = IsNum();
                double b = IsNum();
                double c = IsNum();

                if (a == 0)
                {
                    NoSolutions();
                    continue;
                }

                double t1, t2;

                double disc = Math.Pow(b, 2) - 4 * a * c;
                if (disc < 0)
                {
                    NoSolutions();
                    continue;
                }
                else if (disc == 0)
                {
                    t1 = -b / (2 * a);
                    if (t1 < 0)
                    {
                        NoSolutions();
                        continue;
                    }

                    System.Console.Write("Корни: ");

                    if (t1 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.Write("0 ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.Write("{0} {1} ", Math.Sqrt(t1), (-Math.Sqrt(t1)));
                        Console.ResetColor();
                    }
                }
                else
                {
                    disc = Math.Sqrt(disc);
                    t1 = (-b + disc) / (2 * a);
                    t2 = (-b - disc) / (2 * a);
                    if (t1 >= 0 || t2 >= 0)
                    {
                        System.Console.Write("Корни: ");
                    }
                    if (t1 == 0 || t2 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.Write("0 ");
                        Console.ResetColor();
                    }
                    if (t1 > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.Write("{0} {1} ", Math.Sqrt(t1), (-Math.Sqrt(t1)));
                        Console.ResetColor();
                    }
                    if (t2 > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.Write("{0} {1} ", Math.Sqrt(t2), (-Math.Sqrt(t2)));
                        Console.ResetColor();
                    }
                    if (t1 < 0 && t2 < 0)
                    {
                        NoSolutions();
                    }
                }

                System.Console.WriteLine("Хотите продолжить? (y/n)");
                repeat = Console.ReadLine();
            }
        }
    }
};

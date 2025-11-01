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

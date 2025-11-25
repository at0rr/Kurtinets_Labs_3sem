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

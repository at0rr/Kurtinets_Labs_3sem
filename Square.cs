class Square : Rect
{
    public Square(double side = 0) : base(side, side) { }
    public override string ToString() => $"Квадрат: Сторона = {Length}, площадь = {Area()}";
}

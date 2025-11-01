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

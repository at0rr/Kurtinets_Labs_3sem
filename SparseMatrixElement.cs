public class SparseMatrixElement<T> : IComparable<SparseMatrixElement<T>>
{
    public int xCoord { get; set; }
    public int yCoord { get; set; }
    public int zCoord { get; set; }
    public T value { get; set; }

    public SparseMatrixElement(int coordX, int coordY, int coordZ, T value)
    {
        xCoord = coordX;
        yCoord = coordY;
        zCoord = coordZ;
        this.value = value;
    }

    public int CompareTo(SparseMatrixElement<T> other)
    {
        if (other == null) return 1;
        if (xCoord != other.xCoord) return xCoord.CompareTo(other.xCoord);
        if (yCoord != other.yCoord) return yCoord.CompareTo(other.yCoord);
        return zCoord.CompareTo(other.zCoord);
    }
}

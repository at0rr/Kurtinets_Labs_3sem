public class SparseTensor<T>
{
    private List<SparseMatrixElement<T>> data = new List<SparseMatrixElement<T>>();
    private int sizeX, sizeY, sizeZ;

    public SparseTensor(int sizeX, int sizeY, int sizeZ)
    {
        if (sizeX <= 0 || sizeY <= 0 || sizeZ <= 0)
            throw new ArgumentException("Размеры должны быть положительными");
        this.sizeX = sizeX;
        this.sizeY = sizeY;
        this.sizeZ = sizeZ;
    }

    public void AddElem(int x, int y, int z, T value)
    {
        if (x < 0 || y < 0 || z < 0 || x >= sizeX || y >= sizeY || z >= sizeZ)
            throw new ArgumentException("Введены неверные координаты");
        var newElem = new SparseMatrixElement<T>(x, y, z, value);
        var index = data.BinarySearch(newElem);

        if (index >= 0) // нашли элемент
        {
            if (value.Equals(default(T)))
            {
                data.RemoveAt(index);
            }
            else
            {
                data.RemoveAt(index);
                data.Insert(index, newElem);
            }
        }
        else // не нашли элемент
        {
            if (!value.Equals(default(T)))
            {
                int insertIndex = ~index;
                data.Insert(insertIndex, newElem);
            }
        }
    }

    public T Get(int x, int y, int z)
    {
        if (x < 0 || y < 0 || z < 0 || x >= sizeX || y >= sizeY || z >= sizeZ)
            throw new ArgumentException("Введены неверные координаты");
        var searchElem = new SparseMatrixElement<T>(x, y, z, default(T));
        int index = data.BinarySearch(searchElem);
        return index >= 0 ? data[index].value : default(T);
    }

    public int NonZeroElems => data.Count;

    public void Print()
    {
        System.Console.WriteLine($"Sparse Tensor {sizeX}, {sizeY}, {sizeZ}, ненулевых элементов {NonZeroElems}");
        foreach (var elem in data)
        {
            System.Console.WriteLine($"[{elem.xCoord}, {elem.yCoord}, {elem.zCoord}] = {elem.value}");
        }
        if (data.Count == 0)
        {
            System.Console.WriteLine("Все элементы нулевые");
        }
    }

    public void FillMatrix(T area)
    {
        int x, y, z;
        System.Console.WriteLine("Введите координаты матрицы, куда вставим площадь");
        (x, y, z) = (Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
        AddElem(x, y, z, area);
    }
}

public class SimpleList<T> : IPrint
{
    protected class Node
    {
        public T value { get; set; }
        public Node next { get; set; }

        public Node(T value)
        {
            this.value = value;
            next = null;
        }
    }

    protected Node head;
    protected int len;

    public SimpleList()
    {
        head = null;
        len = 0;
    }

    public virtual void Add(T value)
    {
        Node newNode = new Node(value);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node curr = head;
            while (curr.next != null)
            {
                curr = curr.next;
            }
            curr.next = newNode;
        }
        ++len;
    }

    public bool Remove(T delValue)
    {
        if (head == null) return false;

        if (head.value.Equals(delValue))
        {
            head = head.next;
            --len;
            return true;
        }

        Node curr = head;
        while (curr.next != null)
        {
            if (curr.next.value.Equals(delValue))
            {
                curr.next = curr.next.next;
                --len;
                return true;
            }
            curr = curr.next;
        }
        return false;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= len) throw new IndexOutOfRangeException();

        Node curr = head;
        for (int i = 0; i < index; i++)
        {
            curr = curr.next;
        }
        return curr.value;
    }

    public void Print()
    {
        Node curr = head;
        System.Console.Write($"Stack: ");
        while (curr != null)
        {
            System.Console.Write($"{curr.value} ");
            curr = curr.next;
        }
        System.Console.Write('\n');
    }
}

public class SimpleStack<T> : SimpleList<T>
{
    public void Push(T value)
    {
        Node newNode = new Node(value);
        newNode.next = head;
        head = newNode;
        ++len;
    }

    public T Pop()
    {
        if (head == null) throw new InvalidOperationException("Стек пуст");

        T delValue = head.value;
        head = head.next;
        --len;
        return delValue;
    }

    public override void Add(T value)
    {
        Push(value);
    }
}

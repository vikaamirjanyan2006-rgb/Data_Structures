using MyLinkedListProj;

namespace MyStackProj;

public class MyStack<T>
{
    private MyLinkedList<T> items;

    public MyStack()
    {
        items = new MyLinkedList<T>();
    }

    public void Push(T item)
    {
        items.AddFirst(new MyLinkedListNode<T>(item));
    }

    public T Pop()
    {
        T value = items.Head.Value;
        items.RemoveFirst();
        return value;
    }

    public T Peek()
    {
        return items.Head.Value;
    }
}
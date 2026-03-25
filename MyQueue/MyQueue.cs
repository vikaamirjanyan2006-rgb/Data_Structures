using MyLinkedListProj;
using System.Collections;

namespace MyQueue;

public class MyQueue<T> : IEnumerable<T>
{
    private MyLinkedList<T> _items = new MyLinkedList<T>();

    public int Count => _items.Count;

    public void Enqueue(T item)
    {
        _items.AddLast(new MyLinkedListNode<T>(item));
    }

    public T Dequeue()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("Queue is empty");

        T value = _items.Head.Value;
        _items.RemoveFirst();
        return value;
    }

    public T Peek()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("Queue is empty");

        return _items.Head.Value;
    }

    public void Clear() => _items.Clear();

    public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
using System.Collections;

namespace MyLinkedListProj;

public class MyLinkedList<T> : ICollection<T>
{
    public MyLinkedListNode<T> Head { get; set; }
    public MyLinkedListNode<T> Tail { get; set; }

    #region ICollection
    public int Count { get; private set; }
    public bool IsReadOnly { get => false; }

    public void Add(T item)
    {
        AddLast(new MyLinkedListNode<T>(item));
    }

    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    public bool Contains(T item)
    {
        MyLinkedListNode<T> current = Head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, item))
                return true;
            current = current.Next;
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));
        if (arrayIndex < 0)
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        if (array.Length - arrayIndex < Count)
            throw new ArgumentException();

        int index = arrayIndex;
        MyLinkedListNode<T> current = Head;
        while (current != null)
        {
            array[index++] = current.Value;
            current = current.Next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        MyLinkedListNode<T> current = Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Add
    public void AddFirst(MyLinkedListNode<T> node)
    {
        MyLinkedListNode<T> temp = Head;
        Head = node;
        Head.Next = temp;
        Count++;
        if (Count == 1)
            Tail = Head;
    }

    public void AddLast(MyLinkedListNode<T> node)
    {
        if (Head == null)
        {
            Head = node;
            Tail = node;
        }
        else
        {
            Tail.Next = node;
            Tail = node;
        }
        Count++;
    }
    #endregion

    #region Remove
    public void RemoveFirst()
    {
        Head = Head.Next;
        Count--;
        if (Head == null)
            Tail = null;
    }

    public void RemoveLast()
    {
        if (Head == Tail)
        {
            Head = Tail = null;
            Count--;
            return;
        }

        MyLinkedListNode<T> temp = Head;
        while (temp.Next != Tail)
            temp = temp.Next;

        temp.Next = null;
        Tail = temp;
        Count--;
    }
    #endregion
}
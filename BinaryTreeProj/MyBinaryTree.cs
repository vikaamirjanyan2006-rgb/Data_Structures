
using System.Collections;

namespace MyBinaryTree;

public class MyBinaryTree<T> : IEnumerable<T>
    where T : IComparable<T>
{
    private MyBinaryTreeNode<T> _root;
    private int _count;

    public int Count => _count;

    public void Add(T value)
    {
        if (_root == null)
        {
            _root = new MyBinaryTreeNode<T>(value);
            _count++;
            return;
        }

        var current = _root;

        while (true)
        {
            int comparison = value.CompareTo(current.Value);

            if (comparison < 0)
            {
                if (current.Left == null) { current.Left = new MyBinaryTreeNode<T>(value); _count++; return; }
                current = current.Left;
            }
            else if (comparison > 0)
            {
                if (current.Right == null) { current.Right = new MyBinaryTreeNode<T>(value); _count++; return; }
                current = current.Right;
            }
            else return;
        }
    }

    public bool Contains(T value)
    {
        var current = _root;

        while (current != null)
        {
            int comparison = value.CompareTo(current.Value);

            if (comparison == 0) return true;
            else if (comparison < 0) current = current.Left;
            else current = current.Right;
        }

        return false;
    }

    public bool Remove(T value)
    {
        MyBinaryTreeNode<T> parent = null;
        var current = _root;

        while (current != null)
        {
            int comparison = value.CompareTo(current.Value);

            if (comparison < 0) { parent = current; current = current.Left; }
            else if (comparison > 0) { parent = current; current = current.Right; }
            else break;
        }

        if (current == null) return false;

        if (current.Left != null && current.Right != null)
        {
            var successorParent = current;
            var successor = current.Right;

            while (successor.Left != null)
            {
                successorParent = successor;
                successor = successor.Left;
            }

            current.Value = successor.Value;
            parent = successorParent;
            current = successor;
        }

        var child = current.Left ?? current.Right;

        if (parent == null) _root = child;
        else if (parent.Left == current) parent.Left = child;
        else parent.Right = child;

        _count--;
        return true;
    }

    public IEnumerator<T> GetEnumerator() => InOrder(_root).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private static IEnumerable<T> InOrder(MyBinaryTreeNode<T> node)
    {
        if (node == null) yield break;

        foreach (var v in InOrder(node.Left)) yield return v;
        yield return node.Value;
        foreach (var v in InOrder(node.Right)) yield return v;
    }
}
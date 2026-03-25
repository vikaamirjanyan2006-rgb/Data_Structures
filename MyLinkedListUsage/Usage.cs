
using MyLinkedListProj;
using MyLinkedListProj;
using MyQueue;
using MyStackProj;
using MyStackProj;

namespace MyBinaryTree;

public class Program
{
    public static void Main(string[] args)
    {
        // Binary Tree
        MyBinaryTree<int> tree = new MyBinaryTree<int>();

        tree.Add(5);
        tree.Add(3);
        tree.Add(7);
        tree.Add(1);
        tree.Add(4);
        tree.Add(6);
        tree.Add(8);

        Console.WriteLine(tree.Count);
        Console.WriteLine(tree.Contains(4));
        Console.WriteLine(tree.Contains(9));

        foreach (int val in tree)
            Console.Write(val + " ");

        tree.Remove(3);
        Console.WriteLine(tree.Count);

        foreach (int val in tree)
            Console.Write(val + " ");

        // Queue
        MyQueue<int> queue = new MyQueue<int>();

        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        Console.WriteLine(queue.Peek());

        foreach (int item in queue)
            Console.WriteLine(item);

        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Count);

        // Stack
        MyStack<int> stack = new MyStack<int>();

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        stack.Push(5);

        Console.WriteLine($"Peek: {stack.Peek()}");
        Console.WriteLine($"Pop: {stack.Pop()}");
        Console.WriteLine($"Pop: {stack.Pop()}");
        Console.WriteLine($"Pop: {stack.Pop()}");
        Console.WriteLine($"Peek: {stack.Peek()}");
        Console.WriteLine($"Pop: {stack.Pop()}");

        // Linked List
        MyLinkedListNode<int> first = new MyLinkedListNode<int>(1);
        MyLinkedListNode<int> second = new MyLinkedListNode<int>(2);
        MyLinkedListNode<int> third = new MyLinkedListNode<int>(3);
        MyLinkedListNode<int> fourth = new MyLinkedListNode<int>(4);
        MyLinkedListNode<int> fifth = new MyLinkedListNode<int>(5);

        MyLinkedList<int> list = new MyLinkedList<int>();

        list.AddFirst(first);
        list.AddFirst(second);
        list.AddFirst(fourth);
        list.AddLast(third);
        list.AddLast(fifth);
        list.RemoveFirst();
        list.RemoveLast();

        Console.WriteLine(list.Tail.Value);


        string input = "hello world";

        Console.WriteLine(MyHash.AdditiveHash(input));
        Console.WriteLine(MyHash.MyFoldingHash(input));
        Console.WriteLine(MyHash.MyGetNextBytes(0, input));
        Console.WriteLine(MyHash.MyGetByte(input, 0));
        Console.WriteLine(MyHash.Djb2(input));

        Console.ReadKey();
    }
}
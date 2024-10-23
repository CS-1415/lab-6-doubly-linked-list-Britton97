using System;
using System.Collections.Generic;

namespace Lab06
{
    public class Class1
    {
        public void CallMe()
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public interface IDoubleEndedCollection<T>
    {
        T First { get; } //holds the first value of the list
        T Last { get; } //holds the last value of the list
        int Length { get; } //holds the length of the list
        void AddLast(T value); //adds a value to the end of the list
        void AddFirst(T value);
        void RemoveFirst();
        void RemoveLast();
        void InsertAfter(LinkedListNode<T> node, T value);
        void RemoveByValue(T value);
        void ReverseList();
    }

    public class DoublyLinkedList<T> : IDoubleEndedCollection<T>
    {
        private LinkedList<T> _list = new LinkedList<T>();

        public int Length => _list.Count;

        public T First => _list.First.Value;

        public T Last => _list.Last.Value;

        public void AddFirst(T value) //adds a value to the beginning of the list
        {
            _list.AddFirst(value);
        }

        public void AddLast(T value) //adds a value to the end of the list
        {
            _list.AddLast(value);
        }

        public void RemoveFirst() //removes the first value of the list
        {
            _list.RemoveFirst();
        }

        public void RemoveLast() //removes the last value of the list
        {
            _list.RemoveLast();
        }

        public void InsertAfter(LinkedListNode<T> node, T value) //inserts a value after a given node
        {
            _list.AddAfter(node, value);
        }

        public void RemoveByValue(T value) //removes a value from the list by value
        {
            _list.Remove(value);
        }

        public void ReverseList() //reverses the list
        {
            var node = _list.First;
            var stack = new Stack<T>();

            while (node != null)
            {
                stack.Push(node.Value);
                node = node.Next;
            }

            _list.Clear();

            while (stack.Count > 0)
            {
                _list.AddLast(stack.Pop());
            }
        }
    }
}
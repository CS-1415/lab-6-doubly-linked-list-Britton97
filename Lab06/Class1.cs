using System;
using System.Collections;
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

    public class DoublyLinkedListNode<T>
    {
        public T Value { get; set; } //holds the value of the node
        public DoublyLinkedListNode<T>? Next { get; set; } //holds the next node of the list
        public DoublyLinkedListNode<T>? Previous { get; set; } //holds the previous node of the list

        public DoublyLinkedListNode(T value) //constructor of the class
        {
            Value = value;
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
    public class LinkedListEnumerator<T> : IEnumerator<T>
    {
        private readonly DoublyLinkedListNode<T> _firstNode; //holds the first node of the list
        private DoublyLinkedListNode<T>? _currentNode; //holds the current node of the list

        public LinkedListEnumerator(DoublyLinkedListNode<T> firstNode) //constructor of the class. It takes the first node of the list as a parameter and assigns it to the _firstNode field. It also sets the _currentNode field to null.
        {
            _firstNode = firstNode;
            _currentNode = null;
        }

        public T Current => _currentNode!.Value; //returns the private _currentNode field’s value

        object IEnumerator.Current => Current; //returns the private _currentNode field’s value

        public bool MoveNext() //moves to the next node of the list
        {
            if (_currentNode == null) //if the _currentNode field is null, it is set to the _firstNode field and the method returns true
            {
                _currentNode = _firstNode; //the _currentNode field is set to the _firstNode field
            }
            else //if the _currentNode field is not null, it is set to the next node and the method returns true
            {
                _currentNode = _currentNode.Next; //the _currentNode field is set to the next node
            }
            return _currentNode != null; //returns true if the _currentNode field is not null
        }

        public void Reset() //resets the enumerator
        {
            _currentNode = null; //the _currentNode field is set to null
        }

        public void Dispose()
        {
            // No resources to dispose
        }
    }

    public class DoublyLinkedList<T> : IDoubleEndedCollection<T>, IEnumerable<T>
    {
        private DoublyLinkedListNode<T>? _head; //holds the first node of the list
        private DoublyLinkedListNode<T>? _tail; //holds the last node of the list
        private int _count;

        public int Length => _count;
        public T First => _head != null ? _head.Value : throw new InvalidOperationException("The list is empty."); //holds the first value of the list. It returns the value of the _head field.
        public T Last => _tail != null ? _tail.Value : throw new InvalidOperationException("The list is empty."); //holds the last value of the list. It returns the value of the _tail field.

        public void AddFirst(T value)//adds a value to the beginning of the list
        {
            var newNode = new DoublyLinkedListNode<T>(value); //creates a new node with the given value
            if (_head == null) //if the list is empty
            {
                _head = _tail = newNode; //the _head and _tail fields are set to the new node
            }
            else
            { //if the list is not empty
                newNode.Next = _head; //the new node’s Next field is set to the current head
                _head.Previous = newNode; //the current head’s Previous field is set to the new node
                _head = newNode; //the _head field is set to the new node
            }
            _count++; //the length of the list is incremented
        }

        public void AddLast(T value) //adds a value to the end of the list
        {
            var newNode = new DoublyLinkedListNode<T>(value); //creates a new node with the given value
            if (_tail == null) //if the list is empty
            {
                _head = _tail = newNode; //the _head and _tail fields are set to the new node
            }
            else
            {
                newNode.Previous = _tail; //the new node’s Previous field is set to the current tail
                _tail.Next = newNode; //the current tail’s Next field is set to the new node
                _tail = newNode; //the _tail field is set to the new node
            }
            _count++; //the length of the list is incremented
        }

        public void RemoveFirst() //removes the first value of the list
        {
            if (_head == null) return; //if the list is empty, the method returns
            if (_head == _tail) //if the list has only one node
            {
                _head = _tail = null; //the _head and _tail fields are set to null
            }
            else //if the list has more than one node
            {
                _head = _head.Next; //the _head field is set to the current head’s Next field
                if (_head != null)
                {
                    _head.Previous = null; //the new head’s Previous field is set to null
                }
            }
            _count--; //the length of the list is decremented
        }

        public void RemoveLast() //removes the last value of the list
        {
            if (_tail == null) return; //if the list is empty, the method returns
            if (_head == _tail) //if the list has only one node
            {
                _head = _tail = null; //the _head and _tail fields are set to null
            }
            else //if the list has more than one node
            {
                _tail = _tail.Previous; //the _tail field is set to the current tail’s Previous field
                if (_tail != null)
                {
                    _tail.Next = null; //the new tail’s Next field is set to null
                }
            }
            _count--; //the length of the list is decremented
        }

        public void InsertAfter(DoublyLinkedListNode<T> node, T value) //inserts a value after the given node
        {
            if (node == null) return; //if the given node is null, the method returns
            var newNode = new DoublyLinkedListNode<T>(value); //creates a new node with the given value
            newNode.Next = node.Next; //the new node’s Next field is set to the given node’s Next field
            newNode.Previous = node; //the new node’s Previous field is set to the given node
            if (node.Next != null) //if the given node’s Next field is not null
            {
                node.Next.Previous = newNode; //the given node’s Next field’s Previous field is set to the new node
            }
            node.Next = newNode; //the given node’s Next field is set to the new node
            if (node == _tail) //if the given node is the tail
            {
                _tail = newNode; //the _tail field is set to the new node
            }
            _count++; //the length of the list is incremented
        }

        public void RemoveByValue(T value) //removes the first occurrence of the given value from the list
        {
            var current = _head; //starts from the head
            while (current != null) //iterates through the list while the current node is not null
            {
                if (current.Value != null && current.Value.Equals(value)) //if the current node’s value is equal to the given value
                {
                    if (current == _head) //if the current node is the head
                    {
                        RemoveFirst(); //removes the first node
                    }
                    else if (current == _tail) //if the current node is the tail
                    {
                        RemoveLast(); //removes the last node
                    }
                    else //if the current node is neither the head nor the tail
                    {
                        if (current.Previous != null)
                        {
                            current.Previous.Next = current.Next; //the current node’s Previous field’s Next field is set to the current node’s Next field
                        }
                        if (current.Next != null)
                        {
                            current.Next.Previous = current.Previous; //the current node’s Next field’s Previous field is set to the current node’s Previous field
                        }
                        _count--; //the length of the list is decremented
                    }
                    return; //the method returns
                }
                current = current.Next; //the current node is set to the next node
            }
        }

        public void ReverseList() //reverses the list
        {
            var current = _head; //starts from the head
            DoublyLinkedListNode<T>? temp = null; //creates a temporary node
            while (current != null) //iterates through the list while the current node is not null
            {
                temp = current.Previous; //the temporary node is set to the current node’s Previous field 
                current.Previous = current.Next; //the current node’s Previous field is set to the current node’s Next field
                current.Next = temp; //the current node’s Next field is set to the temporary node
                current = current.Previous; //the current node is set to the current node’s Previous field
            }
            if (temp != null) //if the temporary node is not null
            {
                _head = temp.Previous; //the _head field is set to the temporary node’s Previous field
            }
        }

        public IEnumerator<T> GetEnumerator() //returns an enumerator that iterates through the list
        {
            if (_head == null)
            {
                throw new InvalidOperationException("The list is empty.");
            }
            return new LinkedListEnumerator<T>(_head); //returns a new instance of the LinkedListEnumerator class with the _head field as a parameter
        }

        IEnumerator IEnumerable.GetEnumerator() //returns an enumerator that iterates through the list
        {
            return GetEnumerator(); //returns the result of the GetEnumerator method
        }

        public void InsertAfter(LinkedListNode<T> node, T value) //inserts a value after the given node
        {
            throw new NotImplementedException(); //throws a NotImplementedException
        }
    }
}
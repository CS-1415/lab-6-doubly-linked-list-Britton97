using NUnit.Framework;
using Lab06;

namespace Lab06.Tests
{
    public class LinkedListStartingWithOneAtBackTests
    {
        private DoublyLinkedList<int> _list;

        [SetUp]
        public void Setup()
        {
            _list = new DoublyLinkedList<int>();
            _list.AddLast(1);
        }

        [Test]
        public void SingleAddLastWorks()
        {
            _list.AddLast(2);
            Assert.That(_list.Length, Is.EqualTo(2));
        }

        [Test]
        public void SingleAddFirstWorks()
        {
            _list.AddFirst(0);
            Assert.That(_list.Length, Is.EqualTo(2));
        }

        [Test]
        public void SingleRemoveLastWorks()
        {
            _list.RemoveLast();
            Assert.That(_list.Length, Is.EqualTo(0));
        }

        [Test]
        public void SingleRemoveFirstWorks()
        {
            _list.RemoveFirst();
            Assert.That(_list.Length, Is.EqualTo(0));
        }
    }
}
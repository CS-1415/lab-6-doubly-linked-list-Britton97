using NUnit.Framework;
using Lab06;

namespace Lab06.Tests
{
    public class LinkedListStartingEmptyTests
    {
        private DoublyLinkedList<int> _list;

        [SetUp]
        public void Setup()
        {
            _list = new DoublyLinkedList<int>();
        }

        [Test]
        public void HasCorrectLength()
        {
            Assert.That(_list.Length, Is.EqualTo(0));
        }

        [Test]
        public void SingleAddLastWorks()
        {
            _list.AddLast(1);
            Assert.That(_list.Length, Is.EqualTo(1));
        }

        [Test]
        public void SingleAddFirstWorks()
        {
            _list.AddFirst(1);
            Assert.That(_list.Length, Is.EqualTo(1));
        }
    }
}
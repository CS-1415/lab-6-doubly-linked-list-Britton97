using NUnit.Framework;
using Lab06;

namespace Lab06.Tests
{
    public class LinkedListStartingWithThreeTests
    {
        private DoublyLinkedList<int> _list;

        [SetUp]
        public void Setup()
        {
            _list = new DoublyLinkedList<int>();
            _list.AddLast(1);
            _list.AddLast(2);
            _list.AddLast(3);
        }

        [Test]
        public void ReverseSuccessfullyReversesTheOrderOfTheList()
        {
            _list.ReverseList();
            Assert.That(_list.First, Is.EqualTo(3));
            Assert.That(_list.Last, Is.EqualTo(1));
        }
    }
}
using NUnit.Framework;
using Lab06;
namespace Lab06.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine("Test 1");
            //Class1 c = new Class1();
            //c.CallMe();
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            Assert.That(list.Length, Is.EqualTo(0));
        }

        [Test]
        public void Test3()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddLast(1);
            Assert.That(list.Length, Is.EqualTo(1));
        }

        [Test]
        public void Test4()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddFirst(1);
            Assert.That(list.Length, Is.EqualTo(1));
        }
    }
}
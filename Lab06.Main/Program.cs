// See https://aka.ms/new-console-template for more information
using System;
using Lab06;

namespace Lab06.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            Console.WriteLine("Enter numbers to add to the list. Press Escape to end.");

            while (true)
            {
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }

                if (char.IsDigit(key.KeyChar))
                {
                    int value = int.Parse(key.KeyChar.ToString());
                    list.AddLast(value);
                    Console.WriteLine($"\nAdded {value} to the list.");
                }
                else
                {
                    Console.WriteLine("\nPlease enter a valid digit.");
                }
            }

            Console.WriteLine("\nFinal list:");
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
        }
    }
}
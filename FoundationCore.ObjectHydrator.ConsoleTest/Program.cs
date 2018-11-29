using System;
using System.Collections.Generic;

namespace FoundationCore.ObjectHydrator.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var hydrator = new Hydrator<SimpleCustomer>();
            var customers = hydrator.GetList(5);
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.FirstName);
            }
            Console.ReadLine();
        }
    }
}

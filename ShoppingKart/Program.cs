using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingKart
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter list of shopping items in single line without spaces.");
            var shopping = Console.ReadLine().TrimEnd().Select(x => x.ToString().ToUpper()).ToArray();
            var totalPrice = new Checkout(new Repository.Repository()).GetTotalPrice(shopping);
            Console.WriteLine($"Total shopping cost is {totalPrice}");
        }
    }
}

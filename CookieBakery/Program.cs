using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CookieBakery.Models;

namespace CookieBakery
{
    class Program
    {
        static void Main(string[] args)
        {
            // Builds a bakery from the ground up using plywood and..
            // or just initialize it!
            var bakery = new Bakery(15);

            // Employees are all set, let's open.
            bakery.OpenBakery();

            // The bakery needs customers, say hello
            // to Ted, Fred and Greg
            var ted = new Person("Ted", bakery);
            var fred = new Person("Fred", bakery);
            var greg = new Person("Greg", bakery);

            // They're eager for cookies so go ahead chaps!
            ted.StartGrabbing();
            fred.StartGrabbing();
            greg.StartGrabbing();

            // If we don't put a Read or ReadLine here
            // we'll never know the end of this story.
            Console.Read();
        }
    }
}

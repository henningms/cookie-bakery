using System;
using System.Threading;

namespace CookieBakery.Models
{
    /// <summary>
    /// Person
    /// 
    /// Class representing a cookie monster (person)
    /// </summary>
    public class Person
    {
        private const int TimeToWaitForNextAttempt = 1000;
        private readonly Thread _thread;

        public String Name { get; set; }
        private Bakery Bakery { get; set; }
        
        /// <summary>
        /// A new customer has entered.
        /// 
        /// </summary>
        /// <param name="name">Name of person</param>
        /// <param name="bakery">What bakery did he or she enter</param>
        public Person(String name, Bakery bakery)
        {
            Name = name;
            Bakery = bakery;
            _thread = new Thread(Grab);
        }

        /// <summary>
        /// The Cookie Monster is all settled, let's start
        /// grabbing some cookies
        /// </summary>
        public void StartGrabbing()
        {
            _thread.Start();
        }

        /// <summary>
        /// Simulates the person going up to the counter
        /// and asking for a cookie. If there's some available we
        /// ask to see if we can buy it. If not, then wait a second
        /// or leave the shop.
        /// </summary>
        private void Grab()
        {
            while (Bakery.HasCookiesToGrab())
            {
                Bakery.SellCookieTo(this);
                Thread.Sleep(TimeToWaitForNextAttempt);
            }

            // Shoot, there's no cookies left!
            Console.WriteLine("\t\t\t\t{0}: No more cookies!?? I'm outta here!", Name);
        }

        /// <summary>
        /// There was a cookie available for grabs and
        /// we just received it!
        /// </summary>
        /// <param name="cookie"></param>
        public void ReceiveCookie(Cookie cookie)
        {
            Console.WriteLine("\t\t\t\t{0} received cookie {1}", Name, cookie.Number);
        }
    }
}

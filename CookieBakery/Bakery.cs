using System;
using System.Collections.Generic;
using System.Threading;
using CookieBakery.Models;

namespace CookieBakery
{
    /// <summary>
    /// Bakery
    /// 
    /// Simulates a cookie bakery
    /// </summary>
    public class Bakery
    {
        private readonly Object _synchronizationObject = new object();
        private const int TimeToBake = 667;

        private Queue<Cookie> Cookies { get; set; }

        private int CookiesToProduce { get; set; }
        private int CookiesProduced { get; set; }

        /// <summary>
        /// Initializes our bakery and equips it with ovens and employees.
        /// Just kidding.
        /// </summary>
        /// <param name="totalCookies">How many cookies are expected to be baked a day</param>
        public Bakery(int totalCookies)
        {
            CookiesToProduce = totalCookies;
            CookiesProduced = 0;

            Cookies = new Queue<Cookie>();
        }

        /// <summary>
        /// Opens our bakery and starts producing cookies.
        /// 
        /// </summary>
        public void OpenBakery()
        {
            // Creates a new thread using a lambda expression
            // which simulates a cookie being baked per 'TimeToBake'
            var t = new Thread(() =>
                                   {
                                       for (var i = 0; i < CookiesToProduce; i++)
                                       {
                                           Thread.Sleep(TimeToBake);
                                           CookieBaked();
                                       }
                                   });

            // Starts the oven!
            t.Start();
        }

        /// <summary>
        /// A cookie has been baked so lets put it
        /// on the counter and try to sell it.
        /// 
        /// Synchronized method so that our "plate" doesn't
        /// get altered from different threads at the same time
        /// </summary>
        private void CookieBaked()
        {
            lock (_synchronizationObject)
            {
                var nr = CookiesProduced++;

                Cookies.Enqueue(Cookie.CreateRandomFlavoredCookie(nr));
                Console.WriteLine("Bakery made cookie #" + nr);
            }
        }

        /// <summary>
        /// Helper method for checking if there's any cookies up for grabs
        /// or in the oven soon ready for consuming!
        /// </summary>
        /// <returns>True if there's cookies available or in the oven. False if the bakery is all out.</returns>
        public bool HasCookiesToGrab()
        {
            return ((CookiesProduced < CookiesToProduce) || Cookies.Count > 0);
        }

        /// <summary>
        /// A person wants to buy a cookie. Checks to see if there's any
        /// available and sells it to the specified customer
        /// 
        /// Synchronized method so that our "plate" doesn't
        /// get altered from different threads at the same time.
        /// </summary>
        /// <param name="customer">Person that wants to buy a cookie</param>
        public void SellCookieTo(Person customer)
        {
            lock (_synchronizationObject)
            {
                if (Cookies.Count > 0)
                {
                    customer.ReceiveCookie(Cookies.Dequeue());
                }
            }
        }
    }
}

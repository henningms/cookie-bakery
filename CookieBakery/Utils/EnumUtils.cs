using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookieBakery.Utils
{
    public class EnumUtils
    {
        private static readonly Random Random = new Random();

        public static T RandomEnumValue<T>()
        {
            var values = Enum.GetValues(typeof (T));

            var randomIndex = Random.Next(values.Length);

            return (T) values.GetValue(randomIndex);
        }
    }
}

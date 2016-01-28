using CookieBakery.Models.Enumerations;
using CookieBakery.Utils;

namespace CookieBakery.Models
{
    /// <summary>
    /// Cookie
    /// 
    /// Class representing a live cookie of some kind of flavor!
    /// </summary>
    public class Cookie
    {
        /// <summary>
        /// The Cookie holds what number it came out of the bakery as! This
        /// does not apply to the real life
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// What type of flavor the cookie is
        /// </summary>
        public CookieFlavor Flavor { get; set; }

        /// <summary>
        /// Creates our new cookie, with no flavor
        /// </summary>
        /// <param name="number"></param>
        public Cookie(int number)
        {
            Number = number;
        }

        /// <summary>
        /// Creates our cookie with some magnificent flavor!
        /// </summary>
        /// <param name="number"></param>
        /// <param name="flavor"></param>
        public Cookie(int number, CookieFlavor flavor)
        {
            Number = number;
            Flavor = flavor;
        }

        /// <summary>
        /// Easily create a new cookie with a random flavor!
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Cookie CreateRandomFlavoredCookie(int number)
        {
            return new Cookie(number, EnumUtils.RandomEnumValue<CookieFlavor>());
        }
    }
}

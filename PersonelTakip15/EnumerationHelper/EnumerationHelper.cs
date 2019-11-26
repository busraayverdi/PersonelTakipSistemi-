using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace PersonelTakip15.EnumerationHelper
{
    public static class EnumerationHelper

    {

        public static string GetDescription<TEnum>(this TEnum value)

        {

            var fi = value.GetType().GetField(value.ToString());



            if (fi != null)

            {

                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);



                if (attributes.Length > 0)

                {

                    return attributes[0].Description;

                }

            }



            return value.ToString();

        }

        public static IEnumerable<T> GetAllValues<T>()

        {

            return System.Enum.GetValues(typeof(T)).Cast<T>();

        }

    }
}
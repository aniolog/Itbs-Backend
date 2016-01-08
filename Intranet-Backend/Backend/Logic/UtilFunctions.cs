using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace Backend.Logic
{
    public class UtilFunctions
    {
        static public string NameToFormat(string name) {
            var returner = "";
            for (int letter=0;letter<name.Length;letter++) {
                if (letter != 0)
                {
                    returner = returner + Char.ToLower(name[letter]);
                }
                else {
                    returner = returner + name[letter];
                }
            }
            return returner;
        }

        static public string DateTimeFormat(DateTime date) {

            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            return date.ToLongDateString();

        }
    }
}
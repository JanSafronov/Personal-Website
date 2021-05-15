using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Text.RegularExpressions;

namespace Personal_Website.Back_End.Security
{
    public class Formatting
    {
        public static bool contactFormat(string name, string message, string email = null)
        {
            Regex npat = new Regex(@"^\w{1,50}$");
            Regex mpat = new Regex(@"\w*[']?\w*\s");

            bool b = npat.IsMatch(name) && mpat.IsMatch(message);

            if (email != null)
            {
                Regex epat = new Regex(@"^\w+[@]$");

                b = b && epat.IsMatch(email);
            }

            name = Regex.Replace(name, "'", "\'");

            return b;
        }
    }
}

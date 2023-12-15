using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ladashopq
{
    public class tests
    {
        public static bool ValidatedUser(string Login, string Password)
        {
            if (Login == null || Password == null)
                return false;
            else if (Password == "qwe" && Login == "qwe") return true;
            else return false;
        }
        public static bool ValidateBack(bool click)
        {
            if (click == true)
            {
                return true;
            }
            return false;
        }

        public static bool Tovar(string ProductName)
        {

            if (ProductName == "Вал") return true;
           
            else return false;
        }

        public static bool ValidateValue(string value)
        {
            if (!int.TryParse(value, out var result))
                return false;
            else return true;
        }

    }
}

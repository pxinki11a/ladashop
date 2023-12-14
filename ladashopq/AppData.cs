using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ladashopq
{

    public enum TableName
    {
        Tovars,
        Categories,
        Role,
        Models,
        Users,
        Providers
    }

    internal class AppData
    {
        public static asEntities db = new asEntities();

        public static Frame frameAuth;

        public static int UserID;

        public static Users CurrentUser;

    }
}

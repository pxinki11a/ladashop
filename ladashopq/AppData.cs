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
        Categories,
        Providers,
        Role,
        Tovar,
        Users
    }

    internal class AppData
    {
        public static autoshopdbEntities db = new autoshopdbEntities();

        public static Frame frameAuth;

        public static int UserID;

    }
}

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
        public static autoshopdbEntities3 db = new autoshopdbEntities3();

        public static Frame frameAuth;

        public static int UserID;

    }
}

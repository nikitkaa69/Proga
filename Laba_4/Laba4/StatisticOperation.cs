using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4
{
    static class StatisticOperations
    {

        public static void DotAfterWord(this Set set)
        {
            int len = set.GetSize();
            HashSet<string> res = new HashSet<string>();
            string buf = "";
            for (int i = 0; i < len; i++)
            {
                buf = set.GetItemByIndex(i);
                res.Add(buf + ".");
            }
            set.collection = res;
        }

        public static void RemoveSpace(this Set set)
        {
            set.collection.Remove("");
        }
    }
}

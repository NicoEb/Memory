using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    public static class Fonction
    {
        public static int Additionne(int x, int y)
        {
            return x + y;
        }
        public static int Multiplie(int x, int y)
        {
            return x * y;
        }
        public static double Divise(int x, int y)
        {
            if (y == 0)
            {
                throw new Exception("impossible de diviser par 0");
            }
            return x / y;
        }
    }
}

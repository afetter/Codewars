using System;
namespace Others
{
    public static class Kanguru
    {
        public static string kangaroo(int x1, int v1, int x2, int v2)
        {
            if (x2 > x1 && v2 >= v1)
                return "NO";

            if (x2 == x1 || x2 + v2 == v1 + v2)
                return "YES";

            while (x2 < x1)
            {
                x2 += v2;
                x1 += v1;
                if (x2 == x1)
                    return "YES";
            }
            return "NO";
        }
    }
}

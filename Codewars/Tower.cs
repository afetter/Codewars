using System;
namespace Codewars
{
    /// <summary>
    /// Build Tower by the following given argument:
    /// number of floors(integer and always greater than 0).
    /// </summary>
    /// <param name="nFloors"></param>
    /// <returns>
    /// [
    /// '  *  ', 
    /// ' *** ', 
    /// '*****'
    /// </returns>
    public static class Tower
    {
        public static string[] TowerBuilder(int nFloors)
        {
            var result = new string[nFloors];
            var odd = 1;
            var lenght = 1;
            for (int i = 0; i < nFloors - 1; i++)
            {
                lenght += 2;
            }

            for (int i = 0; i < nFloors; i++)
            {
                var s = "*".PadLeft(odd, '*');
                var mid = (lenght - s.Length) / 2;
                result[i] = $"{"".PadLeft(mid, ' ')}{s}{"".PadRight(mid, ' ')}";
                odd += 2;
            }

            return result;
        }
    }
}

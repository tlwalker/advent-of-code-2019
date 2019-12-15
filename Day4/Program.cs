using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Number of Viable Passwords: {Part1(382345, 843167)}");
            Console.WriteLine();

        }

        static int Part1(int start, int end)
        {
            var passwordFinder = new PasswordFinder(start, end);
            return passwordFinder.FindViablePasswords().Count();
        }
    }

    public class PasswordFinder
    {
        private readonly int _start;
        private readonly int _end;

        public PasswordFinder(int start, int end)
        {
            _start = start;
            _end = end;
        }

        public IEnumerable<int> FindViablePasswords()
        {
            var viablePasswords = Enumerable.Range(_start, _end - _start);
            var passwordsWithDoubles = viablePasswords.Where(HasDoubles);
            var passwordWithEverIncreasingDigits = passwordsWithDoubles.Where(DigitNeverDecreases);
            return new List<int>(passwordWithEverIncreasingDigits);
        }

        private bool DigitNeverDecreases(int value)
        {
            var s = new string(value.ToString().OrderBy(c => c).ToArray());
            return int.Parse(s) == value;
        }

        private bool HasDoubles(int value)
        {
            var s = value.ToString();
            for (var i = 0; i < s.Length - 1; i++)
            {
                var digit = s[i];
                var adjacentDupes = s[i..].TakeWhile(x => x == digit);
                var count = adjacentDupes.Count();
                if ( count == 2)
                {
                    return true;
                }

                i = i + count - 1;
            }

            return false;
        }
    }

}

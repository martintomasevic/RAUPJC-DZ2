using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = new[] { 1, 2, 2, 2, 3, 3, 4, 5 };
            
            string broj = "Broj ";
            string ponavlja = " ponavlja se ";
            string puta = " puta";
            string[] strings = integers.GroupBy(i => i).Select(i => broj + i.Key + ponavlja + i.Count() + puta).ToArray();
                               
            foreach (string i in strings)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
            // strings [0] = Broj 1 ponavlja se 1 puta
            // strings [1] = Broj 2 ponavlja se 3 puta
            // strings [2] = Broj 3 ponavlja se 2 puta
            // strings [3] = Broj 4 ponavlja se 1 puta
            // strings [4] = Broj 5 ponavlja se 1 puta
        }
    }
}

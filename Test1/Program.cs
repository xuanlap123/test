using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>() { 2, 3, 1, 4, 6, 9, 7, 8, 10, 7 };
            var n = list.Count();

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (list[i] < list[j])
                    {           
                        var tg = list[i];
                        list[i] = list[j];
                        list[j] = tg;
                    }
                }
            }
            int findNumber = 0;
            for (int i = n - 2; i >= 0; i--)
            {
                if (list[i] + 1 != list[i-1])
                {
                    findNumber = list[i] + 1;
                    break;
                }
            }

            Console.WriteLine(findNumber);

        }
    }
}

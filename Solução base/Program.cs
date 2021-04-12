using System;
using System.Linq;

namespace tp_torneio
{
    class Program
    {
        static void Main(string[] args)
        {


            int N = int.Parse(Console.ReadLine());
            int K = int.Parse(Console.ReadLine());
            int[] pi = new int[N];
            int[] ei = new int[N];
            int p = 0;
            int e = 0;
            for (int i = 0; i < (N*2); i++)
            {
                if (i % 2 == 0)
                {
                    ei[e] = int.Parse(Console.ReadLine());
                    e++;
                }
                else {
                    pi[p] = int.Parse(Console.ReadLine());
                    p++;
                }
            }
            ei = ei.OrderByDescending(i => i).ToArray();
            pi = pi.OrderByDescending(i => i).ToArray();
            int result = 0;
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(pi[i] + " pi");
                Console.WriteLine(ei[i] + " ei");
                result += pi[i] - ei[i]; 
            }
            if (result < 0) {
                result = -1;
            }
            Console.WriteLine(result + "resultado");
            Console.ReadKey();
        }
    }
}

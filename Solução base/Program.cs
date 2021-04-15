using System.Numerics;
using System;
using System.Linq;
using System.Collections.Generic;

namespace tp_torneio
{
    class Program
    {
        static void Main(string[] args)
        {
            //TESTE LUCAS
            var n = 5;
            var k = 2;
            var srcOriginal = new List<int[]> { new int[] { 2, 10, 0 },
                                        new int[] { 2, 10, 0 },
                                        new int[] { 1, 1, 0 },
                                        new int[] { 3, 1, 0 },
                                        new int[] { 3, 1, 0 }};
            srcOriginal = srcOriginal.OrderByDescending(x => x[0]).ThenBy(x => x[1]).ToList();
            int index = 0;
            int edInicial = 0;
            var ed = new int[] { 0, edInicial, -1 };
            var src = new List<int[]>();
            do
            {
                src.Remove(ed);
                if (index == 0)
                {
                    ed = new int[] { 0, edInicial, -1 };
                    src = new List<int[]> { new int[] { 2, 10, 0 },
                                        new int[] { 2, 10, 0 },
                                        new int[] { 1, 1, 0 },
                                        new int[] { 3, 1, 0 },
                                        new int[] { 3, 1, 0 }};
                    src = src.OrderByDescending(x => x[0]).ThenBy(x => x[1]).ToList();
                }
                if (ed[1] == 0 || index == n)
                {
                    AddPontos(src, index);
                    src.Add(ed);
                    if (!ObjetivoCompleto(src, k))
                    {
                        src.Remove(ed);
                        edInicial += src[index][1];
                        index = 0;
                    }
                    else break;
                }
                else
                {
                    if (ed[1] >= src[index][1])
                    {
                        ++ed[0];
                        ed[1] -= src[index][1];
                    }
                    else
                    {
                        ++src[index][0];
                        ++src[index][2];
                    }
                    ++index;
                }
            } while (index < n);

            Console.WriteLine($"Objetivo completo com {edInicial} de mínimo de esforço!");
            Console.WriteLine("Placar: ");
            //fim TESTE LUCAS

            /*
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
            Console.WriteLine(result + "resultado");*/
            Console.ReadKey();
        }

        private static bool ObjetivoCompleto(List<int[]> src, int k)
        {
            var src2 = src.OrderByDescending(x => x[0]).ThenBy(x => x[2]).ToList();
            var sad = src2.IndexOf(src2.First(x => x[2] == -1));
            if (sad <= k-1)
                return true;
            else return false;
        }

        private static void AddPontos(List<int[]> src, int index)
        {
            for (int i = index; i < src.Count; ++i)
            {
                ++src[i][0];
                ++src[i][2];
            }
        }
    }
}

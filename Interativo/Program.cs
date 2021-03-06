using System.Numerics;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace tp_torneio
{
    class Program
    {
        static void Main(string[] args)
        {
            //O(N)
            var ns = new int[] { 2, 5, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 1000, 10000, 100000 };
            foreach (int n in ns)
            {
                Console.WriteLine($"Programa iniciado com {n} participantes!");
                Iterativa(n);
                Console.WriteLine("Pressione qualquer tecla para executar o próximo N!\n");
                Console.ReadKey();
            }
            Random rnd = new Random();           
        }

        private static void Iterativa(int n)
        {
            //O(NlogN)
            Random rnd = new Random();
            Stopwatch stopWatch = new Stopwatch();
            
            int k = rnd.Next(1, n + 1);
            var srcOriginal = GerarPlacar(n);
            int index = 0;
            long edInicial = 0;
            var ducan = new long[] { 0, edInicial, 1, -1 };
            var src = new List<long[]>();
            bool completed = false;

            ImprimirInicio(srcOriginal, k);

            stopWatch.Start();

            do
            {
                src.Remove(ducan);
           
                if (index == 0)
                {
                    ducan = new long[] { 0, edInicial, 1, -1 };
                    src = ClonarLista(srcOriginal);
                }
            
                if (ducan[1] == 0 || index == n+1)
                {
                    AddPontos(src, index);
                    src.Add(ducan);
                    var final = new List<long[]>();
                    
                    if (!ObjetivoCompleto(src, k, out final))
                    {
                        src.Remove(ducan);
                        if (index < n)
                            edInicial += src[index][1];
                        else break;
                        index = 0;
                    }
                    else
                    {
                        completed = true;
                        ImprimirObjetivoCompleto(edInicial, final);
                        break;
                    }
                }
                else
                {

                    if (ducan[1] >= src[index][1])
                    {
                        ++ducan[0];
                        ducan[1] -= src[index][1];
                    }
                    else
                    {
                        ++src[index][0];
                        ++src[index][2];
                    }
                    ++index;
                }
            } while (index < n+1);

            stopWatch.Stop();

            ImprimirFinal(n, k, stopWatch, completed);
        }

        private static bool ObjetivoCompleto(List<long[]> src, long k, out List<long[]> ord)
        {
            //O(1)
            var ordenado = src.OrderByDescending(x => x[0]).ThenByDescending(x => x[2]).ToList();
            var index = ordenado.IndexOf(ordenado.First(x => x[3] == -1));
            if (index <= k - 1)
            {
                ord = ordenado;
                return true;
            }
            else
            {
                ord = src;
                return false;
            }
        }

        private static void AddPontos(List<long[]> src, int index)
        {
            //O(N)
            for (int i = index; i < src.Count; ++i)
            {
                ++src[i][0];
                ++src[i][2];
            }
        }

        private static List<long[]> ClonarLista(List<long[]> src)
        {
            //O(1)
            return src.Select(item => (long[])item.Clone()).ToList();
        }

        private static void ImprimirMatriz(List<long[]> src)
        {
            //O(N²)
            foreach (long[] array in src)
            {
                for(long i = 0; i < 2; i++)
                    Console.Write(array[i] + "\t\t" + (array[i+2] == -1 ? "<- Ducan\t" : ""));
                Console.WriteLine();
            }
        }

        private static void ImprimirObjetivoCompleto(long edInicial, List<long[]> final)
        {
            //O(1)
            Console.WriteLine($"Objetivo completo com {edInicial} de mínimo de esforço!");
            Console.WriteLine("Placar: ");
            Console.WriteLine("Pontuação\tEsforço");
            final = final.Select(x => {
                if (x[3] == -1) x[1] = edInicial; return x;
            }).ToList();
            ImprimirMatriz(final);
        }

        private static void ImprimirInicio(List<long[]> srcOriginal, long k)
        {
            //O(1)
            Console.WriteLine("Placar inicial");
            Console.WriteLine("Pontuação\tEsforço");
            ImprimirMatriz(srcOriginal);
            Console.WriteLine($"Objetivo de Ducan: {k}");
        }

        private static List<long[]> GerarPlacar(int n)
        {
           //O(N)
            Random rnd = new Random();
            var src = new List<long[]>();
            for(int i = 0; i < n; ++i)
                src.Add(new long[] { rnd.Next(0, (n+2)), rnd.Next(0, 100000), 0, -2 });
            return src.OrderByDescending(x => x[0]).ThenBy(x => x[1]).ToList(); ;
        }

        private static void ImprimirFinal(int n, int k, Stopwatch stopWatch, bool completed)
        {
            //O(1)
            Console.WriteLine($"Tempo de Execução com {n} participantes com o objetivo de estar em {k}º lugar: " + stopWatch.Elapsed);
            if (!completed)
                Console.WriteLine("Esforço: -1");
        }
    }
}

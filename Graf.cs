using System;
using System.Collections.Generic;

namespace CircleList
{
    
    class Graf
    {
        // количество вершин
        const int n = 4;
        // количество связей
        const int m = 5;
        // вспомогательный список обработанных вершин
        static bool[] visited;
        // смежности
        static int[,] graphSM = new int[n,n] {
        /*1*/         { 0, 1, 0, 1 },
        /*2*/         { 1, 0, 1, 1 },
        /*3*/         { 0, 1, 0, 1 },
        /*4*/         { 1, 1, 1, 0 }
        };

        static int[,] graphI = new int[n, m] {
                //      a  b  c  d  e          
        /*1*/         { 1, 1, 0, 0, 0 },
        /*2*/         { 1, 0, 1, 1, 0 },
        /*3*/         { 0, 0, 0, 1, 1 },
        /*4*/         { 0, 1, 1, 0, 1 }
        };




        static void Main(string[] args)
        {
            // задать стартовую вершину(аналог корневой вершины при обходе дерева).
            int index = 3;

            visited = new bool[n];
            DfsSM(index - 1);
            Console.WriteLine();

            //visited = new bool[n];
            //BfsSM(index - 1);
            //Console.WriteLine();

            visited = new bool[n];
            DfsI(index - 1);
            Console.WriteLine();

            //visited = new bool[n];
            //BfsI(index - 1);
            //Console.WriteLine();

            Console.Read();
        }

        ////////////////////////смежности

        //Поиск в глубину (англ. Depth-first search, DFS) для смежностей  -- рекурсивно
        static void DfsSM(int vertex)
        {
            //обработать стартовую вершину
            Console.Write(vertex + 1 + " ");
            //паметить как обработанную
            visited[vertex] = true;

            for (int i = 0; i < n; i++)
            {
                //повторить для всех смежных с vertex, которые еще необработаны
                if ((graphSM[vertex, i] != 0) && (!visited[i]))
                {
                    DfsSM(i);
                }
            }
        }

        //Поиск в ширину (англ. breadth-first search, BFS)  для смежностей
        static void BfsSM(int vertex)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(vertex);

            Console.Write(vertex + 1 + " ");
            visited[vertex] = true;

            while (queue.Count != 0)
            {
                int pointer = queue.Dequeue();
                // проходимся по всем смежным вершинам
                for (int i = 0; i < n; i++)
                {
                    if ((graphSM[pointer, i] != 0) && (!visited[i]))
                    {
                        Console.Write(i + 1 + " ");
                        // если вершина не была обработана ранее, то добавляем ее
                        queue.Enqueue(i);
                        visited[i] = true;
                    }
                }
            }
        }

        ////////////////////////инциндентности


        //Поиск в глубину (англ. Depth-first search, DFS) для инциндентностей
        static void DfsI(int vertex)
        {
            //обработать стартовую вершину
            Console.Write(vertex + 1 + " ");
            //паметить как обработанную
            visited[vertex] = true;

            for (int i = 0; i < n; i++)
            {
                // находим инциндетное ребро
                if (graphI[vertex, i] != 0)
                {
                    int temp = 0;
                    // находим инциндентную по ребру вершину
                    while (graphI[temp, i] != 1 || vertex == temp)
                    {
                        temp++;
                    }
                    if (!visited[temp])
                    {
                        DfsI(temp);
                    }
                }
            }
        }

        //Поиск в ширину (англ. breadth-first search, BFS)   для инциндентностей
        static void BfsI(int vertex)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(vertex);

            Console.Write(vertex + 1 + " ");
            visited[vertex] = true;

            while (queue.Count != 0)
            {
                int pointer = queue.Dequeue();
                for (int i = 0; i < m; i++)
                {
                    // находим инциндетное ребро
                    if (graphI[pointer, i] != 0)
                    {
                        int temp = 0;
                        // находим инциндентную по ребру вершину
                        while (graphI[temp, i] != 1 || pointer == temp)
                        {
                            temp++;
                        }
                        if (!visited[temp])
                        {
                            Console.Write(temp + 1 + " ");
                            queue.Enqueue(temp);
                            visited[temp] = true;
                        }
                    }
                }
            }

        }
    }
}

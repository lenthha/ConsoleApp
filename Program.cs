using System;
using System.Collections.Generic;

class Program
{
    const int MAX = 100;
    static int temp;
    static int[] col = new int[MAX];
    static int[,] matrix = new int[MAX, MAX];

    static void DFS(int v)
    {
        if (col[v] != 0)
        {
            return;
        }
        col[v] = 1;
        for (int i = 0; i < temp; ++i)
        {
            if (matrix[v, i] != 0)
            {
                DFS(i);
            }
        }
        col[v] = 2;
    }

    static void Main()
    {
        int c;
        string[] input = Console.ReadLine().Split();
        temp = int.Parse(input[0]);
        c = int.Parse(input[1]);

        for (int i = 0; i < c; ++i)
        {
            input = Console.ReadLine().Split();
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            matrix[a - 1, b - 1] = 1;
            matrix[b - 1, a - 1] = 1;
        }

        int counter = 0;
        for (int i = 0; i < temp; ++i)
        {
            if (col[i] == 0)
            {
                counter++;
                DFS(i);
            }
        }
        Console.WriteLine(counter);
    }
}

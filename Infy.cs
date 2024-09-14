
using System;

public class Infy
{
    public static void Partition(int n)
    {
        int count = 0; // Variable to keep track of the count of partitions
        Partition(n, n, "", ref count);
        Console.WriteLine($"\nTotal Partitions: {count}"); // 
    }
    public static void Partition(int n, int max, string answer, ref int count)
    {
        if (n == 0)
        {
            System.Console.WriteLine(answer.Substring(1));
            count++;
            return;
        }

        for (int i = Math.Min(max, n); i >= 1; i--)
        {
            Partition(n - i, i, answer + "+" + i, ref count);
        }
    }
    public static void Main(string[] args)
    {
        Partition(4);
    }

}
using System;
using System.Collections.Generic;

class TwoSum
{
    public static List<Tuple<int, int>> FindAllTwoSum(List<int> list, int sum)
    {
        Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
        List<Tuple<int, int>> result = new List<Tuple<int, int>>();

        for (int i = 0; i < list.Count; i++)
        {
            int complement = sum - list[i];
            if (map.ContainsKey(complement))
            {
                foreach (int index in map[complement])
                {
                    result.Add(Tuple.Create(index, i));
                }
            }

            if (!map.ContainsKey(list[i]))
            {
                map[list[i]] = new List<int>();
            }
            map[list[i]].Add(i);
        }

        return result;
    }

    public static void Main(string[] args)
    {
        List<Tuple<int, int>> indices = FindAllTwoSum(new List<int>() { 3, 1, 5, 7, 5, 9 }, 10);
        if (indices.Count > 0)
        {
            foreach (var pair in indices)
            {
                Console.WriteLine(pair.Item1 + " " + pair.Item2);
            }
        }
        else
        {
            Console.WriteLine("No two sum solution found");
        }
    }
}

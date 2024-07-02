using System;

public class Program
{
    public static void Main(string[] args)
    {
        int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7 }; // Corrected array initialization
        int k = 3;

        var result = RotateArray(nums, k);
        foreach (int i in result)
        {
            Console.Write(i + " "); // Changed to write on the same line
        }
    }

    public static int[] RotateArray(int[] nums, int k)
    {
        int length = nums.Length;
        int[] rotatedArray = new int[length];

        // Normalize k to ensure it's within the bounds of the array length
        k = k % length;

        for (int i = 0; i < length; i++)
        {
            rotatedArray[(i + k) % length] = nums[i];
        }

        return rotatedArray;
    }
}

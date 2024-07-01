public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }

        int i = 0;

        for (int j = 1; j < nums.Length; j++)
        {
            if (nums[j] != nums[i])
            {
                i++;
                nums[i] = nums[j];
            }
        }

        return i + 1;
    }

    /*    public static void Main(string[] args)
        {
            int[] nums = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            Solution solution = new Solution();
            int k = solution.RemoveDuplicates(nums);

            Console.WriteLine("Number of unique elements: " + k); // Output: 5
            Console.WriteLine("Modified array: ");
            for (int i = 0; i < k; i++)
            {
                Console.Write(nums[i] + " ");
            }
            // Output: 0 1 2 3 4
        }*/
}
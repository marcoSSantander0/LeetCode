using System;
using System.Formats.Asn1;

//Problem: 

/* Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

You can return the answer in any order. */


class Program
{
    static void Main(string[] args)
    {
        Solutions solutions = new Solutions();

        int[] nums = { 2, 7, 11, 15 };
        int target = 9;
        int[] result = solutions.TwoSum(nums, target);
        Console.WriteLine($"The result of my solution is: [{result[0]}, {result[1]}]");
        result = solutions.BestTwoSum(nums, target);
        Console.WriteLine($"The result of the best solution is: [{result[0]}, {result[1]}]");
    }
}

public class Solutions {
    //My solution
    public int[] TwoSum(int[] nums, int target) {
        for(int i = 0; i < nums.Length; i++){
            for(int j = 0; j < nums.Length; j++){
                if(i == j) break;
                if(nums[j] == target - nums[i]){
                    return [i, j];
                }
            }
        }
        return new int[]{};
    }

    //Best solution by Otabek
    public int[] BestTwoSum(int[] nums, int target) 
    {
        Dictionary<int, int> numMap = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if (numMap.ContainsKey(complement)){
                return new int[] { numMap[complement], i};
            }
            numMap[nums[i]] = i;
        }
        return new int[]{};
    }  
}

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        int[] indices = new int[2];
        bool IsFound = false;
        // Nested Loop: 
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if ((nums[i] + nums[j]) == target)
                {
                    indices[0] = i;
                    indices[1] = j;
                    IsFound = true;
                    break;
                }
            }
            if (IsFound)
                break;
            else
                continue;
        }
        return indices;
    }
}
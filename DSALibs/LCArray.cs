public class LCArray
{
        public void SortColors(int[] nums) {
            int leftBoundary = 0;
            int rightBoundary = nums.Length -1;

            int i=0;

            while(i<nums.Length && i<=rightBoundary)
            {
                if(nums[i] == 2)
                {
                    var temp = nums[i];
                    nums[i] = nums[rightBoundary];
                    nums[rightBoundary] = temp;
                    rightBoundary--;
                }
                else if(nums[i] == 0)
                {
                    var temp = nums[i];
                    nums[i] = nums[leftBoundary];
                    nums[leftBoundary] = temp;
                    leftBoundary++;
                    i++;
                }
                else
                {
                    i++;
                }
            }
        
    }
   
}
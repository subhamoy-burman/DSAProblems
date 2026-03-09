public class LCArray
{
    public void SortColors(int[] nums)
    {
        int leftBoundary = 0;
        int rightBoundary = nums.Length - 1;

        int i = 0;

        while (i < nums.Length && i <= rightBoundary)
        {
            if (nums[i] == 2)
            {
                var temp = nums[i];
                nums[i] = nums[rightBoundary];
                nums[rightBoundary] = temp;
                rightBoundary--;
            }
            else if (nums[i] == 0)
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

    public List<Tuple<int, int>> MergeIntervals(List<Tuple<int, int>> intervals)
    {
        var result = new List<Tuple<int, int>>();
        intervals.Sort((a, b) => a.Item1.CompareTo(b.Item1));

        result.Add(intervals[0]);

        for (int i = 1; i < intervals.Count; i++)
        {
            if (intervals[i].Item1 <= result[result.Count - 1].Item2)
            {
                var temp = result[result.Count - 1].Item1;
                result[result.Count - 1] = new Tuple<int, int>(temp, Math.Max(result[result.Count - 1].Item2, intervals[i].Item2));
            }
            else
            {
                result.Add(intervals[i]);
            }
        }
        return result;
    }

}
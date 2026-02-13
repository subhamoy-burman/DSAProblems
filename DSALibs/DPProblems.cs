using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALibs
{
    public static class DPProblems
    {

        /// <summary>
        /// This is wrong implementation
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static int EditDistance(string str1, string str2)
        {
            var strArr1 = str1.ToArray();
            Array.Sort(strArr1);

            var strArr2 = str2.ToArray();
            Array.Sort(strArr2);
            return EditDistanceFunc(strArr1, strArr2, 0, 0);
        }

        private static int EditDistanceFunc(char[] str1, char[] str2, int index1, int index2)
        {
            if (index1 >= str1.Length && index2 >= str2.Length)
            {
                return 0;
            }

            if (index1 < str1.Length && index2 < str2.Length)
            {
                if (str1[index1] == str2[index2])
                {
                    return EditDistanceFunc(str1, str2, index1 + 1, index2 + 1);
                }
                else
                {
                    return 1 + EditDistanceFunc(str1, str2, index1 + 1, index2 + 1);
                }
            }

            if (index1 < str1.Length)
            {
                return 1 + EditDistanceFunc(str1, str2, index1 + 1, index2);
            }
            else
            {
                return 1 + EditDistanceFunc(str1, str2, index1, index2 + 1);
            }
        }

        public static int EditDistanceImplementation(string str1, string str2)
        {
            return EditDistanceImplementationFunc(str1, str2, str1.Length, str2.Length);
        }

        private static int EditDistanceImplementationFunc(string str1, string str2, int index1, int index2)
        {
            if(index2 == 0)
                return index1;
            if(index1 == 0)
                return index2;

            if (str1[index1 - 1] == str2[index2 - 1])
            {
                return EditDistanceImplementationFunc(str1, str2, index1 - 1, index2 - 1);
            }
            else
            {
                return
                    Math.Min(
                        1 + EditDistanceImplementationFunc(str1, str2, index1 - 1, index2 - 1), // Replace
                            Math.Min(1 + EditDistanceImplementationFunc(str1, str2, index1 - 1, index2), // Delete
                                    1 + EditDistanceImplementationFunc(str1, str2, index1, index2 - 2))); //Insert
            }
        }
    
        //Recursive solution to find the length
        public static int FindLongestCommonSubsequece(string str1, string str2)
        {
            return FindLCSFunc(str1, str2, str1.Length - 1, str2.Length - 1);
        }

        private static int FindLCSFunc(string str1, string str2, int i, int j)
        {
            if(i<0 || j<0)
            {
                return 0;
            }

            if (str1[i] == str2[j])
            {
                return 1 + FindLCSFunc(str1, str2, i - 1, j - 1);
            }
            else 
            {
                return Math.Max(FindLCSFunc(str1, str2, i - 1, j),
                    FindLCSFunc(str1, str2, i, j - 1));
            }
        }

        static Tuple<int, List<int>> Knapsack(List<Tuple<int, int>> items, int index, int remainingCapacity)
        {
            // Base case: no items left
            if (index < 0)
            {
                return Tuple.Create(0, new List<int>());
            }

            var (value, weight) = items[index];

            // Option 1: Try taking the current item
            Tuple<int, List<int>> takeResult = null;
            if (weight <= remainingCapacity)
            {
                takeResult = Knapsack(items, index - 1, remainingCapacity - weight);

                // Add current item's value and index
                int totalValueIfTaken = takeResult.Item1 + value;
                var updatedList = new List<int>(takeResult.Item2) { index };

                takeResult = Tuple.Create(totalValueIfTaken, updatedList);
            }

            // Option 2: Skip the current item
            var skipResult = Knapsack(items, index - 1, remainingCapacity);

            // Choose the better option
            if (takeResult == null || skipResult.Item1 > takeResult.Item1)
            {
                return skipResult;
            }
            else
            {
                return takeResult;
            }
        }

        // Wrong impmentation
        public static List<int> BuildLIS(int currIndex, int prevIndex, List<int> listOfNumbers, List<int> maxLisSoFar, int[] arr)
        {
            if (currIndex >= arr.Length)
            {
                // Compare current list with maxLisSoFar before returning
                return listOfNumbers.Count > maxLisSoFar.Count ? listOfNumbers : maxLisSoFar;
            }

            List<int> pick = new List<int>();
            List<int> dontPick;

            // Option 1: Pick current element if it's strictly increasing
            if (prevIndex == -1 || arr[currIndex] > arr[prevIndex])
            {
                listOfNumbers.Add(arr[currIndex]);
                List<int> newList = new List<int>(listOfNumbers);
                pick = BuildLIS(currIndex + 1, currIndex, newList, maxLisSoFar, arr);
            }
            else
            {
                pick = new List<int>(listOfNumbers); // fallback
            }

            // Option 2: Don't pick current element
            dontPick = BuildLIS(currIndex + 1, prevIndex, new List<int>(listOfNumbers), maxLisSoFar, arr);

            // Choose better of the two options
            List<int> betterOption = pick.Count > dontPick.Count ? pick : dontPick;
            return betterOption;
        }

        public static int MaxProfitSellingFeeBasedStock(int[] stockPrices, int fee)
        {
            Debug.WriteLine("=== Stock Trading with Transaction Fee ===");
            Debug.WriteLine($"Prices: [{string.Join(", ", stockPrices)}]");
            Debug.WriteLine($"Transaction Fee: {fee}");
            Debug.WriteLine("==========================================\n");
            
            int result = RecMaxProfitSellingFeeBasedStock(0, true, stockPrices, fee, 0);
            
            Debug.WriteLine($"\n=== Final Maximum Profit: {result} ===\n");
            return result;
        }

        private static int RecMaxProfitSellingFeeBasedStock(int index, bool isBuyFlag, int[] stockPrices, int fee, int depth)
        {
            string indent = new string(' ', depth * 2);
            string state = isBuyFlag ? "BUY" : "SELL";
            
            Debug.WriteLine($"{indent}┌─ Day {index} | State: {state} | Price: {(index < stockPrices.Length ? stockPrices[index].ToString() : "N/A")}");
            
            if(index >= stockPrices.Length)
            {
                Debug.WriteLine($"{indent}└─ Base case reached → Return 0\n");
                return 0;
            }

            if(isBuyFlag)
            {
                Debug.WriteLine($"{indent}│  Evaluating BUY decisions:");
                Debug.WriteLine($"{indent}│  → Option 1: BUY at {stockPrices[index]} (cost: -{stockPrices[index]})");
                
                var pickingToBuy = - stockPrices[index] + RecMaxProfitSellingFeeBasedStock(index + 1, false, stockPrices, fee, depth + 1);
                
                Debug.WriteLine($"{indent}│  → Option 2: SKIP buying");
                var skippingToBuy = RecMaxProfitSellingFeeBasedStock(index + 1, true, stockPrices, fee, depth + 1);

                var maxProfit = Math.Max(pickingToBuy, skippingToBuy);
                string decision = pickingToBuy > skippingToBuy ? $"BUY at {stockPrices[index]}" : "SKIP";
                
                Debug.WriteLine($"{indent}│  PickBuy: {pickingToBuy} vs SkipBuy: {skippingToBuy}");
                Debug.WriteLine($"{indent}└─ Decision: {decision} → Profit: {maxProfit}\n");
                
                return maxProfit;
            }
            else
            {
                Debug.WriteLine($"{indent}│  Evaluating SELL decisions:");
                Debug.WriteLine($"{indent}│  → Option 1: SELL at {stockPrices[index]} (gain: {stockPrices[index]} - fee: {fee})");
                
                var pickingToSale = stockPrices[index] + RecMaxProfitSellingFeeBasedStock(index + 1, true, stockPrices, fee, depth + 1) - fee;
                
                Debug.WriteLine($"{indent}│  → Option 2: SKIP selling (hold position)");
                var skippingToSale = RecMaxProfitSellingFeeBasedStock(index + 1, false, stockPrices, fee, depth + 1);

                var maxProfit = Math.Max(pickingToSale, skippingToSale);
                string decision = pickingToSale > skippingToSale ? $"SELL at {stockPrices[index]}" : "HOLD";
                
                Debug.WriteLine($"{indent}│  PickSell: {pickingToSale} vs SkipSell: {skippingToSale}");
                Debug.WriteLine($"{indent}└─ Decision: {decision} → Profit: {maxProfit}\n");
                
                return maxProfit;
            }
        }

        public static int MaxProfitSellingFeeBasedStockBottomUp(int[] stockPrices, int fee)
        {
            if (stockPrices.Length == 0)
                return 0;

            Debug.WriteLine("=== Bottom-Up DP: Stock Trading with Transaction Fee ===");
            Debug.WriteLine($"Prices: [{string.Join(", ", stockPrices)}]");
            Debug.WriteLine($"Transaction Fee: {fee}");
            Debug.WriteLine("=========================================================\n");

            int n = stockPrices.Length;
            int[,] dp = new int[n, 2];
            
            // Base case: Day 0
            dp[0, 0] = 0;
            dp[0, 1] = -stockPrices[0];
            
            Debug.WriteLine("┌─────────────────────────────────────────────────────────────────┐");
            Debug.WriteLine("│ DP Table Legend:                                                │");
            Debug.WriteLine("│ dp[i][0] = Max profit at day i ready to BUY (no stock held)    │");
            Debug.WriteLine("│ dp[i][1] = Max profit at day i ready to SELL (stock held)      │");
            Debug.WriteLine("└─────────────────────────────────────────────────────────────────┘\n");

            Debug.WriteLine($"BASE CASE (Day 0, Price: {stockPrices[0]}):");
            Debug.WriteLine($"  dp[0][0] = 0           (No action taken)");
            Debug.WriteLine($"  dp[0][1] = -{stockPrices[0]}         (Bought stock at {stockPrices[0]})");
            Debug.WriteLine($"  Table: [{dp[0, 0]:D2}][{dp[0, 1]:D3}]\n");
            Debug.WriteLine("─────────────────────────────────────────────────────────────────\n");

            // Build up from day 1 to day n-1
            for (int i = 1; i < n; i++)
            {
                Debug.WriteLine($"DAY {i} | Price: {stockPrices[i]}");
                Debug.WriteLine("───────────────────────────────────────────────────────");
                
                // State 0: Ready to BUY (no stock held)
                int skipBuy = dp[i - 1, 0];
                int sellToday = dp[i - 1, 1] + stockPrices[i] - fee;
                dp[i, 0] = Math.Max(skipBuy, sellToday);
                
                Debug.WriteLine($"  State [0] - Ready to BUY (no stock):");
                Debug.WriteLine($"    Option A: Skip (stay ready to buy)     = dp[{i-1}][0] = {skipBuy}");
                Debug.WriteLine($"    Option B: SELL today                   = dp[{i-1}][1] + {stockPrices[i]} - {fee} = {dp[i - 1, 1]} + {stockPrices[i]} - {fee} = {sellToday}");
                Debug.WriteLine($"    ✓ BEST: dp[{i}][0] = Max({skipBuy}, {sellToday}) = {dp[i, 0]}");
                
                // State 1: Ready to SELL (stock held)
                int holdStock = dp[i - 1, 1];
                int buyToday = dp[i - 1, 0] - stockPrices[i];
                dp[i, 1] = Math.Max(holdStock, buyToday);
                
                Debug.WriteLine($"\n  State [1] - Ready to SELL (holding stock):");
                Debug.WriteLine($"    Option A: HOLD (keep stock)            = dp[{i-1}][1] = {holdStock}");
                Debug.WriteLine($"    Option B: BUY today                    = dp[{i-1}][0] - {stockPrices[i]} = {dp[i - 1, 0]} - {stockPrices[i]} = {buyToday}");
                Debug.WriteLine($"    ✓ BEST: dp[{i}][1] = Max({holdStock}, {buyToday}) = {dp[i, 1]}");
                
                // Show current DP table row
                Debug.WriteLine($"\n  📊 DP Table Row {i}: [{dp[i, 0]:D2}][{dp[i, 1]:D3}]");
                Debug.WriteLine("");
            }

            Debug.WriteLine("═════════════════════════════════════════════════════════════════");
            Debug.WriteLine("FINAL DP TABLE:");
            Debug.WriteLine("─────────────────────────────────────────────────────────────────");
            Debug.WriteLine("Day | Price |  [0] No Stock  | [1] Holding Stock");
            Debug.WriteLine("─────────────────────────────────────────────────────────────────");
            for (int i = 0; i < n; i++)
            {
                Debug.WriteLine($" {i,2} |  {stockPrices[i],3}  |      {dp[i, 0],3}       |       {dp[i, 1],4}");
            }
            Debug.WriteLine("─────────────────────────────────────────────────────────────────");
            Debug.WriteLine($"\n✓ FINAL ANSWER: dp[{n-1}][0] = {dp[n - 1, 0]}");
            Debug.WriteLine("  (Maximum profit when we end with no stock held)\n");

            return dp[n - 1, 0];
        }
    
        public static int LongestIncreaingSubsequence(int[] arr)
        {
            Debug.WriteLine("=== Longest Increasing Subsequence (Recursive) ===");
            Debug.WriteLine($"Array: [{string.Join(", ", arr)}]");
            Debug.WriteLine("==================================================\n");
            
            int result = FuncLongestIncreaingSubsequence(0, arr, -1, 0);
            
            Debug.WriteLine($"\n=== Final LIS Length: {result} ===\n");
            return result;
        }

        private static int FuncLongestIncreaingSubsequence(int index, int[] arr, int lastElement, int depth)
        {
            string indent = new string(' ', depth * 2);
            string lastElementStr = lastElement == -1 ? "NONE" : lastElement.ToString();
            
            Debug.WriteLine($"{indent}┌─ Index {index} | LastElement: {lastElementStr} | Current: {(index < arr.Length ? arr[index].ToString() : "N/A")}");
            
            if(index >= arr.Length)
            {
                Debug.WriteLine($"{indent}└─ Base case: End of array → Return 0\n");
                return 0;
            }

            if(arr[index] > lastElement)
            {
                Debug.WriteLine($"{indent}│  {arr[index]} > {lastElementStr} → Can PICK or DON'T PICK");
                Debug.WriteLine($"{indent}│  → Option 1: PICK {arr[index]} (add 1 to length)");
                
                var pick = 1 + FuncLongestIncreaingSubsequence(index + 1, arr, arr[index], depth + 1);
                
                Debug.WriteLine($"{indent}│  → Option 2: DON'T PICK {arr[index]} (skip this element)");
                var dontPick = FuncLongestIncreaingSubsequence(index + 1, arr, lastElement, depth + 1);

                var maxLength = Math.Max(pick, dontPick);
                string decision = pick > dontPick ? $"PICK {arr[index]}" : $"SKIP {arr[index]}";
                
                Debug.WriteLine($"{indent}│  Pick: {pick} vs DontPick: {dontPick}");
                Debug.WriteLine($"{indent}└─ Decision: {decision} → Length: {maxLength}\n");
                
                return maxLength;
            }
            else
            {
                Debug.WriteLine($"{indent}│  {arr[index]} <= {lastElementStr} → Cannot pick (would break increasing order)");
                Debug.WriteLine($"{indent}│  → Only option: SKIP {arr[index]}");
                
                var result = FuncLongestIncreaingSubsequence(index + 1, arr, lastElement, depth + 1);
                
                Debug.WriteLine($"{indent}└─ Forced SKIP → Length: {result}\n");
                
                return result;
            }
            
        }
    
        public static List<int> LongestDivisibleSubset(int[] arr)
        {
            List<List<int>> result = new List<List<int>>();
            List<int> subSet = new List<int>();
            FuncLongestDivisibleSubset(arr, 0, result, subSet);
            return result.OrderByDescending(x => x.Count).First();
        }

        private static void FuncLongestDivisibleSubset(int[] arr, int index, List<List<int>> result, List<int> subset)
        {
            if(index >= arr.Length)
            {
                result.Add([.. subset]);
                return;
            }

            if(subset.Count == 0 || arr[index] % subset.Last() == 0)
            {  
                subset.Add(arr[index]);
                FuncLongestDivisibleSubset(arr, index + 1, result, subset);
                subset.RemoveAt(subset.Count - 1);
            }
            FuncLongestDivisibleSubset(arr, index + 1, result, subset);
            
        }
    }
}

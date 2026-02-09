# Lecture: From Recursion to Memoization using Longest Increasing Subsequence (LIS)

**Target Audience:** College fresh graduates  
**Duration:** 45-50 minutes  
**Running Example:** `arr = [1, 3, 2, 4]`  
**Teaching Style:** Socratic questioning → Answer → Visual demonstration

---

## Part A — Hook + Problem Restatement (1 min)

### Opening Story

**Say to students:**

> "Imagine you're tracking daily temperatures over a week: [1°C, 3°C, 2°C, 4°C]. You want to find the longest stretch of days where temperature kept increasing — but the days don't have to be consecutive! You could pick day 1 (1°C) → day 2 (3°C) → day 4 (4°C). That's a length of 3."

**Problem Definition:**

Given an array of integers, find the **length** of the longest subsequence where each element is strictly greater than the previous one.

- Subsequence: we can skip elements, but must maintain order
- Strictly increasing: each picked element must be > last picked element

**Example:** `[1, 3, 2, 4]`  
- One possible LIS: `[1, 3, 4]` → length = 3
- Another: `[1, 2, 4]` → length = 3
- Not valid: `[1, 3, 2]` → 2 < 3, breaks increasing order

**Set Expectations:**

> "Today we'll solve this using recursion first. Then we'll notice something wasteful happening. Then we'll add memory to make it efficient. By the end, you'll write the memoized solution yourself."

---

## Part B — Build Recursion from First Principles (5-7 min)

### Socratic Build-up

**Ask students:**

> "Let's think element by element. I'm standing at index 0, looking at element `1`. What choices do I have?"

**Wait for answers, then confirm:**

- **Choice 1:** PICK element 1
- **Choice 2:** DON'T PICK element 1 (maybe a better sequence starts later)

**Ask:**

> "If I decide to PICK element 1, what happens next?"

**Guide to answer:**

- Move to next index (index 1)
- Remember that I picked 1 (it becomes the "last picked element")
- At index 1, I can only pick element 3 if 3 > 1 ✓

**Ask:**

> "If I DON'T PICK element 1, what happens?"

**Answer:**

- Move to index 1
- Still remember nothing was picked yet (last = NONE)
- At index 1, I'm free to pick element 3

### The Recursive Insight

**Point to board:**

> "So at EVERY index, we try both paths and take the maximum. This is a classic pick/don't-pick recursion."

### Function Signature

**Ask:**

> "What information do I need to pass down in recursion to make decisions?"

**Wait, then reveal:**

```
Solve(index, lastPickedElement)
    → Returns: maximum LIS length from index onwards
```

**But ask immediately:**

> "Wait — what if I pass `lastPickedElement` as the actual VALUE? Like `Solve(1, 1)` meaning 'at index 1, last picked value was 1'. Could there be a problem?"

**Guide to problem:**

- What if array has duplicates or large numbers?
- The "last value" could be anything from -∞ to +∞
- Hard to memoize (infinite possible values)

**Reveal the fix:**

> "Instead, pass the INDEX of last picked element. We call it `prevIndex`."

### Corrected Signature

```
Solve(index, prevIndex)
    → Returns: maximum LIS length from 'index' onwards
    → prevIndex = index of last picked element (or -1 if NONE)
```

**Ask:**

> "How many possible values can prevIndex take?"

**Answer:**

- prevIndex ∈ {-1, 0, 1, 2, ..., n-1}
- That's only n+1 values — BOUNDED!
- This makes memoization possible.

### Base Case

**Ask:**

> "What happens when index reaches the end of array?"

**Answer:**

```
if (index >= arr.Length)
    return 0;  // no more elements to pick
```

### Recursive Logic Outline

```csharp
Solve(index, prevIndex):
    // Base case
    if (index >= n)
        return 0
    
    // Can we pick arr[index]?
    canPick = (prevIndex == -1) OR (arr[index] > arr[prevIndex])
    
    if (canPick):
        pick = 1 + Solve(index+1, index)     // pick it, gain +1 length
        dontPick = Solve(index+1, prevIndex) // skip it
        return Max(pick, dontPick)
    else:
        return Solve(index+1, prevIndex)     // forced to skip
```

---

## Part C — Draw Recursion Tree (with example) (7-10 min)

### Setting Up the Trace

**Say:**

> "Let's trace the recursion for `arr = [1, 3, 2, 4]`. I'll show a SNAPSHOT — not the entire tree (it's exponential), but enough to see the pattern."

**Notation for nodes:**

```
[ (index, prevIndex) ] → state
```

### Recursion Tree Snapshot (ASCII)

```
                       [Start: (0, -1)]
                       "index=0, prev=NONE"
                              |
                 +------------+------------+
                 |                         |
              PICK 1                   DON'T PICK 1
           (add +1, prev=0)            (prev stays -1)
                 |                         |
                 V                         V
            [ (1, 0) ]                [ (1, -1) ]
        "index=1, prev=0"         "index=1, prev=NONE"
           (3 > 1? YES)               (can pick 3)
                 |                         |
        +--------+--------+        +--------+--------+
        |                 |        |                 |
     PICK 3          SKIP 3    PICK 3           SKIP 3
   (add +1)         (prev=0)  (add +1)       (prev=-1)
        |                 |        |                 |
        V                 V        V                 V
    [ (2, 1) ]       [ (2, 0) ]  [ (2, 1) ]     [ (2, -1) ]
  "prev=1"          "prev=0"    "prev=1"       "prev=NONE"
  (2 > 3? NO)       (2 > 1? YES) (2 > 3? NO)   (2 > -1? YES)
        |                 |        |                 |
    forced skip      PICK or SKIP  forced skip   PICK or SKIP
        |                 |        |                 |
        V                 V        V                 V
    [ (3, 1) ]       [ (3, 0) ]  [ (3, 1) ]     [ (3, -1) ]
                     [ (3, 2) ]
```

**Point to duplicate states:**

> "Look here! Do you see `(2, 1)` appearing TWICE? Once from the left branch, once from the right. That's an OVERLAPPING SUBPROBLEM."

### Highlighting the Overlap

**Draw a box around the repeated state:**

```
    +-------------------+
    | REPEATED STATE:   |
    | (index=2, prev=1) |
    +-------------------+
           ↑         ↑
           |         |
      From path   From path
      (pick 1,    (don't pick 1,
       pick 3)     pick 3)
```

**Ask:**

> "What does this mean for our recursion?"

**Answer:**

- We're computing the same subproblem multiple times
- The answer to `(2, 1)` is the same no matter how we got there
- This is WASTEFUL
- If we could just remember the answer the first time, we'd save work

**Say:**

> "That's where memoization comes in. But first, let's be crystal clear about what our 'state' is."

---

## Part D — Define the DP State (The Moment of Truth) (5 min)

### The Critical Question

**Ask:**

> "If we wanted to create a cache to store answers, what should the KEY be?"

**Wait for answers. Guide if needed:**

- Need to uniquely identify each subproblem
- Two parameters: `index` and `prevIndex`

**Confirm:**

> "Correct! The state is `(index, prevIndex)`."

### Why prevIndex, Not lastValue?

**Ask:**

> "Earlier I mentioned we could have used the actual last value picked. Why did we switch to prevIndex?"

**Answer:**

- `lastValue` could be any integer → unbounded
- `prevIndex` is bounded: {-1, 0, 1, 2, ..., n-1}
- For `arr = [1, 3, 2, 4]`, n=4, so prevIndex ∈ {-1, 0, 1, 2, 3}
- That's only 5 values!

### State Space Size

**Ask:**

> "How many unique states are there?"

**Calculate together:**

- `index` can be 0, 1, 2, 3, 4 (4+1 = 5 values, including the base case)
- `prevIndex` can be -1, 0, 1, 2, 3 (5 values)
- Total states = 5 × 5 = 25

**Say:**

> "Instead of exponential recursion, we have only 25 unique subproblems. If we solve each once and store it, we're done!"

### Precise State Definition

**Write on board:**

```
DP State: dp[index][prevIndex]
    = Maximum LIS length starting from 'index',
      given that the last picked element was at 'prevIndex'
```

**Ask:**

> "What does `prevIndex = -1` mean?"

**Answer:**

- No element has been picked yet
- We're free to pick any element

---

## Part E — DP Table Layout + Why prevCol = prevIndex + 1 (5 min)

### The Index Problem

**Ask:**

> "We said prevIndex can be -1. Can we use -1 as an array index in C#?"

**Wait for "No!"**

**Say:**

> "Exactly. Array indices must be non-negative. So we need a MAPPING."

### The Mapping

**Draw this box on board:**

```
+-------------------+-------------------+
| prevIndex (real)  | prevCol (array)   |
+-------------------+-------------------+
|       -1          |        0          | ← "NONE" column
|        0          |        1          |
|        1          |        2          |
|        2          |        3          |
|        3          |        4          |
+-------------------+-------------------+

Formula: prevCol = prevIndex + 1
```

**Point to the mapping:**

> "Column 0 represents 'no previous element'. Columns 1-4 represent prev elements at indices 0-3."

### Table Dimensions

**Ask:**

> "What size should our DP table be?"

**Calculate:**

- Rows: index goes from 0 to n (4+1 = 5)
- Columns: prevCol goes from 0 to n (4+1 = 5)
- Table size: `int[,] dp = new int[5, 5]`

**General formula:**

```
dp = new int[n+1, n+1]
```

### What Does Each Cell Mean?

**Point to a specific cell:**

```
dp[2][3]
```

**Ask:**

> "In plain English, what does this cell store?"

**Guide to answer:**

- Row 2 → index = 2
- Column 3 → prevCol = 3 → prevIndex = 3-1 = 2
- Meaning: "Max LIS length from index 2 onwards, given last picked was at index 2"

**Wait, that's weird!**

> "Hold on — can we be at index 2 with prevIndex also = 2? That would mean we already picked element at index 2, but we're still at index 2. That's impossible!"

**Point:**

> "Right! So `dp[2][3]` will never be computed. Some cells in the table are INVALID states. That's okay — we only compute reachable states."

---

## Part F — Step-by-Step DP Filling (Core Visualization) (10-15 min)

### Initial Setup

**Say:**

> "Let's fill the DP table step by step. We'll show SNAPSHOTS after each memo write. Unknown cells stay as `.`"

**Array reminder:**

```
Index:  0   1   2   3
Array: [1,  3,  2,  4]
```

### Initial Table (All Unknown)

```
+-------+------+------+------+------+------+
| index | NONE | p=0  | p=1  | p=2  | p=3  |
|       | (c0) | (c1) | (c2) | (c3) | (c4) |
+-------+------+------+------+------+------+
|   0   |  .   |  .   |  .   |  .   |  .   |
+-------+------+------+------+------+------+
|   1   |  .   |  .   |  .   |  .   |  .   |
+-------+------+------+------+------+------+
|   2   |  .   |  .   |  .   |  .   |  .   |
+-------+------+------+------+------+------+
|   3   |  .   |  .   |  .   |  .   |  .   |
+-------+------+------+------+------+------+
|   4   |  .   |  .   |  .   |  .   |  .   |
+-------+------+------+------+------+------+
```

### Base Case (Row 4)

**Say:**

> "Base case: when index = 4 (beyond array), return 0 for all prevIndex values."

**Point to row 4:**

```
+-------+------+------+------+------+------+
| index | NONE | p=0  | p=1  | p=2  | p=3  |
+-------+------+------+------+------+------+
|   0   |  .   |  .   |  .   |  .   |  .   |
+-------+------+------+------+------+------+
|   1   |  .   |  .   |  .   |  .   |  .   |
+-------+------+------+------+------+------+
|   2   |  .   |  .   |  .   |  .   |  .   |
+-------+------+------+------+------+------+
|   3   |  .   |  .   |  .   |  .   |  .   |
+-------+------+------+------+------+------+
|   4   |  0   |  0   |  0   |  0   |  0   | ← BASE CASE
+-------+------+------+------+------+------+
```

### Snapshot 1: Solve(3, 2) — "At index 3, prev=2"

**State:** `(index=3, prevIndex=2)`  
**Array values:** `arr[3]=4, arr[2]=2`  
**Check:** `4 > 2?` **YES**, can pick

**Computation:**

```
pick = 1 + Solve(4, 3) = 1 + 0 = 1
dontPick = Solve(4, 2) = 0
result = Max(1, 0) = 1
```

**Store:** `dp[3][2+1] = dp[3][3] = 1`

**Table after write:**

```
+-------+------+------+------+------+------+
| index | NONE | p=0  | p=1  | p=2  | p=3  |
+-------+------+------+------+------+------+
|   0   |  .   |  .   |  .   |  .   |  .   |
+-------+------+------+------+------+------+
|   1   |  .   |  .   |  .   |  .   |  .   |
+-------+------+------+------+------+------+
|   2   |  .   |  .   |  .   |  .   |  .   |
+-------+------+------+------+------+------+
|   3   |  .   |  .   |  .   |  1   |  .   | ← COMPUTED
+-------+------+------+------+------+------+
|   4   |  0   |  0   |  0   |  0   |  0   |
+-------+------+------+------+------+------+
```

### Snapshot 2: Solve(3, 1) — "At index 3, prev=1"

**State:** `(index=3, prevIndex=1)`  
**Array values:** `arr[3]=4, arr[1]=3`  
**Check:** `4 > 3?` **YES**

**Computation:**

```
pick = 1 + Solve(4, 3) = 1 + 0 = 1
dontPick = Solve(4, 1) = 0
result = Max(1, 0) = 1
```

**Store:** `dp[3][1+1] = dp[3][2] = 1`

```
+-------+------+------+------+------+------+
| index | NONE | p=0  | p=1  | p=2  | p=3  |
+-------+------+------+------+------+------+
|   0   |  .   |  .   |  .   |  .   |  .   |
+-------+------+------+------+------+------+
|   1   |  .   |  .   |  .   |  .   |  .   |
+-------+------+------+------+------+------+
|   2   |  .   |  .   |  .   |  .   |  .   |
+-------+------+------+------+------+------+
|   3   |  .   |  .   |  1   |  1   |  .   | ← COMPUTED
+-------+------+------+------+------+------+
|   4   |  0   |  0   |  0   |  0   |  0   |
+-------+------+------+------+------+------+
```

### Snapshot 3: Solve(3, 0) — "At index 3, prev=0"

**State:** `(index=3, prevIndex=0)`  
**Array values:** `arr[3]=4, arr[0]=1`  
**Check:** `4 > 1?` **YES**

**Computation:**

```
pick = 1 + Solve(4, 3) = 1
dontPick = Solve(4, 0) = 0
result = 1
```

**Store:** `dp[3][1] = 1`

```
+-------+------+------+------+------+------+
| index | NONE | p=0  | p=1  | p=2  | p=3  |
+-------+------+------+------+------+------+
|   0   |  .   |  .   |  .   |  .   |  .   |
+-------+------+------+------+------+------+
|   1   |  .   |  .   |  .   |  .   |  .   |
+-------+------+------+------+------+------+
|   2   |  .   |  .   |  .   |  .   |  .   |
+-------+------+------+------+------+------+
|   3   |  .   |  1   |  1   |  1   |  .   | ← COMPUTED
+-------+------+------+------+------+------+
|   4   |  0   |  0   |  0   |  0   |  0   |
+-------+------+------+------+------+------+
```

### Snapshot 4: Solve(3, -1) — "At index 3, prev=NONE"

**State:** `(index=3, prevIndex=-1)`  
**Check:** `prevIndex == -1?` **YES**, can pick

**Computation:**

```
pick = 1 + Solve(4, 3) = 1
dontPick = Solve(4, -1) = 0
result = 1
```

**Store:** `dp[3][0] = 1`

```
+-------+------+------+------+------+------+
| index | NONE | p=0  | p=1  | p=2  | p=3  |
+-------+------+------+------+------+------+
|   0   |  .   |  .   |  .   |  .   |  .   |
+-------+------+------+------+------+------+
|   1   |  .   |  .   |  .   |  .   |  .   |
+-------+------+------+------+------+------+
|   2   |  .   |  .   |  .   |  .   |  .   |
+-------+------+------+------+------+------+
|   3   |  1   |  1   |  1   |  1   |  .   | ← ROW 3 DONE
+-------+------+------+------+------+------+
|   4   |  0   |  0   |  0   |  0   |  0   |
+-------+------+------+------+------+------+
```

### Snapshot 5: Solve(2, 1) — "At index 2, prev=1"

**State:** `(index=2, prevIndex=1)`  
**Array values:** `arr[2]=2, arr[1]=3`  
**Check:** `2 > 3?` **NO**, cannot pick

**Computation:**

```
Forced to skip
result = Solve(3, 1) = dp[3][2] = 1  ← MEMO HIT!
```

**Store:** `dp[2][2] = 1`

**Point out:**

> "Notice we didn't recompute Solve(3,1) — we just looked it up from the table!"

```
+-------+------+------+------+------+------+
| index | NONE | p=0  | p=1  | p=2  | p=3  |
+-------+------+------+------+------+------+
|   0   |  .   |  .   |  .   |  .   |  .   |
+-------+------+------+------+------+------+
|   1   |  .   |  .   |  .   |  .   |  .   |
+-------+------+------+------+------+------+
|   2   |  .   |  .   |  1   |  .   |  .   | ← COMPUTED (memo hit)
+-------+------+------+------+------+------+
|   3   |  1   |  1   |  1   |  1   |  .   |
+-------+------+------+------+------+------+
|   4   |  0   |  0   |  0   |  0   |  0   |
+-------+------+------+------+------+------+
```

### Snapshot 6: Solve(2, 0) — "At index 2, prev=0"

**State:** `(index=2, prevIndex=0)`  
**Array values:** `arr[2]=2, arr[0]=1`  
**Check:** `2 > 1?` **YES**

**Computation:**

```
pick = 1 + Solve(3, 2) = 1 + 1 = 2
dontPick = Solve(3, 0) = 1
result = Max(2, 1) = 2
```

**Store:** `dp[2][1] = 2`

```
+-------+------+------+------+------+------+
| index | NONE | p=0  | p=1  | p=2  | p=3  |
+-------+------+------+------+------+------+
|   0   |  .   |  .   |  .   |  .   |  .   |
+-------+------+------+------+------+------+
|   1   |  .   |  .   |  .   |  .   |  .   |
+-------+------+------+------+------+------+
|   2   |  .   |  2   |  1   |  .   |  .   | ← COMPUTED
+-------+------+------+------+------+------+
|   3   |  1   |  1   |  1   |  1   |  .   |
+-------+------+------+------+------+------+
|   4   |  0   |  0   |  0   |  0   |  0   |
+-------+------+------+------+------+------+
```

### Continue Filling (Fast-Forward)

**Say:**

> "We continue this process backwards through index 1 and index 0. Let me show you the fully filled table."

### Final DP Table

```
+-------+------+------+------+------+------+
| index | NONE | p=0  | p=1  | p=2  | p=3  |
+-------+------+------+------+------+------+
|   0   |  3   |  .   |  .   |  .   |  .   | ← Final answer here
+-------+------+------+------+------+------+
|   1   |  2   |  2   |  .   |  .   |  .   |
+-------+------+------+------+------+------+
|   2   |  2   |  2   |  1   |  .   |  .   |
+-------+------+------+------+------+------+
|   3   |  1   |  1   |  1   |  1   |  .   |
+-------+------+------+------+------+------+
|   4   |  0   |  0   |  0   |  0   |  0   | ← Base case
+-------+------+------+------+------+------+
```

**Point to the cells with dots:**

> "These cells are never computed because they represent invalid states (can't be at index with prevIndex >= index in most paths)."

---

## Part G — Which Cell is the Final Answer (2-3 min)

### The Original Call

**Ask:**

> "When we start solving the problem, what do we call?"

**Answer:**

```
Solve(index=0, prevIndex=-1)
```

**Explain:**

- Start at index 0 (beginning of array)
- No element picked yet (prevIndex = -1)

### Where Is It Stored?

**Ask:**

> "Using our mapping, where would this be stored in the DP table?"

**Calculate together:**

```
dp[index][prevCol]
= dp[0][prevIndex + 1]
= dp[0][-1 + 1]
= dp[0][0]
```

**Point to the table:**

```
+-------+------+------+
| index | NONE | ...  |
+-------+------+------+
|   0   |  3   | ...  | ← This cell!
+-------+------+------+
```

**Say:**

> "So `dp[0][0]` contains our final answer: the maximum LIS length starting from index 0 with no previous element."

### Verification

**Ask:**

> "Does 3 make sense for `[1, 3, 2, 4]`?"

**Trace one LIS:**

- Pick 1 (at index 0)
- Pick 2 (at index 2)
- Pick 4 (at index 3)
- Subsequence: `[1, 2, 4]` → length 3 ✓

**Or:**

- Pick 1, 3, 4 → length 3 ✓

**Confirm:**

> "Yes! The answer is 3."

---

## Part H — Students Can Code It Now (5 min)

### Step-by-Step Coding Checklist

**Give students this checklist:**

```
☐ 1. Create DP table: int[,] dp = new int[n+1, n+1]
     Initialize all cells to -1 (means "not computed yet")

☐ 2. Write the main function:
     public static int LIS_Memoized(int[] arr)
         → Initialize dp
         → Call Solve(0, -1, arr, dp)
         → Return result

☐ 3. Write Solve(int index, int prevIndex, int[] arr, int[,] dp):

     ☐ 3a. Base case:
           if (index >= arr.Length)
               return 0;

     ☐ 3b. Memo check:
           int prevCol = prevIndex + 1;
           if (dp[index][prevCol] != -1)
               return dp[index][prevCol];  // already computed

     ☐ 3c. Compute dontPick:
           int dontPick = Solve(index + 1, prevIndex, arr, dp);

     ☐ 3d. Compute pick (if valid):
           int pick = 0;
           if (prevIndex == -1 || arr[index] > arr[prevIndex])
               pick = 1 + Solve(index + 1, index, arr, dp);

     ☐ 3e. Store and return:
           dp[index][prevCol] = Math.Max(pick, dontPick);
           return dp[index][prevCol];
```

### Complete C# Implementation

**Provide the final clean code:**

```csharp
using System;

public static class DPProblems
{
    public static int LIS_Memoized(int[] arr)
    {
        int n = arr.Length;
        int[,] dp = new int[n + 1, n + 1];
        
        // Initialize all cells to -1 (not computed)
        for (int i = 0; i <= n; i++)
            for (int j = 0; j <= n; j++)
                dp[i, j] = -1;
        
        // Start solving from index 0, no previous element (-1)
        return Solve(0, -1, arr, dp);
    }
    
    private static int Solve(int index, int prevIndex, int[] arr, int[,] dp)
    {
        // Base case: reached end of array
        if (index >= arr.Length)
            return 0;
        
        // Map prevIndex to column (shift by +1 to handle -1)
        int prevCol = prevIndex + 1;
        
        // Memo check: if already computed, return stored value
        if (dp[index, prevCol] != -1)
            return dp[index, prevCol];
        
        // Option 1: Don't pick current element
        int dontPick = Solve(index + 1, prevIndex, arr, dp);
        
        // Option 2: Pick current element (if valid)
        int pick = 0;
        if (prevIndex == -1 || arr[index] > arr[prevIndex])
        {
            pick = 1 + Solve(index + 1, index, arr, dp);
        }
        
        // Store the result and return
        dp[index, prevCol] = Math.Max(pick, dontPick);
        return dp[index, prevCol];
    }
}
```

### Testing the Code

**Provide test case:**

```csharp
// Test
int[] arr = { 1, 3, 2, 4 };
int result = DPProblems.LIS_Memoized(arr);
Console.WriteLine($"LIS Length: {result}");  // Output: 3
```

---

## Summary & Key Takeaways (2 min)

### What We Learned

**Recap together:**

1. **Recursion First:**
   - At each index: pick or don't pick
   - State: `(index, prevIndex)`
   - Exponential time without memoization

2. **Identify Overlapping Subproblems:**
   - Same `(index, prevIndex)` computed multiple times
   - Opportunity for memoization

3. **DP State:**
   - `dp[index][prevIndex]` = max LIS length from index with last picked at prevIndex
   - Why prevIndex, not value? → Bounded range

4. **Mapping Trick:**
   - `prevCol = prevIndex + 1`
   - Column 0 = "NONE" (prevIndex = -1)
   - Columns 1 to n = prev indices 0 to n-1

5. **Final Answer:**
   - Stored in `dp[0][0]`
   - Represents: start at index 0, no previous element

### Complexity

**Briefly mention:**

- **Time:** O(n²) — n×n states, each computed once
- **Space:** O(n²) — DP table size
- **Improvement:** There's an O(n log n) solution using binary search + DP, but that's for another day!

### Practice Problems

**Suggest to students:**

1. Try this with `arr = [10, 9, 2, 5, 3, 7, 101, 18]` → answer should be 4
2. Modify to print the actual LIS sequence, not just length
3. Try "Longest Common Subsequence" — similar memoization pattern

---

## Teaching Notes for Instructor

### Timing Breakdown

- Part A: 1 min (hook)
- Part B: 5-7 min (build recursion)
- Part C: 7-10 min (draw tree, show overlap)
- Part D: 5 min (define DP state)
- Part E: 5 min (mapping trick)
- Part F: 10-15 min (step-by-step table filling)
- Part G: 2-3 min (final answer location)
- Part H: 5 min (coding checklist + code)
- Summary: 2 min

**Total: ~45-50 minutes**

### Common Student Questions (Be Ready)

**Q1:** "Why not use a 1D array?"

**A:** We have TWO dimensions of state: index AND prevIndex. Both vary independently.

**Q2:** "Can I use a dictionary instead of a 2D array?"

**A:** Yes! `Dictionary<(int, int), int>` works. The 2D array is just more direct here.

**Q3:** "What if the array has duplicates?"

**A:** Our `arr[index] > arr[prevIndex]` check is strict (>), so duplicates won't be picked consecutively. Still works!

**Q4:** "Can we do bottom-up DP instead of top-down?"

**A:** Yes, but the iteration order is tricky (have to go backwards from n to 0). Top-down is more intuitive for this problem.

### Excalidraw Tips

- Draw the recursion tree snapshot on one slide
- Animate the DP table filling on another slide (show each snapshot)
- Use color coding:
  - Green = computed cell
  - Gray = base case
  - White/blank = not yet computed
- Use arrows to show memo hits

### Engagement Tips

- Pause after each question — wait 5-10 seconds
- Call on students randomly for answers
- If stuck, give a hint and wait again
- After showing solution, ask "Does this make sense?" and check for nods

---

## End of Lecture

**Final words to students:**

> "You now understand the journey from recursion to memoization. This pattern — recursive exploration + overlapping subproblems + caching — is the HEART of dynamic programming. Master this, and you'll recognize DP opportunities everywhere. Now go code it yourself!"


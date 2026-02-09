# Universal Prompt: "Teach Any DP Problem (Recursion → DP) like a Lecture"

## Purpose
You are my teaching assistant. I am teaching college fresh grads how to go from a vanilla problem statement → recursion → DP using the Socratic method.

---

## Inputs (I will provide these)

1. **Problem (vanilla description):** `{{PROBLEM_VANILLA}}`
2. **Goal / output:** `{{OUTPUT_DESCRIPTION}}`
3. **Constraints (optional):** `{{CONSTRAINTS}}`
4. **One small example input:** `{{EXAMPLE_INPUT}}`
5. **Example output:** `{{EXAMPLE_OUTPUT}}`
6. **Language for final code:** `{{LANGUAGE}}` (default: C#)
7. **DP style preference:** `{{DP_STYLE}}` (options: top-down memoization, bottom-up tabulation, both)

---

## Teaching Constraints / Style (must follow)

### Core Principles
- ✅ **Teach like a real lecture:** Question → Pause → Answer
- ✅ **Socratic method:** Ask questions first, let students think, then answer
- ✅ **Build intuition gradually:** Avoid jumping directly to formulas
- ✅ **Single running example:** Use only `{{EXAMPLE_INPUT}}` throughout
- ✅ **Visual first:** Show diagrams before code

### Visualization Requirements
- ✅ **Small recursion tree snapshot:** Not full exponential tree, just enough branching (2-3 levels)
- ✅ **Show overlapping subproblems:** At least one repeated state clearly marked
- ✅ **DP table evolution:** Step-by-step snapshots after each memo write (top-down) or iteration (bottom-up)
- ✅ **ASCII dashed boxes:** Copy-paste ready for Excalidraw
- ✅ **Keep grids ≤ 6×6:** For larger examples, use `...` for middle rows/cols
- ✅ **Narration cues:** Include "Point to ...", "Highlight ...", "Circle ..." throughout

### Complexity & Code
- ✅ **Complexity:** Mention briefly only AFTER DP is clear (don't over-explain)
- ✅ **Guided coding plan:** Checklist so students can implement themselves
- ✅ **Final code:** Clean, readable names, comments mapping code → state meaning

### Engagement
- ✅ **Checkpoints:** Add comprehension checks after major sections
- ✅ **Prediction pauses:** Ask students to predict before revealing
- ✅ **Common mistakes:** Call out typical errors and how to fix them

---

## ⏱️ TIMING GUIDANCE

**Complete lecture:** 75-90 minutes

**Option 1 (Single Session):** Focus on top-down OR bottom-up only [50-60 min]
**Option 2 (Two Sessions):**
- Session 1: Parts 0-G (recursion + top-down memoization) [45-50 min]
- Session 2: Quick recap + Part H (bottom-up) + Parts K-M [40-45 min]

---

## Output Format (must follow exactly)

---

## Part 0 — Is This a DP Problem? (Recognition) (2-3 min)

### Hook the Problem Type

**Ask students:**
> "Before we dive in, let's develop intuition for recognizing DP problems. What makes a problem a DP problem?"

**Guide with questions:**

1. **Optimal Substructure Question:**
   - "Does this problem ask for 'optimal', 'maximum', 'minimum', or 'count all ways'?"
   - "Can we build the optimal solution from optimal solutions to smaller subproblems?"

2. **Overlapping Subproblems Question:**
   - "If we tried all possibilities, would we solve the same smaller problem multiple times?"
   - "Is there a recursive structure where subproblems repeat?"

3. **Dependency Question:**
   - "Can we express the answer at step N in terms of answers at steps N-1, N-2, ...?"

### Quick Comparison Table

**Show on board:**

```
+------------------+-------------------------+-------------------+
| Approach         | When to Use             | Example           |
+------------------+-------------------------+-------------------+
| Greedy           | Local choice → Global   | Activity Select   |
|                  | No backtracking needed  |                   |
+------------------+-------------------------+-------------------+
| Divide-Conquer   | Independent subproblems | Merge Sort        |
|                  | (no overlap)            |                   |
+------------------+-------------------------+-------------------+
| Dynamic Prog     | Overlapping subs +      | LIS, Knapsack     |
|                  | Optimal substructure    |                   |
+------------------+-------------------------+-------------------+
```

**Say:**
> "Today's problem has overlapping subproblems and optimal substructure. That's our signal: it's a DP problem. Let's solve it step by step."

---

## Part A — Hook + Problem Restatement (1–2 min)

### Opening Story / Real-World Connection

**Provide a relatable analogy or scenario:**
> "Imagine [real-world scenario that maps to the problem]..."

### Problem Definition (Vanilla)

**Restate `{{PROBLEM_VANILLA}}` in simple terms:**
- What are we given?
- What are we asked to find?
- What are the rules/constraints?

### Example Walkthrough

**Use `{{EXAMPLE_INPUT}}` → `{{EXAMPLE_OUTPUT}}`:**

```
Input:  {{EXAMPLE_INPUT}}
Output: {{EXAMPLE_OUTPUT}}
```

**Explain WHY this is the output** (trace one solution path manually).

### Set Expectations

**Say to students:**
> "We'll start by exploring this with recursion—trying all possibilities. Then we'll notice we're doing wasteful work. Finally, we'll add memory (DP) to eliminate that waste."

---

## Part B — Build Recursion from First Principles (Socratic) (5–8 min)

### Socratic Build-Up

**Ask these questions in order (adapt to problem):**

#### 1. Choice Question
**Ask:**
> "At any step in this problem, what CHOICES do we have?"

**Wait for student answers, then confirm/correct:**
- List all possible choices (e.g., "pick or don't pick", "take coin or skip coin", "include item or exclude")

#### 2. State Question
**Ask:**
> "To make the right decision at each step, what INFORMATION do we need to know?"

**Guide to answer:**
- Which parameters define where we are in the problem?
- What changes as we make decisions?

**Common state types:**
- Index/position in array
- Remaining capacity/amount
- Previous choice made
- (Avoid temporary variables that don't affect subproblem identity)

#### 3. Base Case Question
**Ask:**
> "When do we STOP recursion? What's the simplest case we can answer directly?"

**Answer together:**
- Identify boundary conditions (e.g., index out of bounds, amount = 0)
- What should we return in each base case?

#### 4. Return Meaning Question
**Ask:**
> "What does our recursive function RETURN? What does that value represent?"

**Clarify:**
- Is it a count? A maximum? A boolean?
- Ensure students understand the semantic meaning

### Function Signature Proposal

**Reveal the recursion signature:**

```
{{LANGUAGE}} signature example:
Solve(param1, param2, ...)
    → Returns: [what it means]
```

**Example for Coin Change:**
```csharp
Solve(index, amount)
    → Returns: minimum coins needed to make 'amount' 
               using coins from index onwards
```

### Pseudocode Outline

**Provide SHORT pseudocode (not full implementation yet):**

```
Solve(state_params):
    // Base case(s)
    if (stopping_condition)
        return base_value
    
    // Recursive choices
    choice1 = Solve(next_state1)
    choice2 = Solve(next_state2)
    ...
    
    // Combine and return
    return best_of(choice1, choice2, ...)
```

### ⚠️ COMMON MISTAKE

**Call out:**
```
⚠️ COMMON MISTAKE:
Students confuse "state parameters" (subproblem identity) 
with "temporary variables" (computation helpers).

Example: In Coin Change, the current coin VALUE is not state—
it's derived from INDEX. Only index and remaining amount are state.

Rule of thumb: State = bare minimum info to resume the problem.
```

---

## Part C — Recursion Tree Snapshot (7–10 min)

### Setting Up the Trace

**Say:**
> "Let's trace our recursion using `{{EXAMPLE_INPUT}}`. I'll draw a SNAPSHOT—not the entire exponential tree, just enough to see the branching pattern."

### Node Notation

**Explain notation before drawing:**
```
+------------------------+
| State: (param values)  |
| Meaning: [English]     |
+------------------------+
```

### Recursion Tree Diagram (ASCII)

**Draw 2-3 levels of branching:**

```
                  +-------------------+
                  | State: (...)      |
                  | [Root meaning]    |
                  +-------------------+
                           |
            +--------------+--------------+
            |                             |
      [Decision 1]                  [Decision 2]
      (e.g., PICK)                  (e.g., SKIP)
            |                             |
            V                             V
   +-----------------+          +-----------------+
   | State: (...)    |          | State: (...)    |
   | [Meaning]       |          | [Meaning]       |
   +-----------------+          +-----------------+
            |                             |
       +----+----+                   +----+----+
       |         |                   |         |
   [choice]  [choice]            [choice]  [choice]
       |         |                   |         |
       V         V                   V         V
    (...)      (...)              (...)      (...)
```

**Fill in with actual values from `{{EXAMPLE_INPUT}}`.**

### Narration Cues

**Include these:**
- **Point to root:** "This represents the original question: [restate problem]."
- **Point to edges:** "This edge means we chose [decision]. Notice how the state changes from [...] to [...]."
- **Point to leaf nodes:** "These leaves are base cases where [condition]. We return [value]."

### 🤔 PREDICTION PAUSE

**Before showing the full tree:**
> "Before I draw the rest, predict: if we make choice X at the root, what will the next state be?"

Wait 10 seconds. Take 1-2 answers. Then reveal.

---

## Part D — Define the DP State (The "Moment of Truth") (5–8 min)

### The Critical Question

**Ask:**
> "Looking at our recursion tree, what identifies a UNIQUE subproblem? If we wanted to label each node uniquely, what would we write?"

**Wait for answers. Guide if needed:**
- "Is it just one parameter? Or multiple?"
- "Does anything else matter?"

### Reveal the State

**Confirm:**
```
DP State = (param1, param2, ...)

In plain English:
dp[param1][param2] = [what this represents]
```

**Example for Knapsack:**
```
State = (index, remainingCapacity)

dp[index][capacity] = 
    Maximum value obtainable from items [index...n-1]
    with knapsack capacity 'capacity'
```

### Bounded Parameters Question

**Ask:**
> "How many possible values can each parameter take?"

**Calculate together:**
- param1 range: [min1, max1] → count1 values
- param2 range: [min2, max2] → count2 values
- Total states = count1 × count2 × ...

**Emphasize:**
> "This is BOUNDED. We have a finite (and small) number of unique subproblems. That's what makes DP feasible."

### ✋ CHECKPOINT

**Ask students:**
1. "Can you explain the state in your own words?"
2. "Why does this state uniquely identify a subproblem?"
3. "Show me one example of this state from our tree."

Wait for responses. Clarify misconceptions before moving on.

---

## Part E — Identify Overlap (Overlapping Subproblems) (3–6 min)

### The Repeat Question

**Ask:**
> "Looking at the recursion tree we drew, do we ever solve the SAME state more than once?"

**Point to the tree and wait for students to spot duplicates.**

### Highlight the Repeated State

**Draw a box around repeated nodes:**

```
    +----------------------------+
    | REPEATED STATE:            |
    | State: (...)               |
    |                            |
    | Reached from:              |
    |  - Path A: [describe]      |
    |  - Path B: [describe]      |
    +----------------------------+
           ↑              ↑
           |              |
      [Path A]       [Path B]
```

**Trace the two paths explicitly:**
- "From the root, if we go [decision sequence A], we reach this state."
- "But if we go [decision sequence B], we reach the SAME state."

### The Waste Explanation

**Ask:**
> "What happens when we reach this state the second time via Path B?"

**Answer:**
- "We recompute everything below it."
- "But the answer is the SAME—it doesn't matter how we got there."
- "That's WASTEFUL."

**Say:**
> "This overlap is the key insight. If we could just REMEMBER the answer the first time we computed it, we'd never recompute. That's memoization."

---

## Part F — DP Table Layout (Visual) (5–8 min)

### Table Dimensions Question

**Ask:**
> "If we create a table to store all possible states, what size should it be?"

**Answer together:**
- Based on parameter ranges from Part D
- Example: `dp = new int[n+1, capacity+1]` (explain the +1 if needed)

### Index Mapping (if needed)

**If any parameter can be negative or needs shifting:**

```
+-------------------+-------------------+
| Actual param      | Array index       |
+-------------------+-------------------+
| -1                | 0                 | ← Example: "NONE"
|  0                | 1                 |
|  1                | 2                 |
| ...               | ...               |
+-------------------+-------------------+

Formula: arrayIndex = actualParam + shift
```

**Explain WHY the shift is needed.**

### Cell Meaning in Plain English

**Point to a specific cell:**
```
dp[i][j]
```

**Ask:**
> "In one sentence, what does this cell store?"

**Provide the English translation:**
```
dp[i][j] = [precise meaning with i and j explained]
```

### Empty Table Template

**Show initial table (small example, ≤6×6):**

```
+-------+-----+-----+-----+-----+-----+
|  i\j  |  0  |  1  |  2  |  3  |  4  |
+-------+-----+-----+-----+-----+-----+
|   0   |  .  |  .  |  .  |  .  |  .  |
+-------+-----+-----+-----+-----+-----+
|   1   |  .  |  .  |  .  |  .  |  .  |
+-------+-----+-----+-----+-----+-----+
|   2   |  .  |  .  |  .  |  .  |  .  |
+-------+-----+-----+-----+-----+-----+
|   3   |  .  |  .  |  .  |  .  |  .  |
+-------+-----+-----+-----+-----+-----+

Legend:
  .  = not yet computed
  X  = computed value
```

**Narration:**
- **Point to row headers:** "Rows represent [param1] values [range]."
- **Point to column headers:** "Columns represent [param2] values [range]."
- **Point to dp[0][0]:** "This cell means [specific interpretation]."

---

## Part G — Top-Down Memoization Walkthrough (Core Visualization) (10–15 min)

### Memoization Rule

**Explain:**
> "Top-down memoization = recursion + memory. Before computing, we CHECK: have we solved this before?"

**Pseudocode pattern:**
```
Solve(params):
    if (dp[params] is already computed):
        return dp[params]  // MEMO HIT—no recursion!
    
    // Otherwise, compute as usual
    result = [recursive computation]
    
    dp[params] = result  // STORE for future
    return result
```

### Step-by-Step Fill Using {{EXAMPLE_INPUT}}

**Say:**
> "Let's trace the execution. I'll show snapshots after each memo write. Watch how the table fills."

### Per-Step Template (repeat for each key state)

**For each memo write, follow this structure:**

#### Step X: Solving State (...)

```
+-----------------------------------+
| Solving state: (param values)    |
| Meaning: [English description]   |
|                                   |
| Computation:                      |
|   choice1 = [value or recursive] |
|   choice2 = [value or recursive] |
|   result = best of choices       |
|                                   |
| Store into: dp[i][j]             |
| Value stored: X                   |
+-----------------------------------+
```

#### DP Table Snapshot After Step X

```
+-------+-----+-----+-----+-----+
|  i\j  |  0  |  1  |  2  |  3  |
+-------+-----+-----+-----+-----+
|   0   |  .  |  .  |  .  |  .  |
+-------+-----+-----+-----+-----+
|   1   |  .  |  .  |  X  |  .  | ← Updated cell
+-------+-----+-----+-----+-----+
|   2   |  .  |  .  |  .  |  .  |
+-------+-----+-----+-----+-----+
```

**Narration:**
- **Point to updated cell:** "We just stored X here. This means [interpretation]."

### MEMO HIT Example (critical!)

**At some point, show:**

#### Step Y: Reached State (...) Again

```
+-----------------------------------+
| State: (param values)             |
| CHECK dp[i][j] → already = Z      |
|                                   |
| ✓ MEMO HIT!                       |
| Skip recursion, return Z          |
+-----------------------------------+
```

**Explain:**
> "Notice we DIDN'T recurse below this node. We just looked up the answer. That's the power of memoization."

### Final Filled Table

**Show the completely filled table:**

```
+-------+-----+-----+-----+-----+
|  i\j  |  0  |  1  |  2  |  3  |
+-------+-----+-----+-----+-----+
|   0   |  A  |  B  |  C  |  D  |
+-------+-----+-----+-----+-----+
|   1   |  E  |  F  |  G  |  H  |
+-------+-----+-----+-----+-----+
|   2   |  I  |  J  |  K  |  L  |
+-------+-----+-----+-----+-----+
```

**Point to specific cells:**
- "This cell was computed first."
- "These cells triggered memo hits."

### ⚠️ COMMON MISTAKE

```
⚠️ COMMON MISTAKE:
Students forget to initialize dp with sentinel values (e.g., -1, null).
If you don't, you can't tell "not computed" from "answer is 0."

Correct initialization:
for (int i = 0; i <= n; i++)
    for (int j = 0; j <= m; j++)
        dp[i][j] = -1;  // means "not computed"
```

### ✋ CHECKPOINT

**Ask students:**
1. "Where is the first cell we computed?"
2. "Can you trace one example of a memo hit?"
3. "Why is this faster than plain recursion?"

---

## Part H — Bottom-Up Tabulation Walkthrough (if requested) (10–15 min)

### Fill Order Question

**Ask:**
> "In top-down, we started from the original question and recursed. In bottom-up, we fill the table iteratively. What ORDER should we fill cells so dependencies are always ready?"

**Guide to answer:**
- Identify which cells depend on which
- Determine fill direction (left→right, bottom→top, etc.)

### Iteration Structure

**Show loop structure in pseudocode:**

```
for i from [start] to [end]:
    for j from [start] to [end]:
        dp[i][j] = [compute from already-filled cells]
```

**Explain the direction:**
> "We fill row by row (or column by column) because each cell depends on [earlier cells]."

### Base Case Initialization

**Show which cells to fill first:**

```
+-------+-----+-----+-----+-----+
|  i\j  |  0  |  1  |  2  |  3  |
+-------+-----+-----+-----+-----+
|   0   |  B  |  B  |  B  |  B  | ← Base case row
+-------+-----+-----+-----+-----+
|   1   |  B  |  .  |  .  |  .  | ← One base column
+-------+-----+-----+-----+-----+
|   2   |  B  |  .  |  .  |  .  |
+-------+-----+-----+-----+-----+

B = Base case value
```

**Explain:**
> "These represent the base cases from our recursion. We fill them first."

### Step-by-Step Fill

**Show snapshots after each iteration (or meaningful step):**

#### After Iteration 1:

```
+-------+-----+-----+-----+-----+
|  i\j  |  0  |  1  |  2  |  3  |
+-------+-----+-----+-----+-----+
|   0   |  B  |  B  |  B  |  B  |
+-------+-----+-----+-----+-----+
|   1   |  B  |  X  |  X  |  X  | ← Filled row 1
+-------+-----+-----+-----+-----+
|   2   |  B  |  .  |  .  |  .  |
+-------+-----+-----+-----+-----+
```

**For each cell, briefly explain:**
> "dp[1][1] = Max(choice1, choice2) = [show simple calculation]"

### 🤔 PREDICTION PAUSE

**Before computing a cell:**
> "Before I compute dp[2][3], predict: will it be larger or smaller than dp[2][2]? Why?"

### Final Table

**Show the completely filled table and trace the final answer.**

### ⚠️ COMMON MISTAKE

```
⚠️ COMMON MISTAKE:
Students mix up loop bounds (off-by-one errors).

Check these:
✓ Are you iterating to n or n-1?
✓ Do you need i <= n or i < n?
✓ Does your base case cover index 0 or start at 1?
```

---

## Part I — Which DP Cell Contains the Final Answer (2–4 min)

### Original Question Mapping

**Ask:**
> "What state represents the ORIGINAL question we asked?"

**Guide to answer:**
- Identify the starting parameters
- Example: "We started with index=0, capacity=W"

### Where Is It Stored?

**Ask:**
> "Using our DP table, where do we store that state?"

**Reveal:**
```
Final answer is in: dp[...]
```

**Explain:**
> "dp[...] corresponds to [starting condition]. That's why it holds our final answer."

### Narration

**Point to the specific cell:**
- **Highlight:** "This cell right here—dp[...]—is what we return."

### Alternative Answers (if applicable)

**If the problem has multiple valid starting points:**
> "Sometimes we need to check MULTIPLE cells and take the best. For example, [explain scenario]."

---

## Part J — Complexity (Brief, Only Now) (1–2 min)

### Time Complexity

**Before DP:**
- Recursion: O(2^n) or O(branching_factor^depth)
- Why? Exponential tree, lots of repeated work

**After DP:**
- Memoization / Tabulation: O(states × work_per_state)
- Example: O(n × capacity) for Knapsack
- Why? Each state computed exactly once

### Space Complexity

**DP table:** O(states)  
**Recursion stack (top-down only):** O(depth)

**Trade-off:**
> "We use more memory to save time. Classic space-time tradeoff."

**Say:**
> "Don't worry too much about complexity derivations now. The key insight: DP converts exponential to polynomial."

---

## Part K — Guided Coding Plan (Students Implement Themselves) (5–8 min)

### Coding Checklist

**Provide this step-by-step plan:**

```
☐ 1. Identify recursion parameters (state)
     → What defines a unique subproblem?

☐ 2. Write base case(s)
     → When do we stop recursion? What do we return?

☐ 3. Write recursive transitions (choices)
     → What choices do we have at each state?
     → How do we combine results?

☐ 4. Create DP structure with correct size
     → Top-down: int[,] dp = new int[size1, size2]
     → Initialize with sentinel (-1, infinity, null)

☐ 5. Add memoization (top-down) OR loop order (bottom-up)
     → Top-down: check if dp[...] != sentinel, else compute & store
     → Bottom-up: nested loops in correct fill order

☐ 6. Return the correct DP cell
     → Where is the answer to the original question stored?
```

**Say:**
> "Follow this checklist. If you can complete each step, you'll have working code."

### Code Template (Top-Down)

**Provide skeleton code in {{LANGUAGE}}:**

```csharp
public static int Solve(/* input params */)
{
    int n = /* size */;
    int[,] dp = new int[n+1, m+1];
    
    // Initialize
    for (int i = 0; i <= n; i++)
        for (int j = 0; j <= m; j++)
            dp[i, j] = -1;
    
    return Helper(/* starting state */, dp);
}

private static int Helper(/* state params */, int[,] dp)
{
    // Base case
    if (/* stopping condition */)
        return /* base value */;
    
    // Memo check
    if (dp[i, j] != -1)
        return dp[i, j];
    
    // Compute choices
    int choice1 = /* ... */;
    int choice2 = /* ... */;
    
    // Store and return
    dp[i, j] = Math.Max(choice1, choice2); // or Min, or sum
    return dp[i, j];
}
```

### Final Clean Implementation

**Provide complete, commented code:**

```csharp
// [Full working code specific to {{PROBLEM_VANILLA}}]
// Comments should map code to state meaning
```

**Code requirements:**
- ✅ Readable variable names
- ✅ Comments explaining state meaning
- ✅ No premature optimizations
- ✅ Test with {{EXAMPLE_INPUT}}

---

## Part L — Troubleshooting Guide (Keep This Handy) (3-5 min)

### When Students Get Stuck

**Common issues and fixes:**

#### Issue 1: "I don't understand what the state means"

**Fix:**
> Walk through one example manually: "If you were at THIS point in the problem, what would you NEED TO KNOW to continue making decisions?"

**Exercise:**
- Pick a random point in the recursion tree
- Ask: "What info do we have here?"
- That's your state

---

#### Issue 2: "I don't see the overlapping subproblems"

**Fix:**
> Trace TWO DIFFERENT PATHS on the recursion tree that end at the same node.

**Exercise:**
- Start from root, make decision sequence A
- Start from root, make decision sequence B
- Show both reach state (x, y)

---

#### Issue 3: "My memoized code is still slow"

**Checklist:**
1. ✓ Did you initialize dp with sentinel values?
2. ✓ Are you checking `if (dp[...] != sentinel)` BEFORE recursing?
3. ✓ Are you storing the result AFTER computing?
4. ✓ Is your state truly bounded (not infinite)?

---

#### Issue 4: "My code has bugs / wrong answer"

**Debug in this order:**

```
1. Base case boundaries
   → Off-by-one? Check <= vs <

2. Sentinel values
   → Using -1 where 0 is valid answer? Use Int32.MinValue instead
   → Using 0 when you need "infinity"? Use Int32.MaxValue

3. Index mapping shifts
   → Did you apply +1 or -1 consistently?
   → Example: prevIndex = -1 → prevCol = 0

4. Return the right dp cell
   → Are you returning dp[0][0] when answer is in dp[n][m]?

5. Choice logic
   → Are you taking Max when you should take Min?
   → Are you adding 1 for this choice before recursing?
```

---

#### Issue 5: "I can't convert top-down to bottom-up"

**Steps:**
1. Draw the dependency arrows in your DP table
2. Identify which direction to fill so dependencies are ready
3. Replace recursion with nested loops in that order
4. Replace recursive calls with direct dp lookups

---

## Part M — Pattern Recognition & Extensions (5 min)

### This Problem's Structure

**Summarize:**
> "Today's problem had these characteristics:
> - State: [describe]
> - Choices: [describe]
> - Optimization: [max/min/count]
> - Dependency: [describe how subproblems relate]"

### Other Problems with the SAME Pattern

**Show at least 2-3 similar problems:**

```
+---------------------------+---------------------------+
| Problem Name              | How It's Similar          |
+---------------------------+---------------------------+
| [Problem X]               | Same state structure,     |
|                           | different choices         |
+---------------------------+---------------------------+
| [Problem Y]               | 2D state becomes 3D       |
|                           | (add one more param)      |
+---------------------------+---------------------------+
| [Problem Z]               | Same choices, different   |
|                           | optimization (max→count)  |
+---------------------------+---------------------------+
```

### How to Recognize This Pattern in the Wild

**Provide a checklist:**

```
✓ Problem asks for optimal value (max/min) or count ways
✓ You can break it into smaller identical subproblems
✓ Choices at each step are clear (pick/skip, include/exclude)
✓ Greedy doesn't work (local choice ≠ global optimal)
✓ You naturally think "try all possibilities"

→ Then think: DP!
```

### Extensions & Variations

**Mention briefly:**
- **Space optimization:** "Can reduce 2D dp to 1D if we only need previous row"
- **Path reconstruction:** "To print the actual solution, store choices in another array"
- **Constraint variations:** "What if we add another dimension? State becomes 3D"

---

## Part N — Practice & Next Steps (2 min)

### Immediate Practice

**Assign:**
1. **Code it yourself:** Use the checklist from Part K, implement from scratch without looking at solution
2. **Test with edge cases:**
   - Smallest valid input
   - All same values
   - Worst case input

### Follow-Up Problems (Progressive Difficulty)

**Provide 3-5 problems:**

```
Level 1: [Direct application of same pattern]
Level 2: [Small variation—add one constraint]
Level 3: [Different problem type, similar DP approach]
Level 4: [Challenging extension]
```

### Conceptual Challenges

**Ask students to think about:**
- "Can you solve this with O(n) space instead of O(n²)?"
- "Can you reconstruct the actual solution sequence, not just the count/value?"
- "What happens if we relax constraint X?"

---

## Teaching Notes for Instructor

### Delivery Tips

1. **Pause frequently:** After each question, wait 10 seconds minimum
2. **Use the board:** Draw as you talk—students follow better with visuals
3. **Call on students:** Don't just ask rhetorical questions
4. **Validate partial answers:** "That's close! Now think about..."
5. **Show enthusiasm:** "This is cool!" energy is contagious

### Things to Avoid

❌ Showing code before concepts  
❌ Jumping to complexity analysis too early  
❌ Drawing the FULL recursion tree (exponential branches overwhelm)  
❌ Using vague variable names like `dp[i][j]` without explaining  
❌ Assuming students remember math notation (be explicit)

### Backup Slides (If Time Runs Out)

Have these ready:
- Completed DP table (don't fill it live if time is short)
- Final code (just show, don't derive)
- Complexity summary

### Common Student Misconceptions (Be Ready to Address)

| Misconception                          | Correction                              |
|----------------------------------------|-----------------------------------------|
| "DP = just memoization"                | "DP = optimal substructure + overlap"   |
| "More dimensions = harder"             | "Just more parameters in state"         |
| "Bottom-up always faster"              | "Often same complexity, different style"|
| "I need to memorize DP patterns"       | "Understand state + choices, rest flows"|

---

## Summary: Your Checklist Before Delivering This Lecture

```
☐ Choose a small, clear example ({{EXAMPLE_INPUT}})
☐ Trace recursion manually beforehand—know the tree
☐ Identify at least one overlapping state to highlight
☐ Prepare DP table snapshots (3-5 key steps)
☐ Write final code and test it
☐ Prepare board space for tree + table
☐ Have timing checkpoints (don't rush Part G/H)
☐ Prepare answers to "Why not greedy?" question
☐ Have 2-3 follow-up practice problems ready
```

---

## Example Usage of This Prompt

```
Problem: Coin Change
Goal: Minimum number of coins to make amount
Example Input: coins = [1, 2, 5], amount = 11
Example Output: 3 (5 + 5 + 1)
Language: C#
DP Style: Both (top-down, then bottom-up)

[Execute the lecture following all parts A-N above]
```

---

## Final Notes

This prompt is designed to be **adapted**, not rigidly followed. Adjust pacing based on your students' background. The key is:

1. **Build intuition before formulas**
2. **Show visually before coding**
3. **Engage through questions, not lectures**
4. **Make mistakes safe:** "Wrong answers help us learn!"

Good luck teaching! 🎓

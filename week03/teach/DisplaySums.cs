public static class DisplaySums {
    public static void Run() {
        DisplaySumPairs([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
        // Should show something like (order does not matter):
        // 6 4
        // 7 3
        // 8 2
        // 9 1 

        Console.WriteLine("------------");
        DisplaySumPairs([-20, -15, -10, -5, 0, 5, 10, 15, 20]);
        // Should show something like (order does not matter):
        // 10 0
        // 15 -5
        // 20 -10

        Console.WriteLine("------------");
        DisplaySumPairs([5, 11, 2, -4, 6, 8, -1]);
        // Should show something like (order does not matter):
        // 8 2
        // -1 11
    }

    /// <summary>
    /// Display pairs of numbers (no duplicates should be displayed) that sum to
    /// 10 using a set in O(n) time.  We are assuming that there are no duplicates
    /// in the list.
    /// </summary>
    /// <param name="numbers">array of integers</param>

    // We create an empty HashSet<int> to store the numbers we have already visited.
    // We use a foreach loop to go through each number.
    // We calculate the complement (10 - number) to find the number needed to make 10.
    // We use Contains() to check if that complement is already in the Set.
    // If it exists, we display the pair.
    // We add the current number to the Set using Add().
    private static void DisplaySumPairs(int[] numbers) {
        HashSet<int> seen = new HashSet<int>();

        foreach (int number in numbers) {
            int complement = 10 - number;

            if (seen.Contains(complement)) {
                Console.WriteLine($"{number} {complement}");
            }

            seen.Add(number);
        }
    }
}
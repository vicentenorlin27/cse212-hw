using System;
using System.Collections.Generic;

public class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' containing multiples of 'number'.
    /// </summary>
    public static double[] MultiplesOf(double number, int length)
    {
        /*
         * Plan for MultiplesOf:
         * 1. Create a new array of doubles with a size equal to 'length'.
         * 2. Use a for loop that runs 'length' times (from index 0 to length - 1).
         * 3. Inside the loop, calculate each multiple by multiplying the starting 'number' 
         *    by (index + 1).
         * 4. Assign this calculated value to the corresponding index in the array.
         * 5. Return the completed array.
         */
        double[] results = new double[length];
        for (int i = 0; i < length; i++)
        {
            results[i] = number * (i + 1); // <-- Make sure parentheses () are used here, NOT square brackets []
        }
        return results;
    }

    /// <summary>
    /// Rotate the 'data' list to the right by the 'amount'. For example, if the data is 
    /// <List>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs 
    /// should be <List>{7, 8, 9, 1, 2, 3, 4, 5, 6}.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        /*
         * Plan for RotateListRight:
         * 1. Determine the effective rotation amount using modulo (amount % data.Count) 
         *    just in case amount is equal to or larger than the list size.
         * 2. If the effective amount is 0, no rotation is needed, so return.
         * 3. Find the index where the split occurs. The last 'amount' elements will move to the front. 
         *    This split index is (data.Count - amount).
         * 4. Use GetRange to extract the tail slice (from the split index to the end) 
         *    and the head slice (from index 0 up to the split index).
         * 5. Clear the original list and rebuild it by adding the tail slice followed by the head slice.
         */
        int count = data.Count;
        amount = amount % count;
        if (amount == 0) return;

        List<int> tail = data.GetRange(count - amount, amount);
        List<int> head = data.GetRange(0, count - amount);

        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}
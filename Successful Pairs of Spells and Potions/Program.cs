// See https://aka.ms/new-console-template for more information
var spells = new int[] { 5, 1, 3 };
var potions  = new int[] { 4, 1, 5, 3, 2 };
int success = 7;
Solution s = new Solution();
var answer = s.SuccessfulPairs(spells, potions, success);
Console.WriteLine(string.Join(",", answer));
public class Solution
{
  public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
  {
    // size of spells = n (max no of elements can be = 10^5)  
    // size of potions = m (max no of elements can be = 10^5)
    // if we use BF approach then in worst scenario (n*m) no of loops are required
    // asnwer we need to return as  pairs of length n , which means n no of loop is required , so we only left with reducing the loop for size m
    // how can we achieve (n * logm).
    // to achieve log m we need to perform bianry search. BS is only can be performed on sorted data set, we need to sort potions data set
    // during BS if we find a index where spells[i] * potions[j] >= success, which means all the indexes after this also satisfy the condition as the array is sorted and in next index we get more higher value
    // so we need to go left until condition break, i.e we have to find the starting posiiton where the conditions satisfied

    int n = spells.Length;
    int m = potions.Length;
    Array.Sort(potions);
    int[] pairs = new int[n];
    for (int i = 0; i < n; i++)
    {
      int l = 0;
      int r = m - 1;
      while (l <= r)
      {
        int mid = l + (r - l) / 2;
        long product = Convert.ToInt64(spells[i]) * Convert.ToInt64(potions[mid]);
        if (product >= success)
        {
          r = mid - 1;
        }
        else
        {
          l = mid + 1;
        }
      }
      pairs[i] = m - l;
    }

    return pairs;
  }
}
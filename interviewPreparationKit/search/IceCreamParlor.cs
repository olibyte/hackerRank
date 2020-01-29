using System;
using System.Collections.Generic;
using System.Linq;

internal class Solution
{

    // Complete the whatFlavors function below.
    private static void whatFlavors(int[] cost, int money)
    {
        Dictionary dicIndexes = new Dictionary<int, int>();

        int currentCost;

        for(int i = 0; i < cost.Length; i++)
        {
            currentCost = cost[i];
            if(dicIndexes.TryGetValue(money - currentCost, out int index) && index != i)
            {
                Console.WriteLine(string.Format("{0} {1}", (dicIndexes[money - currentCost] + 1), (i + 1)));
                return;
            }
            else
            {
                dicIndexes[currentCost] = i;
            }
        }
       
    }

    

    private static void Main(string[] args)
    {
        var t = Convert.ToInt32(Console.ReadLine());

        for (var tItr = 0; tItr < t; tItr++)
        {
            var money = Convert.ToInt32(Console.ReadLine());
            var n = Convert.ToInt32(Console.ReadLine());
            var costsArr = Console.ReadLine().Split(' ').Where(v => !string.IsNullOrEmpty(v)).ToArray();
            var cost = Array.ConvertAll(costsArr, costTemp => Convert.ToInt32(costTemp));
            whatFlavors(cost, money);
        }
    }

    private class CostIndexSorter : IComparer<CostAndIndex>
    {
        public int Compare(CostAndIndex x, CostAndIndex y) => x.Cost.CompareTo(y.Cost);
    }
}
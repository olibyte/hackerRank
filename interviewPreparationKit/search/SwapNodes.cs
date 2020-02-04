using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    public class Node
    {
        public int Key { get; set; }

        public Node Root { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public int Height { get; set; }
    }

    static int[][] SwapNodes(int[][] indexes, int[] queries)
    {
        var root = GetTree(indexes);

        var inOrderTraverses = new List<int[]>();
        foreach (var query in queries)
        {
            SwapNodes(root, query);
            var inOrderTraverse = GetInOrderTraverse(root);
            inOrderTraverses.Add(inOrderTraverse);
        }

        return inOrderTraverses.ToArray();
    }

    private static void SwapNodes(Node root, int queryLevel)
    {
        var stack = new Stack<Node>();
        root.Height = 1;
        stack.Push(root);
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            var nextHeight = node.Height + 1;
            if (node.Height % queryLevel == 0)
            {
                SwapNodes(node);
            }

            if (node.Right != null)
            {
                node.Right.Height = nextHeight;
                stack.Push(node.Right);
            }

            if (node.Left != null)
            {
                stack.Push(node.Left);
                node.Left.Height = nextHeight;
            }
        }
    }

    private static void SwapNodes(Node node)
    {
        var left = node.Left;
        node.Left = node.Right;
        node.Right = left;
    }

    private static int[] GetInOrderTraverse(Node rootNode)
    {
        var inOrderTraverse = new List<int>();

        var stack = new Stack<Node>();
        var node = rootNode;

        while (stack.Count > 0 || node != null)
        {
            if (node != null)
            {
                stack.Push(node);
                node = node.Left;
            }
            else
            {
                node = stack.Pop();
                inOrderTraverse.Add(node.Key);
                node = node.Right;
            }
        }

        return inOrderTraverse.ToArray();
    }

    private static Node GetTree(int[][] indexes)
    {
        var nodes = indexes.Select(x => new Node { }).ToArray();

        for (int i = 0; i < indexes.Length; i++)
        {
            var node = nodes[i];
            node.Key = i + 1;

            var leftIndex = indexes[i][0] - 1;
            if (leftIndex > 0)
            {
                node.Left = nodes[leftIndex];
                nodes[leftIndex].Root = node;
            }

            var rightIndex = indexes[i][1] - 1;
            if (rightIndex > 0)
            {
                node.Right = nodes[rightIndex];
                nodes[rightIndex].Root = node;
            }
        }

        return nodes[0];
    }

    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());

        int[][] indexes = new int[n][];

        for (int indexesRowItr = 0; indexesRowItr < n; indexesRowItr++)
        {
            indexes[indexesRowItr] = Array.ConvertAll(Console.ReadLine().Split(' '), indexesTemp => Convert.ToInt32(indexesTemp));
        }

        int queriesCount = Convert.ToInt32(Console.ReadLine());

        int[] queries = new int[queriesCount];

        for (int queriesItr = 0; queriesItr < queriesCount; queriesItr++)
        {
            int queriesItem = Convert.ToInt32(Console.ReadLine());
            queries[queriesItr] = queriesItem;
        }

        int[][] result = SwapNodes(indexes, queries);

        Console.WriteLine(String.Join("\n", result.Select(x => String.Join(" ", x))));
    }
}
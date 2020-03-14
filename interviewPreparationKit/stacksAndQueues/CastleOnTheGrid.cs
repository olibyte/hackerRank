using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
class Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return x.ToString("D10") + y.ToString("D10");
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return GetHashCode().Equals(obj.GetHashCode());
        }
    }
class Solution {

        static Queue<Point> q = new Queue<Point>();
        static Dictionary<Point, int> distanceTo = new Dictionary<Point, int>();
    // Complete the minimumMoves function below.
    static int minimumMoves(string[] grid, int startX, int startY, int goalX, int goalY) {

   int gridSize = grid.Length;

            Point start = new Point(startX, startY);
            Point end = new Point(goalX, goalY);

            q.Enqueue(start);
            distanceTo[start] = 0;
            while (q.Count != 0 && !distanceTo.ContainsKey(end))
            {
                Point p = q.Dequeue();
                int x = p.x;
                int y = p.y;
                int distance = distanceTo[p];

                for (int i = x + 1; i < gridSize && AddPoint(i, y, distance + 1, grid); i++) ;
                for (int i = x - 1; i >= 0 && AddPoint(i, y, distance + 1, grid); i--) ;

                for (int i = y + 1; i < gridSize && AddPoint(x, i, distance + 1, grid); i++) ;
                for (int i = y - 1; i >= 0 && AddPoint(x, i, distance + 1, grid); i--) ;
            }

            return distanceTo[end];
    }
     static bool AddPoint(int x, int y, int distance, string[] grid)
        {
            if (grid[x][y] != '.')
                return false;

            Point p = new Point(x, y);
            if (!distanceTo.ContainsKey(p))
            {
                distanceTo[p] = distance;
                q.Enqueue(p);
            }
            return true;
        }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        string[] grid = new string [n];

        for (int i = 0; i < n; i++) {
            string gridItem = Console.ReadLine();
            grid[i] = gridItem;
        }

        string[] startXStartY = Console.ReadLine().Split(' ');

        int startX = Convert.ToInt32(startXStartY[0]);

        int startY = Convert.ToInt32(startXStartY[1]);

        int goalX = Convert.ToInt32(startXStartY[2]);

        int goalY = Convert.ToInt32(startXStartY[3]);

        int result = minimumMoves(grid, startX, startY, goalX, goalY);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

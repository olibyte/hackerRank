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

class Solution {

    static bool CanPutWord(WordPlaceholder placeholder, string word, List<WordPlaceholder> crossings)
    {
        if (word.Length != placeholder.Length) return false;
        if (crossings == null || !crossings.Any()) return true;
        foreach(var c in crossings)
        {
            if (c.Word == null) continue;
            var crossAt2 = c.CrossWithAt(placeholder);
            var crossAt1 = placeholder.CrossWithAt(c);

            if (word[crossAt1] != c.Word[crossAt2]) return false;
        }
        return true;
    }

    static bool FitWordsRecursive(List<WordPlaceholder> placeholders, List<string> words, Dictionary<WordPlaceholder, List<WordPlaceholder>> crossings) 
    {
        if (words.Count == 0) return true;

        foreach(var p in placeholders)
            foreach(var w in words)
            {
                var c = crossings.ContainsKey(p) ? crossings[p] : null;

                if (CanPutWord(p, w, c))
                {
                    p.Word = w;
                    var result = FitWordsRecursive(placeholders.Where(o => o != p).ToList(), words.Where(o => o != w).ToList(), crossings);
                    if (result) return true;
                }
            }
        return false;
    }

    // Complete the crosswordPuzzle function below.
    static string[] crosswordPuzzle(string[] crossword, string words) 
    {
        var placeholders = new List<WordPlaceholder>();

        // Finding horizontal placeholders
        for (var i = 0; i < crossword.Length; i++) 
        {
            var line = crossword[i];
            var matches = Regex.Matches(line, "-{2,}");
            foreach (Match m in matches)
                placeholders.Add(new WordPlaceholder() {
                    Start = new Point(m.Index, i),
                    End = new Point(m.Index + m.Length - 1, i)
                });
        }

        // Finding vertical placeholders
        for (var i = 0; i < crossword[0].Length; i++)
        {
            var column = string.Join("", crossword.Select(o => o[i]).ToList());
            var matches = Regex.Matches(column, "-{2,}");
            foreach (Match m in matches)
                placeholders.Add(new WordPlaceholder() {
                    Start = new Point(i, m.Index),
                    End = new Point(i, m.Index + m.Length - 1)
                });
        }

        // Pre process all crossings
        var crossings = new Dictionary<WordPlaceholder, List<WordPlaceholder>>();

        foreach (var p1 in placeholders)
            foreach (var p2 in placeholders)
            {
                var crossingAt = p1.CrossWithAt(p2);
                if (crossingAt >= 0)
                {
                    if (!crossings.ContainsKey(p1))
                        crossings[p1] = new List<WordPlaceholder>();
                    crossings[p1].Add(p2);
                }
            }

        var wordsList = words.Split(';').ToList();

        // Call recursive function to find the combination
        var result = false;
        foreach(var p in placeholders)
        {
            foreach(var p2 in placeholders)
                p2.Word = null;
            result = false;

            foreach(var w in wordsList)
            {
                var c = crossings.ContainsKey(p) ? crossings[p] : null;

                if (CanPutWord(p, w, c))
                {
                    p.Word = w;
                    result = FitWordsRecursive(placeholders.Where(o => o != p).ToList(), wordsList.Where(o => o != w).ToList(), crossings);
                    if (result) break;
                }
            }

            if (result) break;
        }

        // Post-process to fill in the blanks
        var resultBoard = new List<string>();
        foreach (var line in crossword)
            resultBoard.Add(line);
        
        foreach (var p in placeholders)
        {
            if (p.Orientation == "H") 
            {
                for (int i = p.Start.X, j = 0; i <= p.End.X; i++, j++)
                {
                    resultBoard[p.Start.Y] = new StringBuilder(resultBoard[p.Start.Y]) 
                    {
                        [i] = p.Word[j]
                    }.ToString();
                }
            }
            else
            {
                for (int i = p.Start.Y, j = 0; i <= p.End.Y; i++, j++)
                {
                    resultBoard[i] = new StringBuilder(resultBoard[i]) 
                    {
                        [p.Start.X] = p.Word[j]
                    }.ToString();
                }
            }
        }

        return resultBoard.ToArray();
    }

    static void Main(string[] args) 
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] crossword = new string [10];

        for (int i = 0; i < 10; i++) 
        {
            string crosswordItem = Console.ReadLine();
            crossword[i] = crosswordItem;
        }

        string words = Console.ReadLine();

        string[] result = crosswordPuzzle(crossword, words);

        textWriter.WriteLine(string.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }

    struct Point 
    {
        public int X, Y;
        public Point(int x, int y) 
        {
            X = x;
            Y = y;
        }
    }

    class WordPlaceholder 
    {
        public Point Start { get; set; }
        public Point End { get; set; }
        public string Word { get; set; }
        public int Length => Math.Max(Math.Abs(Start.X - End.X), Math.Abs(Start.Y - End.Y)) + 1;
        public string Orientation => Start.X == End.X ? "V" : "H";

        public int CrossWithAt(WordPlaceholder p) 
        {
            if (Orientation == p.Orientation) return -1;
            if (Orientation == "H" && Start.Y >= p.Start.Y && Start.Y <= p.End.Y) {
                return p.Start.X - Start.X;
            }
            if (Orientation == "V" && Start.X >= p.Start.X && Start.X <= p.End.X) {
                var crossingPoint = p.Start.Y - Start.Y;
                return crossingPoint < Length ? crossingPoint : -1;
            }
            return -1;
        }

        public override string ToString()
        {
            return $"[({Start.X}, {Start.Y}), ({End.X}, {End.Y})] ({Length}) ({Orientation}) = {Word}";
        }
    }
}
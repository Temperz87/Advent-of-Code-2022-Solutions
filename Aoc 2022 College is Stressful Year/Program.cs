using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TextCopy;

class Program
{
    private static void Main(string[] args)
    {
        Day1();
    }
    
    private static void PrintAnswer(object text)
    {
        ClipboardService.SetText(text.ToString());
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(text.ToString());
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void Print(string text, ConsoleColor color = ConsoleColor.Green)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text.ToString());
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void Day1()
    {
        string[] input = InputGetter.GetStringInputs();
        List<int> allCalories = new List<int>();
        int currentcalorie = 0;
        foreach (string str in input)
        {
            if (str == "")
            {
                allCalories.Add(currentcalorie);
                currentcalorie = 0;
                continue;
            }
            currentcalorie += int.Parse(str);
        }
        allCalories.Add(currentcalorie);
        int max = 0;
        foreach (int i in allCalories)
        {
            if (i > max)
                max = i;
        }
        allCalories.Sort();
        //PrintAnswer(max); for part 1
        PrintAnswer(allCalories[allCalories.Count - 1] + allCalories[allCalories.Count - 2] + allCalories[allCalories.Count - 3]); // for part 2
    }
}

class InputGetter
{
    private const string filePath = @"C:\Users\newid\source\repos\Aoc 2022 College is Stressful Year\Aoc 2022 College is Stressful Year\inputs.txt"; // I can't be bothered to do this properly so uhhhhhhhhhhhhhhhhhhhhhhhhhh
    public static string[] GetStringInputs()
    {

        string[] lines = File.ReadAllLines(filePath);
        return lines;
    }

    public static long[] GetLongInputs()
    {
        string[] lines = File.ReadAllLines(filePath);
        long[] longs = new long[lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            longs[i] = long.Parse(lines[i]);
        }
        return longs;
    }
}

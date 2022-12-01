using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TextCopy;

class Program
{
    private static void printAnswer(object text)
    {
        ClipboardService.SetText(text.ToString());
        Console.WriteLine(text.ToString());
    }


    private static void Main(string[] args)
    {
        Day1();
    }

    private static void Day1()
    {
        string[] input = InputGetter.GetStringInputs();
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

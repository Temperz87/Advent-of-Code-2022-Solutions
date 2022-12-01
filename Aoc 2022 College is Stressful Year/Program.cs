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
    public static string[] GetStringInputs()
    {
        string[] lines = File.ReadAllLines(@"C:\Users\newid\source\repos\AoC 2022 College is Stressful Year\AoC 2022 College is Stressful Year\inputs.txt");
        return lines;
    }

    public static long[] GetLongInputs()
    {
        string[] lines = File.ReadAllLines(@"inputs.txt");
        long[] longs = new long[lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            longs[i] = long.Parse(lines[i]);
        }
        return longs;
    }
}

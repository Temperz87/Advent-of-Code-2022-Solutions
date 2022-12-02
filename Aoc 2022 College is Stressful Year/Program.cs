using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TextCopy;

class Program
{
    private static void Main(string[] args)
    {
        Day2P2();
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

    private static void Day1() // Completed P1 in 2:42 with a rank of 928, P2 in 4:81 wiht a rank of 921
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

    public static void Day2P1() // Completed P1 in 12:48 with a rank of 4581, P2 in 19:30 with a rank of 4345
    {
        string[] inputs = InputGetter.GetStringInputs();
        int score = 0;
        foreach (string s in inputs)
        {
            if (s[0] == 'C' && s[2] == 'X')
                score += 7;
            else if (s[0] == 'A' && s[2] == 'Y')
                score+=8;
            else if (s[0] == 'B' && s[2] == 'Z')
                score+=9;
            else if (s[0] == 'A' && s[2] == 'X')
                score += 4;
            else if (s[0] == 'B' && s[2] == 'Y')
                score += 5;
            else if (s[0] == 'C' && s[2] == 'Z')
                score += 6;
            else // Copilot generated this else at 12:10 am and I have about 2 minutes to wait cuz I spammed answers, is this cheating?
            {
                if (s[2] == 'X')
                    score += 1;
                else if (s[2] == 'Y')
                    score += 2;
                else if (s[2] == 'Z')
                    score += 3;
            }
        }
        PrintAnswer(score);
    }


    public static void Day2P2() // Honestly was easier in the moment to split this day into two functions
    {
        string[] inputs = InputGetter.GetStringInputs();
        int score = 0;
        foreach (string s in inputs)
        {
            if (s[2] == 'X')
            {
                if (s[0] == 'A')
                    score += 3;
                else if (s[0] == 'B')
                    score += 1;
                else
                    score += 2;
            }
            else if (s[2] == 'Y')
            {
                if (s[0] == 'A')
                    score += 4;
                else if (s[0] == 'B')
                    score += 5;
                else
                    score += 6;
            }
            else
            {
                if (s[0] == 'A')
                    score += 8;
                else if (s[0] == 'B')
                    score += 9;
                else
                    score += 7;
            }
        }
        PrintAnswer(score);
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

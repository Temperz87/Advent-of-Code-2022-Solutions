﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TextCopy;

class Program
{
    private static void Main(string[] args)
    {
        Day4P2();
    }

    private static void PrintAnswer(object text) // Prints to console in a funny color and copies said answer to the clipboard so I can save 0.01 seconds 
    {
        ClipboardService.SetText(text.ToString());
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(text.ToString());
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void Print(string text, ConsoleColor color = ConsoleColor.Green) // Just an easy function to Print, as typing Console.WriteLine() takes more time, and also colors are easier to do this way for me
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text.ToString());
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void Day1() // Completed P1 in 2:42 with a rank of 928, P2 in 4:81 with a rank of 921, puzzle was opened in 0:02
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

    public static void Day2P1() // Completed P1 in 12:48 with a rank of 4581, P2 in 19:30 with a rank of 4345, puzzle was opened in 0:03
    {
        string[] input = InputGetter.GetStringInputs();
        int score = 0;
        foreach (string s in input)
        {
            if (s[0] == 'C' && s[2] == 'X')
                score += 7;
            else if (s[0] == 'A' && s[2] == 'Y')
                score += 8;
            else if (s[0] == 'B' && s[2] == 'Z')
                score += 9;
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
        string[] input = InputGetter.GetStringInputs();
        int score = 0;
        foreach (string s in input)
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

    public static void Day3P1() // Completed P1 in 14:04 with a rank of 4705, P2 in 21:03 with a rank of 4089, puzzle was opened in 0:01
    {
        string[] input = InputGetter.GetStringInputs();
        int sum = 0;
        foreach (string str in input)
        {
            string str1 = str.Substring(0, (str.Length) / 2);
            string str2 = str.Substring((str.Length - 1) / 2 + 1);
            Console.WriteLine(str1 + " : " + str2);
            foreach (char c in str1.ToCharArray())
            {
                if (str2.ToCharArray().Contains(c))
                {
                    int toAdd = 0;
                    if (c.ToString().ToUpper() == c.ToString())
                        toAdd += c - 38;
                    else
                        toAdd += c - 96;
                    sum += toAdd;
                    Console.WriteLine("Added " + toAdd);
                    break;
                }
            }
        }
        PrintAnswer(sum);
    }

    public static void Day3P2() // I only did this cuz I realized the writing the parts in the same function after the fact would take a lot of time so I copy pasted the first one and changed it a bit
    {
        string[] input = InputGetter.GetStringInputs();
        int sum = 0;
        for (int i = 0; i < input.Length; i += 3)
        {
            string str1 = input[i];
            string str2 = input[i + 1];
            string str3 = input[i + 2];
            foreach (char c in str1.ToCharArray())
            {
                if (str2.ToCharArray().Contains(c) && str3.ToCharArray().Contains(c))
                {
                    int toAdd = 0;
                    if (c.ToString().ToUpper() == c.ToString())
                        toAdd += c - 38;
                    else
                        toAdd += c - 96;
                    sum += toAdd;
                    break;
                }
            }
        }
        PrintAnswer(sum);
    }

    public static void Day4P1() // Completed P1 in 9:54 with a rank of 4562, P2 in 30:10 wiht a rnak of 9636, puzzle was opened in 0:03
    {
        string[] inputs = InputGetter.GetStringInputs();
        int pair = 0;
        foreach (string str in inputs) {
            string[] split = str.Split(',');
            string[] e1s = split[0].Split("-");
            string[] e2s = split[1].Split("-");
            
            ElfPair e1 = new ElfPair(int.Parse(e1s[0]), int.Parse(e1s[1]));
            ElfPair e2 = new ElfPair(int.Parse(e2s[0]), int.Parse(e2s[1]));
            if ((e1.min <= e2.min && e1.max >= e2.max) || (e2.min <= e1.min && e2.max >= e1.max))
                pair++;
        }
        PrintAnswer(pair);
    }
    public static void Day4P2()
    {
        /* What went wrong for me to take a while?
         * for one, the problem was just harder in general
         * for two, I am shit at boolean stuff, so that sucks
         * for three, I forgot what the question was asking, so I could've finished 5 minutes earlier but last minute I removed the negation if the if statement
         * If I hadn't forgotten what the question was asking, I would've kept the ! in the if statement and been done, simple mistakes like these (and reading better in general) are what I have to work on to do better
        */
        string[] inputs = InputGetter.GetStringInputs();
        int pair = 0;
        foreach (string str in inputs)
        {
            string[] split = str.Split(',');
            string[] e1s = split[0].Split("-");
            string[] e2s = split[1].Split("-");

            ElfPair e1 = new ElfPair(int.Parse(e1s[0]), int.Parse(e1s[1]));
            ElfPair e2 = new ElfPair(int.Parse(e2s[0]), int.Parse(e2s[1]));
            if (!((e1.min < e2.min && e1.max < e2.min) || (e2.min < e1.min && e2.max < e1.min))) // I am losing my mind
            {
                pair++;
                //Print("Solution: " + e1.min + "-" + e1.max + "," + e2.min + "-" + e2.max);
            }
            //else
                //Print("Wrong: " + e1.min + "-" + e1.max + "," + e2.min + "-" + e2.max, ConsoleColor.Magenta);
        }
        PrintAnswer(pair);
    }

    public class ElfPair
    {
        public int max;
        public int min;
        public ElfPair(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
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

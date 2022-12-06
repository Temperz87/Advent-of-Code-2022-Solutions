using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TextCopy;

class Program
{
    private static void Main(string[] args)
    {
        Day6();
    }

    private static void PrintAnswer(object text) // Prints to console in a funny color and copies said answer to the clipboard so I can save 0.01 seconds 
    {
        ClipboardService.SetText(text.ToString());
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(text.ToString());
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void Print(object text, ConsoleColor color = ConsoleColor.Green) // Just an easy function to Print, as typing Console.WriteLine() takes more time, and also colors are easier to do this way for me
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

    public static void Day4P1() // Completed P1 in 9:54 with a rank of 4562, P2 in 30:10 with a rank of 9636, puzzle was opened in 0:03
    {
        string[] inputs = InputGetter.GetStringInputs();
        int pair = 0;
        foreach (string str in inputs)
        {
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

    public static void Day5P1() // Completed P1 in 29:36 with a rank of 5408, P2 in 35:29 with a rank of 5417, puzzle was opened in 0:01
    {
        string[] inputs = InputGetter.GetStringInputs();
        //int sum = 0; // I wrote this line at 11:19 pm, every previous challenge had a sum to print at the end, so ima assume this one will too : I was wrong.....
        List<char>[] allStacks = new List<char>[9]; // I thought it'd be faster not to write something to parse the inputs, but i instead fumbled on parsing them manually so fuck, and I also couldn't use test input, so double fuck

        List<char> stack0 = new List<char>();
        stack0.Add('F');
        stack0.Add('H');
        stack0.Add('B');
        stack0.Add('V');
        stack0.Add('R');
        stack0.Add('Q');
        stack0.Add('D');
        stack0.Add('P');
        allStacks[0] = stack0;
        stack0.Reverse();

        List<char> stack1 = new List<char>();
        stack1.Add('L');
        stack1.Add('D');
        stack1.Add('Z');
        stack1.Add('Q');
        stack1.Add('W');
        stack1.Add('V');
        allStacks[1] = stack1;
        stack1.Reverse();

        List<char> stack2 = new List<char>();
        stack2.Add('H');
        stack2.Add('L');
        stack2.Add('Z');
        stack2.Add('Q');
        stack2.Add('G');
        stack2.Add('R');
        stack2.Add('P');
        stack2.Add('C');
        allStacks[2] = stack2;
        stack2.Reverse();

        List<char> stack3 = new List<char>();
        stack3.Add('R');
        stack3.Add('D');
        stack3.Add('H');
        stack3.Add('F');
        stack3.Add('J');
        stack3.Add('V');
        stack3.Add('B');
        allStacks[3] = stack3;
        stack3.Reverse();

        List<char> stack4 = new List<char>();
        stack4.Add('Z');
        stack4.Add('W');
        stack4.Add('L');
        stack4.Add('C');
        allStacks[4] = stack4;
        stack4.Reverse();

        List<char> stack5 = new List<char>();
        stack5.Add('J');
        stack5.Add('R');
        stack5.Add('P');
        stack5.Add('N');
        stack5.Add('T');
        stack5.Add('G');
        stack5.Add('V');
        stack5.Add('M');
        allStacks[5] = stack5;
        stack5.Reverse();

        List<char> stack6 = new List<char>();
        stack6.Add('J');
        stack6.Add('R');
        stack6.Add('L');
        stack6.Add('V');
        stack6.Add('M');
        stack6.Add('B');
        stack6.Add('S');
        allStacks[6] = stack6;
        stack6.Reverse();

        List<char> stack7 = new List<char>();
        stack7.Add('D');
        stack7.Add('P');
        stack7.Add('J');
        allStacks[7] = stack7;
        stack7.Reverse();

        List<char> stack8 = new List<char>();
        stack8.Add('D');
        stack8.Add('C');
        stack8.Add('N');
        stack8.Add('W');
        stack8.Add('V');
        allStacks[8] = stack8;
        stack8.Reverse();

        for (int i = 10; i < inputs.Length; i++)
        {
            string input = inputs[i];
            Print(input);
            int toMove = int.Parse(input.Substring(input.IndexOf("move ") + 5, input.IndexOf(" from") - 5).Trim());
            int from = int.Parse(input.Substring(input.IndexOf("from ") + 5, input.IndexOf(" to") - input.IndexOf("from ") - 5).Trim());
            int to = int.Parse(input.Substring(input.IndexOf("to ") + 3).Trim());
            Print(toMove + " : " + from + " : " + to);
            for (int j = 0; j < toMove; j++)
            {
                //Print("moved");
                char c = allStacks[from - 1][0];
                allStacks[from - 1].RemoveAt(0);
                allStacks[to - 1].Insert(0, c);
            }
        }
        String answer = "";
        for (int i = 0; i < 9; i++)
            if (allStacks[i].Count() > 0)
                answer += allStacks[i][0].ToString();
        PrintAnswer(answer);
    }

    public static void Day5P2() // This day was when shit got real, like day 5 was WAY harder than the last day, as of writing half of the people have a gold star on day 5 than did on day 4, and about 1/4 compared to day 1
    {
        string[] inputs = InputGetter.GetStringInputs();
        List<char>[] allStacks = new List<char>[9];

        List<char> stack0 = new List<char>();
        stack0.Add('F');
        stack0.Add('H');
        stack0.Add('B');
        stack0.Add('V');
        stack0.Add('R');
        stack0.Add('Q');
        stack0.Add('D');
        stack0.Add('P');
        allStacks[0] = stack0;
        stack0.Reverse();

        List<char> stack1 = new List<char>();
        stack1.Add('L');
        stack1.Add('D');
        stack1.Add('Z');
        stack1.Add('Q');
        stack1.Add('W');
        stack1.Add('V');
        allStacks[1] = stack1;
        stack1.Reverse();

        List<char> stack2 = new List<char>();
        stack2.Add('H');
        stack2.Add('L');
        stack2.Add('Z');
        stack2.Add('Q');
        stack2.Add('G');
        stack2.Add('R');
        stack2.Add('P');
        stack2.Add('C');
        allStacks[2] = stack2;
        stack2.Reverse();

        List<char> stack3 = new List<char>();
        stack3.Add('R');
        stack3.Add('D');
        stack3.Add('H');
        stack3.Add('F');
        stack3.Add('J');
        stack3.Add('V');
        stack3.Add('B');
        allStacks[3] = stack3;
        stack3.Reverse();

        List<char> stack4 = new List<char>();
        stack4.Add('Z');
        stack4.Add('W');
        stack4.Add('L');
        stack4.Add('C');
        allStacks[4] = stack4;
        stack4.Reverse();

        List<char> stack5 = new List<char>();
        stack5.Add('J');
        stack5.Add('R');
        stack5.Add('P');
        stack5.Add('N');
        stack5.Add('T');
        stack5.Add('G');
        stack5.Add('V');
        stack5.Add('M');
        allStacks[5] = stack5;
        stack5.Reverse();

        List<char> stack6 = new List<char>();
        stack6.Add('J');
        stack6.Add('R');
        stack6.Add('L');
        stack6.Add('V');
        stack6.Add('M');
        stack6.Add('B');
        stack6.Add('S');
        allStacks[6] = stack6;
        stack6.Reverse();

        List<char> stack7 = new List<char>();
        stack7.Add('D');
        stack7.Add('P');
        stack7.Add('J');
        allStacks[7] = stack7;
        stack7.Reverse();

        List<char> stack8 = new List<char>();
        stack8.Add('D');
        stack8.Add('C');
        stack8.Add('N');
        stack8.Add('W');
        stack8.Add('V');
        allStacks[8] = stack8;
        stack8.Reverse();

        for (int i = 10; i < inputs.Length; i++)
        {
            string input = inputs[i];
            Print(input);
            int toMove = int.Parse(input.Substring(input.IndexOf("move ") + 5, input.IndexOf(" from") - 5).Trim());
            int from = int.Parse(input.Substring(input.IndexOf("from ") + 5, input.IndexOf(" to") - input.IndexOf("from ") - 5).Trim());
            int to = int.Parse(input.Substring(input.IndexOf("to ") + 3).Trim());
            Print(toMove + " : " + from + " : " + to);
            List<char> toReverse = new List<char>();
            for (int j = 0; j < toMove; j++)
            {
                char c = allStacks[from - 1][0];
                allStacks[from - 1].RemoveAt(0);
                toReverse.Add(c);
            }
            toReverse.Reverse();
            foreach (char c in toReverse)
            {
                allStacks[to - 1].Insert(0, c);
            }
        }
        String answer = "";
        for (int i = 0; i < 9; i++)
            if (allStacks[i].Count() > 0)
                answer += allStacks[i][0].ToString();
        PrintAnswer(answer);
    }

    public static void Day6() // Completed P1 in 13:53 with a rank of 8668, P2 in 20:22 with a rank of 9773, puzzle was opened in 0:02
    {
        // I read the question wrong like 5 times so this was harder than it had to be, this is probably the easiest puzzle so far
        string inputs = InputGetter.GetStringInput();
        // I'm not predicting a sum here, so no int sum (written at 12:42 am on December 5th)
        for (int i = 13; i < inputs.Length; i++)
        {
            List<char> allChars = new List<char>();
            bool multipleOccurences = false;
            for (int j = i; j >= i - 13; j--)
                allChars.Add(inputs[j]);
            foreach (char c in allChars)
            {
                int all = 0;
                foreach (char d in allChars)
                    if (d == c)
                        all++;
                if (all > 1)
                {
                    multipleOccurences = true;
                    break;
                }
            }
            if (!multipleOccurences)
            {
                PrintAnswer(i + 1);
                return;
            }
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
    public static string GetStringInput()
    {
        string lines = File.ReadAllText(filePath);
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

using System;

namespace MyClassLibrary;

public static class LevenshteinDistance
{
    public static int Calculate(string ftWord, string secWord)
    {
        int ftLen = ftWord.Length;
        int secLen = secWord.Length;

        var matrix = new int[ftLen + 1, secLen + 1];

        for (int i = 0; i <= ftLen; ++i) matrix[i, 0] = i;

        for (int i = 0; i <= secLen; ++i) matrix[0, i] = i;

        for (int i = 1; i <= ftLen; ++i)
        {
            for (int j = 1; j <= secLen; ++j)
            {
                int cost = ftWord[i - 1] == secWord[j - 1] ? 0 : 1;

                int deletion = matrix[i - 1, j] + 1;
                int insertion = matrix[i, j - 1] + 1;
                int substitution = matrix[i - 1, j - 1] + cost;

                matrix[i, j] = Math.Min(Math.Min(deletion, insertion), substitution);
            }
        }

        return matrix[ftLen, secLen];
    }

    public static void Main()
    {
        System.Console.WriteLine(Calculate("слово", "строка"));
        System.Console.WriteLine(Calculate("кот", "кит"));
        System.Console.WriteLine(Calculate("", "привет"));
        System.Console.WriteLine(Calculate("hello", "hello"));
    }
}

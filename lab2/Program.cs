using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        // Прочитати текст з файлу
        string text = File.ReadAllText("input.txt");

        Console.WriteLine(text);

        List<string> arrayOfWords = new List<string>();
        List<string> arrayOfSpaces = new List<string>();

        StringBuilder word = new StringBuilder();
        StringBuilder spaces = new StringBuilder();

        for (int i = 0; i < text.Length - 1; i++)
        {
            if (text[i] != ' ')
            {
                if (text[i + 1] == ' ')
                {
                    word.Append(text[i]);
                    arrayOfWords.Add(word.ToString());
                    word.Clear();
                }
                else
                {
                    word.Append(text[i]);
                }
            }
            else
            {
                if (text[i + 1] != ' ')
                {
                    spaces.Append(text[i]);
                    arrayOfSpaces.Add(spaces.ToString());
                    spaces.Clear();
                }
                else
                {
                    spaces.Append(text[i]);
                }
            }
        }


        if (text[text.Length - 1] != ' ') {
            word.Append(text[text.Length - 1]);
        } else {
            spaces.Append(text[text.Length - 1]);
        }

        Console.WriteLine(word.ToString());


        if (word.ToString().Length > 0) {
            arrayOfWords.Add(word.ToString());
        }

        if (spaces.ToString().Length > 0) {
            arrayOfSpaces.Add(spaces.ToString());
        }


        int longestWordIndex = FindLongestWordIndex(arrayOfWords);
        string longestWord = arrayOfWords[longestWordIndex];

        // Замінити букви в найдовшому слові наступними за алфавітом
        string replacedWord = ReplaceLetters(longestWord);

        // Замінити найдовше слово на нове за тим самим індексом
        arrayOfWords[longestWordIndex] = replacedWord;

        // Відсортувати всі слова в алфавітному порядку
        arrayOfWords.Sort();

        Console.WriteLine(arrayOfWords.Count);
        Console.WriteLine(arrayOfSpaces.Count);


        // Записати результати у файл
        using (StreamWriter writer = new StreamWriter("output.txt"))
        {
            for (int i = 0; i < arrayOfWords.Count; i++)
            {
                string wordName = arrayOfWords[i];
                if (i <= arrayOfSpaces.Count - 1) {
                    writer.Write(wordName + arrayOfSpaces[i]);
                } else {
                    writer.Write(wordName);
                }
            }
        }

        // Вивести результати на екран
        Console.WriteLine("Замінений текст:");
        foreach (string wordValue in arrayOfWords)
        {
            Console.WriteLine(wordValue);
        }
    }

    static int FindLongestWordIndex(List<string> words)
    {
        int longestWordIndex = 0;
        int maxLength = 0;

        for (int i = 0; i < words.Count; i++)
        {
            if (words[i].Length > maxLength)
            {
                maxLength = words[i].Length;
                longestWordIndex = i;
            }
        }

        return longestWordIndex;
    }

    static string ReplaceLetters(string word)
    {
        char[] letters = word.ToCharArray();

        for (int i = 0; i < letters.Length; i++)
        {
            if (char.IsLetter(letters[i]))
            {
                if (letters[i] == 'Z')
                {
                    letters[i] = 'A';
                }
                else if (letters[i] == 'z')
                {
                    letters[i] = 'a';
                }
                else
                {
                    letters[i]++;
                }
            }
        }

        return new string(letters);
    }
}

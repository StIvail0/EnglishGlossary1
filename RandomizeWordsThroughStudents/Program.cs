using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RandomizeWordsThroughStudents
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string filePath = @"C:\Users\Ivailo\Downloads\EnglishGlossary-master\EnglishGlossary-master\ReadyToUseTextFiles\book1.txt";
            List<string> words = new List<string>();
            words = File.ReadAllLines(filePath).ToList();

            //shuffle the list
            words = words.OrderBy(i => Guid.NewGuid()).ToList();

            var studentNumbWithWords = new Dictionary<int, List<string>>();
            while (words.Count != 0)
            {
                for (int i = 1; i <= 24; i++)
                {
                    //first time we go thorught the for we create the dictinary keys
                    if (!studentNumbWithWords.ContainsKey(i))
                    {
                        studentNumbWithWords.Add(i, new List<string>());
                    }
                    //we check if count doesnt equal to 0 because of an eror that makes the words[index] negative
                    if (words.Count != 0)
                    {
                        //we start at the of the list and everytime we add and remove the word
                        studentNumbWithWords[i].Add(words[words.Count - 1]);
                        words.RemoveAt(words.Count - 1);
                    }
                }
            }

            string fileName = @"C:\Users\Ivailo\Downloads\EnglishGlossary-master\EnglishGlossary-master\SortedLists\StudentNumbAndWords.txt";

            var file = new FileStream(fileName, FileMode.OpenOrCreate);
            var standardOutput = Console.Out;

            using (var writer = new StreamWriter(file))
            {
                foreach (var student in studentNumbWithWords)
                {
                    Console.SetOut(writer);
                    Console.WriteLine($"Student number: {student.Key}");
                    Console.WriteLine(($"Words: {String.Join(", ", student.Value)}"));
                    Console.WriteLine("");
                    Console.SetOut(standardOutput);
                }
            }
        }
    }
}
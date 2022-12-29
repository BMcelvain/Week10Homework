using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Week10Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CalculateAverageAndSumOfSequence();
            //CalculateMajorantOfArray();
            //CountOccurencesInArray();
            //RemoveOddOccurencesInArray();
            FileWordOccurences();
        }

        static void CalculateAverageAndSumOfSequence()
        {
            List<int> userNumbers = new List<int>();

            while (true)
            {
                Console.WriteLine("Please enter some positive integers or leave blank to end:");
                var userResponse = Console.ReadLine();

                try
                {
                    int userNumber = int.Parse(userResponse);
                    userNumbers.Add(userNumber);
                }
                catch
                {
                    if (userResponse.Equals(""))
                    {
                        Console.WriteLine("Average of sequence: {0}", userNumbers.Sum() / userNumbers.Count());
                        Console.Write("Sum of sequence: {0}", userNumbers.Sum());
                        System.Environment.Exit(0);
                    }
                    else if (userNumbers.Count() == 0)
                    {
                        Console.WriteLine("Please enter an integer or leave it blank to exit.");
                    }
                }
            }
        }

        static void CalculateMajorantOfArray()
        {
            int[] defaultArray = {2, 2, 3, 3, 2, 3, 4, 3, 3};
            Dictionary<int, int> totalIntCountInArray = new Dictionary<int, int>();

            foreach (int number in defaultArray) 
            {
                try
                {
                    totalIntCountInArray[number]++;
                } catch
                {
                    totalIntCountInArray.Add(number, 1);
                }
            }

            List<int> majorants =  new List<int>();
            foreach (KeyValuePair<int, int> kvp in totalIntCountInArray) 
            {
                if(kvp.Value >= (defaultArray.Length/2) + 1) 
                {
                    majorants.Add(kvp.Key);
                }
            }

            if (majorants.Count > 0) 
            {
                foreach(int number in majorants)
                {
                    Console.WriteLine("Majorant(s): {0}", number);
                }
            }
            else
            {
                Console.WriteLine("The majorant does not exist!");
            }
        }

        static void CountOccurencesInArray()
        {
            int[] defaultArray = { 3, 4, 2, 3, 3, 4, 3, 2 };
            Dictionary<int, int> totalIntCountInArray = new Dictionary<int, int>();

            foreach (int number in defaultArray)
            {
                try
                {
                    totalIntCountInArray[number]++;
                }
                catch
                {
                    totalIntCountInArray.Add(number, 1);
                }
            }

            foreach (KeyValuePair<int, int> kvp in totalIntCountInArray)
            {
                Console.WriteLine("Number of {0}s are {1}.", kvp.Key, kvp.Value);
            }
        }

        static void RemoveOddOccurencesInArray()
        {
            int[] defaultArray = { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2, 6, 6, 6};
            Dictionary<int, int> totalIntCountInArray = new Dictionary<int, int>();

            foreach (int number in defaultArray)
            {
                try
                {
                    totalIntCountInArray[number]++;
                }
                catch
                {
                    totalIntCountInArray.Add(number, 1);
                }
            }

            List<int> numbersWithOddNumOfOccurences = new List<int>();
            foreach (KeyValuePair<int, int> kvp in totalIntCountInArray)
            {
                if (kvp.Value%2 != 0) 
                { 
                    numbersWithOddNumOfOccurences.Add(kvp.Key);
                }
            }

            foreach (int number in numbersWithOddNumOfOccurences)
            {
                defaultArray = defaultArray.Where(val => val != number).ToArray();
            }

            foreach (int number in defaultArray)
            {
                Console.WriteLine(number);
            }
        }

        static void FileWordOccurences()
        {
            string fileName = "words.txt";
            if (File.Exists(fileName))
            { 
                StreamReader textFile = new StreamReader(fileName);

                string fileLine;
                string[] lineWords;
                Dictionary<string, int> wordCount= new Dictionary<string, int>();

                while ((fileLine = textFile.ReadLine()) != null)
                {
                    fileLine = RemovePunctuation(fileLine);
                    fileLine = fileLine.ToLower();
                    lineWords = fileLine.Split(" ");

                    foreach (string word in lineWords)
                    {
                        try
                        {
                            wordCount[word]++;
                        }
                        catch
                        {
                            wordCount.Add(word, 1);
                        }
                    }
                }

                textFile.Close();

                var orderedDictionary = from word in wordCount orderby word.Value ascending select word;
                foreach (KeyValuePair<string, int> kvp in orderedDictionary)
                {
                    if (kvp.Key != "")
                    {
                        Console.WriteLine("{0} appeared {1} times.", kvp.Key, kvp.Value);
                    }
                }
            }
        }

        static string RemovePunctuation(string fileLine)
        {
            var makeString = new StringBuilder();

            foreach (char character in fileLine)
            {
                if (!char.IsPunctuation(character) && !char.IsSymbol(character))
                {
                    makeString.Append(character);
                }
            }

            return makeString.ToString();
        }
    }
}

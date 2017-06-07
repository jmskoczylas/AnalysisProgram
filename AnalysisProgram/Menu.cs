using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisProgram
{
    class Menu
    {
        // MAIN MENU.
        public void ShowMenu()
        {
            Console.WriteLine("******************************* ANALYSIS PROGRAM *******************************");
            Console.WriteLine("1. Do you want to enter the text via the keyboard?");
            Console.WriteLine("2. Do you want to read in the text from a file?");
            Console.WriteLine("\n*************************** Choose apropriate option ***************************");
        }

        // ERROR MESSAGE.
        public void WrongChoice()
        {
            Console.WriteLine("\nError! You need to choose between option \"1\" or \"2\".");
            Console.WriteLine("\nPlease try again...\n");
        }

        // USER CHOICE SEQUENCE.
        public int UserChoice(int userChoice)
        {
            // Loop continues untill user choice is either '1' or '2'.
            do
            {
                Console.Write("Your choice is: ");
                try
                {   
                    // Read user input and convert it to integer.
                    userChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid value entered!");
                }
            // Boolean condition for loop above.
            } while (userChoice > 2 && userChoice < 1);
            return userChoice;
        }

        // ENTRY HEADER.
        public void EntryHeader()
        {
            Console.WriteLine("\n________________________________ Enter the text ________________________________");
            Console.WriteLine("In order to end editing, enter \"*\" at the end of last sentence.\n");
        }

        // SHOW ARTICLE PROVIDED BY USER.
        public void ShowEntry(string article)
        {
            Console.WriteLine("\n********************************* Your Article *********************************");
            Console.WriteLine(article.Trim());
        }

        // DISPLAY RESULTS OF ANALYSIS.
        public void ShowAnalysis(
                int sentenceCount, 
                int vowelCount,
                int constantCount,
                int upperCaseCount,
                int lowerCaseCount,
                Dictionary<char, int> SingleCharacterWithCounter,
                Dictionary<char,double> LetterFrequency
            )
        {
            Console.WriteLine("\n*********************************** Analysis ***********************************");
            Console.WriteLine("Sentence count:\t\t{0}", sentenceCount);
            Console.WriteLine("Vowel count:\t\t{0}", vowelCount);
            Console.WriteLine("Constant count:\t\t{0}", constantCount);
            Console.WriteLine("Upper case letters:\t{0}", upperCaseCount);
            Console.WriteLine("Lower case letters:\t{0}", lowerCaseCount);
            Console.WriteLine("\n........................... individual letter count: ...........................");
            Console.WriteLine("\n======= Letter: ======= Count: ======= Frequency: ==============================");
            // Iterate through Dictionary provided as parameter.
            foreach (char character in SingleCharacterWithCounter.Keys)
            {
                    // Display only characters used in the text at least once.
                    if (SingleCharacterWithCounter[character] != 0)
                    {
                    Console.WriteLine("\t{0}\t\tx{1}\t\t{2:F2}%\n"
                    // Character.
                    ,character
                    // Count.
                    ,SingleCharacterWithCounter[character]
                    // Precentage frequency.
                    ,LetterFrequency[character]);
                    }
            }
            Console.WriteLine("================================================================================");
        }

        // MOST FREQUENTLY USED WORDS.
        public void MostFrequentWords(Dictionary<string,int> WordsWithCountDictionary, Dictionary<string,double> WordFrequency)
        {
            Console.WriteLine("\n************************** Most frequently used words **************************");
            Console.WriteLine("\n======= Letter: =============== Count: ======= Frequency: ======================");
            // LINQ used to present Dictionary with words used in article, ordered by their value (count).
            var orderedWordsWithCount = from pair in WordsWithCountDictionary
                        // All words with more than 2 letters.
                        where pair.Key.Length >= 3
                        // Set in descending oreder using value as determinant.
                        orderby pair.Value descending
                        select pair;
            // Loop used to display contents of Dictionary used in parameters.
            foreach (var item in orderedWordsWithCount.Take(10))
            {
                if (item.Key.Length > 6)
                {
                    Console.WriteLine("\t{0}\t\tx{1}\t\t{2:F2}%\n", item.Key, item.Value, WordFrequency[item.Key]);
                }
                else
                {
                    Console.WriteLine("\t{0}\t\t\tx{1}\t\t{2:F2}%\n", item.Key, item.Value, WordFrequency[item.Key]);
                }
            }
            Console.WriteLine("================================================================================");
        }

        // DISPLAYS OUTCOME FOR MOOD MODULE.
        public void ShowMood(bool isPositive)
        {
            Console.WriteLine("\n************************************* Mood *************************************");
            if (isPositive)
            {
                Console.WriteLine("Mood of the text is POSITIVE!");
            }
            else
            {
                Console.WriteLine("Mood of the text is NEGATIVE!");
            }
            Console.WriteLine("\n********************************************************************************");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AnalysisProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Menu choice variable.
            int choice=0;
            // Article used for analysis.
            string article = "";

            // Menu object.
            Menu myMenu = new Menu();
            // Analysis object.
            Analysis myAnalysis = new Analysis(article);
            // Article read from outside document object.
            External ExternalArticle = new External();

            // Show menu on top of the program.
            myMenu.ShowMenu();

            try
            {
                // Loop will continue to perform code below untill "int choice" is equal to '1' or '2'.
                do
                {
                    // Looped menu choice segment. Continues until receives either '1' or '2'.
                    choice = myMenu.UserChoice(choice);

                    // Menu options.
                    switch (choice)
                    {
                        case 1:
                            // Show header.
                            myMenu.EntryHeader();
                            // Allows user to enter their own text.
                            myAnalysis.AddEntry();
                            // Displays article entered by user.
                            myMenu.ShowEntry(myAnalysis.Article);
                            // Perform basic analysis.
                            myMenu.ShowAnalysis(
                                // Sentence count.
                                myAnalysis.SentenceCount,
                                // Vowel count.
                                myAnalysis.VowelCount,
                                // Constant count.
                                myAnalysis.ConstantCount,
                                // Upper case letters count.
                                myAnalysis.UpperCaseCount,
                                // Lower case letters count.
                                myAnalysis.LowerCaseCount,
                                // Single letters count.
                                myAnalysis.SingleLetterWithCounter,
                                // Single leter frequency.
                                myAnalysis.LetterFrequencyPrecentage
                                );
                            // Displays top 10 most frequently used words in article,
                            // that are at least 3 letters long and shows both count
                            // and precentage frequency in the text.
                            myMenu.MostFrequentWords(
                                myAnalysis.CleanWordWithCount,
                                myAnalysis.SingleWordPrecentageFrequency
                                );
                            // Write all words over seven characters long into separate file.
                            myAnalysis.WriteWords();
                            // Displays result of text positivity analysis.
                            myMenu.ShowMood(myAnalysis.CheckIfPositive);
                            break;
                        case 2:
                            // Set external document as parameter for myAnalysis object.
                            myAnalysis = new Analysis(ExternalArticle.ReadText);
                            // Perform basic analysis.
                            myMenu.ShowAnalysis(
                                // Sentence count.
                                myAnalysis.SentenceCount,
                                // Vowel count.
                                myAnalysis.VowelCount,
                                // Constant count.
                                myAnalysis.ConstantCount,
                                // Upper case letters count.
                                myAnalysis.UpperCaseCount,
                                // Lower case letters count.
                                myAnalysis.LowerCaseCount,
                                // Single letters count.
                                myAnalysis.SingleLetterWithCounter,
                                // Single leter frequency.
                                myAnalysis.LetterFrequencyPrecentage                                
                                );
                            // Displays top 10 most frequently used words in article,
                            // that are at least 3 letters long and shows both count
                            // and precentage frequency in the text.
                            myMenu.MostFrequentWords(
                                myAnalysis.CleanWordWithCount,
                                myAnalysis.SingleWordPrecentageFrequency
                                );
                            // Write all words over seven characters long into separate file.
                            myAnalysis.WriteWords();
                            // Displays result of text positivity analysis.
                            myMenu.ShowMood(myAnalysis.CheckIfPositive);
                            break;
                        default:
                            // In case of any other choice than '1' or '2',
                            // Outputs custom message.
                            myMenu.WrongChoice();
                            break;
                    }
                // Boolean condition for loop above.
                } while (choice > 2 || choice < 1);
            }
            catch (Exception e)
            {
                // Catch and display message for all possible exceptions.
                Console.WriteLine(e.Message);
            }
        }
    }
}

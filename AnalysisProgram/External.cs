using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AnalysisProgram
{
    class External
    {
        public string ReadText
        {
            get
            {
                List<string> article = new List<string>();

                // Empty string where each line of text in external document 
                // will be stored.
                string articleConverted = "";

                try
                {
                    // Directory to external document.
                    string dir = System.IO.Path.GetDirectoryName(
                    System.Reflection.Assembly.GetExecutingAssembly().Location);
                    using (StreamReader sr = new StreamReader( dir + @"\document.txt"))
                    {
                        while (sr.EndOfStream != true)
                        {
                            // Loop will continue to add each line of text to a list,
                            // untill end of document is reached.
                            article.Add(sr.ReadLine());
                        }
                        foreach (string textLine in article)
                        {
                            // Loop iterates through created List, outputs each line of text,
                            // and also puts that line into single string for later use.
                            Console.WriteLine(textLine);
                            articleConverted += textLine + " ";
                        }
                        sr.Close();
                    }
                }
                catch (FileNotFoundException e)
                {
                    // Output error message in case of directory problems.
                    Console.WriteLine(e.Message);
                }
                return articleConverted.Trim();
            }
            set
            {
                // String of text iside external article.
                value = ReadText;
            }
        }
    }
}

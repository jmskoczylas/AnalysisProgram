using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AnalysisProgram
{
    class Analysis
    {

        private string article;


        // CONSTRUCTOR
        public Analysis(string myArticle)
        {
            article = myArticle;
        }


        // TEXT ENTERED BY USER.
        public string Article
        {
            get
            {
                return article;
            }
            set
            {
                value = article;
            }
        }


        // LIST OF EACH WORD USED IN THE ARTICLE (WITH ADDITIONAL CHARACTERS AS PART OF EACH WORD - '!','"','.',ETC.).
        public List<string> WordLibrary
        {
            get
            {
                List<string> SingleWord = new List<string>();
                // Iterate through each word in article (separated by 'space' char).
                foreach (string word in article.Split(' '))
                {
                    if (word != "")
                    {
                        // each word in array above is being added into list object as long as it is not empty string.
                        SingleWord.Add(word);
                    }
                }
                return SingleWord;
            }
            set
            {
                // List of all words used in text (with additional characters - '.', '!', '?', etc.).
                value = WordLibrary;
            }
        }


        // USED AS OPTION "1" IN THE MENU. ALLOWS USER TO INPUT THEIR OWN ARTICLE USING CONSOLE.
        // This method performs a loop which reads user input and adds it into global variable - "article" which will be later used for analysis.
        public void AddEntry()
        {
            do
            {
                // Adding user input into existing string (adds space between sentences).
                article = article.Trim() + " " + Console.ReadLine().Trim();
            }
            // Loop breaks if user inputs '*' at the end of the entry.
            while (article[article.Length - 1] != '*');
            // Replace multiple spaces with just one space (in case of user error).
            article = System.Text.RegularExpressions.Regex.Replace(article, @"\s+", " ");
            // Removes '*' char from the string (to make final display more appealing).
            article = article.Remove(article.Length - 1);
        }


        // RETURNS INTEGER EQUAL TO NUMBER OF SENTENCES IN GIVEN ARTICLE.
        public int SentenceCount
        {
            get
            {
                int sentenceCounter = 0;
                foreach (string word in WordLibrary)
                {
                    // checking last char in each word in WordLibrary. 
                    switch (word[word.Length - 1])
                    {
                        // Check if sentence finishes inside quotation marks or inside bracket.
                        case '"':
                        case ')':
                            // Since '"' is a last character in word string, we need to check second to last char.
                            switch (word[word.Length - 2])
                            {
                                // If second to last char is either '!','?' or '.', increase sentenceCounter.
                                case '!':
                                case '.':
                                case '?':
                                    sentenceCounter++;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        // Same logic as above applied if last char in word string is either  '!','?' or '.'.
                        case '.':
                        case '?':
                        case '!':
                            sentenceCounter++;
                            break;
                        default:
                            break;
                    }
                }
                return sentenceCounter;
            }
            set
            {
                // Integer count of all sentences in text.
                value = SentenceCount;
            }
        }


        // RETURNS NUMBER OF VOWELS IN ARTICLE 
        public int VowelCount
        {
            get
            {
                int vowelCounter = 0;

                // Loop iterates through every single character in article.
                for (int i = 0; i < article.Length; i++)
                {
                    // Variable is true when char with index position equal to 'i' can be found in "aeiouAEIOU"
                    // (if char cannot be found in "aeiouAEIOU" - returns -1 and therefore is false).
                    bool isVowel = "aeiouAEIOU".IndexOf(article[i]) >= 0;
                    if (isVowel)
                    {
                        // Each time char is a vowel - increase the counter.
                        vowelCounter++;
                    }
                }
                return vowelCounter;
            }
            set
            {
                // Integer count of all vowels in text.
                value = VowelCount;
            }
        }


        // RETURNS NUMBER OF CONSTANTS IN ARTICLE
        public int ConstantCount
        {
            get
            {
                int constantCounter = 0;

                // loop iterates through every single character in article.
                for (int i = 0; i < article.Length; i++)
                {
                    // Variable is true when char with index position equal to 'i' can be found in "aeiouAEIOU"
                    // (if char cannot be found in "aeiouAEIOU" - returns -1 and therefore is false).
                    bool isConstant = "bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ".IndexOf(article[i]) >= 0;
                    if (isConstant)
                    {
                        // each time char is a constant - increase the counter by 1.
                        constantCounter++;
                    }
                }
                return constantCounter;
            }
            set
            {
                // Integer count of all constants in text.
                value = ConstantCount;
            }
        }


        // RETURNS INTEGER EQUAL TO NUMBER OF UPPERCASE LETTERS IN ARTICLE
        public int UpperCaseCount
        {
            get
            {
                int upperCaseCounter = 0;

                // iterate through every single character in article.
                for (int i = 0; i < article.Length; i++)
                {
                    if (char.IsUpper(article[i]))
                    {
                        // if char with index position 'i' is upper case letter, increase counter by 1.
                        upperCaseCounter++;
                    }
                }
                return upperCaseCounter;
            }
            set
            {
                // Integer count of all upper case letters.
                value = UpperCaseCount;
            }
        }


        // RETURNS INTEGER EQUAL TO NUMBER OF LOWERCASE LETTERS IN ARTICLE
        public int LowerCaseCount
        {
            get
            {
                int lowerCaseCounter = 0;

                // iterate through every single character in article.
                for (int i = 0; i < article.Length; i++)
                {
                    if (char.IsLower(article[i]))
                    {
                        // if char with index position 'i' is lower case letter, increase counter by 1.
                        lowerCaseCounter++;
                    }
                }
                return lowerCaseCounter;
            }
            set
            {
                // Integer count of all lower case letters.
                value = LowerCaseCount;
            }
        }


        // RETURNS DICTIONARY WITH EACH CHARACTER IN TH ARTICLE AND HOW MANY TIMES ITS BEEN USED.
        public Dictionary<char, int> SingleLetterWithCounter
        {
            get
            {
                Dictionary<char, int> letterFrequency = new Dictionary<char, int>();
                for (char i = 'a'; i <= 'z'; i++)
                {
                    // Add letters a-z with value 0 into dictionary (0 is initial letter count in article) - for sorting purpouses.
                    letterFrequency.Add(i, 0);
                }
                // Iterate through every single char in article.
                foreach (char character in article.ToLower())
                {
                    // If statement to weed out all characters other tha a-z.
                    if (character >= 'a' && character <= 'z')
                    {
                        if (letterFrequency.ContainsKey(character))
                        {
                            // Interate value (count) by 1 for each letter in article.
                            letterFrequency[Convert.ToChar(character)]++;
                        }
                    }
                }
                return letterFrequency;
            }
            set
            {
                // Dictionary with all letters used in text and their count.
                value = SingleLetterWithCounter;
            }
        }


        // RETURNS LIST STORING DOUBLES WITH FREQUENCY OF INIVIDUAL CHARACTERS
        public Dictionary<char, double> LetterFrequencyPrecentage
        {
            get
            {
                int letterTotal = 0;
                // Iterate through values (count) iside SingleLetterWithCounter .
                foreach (int count in SingleLetterWithCounter.Values)
                {
                    // Add value to letterTotal.
                    letterTotal += count;
                }
                Dictionary<char, double> LetterFrequencyPrecentage = new Dictionary<char, double>();
                // Iterate through all letters in SignleLetterWithCounter
                foreach (char letter in SingleLetterWithCounter.Keys)
                {
                    // Puts entry into LetterFrequencyPrecentage Dictionary with apropriate letter as key
                    // and frequency of that particular letter in whole article.
                    LetterFrequencyPrecentage.Add(letter, ((double)SingleLetterWithCounter[letter] / (double)letterTotal * 100));
                }
                return LetterFrequencyPrecentage;
            }
            set
            {
                // Dictionary with all letters used in text and their frequency represented in precentage.
                value = LetterFrequencyPrecentage;
            }
        }


        // CLEANS WORDS FROM ADDITIONAL CHARACTERS (quatation marks, dots, question marks,etc.) AND STORES IT IN THE LIST
        public List<string> CleanWordList
        {
            get
            {
                List<string> SingleWordRecycled = new List<string>();
                // As WordLibrary contains each word in article, but
                // along with additional characters (such as '.',')','!',etc.)
                // this loop will iterate through each word...
                foreach (var word in WordLibrary)
                {
                    string wordRecycled = ""; // Variable created to store single, cleaned word.
                    foreach (var letter in word.ToLower())
                    {
                        // If statement set to weed out all those additional characters.
                        if (letter >= 'a' && letter <= 'z')
                        {
                            // Each letter is added into new empty variable.
                            wordRecycled += letter;
                        }
                    }
                    if (wordRecycled != "")
                    {
                        // As long as that variable isn't empty, add it into the list.
                        SingleWordRecycled.Add(wordRecycled);
                    }
                }
                return SingleWordRecycled;
            }
            set
            {
                // List  with all words used in text and cleaned off additional characters.
                value = CleanWordList;
            }
        }


        // COUNTS HOW MANY TIMES EACH WORD IS MENTIONED IN ARTICLE AND STORES IT IN DICTIONARY
        public Dictionary<string, int> CleanWordWithCount
        {
            get
            {
                Dictionary<string, int> CleanedWordCount = new Dictionary<string, int>();
                // Iterates through list of words after getting rid of unwanted characters.
                foreach (var word in CleanWordList)
                {
                    if (CleanedWordCount.ContainsKey(word))
                    {
                        // If word has already been added to Dictionary, increase value (count) by 1.
                        CleanedWordCount[word]++;
                    }
                    else
                    {
                        // Initialy responsible for adding each word to Dictoionary and setting its value to 1.
                        CleanedWordCount[word] = 1;
                    }
                }
                return CleanedWordCount;
            }
            set
            {
                // Dictionary with all words used in text (cleaned off additional characters) and their count.
                value = CleanWordWithCount;
            }
        }


        // DICTIONARY WITH PRECENTAGE FREQUENCY OF EACH WORD MENTIONED IN ARTICLE.
        public Dictionary<string, double> SingleWordPrecentageFrequency
        {
            get
            {
                // Total number of words in article.
                int totalWordNumInText = 0;
                Dictionary<string, double> WordFrequencyPrecentage = new Dictionary<string, double>();
                foreach (string word in CleanWordWithCount.Keys)
                {
                    // Iterate through Dictionary using keys (words) and add integer stored in value (count)
                    // to totalWordNumInText, in order to establish total number of words.
                    totalWordNumInText += CleanWordWithCount[word];
                }
                foreach (var word in CleanWordWithCount.Keys)
                {
                    // Iterate through same Dictionary also using keys, add entry to new Dictionary called
                    // WordFrequencyPrecentage where word is a key and frequency (word count divided by total number of words)
                    // as a value.
                    WordFrequencyPrecentage.Add(word, (double)CleanWordWithCount[word] / (double)totalWordNumInText * 100);
                }
                return WordFrequencyPrecentage;
            }
            set
            {
                // Dictionary with all words used in text and their frequency represented in precentage.
                value = SingleWordPrecentageFrequency;
            }
        }


        // POSITIVE WORD LIST (TWITTER)
        public List<string> PositiveWordList
        {
            get
            {
                List<string> positiveWords = new List<string>();
                // Directory to text document to be read by StreamReader.
                string dir = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location);
                using (StreamReader readList = new StreamReader(dir + @"\positive.txt"))
                {
                    while (readList.EndOfStream != true)
                    {
                        // Loop will continue until it reaches end of text document.
                        // Add whole line of text to the List called positiveWords.
                        positiveWords.Add(readList.ReadLine());
                    }
                }
                return positiveWords;
            }
            set
            {
                // List of positive words in external '.txt' file.
                value = PositiveWordList;
            }
        }


        // DATABASE OF NEGATIVE WORDS (TWITTER LIST)
        public List<string> NegativeWordList
        {
            get
            {
                List<string> negativeWords = new List<string>();
                // Directory to text document to be read by StreamReader.
                string dir = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location);
                using (StreamReader readList = new StreamReader(dir + @"\negative.txt"))
                {
                    while (readList.EndOfStream != true)
                    {
                        // Loop will continue until it reaches end of text document.
                        // Add whole line of text to the List called negativeWords.
                        negativeWords.Add(readList.ReadLine());
                    }
                }
                return negativeWords;
            }
            set
            {
                // List of all negative words in external '.txt' file.
                value = NegativeWordList;
            }
        }


        // RETURNS TOTAL COUNT OF POSITIVE WORDS IN TEXT.
        public int PositiveWordsCount
        {
            get
            {
                // Total positive words count in text.
                int positiveCounter = 0;
                // Iterate through List of all words used in text after cleaning them
                // from all characters other than alphabetic.
                foreach (var word in CleanWordList)
                {
                    if (PositiveWordList.Contains(word))
                    {
                        // Increment total positive words count in text by 1, if word 
                        // can be found in PositiveWordList.
                        positiveCounter++;
                    }
                }
                return positiveCounter;
            }
            set
            {
                // Integer count of positive words in text.
                value = PositiveWordsCount;
            }
        }


        // RETURNS TOTAL COUNT OF NEGATIVE WORDS IN TEXT.
        public int NegativeWordsCount
        {
            get
            {
                // Total negative words count in text.
                int negativeCounter = 0;
                foreach (var word in CleanWordList)
                {
                    // Iterate through List of all words used in text after cleaning them
                    // from all characters other than alphabetic.
                    if (NegativeWordList.Contains(word))
                    {
                        // Increment total positive words count in text by 1, if word 
                        // can be found in NegativeWordList.
                        negativeCounter++;
                    }
                }
                return negativeCounter;
            }
            set
            {
                // Integer count of negative words in text.
                value = NegativeWordsCount;
            }
        }


        // RETURNS NEGATIVE WORDS COUNT TO POSITIVE WORDS COUNT RATIO.
        public double NegativityRatio
        {
            get
            {
                // Calculate negative words to positive words ratio.
                return (double)NegativeWordsCount / (double)(PositiveWordsCount + NegativeWordsCount);
            }
            set
            {
                // Double value - ratio of negative words in text to positive words in text.
                value = NegativityRatio;
            }
        }


        // RETURNS BOOLEAN VALUE OF POSITIVITY OF THE TEXT, BASED ON NEGATIVITY RATIO.
        public bool CheckIfPositive
        {
            get
            {
                // Boolean variable - set to true as default.
                bool isPositive = true;
                if (NegativityRatio > 0.5)
                {
                    // Variable is set to false, only when negativity ratio is over 0.5.
                    isPositive = false;
                }
                return isPositive;
            }
            set
            {
                // Boolean value returning false or true - depending on NegativityRatio.
                value = CheckIfPositive;
            }
        }

        public List<string> WordsOverSeven
        {
            get
            {
                List<string> WordsOverSevenCharLong = new List<string>();
                foreach (string word in CleanWordWithCount.Keys)
                {
                    if (word.Length > 7)
                    {
                        WordsOverSevenCharLong.Add(word);
                    }
                }
                return WordsOverSevenCharLong;
            }
            set
            {
                value = WordsOverSeven;
            }
        }

        public void WriteWords()
        {
                string dir = System.IO.Path.GetDirectoryName(
                    System.Reflection.Assembly.GetExecutingAssembly().Location);
                using (StreamWriter output = new StreamWriter(dir + @"\wordsOverSeven.txt"))
                {
                    foreach (string word in WordsOverSeven)
                    {
                        output.WriteLine(word);
                    }
                }
        }
    }
}

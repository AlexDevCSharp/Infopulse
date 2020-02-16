using System;
using System.IO;

namespace Infopulse
{
    interface ITextExecuter
    {
        void TextChecker();
        bool TextValidation(string text);
        bool TextStreamWriter(string text);
        bool TextStreamReader();
    }

    public class TextExecuter : ITextExecuter
    {
        public void TextChecker()
        {
            bool valid; string text;
            for(; ; )
            {
                text=TextInput();
                valid = TextValidation(text);
                if (valid)
                    break;
            }
            TextStreamWriter(text);
            TextStreamReader();
        }

        private string TextInput()
        {
            Console.WriteLine("Write the text please.");
            string text = Console.ReadLine();
            return text;
        }
        public bool TextValidation(string text)
        {
            string allowedSymbols = "AEIOUYBCDFGHJKLMNPQRSTWVXZ aeiouybcdfghjklmnpqrstwvxz";
            foreach (char item in text)
            {
                int count = 0;
                foreach (char sym in allowedSymbols)
                {
                    if (item != sym)
                        count++;
                    else
                        break;
                }
                if (count == 53)
                {
                    return false;
                }
            }
            return true;
        }

        public bool TextStreamWriter(string text)
        {
            string writePath = @"C:\Users\User\Desktop\Infopulse2.txt";
            bool result = false;
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text);
                    result = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }
        public bool TextStreamReader()
        {
            string path = @"C:\Users\User\Desktop\Infopulse2.txt";
            string textFromFile=null; bool result = false;
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    textFromFile = sr.ReadToEnd();
                    result = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            TextProcess(textFromFile);
            return result;
        }
        
        private void TextProcess(string textFromFile)
        {
            string vowels = "AEIOUaeiou"; int count=0; int space = 1; int countForSpace = 0; int words=0;
            foreach (char item in textFromFile)
            {
                if (item == '\r' || item == '\n')
                {
                    continue;
                }
                if (item == ' ')
                {
                    if (space == 1 && count > 0)
                        words++;
                    space = 1;
                    continue;
                }
                count = 0;
                countForSpace = 0;
                if (space == 0)
                    continue;
                foreach (char ch in vowels)
                {
                    if (item == ch && space==1)
                    {
                        count++;
                        break;
                    }
                    else
                    {
                        countForSpace++;
                    }  
                }
                if (countForSpace == 10)
                {
                    space = 0;
                    count = 0;
                }       
            }
            if (space == 1 && count > 0)
                words++;
            Console.WriteLine($"Count of words in text file that consist of vowels characters only: {words}");
        }
    }
}

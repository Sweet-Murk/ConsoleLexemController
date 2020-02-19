using System.Data.SqlTypes;
using System;
using System.IO;
using NUnit.Framework;

namespace test
{
    class Parser
    {
        private string text;

        public Parser(string path)
        {
            text = File.ReadAllText(Path.Combine(path, "file.txt"));
            Parse(text);
        }
        public int Parse(string text)
        {
            int result = 0;
            int count = 0;
            for(int i = 0;i<text.Length; i++)
            {
                if(text[i] ==' ')
                {
                    if(count == 0) 
                    result++;
                    count = 0;
                }
                else if((text[i] != 'a')&&(text[i] != 'e')&&(text[i] != 'u')&&(text[i] != 'o')&&(text[i] != 'i'))
                {
                    count++;
                }
            }
            Console.WriteLine($"The count of words in the file that consist of vowels characters only: {result}");
            return result;
        }
        }
    }

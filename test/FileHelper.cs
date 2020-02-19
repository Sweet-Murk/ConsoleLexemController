using System;
using System.IO;
using System.Reflection;
using System.Diagnostics;
 
namespace test
{
    public class FileHelper
    {
        private string path;
        public FileHelper()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            path = Uri.UnescapeDataString(uri.Path);
            path = Path.GetDirectoryName(path);
        }
        public String CreateFile()
        {
            Console.WriteLine("FileHelper started the process.");
            if(!File.Exists(Path.Combine(path, "file.txt")))
            {
                StreamWriter file = new StreamWriter(Path.Combine(path, "file.txt"));
                Console.WriteLine("Input the text for a new file if you want:");
                file.Write(Console.ReadLine()+' ');
                file.Close();
                return "The file was created.";
            }
            else throw new Exception("The file was created yet. Just open created file and start to deal with it!");
        }

        public String OpenFile()
        {
            string result;
            try
            {
                result = "The file was opened.";
                Process.Start(Path.Combine(path, "file.txt"));
            }
            catch (Exception)
            {
                result = "The file doesn`t exist, it couldn`t be opened";
            };
            return result;
        }
        
        public void ActionMenu()
        {
            string variant;
            Console.WriteLine("Choose the variant\n1. Create the file\n2. Open the file.\n3. Detect count of words in the file that consist of vowels characters only.\n4. Exit from the program");
            switch (Console.ReadLine())
            {
                case "1":
                    variant = CreateFile();
                    Console.Clear();
                    break;
                case "2":
                    variant = OpenFile();
                    Console.Clear();
                    break;
                case "3":
                    Parser parse = new Parser(path);
                    break;
                case "4":
                    return;
            }
            ActionMenu();
        }      
    }
}
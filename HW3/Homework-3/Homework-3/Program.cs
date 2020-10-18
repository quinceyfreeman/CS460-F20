using System;
using System.IO;

namespace Homework_3
{
    class Program
    {
        private static void PrintUsage()
        {
            Console.WriteLine("Usage is:\n" +
            "\tdotnet run C inputfile outputfile\n\n" +
            "Where:" +
            "  C is the column number to fit to\n" +
            "  inputfile is the input text file \n" +
            "  outputfile is the new output file base name containing the wrapped text.\n" +
            "e.g. dotnet run 72 myfile.txt myfile_wrapped.txt");
        }


        static void Main(string[] args)
        {
            int C = 72;
            string inputFileName;
            string outputFileName = "output.txt";
            StreamReader reader = null;

            if (args.Length != 3)
            {
                PrintUsage();
                Environment.Exit(1);
            }
            try
            {
                C = int.Parse(args[0]);
                inputFileName = args[1];
                outputFileName = args[2];
                reader = new StreamReader(inputFileName);

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Could not find the input file.");
                Environment.Exit(1);
            }
            catch (Exception)
            {
                Console.WriteLine("Something is wrong with the input.");
                PrintUsage();
                Environment.Exit(1);
            }

            IQueueInterface<string> words = new LinkedQueue<string>();
            char[] delimiters = {' ', '\n', '\t', '\r', '\v'};
            string[] fileContent = reader.ReadToEnd().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            int i = 0;
            while (i < fileContent.Length)
            {
                string word = fileContent[i];
                words.Push(word);
                i++;
            }
            reader.Close();
        }
    }
}

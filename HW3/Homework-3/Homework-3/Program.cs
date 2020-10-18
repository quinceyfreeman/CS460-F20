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
            int spacesRemaining = WrapSimply(words, C, outputFileName);
            Console.WriteLine("Total spaces remaining (Greedy): " + spacesRemaining);
        }

        private static int WrapSimply(IQueueInterface<string> words, int columnLength, string outputFilename)
        {
            StreamWriter output;

            try
            {
                output = new StreamWriter(outputFilename);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Cannot create or open " + outputFilename +
                        " for writing.  Using standard output instead.");
                output = new StreamWriter(Console.OpenStandardOutput());
            }

            int col = 1;
            int spacesRemaining = 0;

            while (!words.IsEmpty())
            {
                string str = words.Peek();
                int len = str.Length;

                if (col == 1)
                {
                    output.Write(str);
                    col += len;
                    words.Pop();
                }
                else if ((col + len) >= columnLength)
                {
                    output.WriteLine();
                    spacesRemaining += (columnLength - col) + 1;
                    col = 1;
                }
                else
                {
                    output.Write(" ");
                    output.Write(str);
                    col += (len + 1);
                    words.Pop();
                }
            }
            output.WriteLine();
            output.Flush();
            output.Close();
            return spacesRemaining;
        }
    }
}
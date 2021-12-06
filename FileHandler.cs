using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DNATagger
{
    class FileHandler
    {
        static StreamReader fileReader;



        public static Boolean openFile(String path)
        {
            if (path == null)
            {
                Console.WriteLine("Error: Tried to open unspecified file");
                return false;
            }
            if (!File.Exists(path))
            {
                Console.WriteLine("Error: Could not find file: " + path);
                return false;
            }
            try
            {
                fileReader = File.OpenText(path);
            }
            catch
            {
                Console.WriteLine("Error: Exception while reading from file");
                return false;
            }
            return true;
        }



        public static void closeFile() {
            fileReader.Close();
            fileReader.Dispose();
            fileReader = null;
        }



        public static List<DNASequence> readFasta(String path) {
            List<DNASequence> output = new List<DNASequence>();
            if (openFile(path))
            {
                StringBuilder fastaBlock = new StringBuilder();
                String line;
                if (fileReader.EndOfStream)
                {
                    Console.WriteLine("Warning: Fasta file is empty");
                }
                else
                {
                    while (!fileReader.EndOfStream)
                    {
                        line = fileReader.ReadLine();
                        Console.WriteLine(line);
                        if (line.ToCharArray()[0] == '>')
                        {
                            if (fastaBlock.Length > 0)
                            {
                                output.Add(new DNASequence(fastaBlock.ToString(), src : path));
                                fastaBlock.Clear();
                            }
                            fastaBlock.Append(line + "\n");
                        }
                        else fastaBlock.Append(line);
                    }
                    output.Add(new DNASequence(fastaBlock.ToString(), src : path));
                }
            }
            closeFile();
            return output;
        }
    }
}

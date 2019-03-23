
using System;
using System.IO;
using System.Collections.Generic;

namespace DocumentMerger2
{
    class Program
    {
        static void Main(string[] args)
        {
            int x;
            x = args.Length -1;
            var FileContentString = new List<string>();
            StreamWriter Output = null;
            string OutPutName = "Output";
            string line;
            string FinalFileContents = string.Empty;

            //Used this to check # of arguments supplied to the program
            //Console.WriteLine(args.Length);


            if (args.Length >= 3)
            {

                for (int i = 0;  i <=x; i++) 
                {
                    string arg = args[i];

                    if (i == x)
                    {
                        Output = new StreamWriter(arg);
                        OutPutName = arg;
                    }

                    else
                    {
                        try
                        {
                            StreamReader sr = new StreamReader(arg);
                            line = sr.ReadToEnd();
                            FinalFileContents += line;
                            FileContentString.Add(line);
                            sr.Close();
                        }

                        catch (IOException e)
                        {
                            Console.WriteLine("The file could not be read:");
                            Console.WriteLine(e.Message);
                            Environment.Exit(0);
                        }
                    }
                }

                using (Output)
                {
                    foreach (String s in FileContentString)
                        Output.WriteLine(s);
                        string ListToString = FileContentString.ToString();
                        Console.WriteLine("Merged File is named {0}", OutPutName);
                        Console.WriteLine("It has {0} characters", FinalFileContents.Length); 
                        Output.Close();
                }

            }
     
            else
            {
                Console.WriteLine("Not enough Arguments were provided");
                Console.WriteLine("I Need at least 3 to proceed.");
                Console.WriteLine("This Program will take all Arguments");
                Console.WriteLine("Except the last and use that to merge a file");
                Console.WriteLine("The final Argument will be the merged file's name");
                Console.WriteLine("");
            }
        }
    }       
}

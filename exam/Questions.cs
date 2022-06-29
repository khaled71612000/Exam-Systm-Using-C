using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace exam
{
    class Questions
    {
        string Body { get; set; }
        string Header1 { get; set; }
        string Header2 { get; set; }
        int Mark { get; set; }
       public Questions() { }
        public Questions(string b,  string h , string h2, int m)
        {
            Body = b;
            Header1 = h;
            Header2 = h;
            Mark = m;
        }

       public void questionPrint(FileStream fileStream , string outputfile)
        {
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    outputintoFile(outputfile);
                }
            }
        }

        public void outputintoFile(string fileName)
        {

            FileStream stream = null;
            try
            {
                // Create a FileStream with mode CreateNew  
                stream = new FileStream(fileName, FileMode.OpenOrCreate);
                // Create a StreamWriter from FileStream  
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                {
                        writer.WriteLine(Console.ReadLine().ToLower());
                }
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
            }
        }

    }
}

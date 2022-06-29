using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace exam
{
    class Program
    {
        private static void TimerCallback(Object o)
        {
            Console.WriteLine("You Have 10 minutes From Now " + DateTime.Now);
        }
        static void Main(string[] args)
        {
            Questions q1 = new Questions();
            string outputfile = @"C:\Users\Kspades\OneDrive\Desktop\Student.txt";

            //read file
            var fileStream = new FileStream(@"C:\Users\Kspades\OneDrive\Desktop\ques1.txt", FileMode.Open, FileAccess.Read);
            //print file
            q1.questionPrint(fileStream , outputfile);

            //start timer
             Timer _timer = null;
            _timer = new Timer(TimerCallback, null, 0, 60000);


            //enter answers
            //put answer in file
            string fileName = outputfile;
            q1.outputintoFile(fileName);
            //stop timer
            //compare answers
            int file1byte;
            int file2byte;
            FileStream fs1;
            FileStream fs2;

            // Open the two files.
            fs1 = new FileStream(@"C:\Users\Kspades\OneDrive\Desktop\Student.txt", FileMode.Open);
            fs2 = new FileStream(@"C:\Users\Kspades\OneDrive\Desktop\answer.txt", FileMode.Open);

            // Read and compare a byte from each file until either a
            // non-matching set of bytes is found or until the end of
            // file1 is reached.
            int score = 0;
            do
            {
                // Read one byte from each file.
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
                Console.WriteLine(file1byte);
                if(file1byte == file1byte)
                {
                    score += 10;
                }

            }
            while ((file1byte == file2byte) && (file1byte != -1));

            Console.WriteLine(score);
            // Close the files.
            fs1.Close();
            fs2.Close();
            //print score
            Console.ReadLine();
        }
    }
}

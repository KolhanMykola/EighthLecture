using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EighthLecture
{
    class Names:IStrategyStudentGroup
    {
        private string path;
        private Dictionary<int, Student> studentData;
        private readonly string newLine = Environment.NewLine;

        public Names(string path, Dictionary<int, Student> studentData)
        {
            this.path = path;
            this.studentData = studentData;
        }

        public string Path { get => path; set => path = value; }

        public void Create()
        {
            Console.WriteLine("Hy from Name class");

            string[] inputedPathArray = path.Split('\\');
            string inputedFileName = (inputedPathArray[inputedPathArray.Length - 1]).Split('.')[0];
            string pathForNewFile = null;

            for (int i = 0; i < inputedPathArray.Length - 2; i++)
            {
                pathForNewFile += inputedPathArray[i] + "\\";
            }

            pathForNewFile += "Processed" + "\\" + inputedFileName + "_processed_unique_students.txt";
            FileStream fileStream = File.Create(pathForNewFile);
            byte[] writedArray = Encoding.Default.GetBytes(WritedArray());
            fileStream.Write(writedArray, 0, writedArray.Length);
            fileStream.Close();
            fileStream.Dispose();
        }

        private string WritedArray()
        {
            string write = "";
            Student temps = null;
            string temp = null;

            foreach (var student in studentData)
            {
                temps = student.Value;
                temp = temps.FullName;
                if (!write.Contains(temp))
                {
                    write += student.Key.ToString() + ". " + temp + newLine;
                }                          
            }

            return write;
        }        
    }
}

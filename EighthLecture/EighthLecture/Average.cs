using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EighthLecture
{
    class Average:IStrategyStudentGroup
    {
        private string path;
        private Dictionary<int, Student> studentData;

        public Average(string path, Dictionary<int, Student> studentData)
        {
            this.path = path;
            this.studentData = studentData;
        }

        public string Path { get => path; set => path = value; }

        public void Create()
        {
            Console.WriteLine("Hy from Average class");

            string[] inputedPathArray = path.Split('\\');
            string inputedFileName = inputedPathArray[inputedPathArray.Length - 1].Split('.')[0]; ;
            string pathForNewFile = null;

            for (int i = 0; i < inputedPathArray.Length - 2; i++)
            {
                pathForNewFile += inputedPathArray[i] + "\\";
            }

            pathForNewFile += "Processed" + "\\" + inputedFileName + "_processed_avarage_score.txt";
            FileStream fileStream = File.Create(pathForNewFile);
            byte[] writedArray = Encoding.Default.GetBytes(WritedArray());
            fileStream.Write(writedArray, 0, writedArray.Length);
            fileStream.Close();
            fileStream.Dispose();
        }

        private string WritedArray()
        {
            string write = null;
            Student temps = null;
            int temp = 0;

            foreach (var student in studentData)
            {
                temps = student.Value;
                temp += Convert.ToInt32(temps.Score);                
            }

            write = (temp / studentData.Count).ToString();
            return write;
        }
    }
}

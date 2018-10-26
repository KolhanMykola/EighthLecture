using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EighthLecture
{
    class Duration : IStrategyStudentGroup
    {
        private string path;
        private Dictionary<int, Student> studentData;
        private readonly string newLine = Environment.NewLine;

        public Duration(string path, Dictionary<int, Student> studentData)
        {
            this.path = path;
            this.studentData = studentData;
        }

        public string Path { get => path; set => path = value; }

        public void Create()
        {
            Console.WriteLine("Hy from Duration class");
            string[] inputedPathArray = path.Split('\\');
            string inputedFileName = inputedPathArray[inputedPathArray.Length - 1].Split('.')[0]; 
            string pathForNewFile = null;

            for (int i = 0; i < inputedPathArray.Length-2; i++)
            {
                pathForNewFile += inputedPathArray[i] + "\\"; 
            }

            pathForNewFile += "Processed" + "\\" + inputedFileName + "_processed_durations.csv";
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
            string tempFirst = null, tempSecond = null;

            foreach (var student in studentData)
            {
                temps = student.Value;
                tempFirst = temps.FullName.Split(' ')[0];
                tempSecond = temps.FullName.Split(' ')[1];
                write += "First Name " + tempFirst + newLine + "Last Name " + tempSecond + newLine;                
                tempFirst = (DateTime.Parse(temps.EndTime) - DateTime.Parse(temps.StartTime)).TotalSeconds.ToString();
                write += "Duration : " + tempFirst + newLine;
                write += String.Format("{0:##(###) ###-##-##}", long.Parse(temps.PhoneNumber.Trim())) + ";" + newLine;
            }

            return write;             
        }      
    }
}

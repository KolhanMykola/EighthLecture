using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EighthLecture
{
    class GetDataFromFile
    {
        private Dictionary<int, Student> studentData;

        public GetDataFromFile()
        {
            studentData = new Dictionary<int, Student>();
        }

        internal Dictionary<int, Student> StudentData { get => studentData; }

        internal void ParseFile(FileInfo fileInfo)
        {
            FileStream readStream = null; 
            string[] data = null;
            try
            { 
                readStream = File.Open(fileInfo.FullName,FileMode.Open);
                byte[] readArray = new byte[readStream.Length];
                readStream.Read(readArray, 0, readArray.Length);                
                string textFromFile = Encoding.Default.GetString(readArray);
                data = textFromFile.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (readStream != null)
                {
                    readStream.Close();
                    readStream.Dispose();
                }

                if (SetStudentData(data))
                {
                    ContexFile file = new ContexFile(new Names(fileInfo.FullName, studentData));
                    file.ExecuteOperation();
                    file.SetStrategyStudent(new Average(fileInfo.FullName, studentData));
                    file.ExecuteOperation();
                    file.SetStrategyStudent(new Duration(fileInfo.FullName, studentData));
                    file.ExecuteOperation();
                                        
                    MoveFile(fileInfo,true);
                }
                else MoveFile(fileInfo, false);                              
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("FileNotFoundException");
                MoveFile(fileInfo, false);
            }
            catch (PathTooLongException e)
            {
                Console.WriteLine("PathTooLongException");
                MoveFile(fileInfo, false);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("UnauthorizedAccessException");
                MoveFile(fileInfo, false);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("ArgumentException. Please check data in file");
                MoveFile(fileInfo, false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MoveFile(fileInfo, false);
            }
            
        }

        private void MoveFile(FileInfo fileInfo, bool rezult)
        {
            var processedPath = Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Processed");
            var errorPath = Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Error");

            try
            {
                if (rezult) fileInfo.MoveTo(processedPath.FullName + "\\" + fileInfo.Name);                
                else fileInfo.MoveTo(errorPath.FullName + "\\" + new Random().Next(100) + fileInfo.Name);
            }
            catch (Exception ex)
            {
                fileInfo.Delete();
                Console.WriteLine(ex.Message);
            }
        }
       
        private bool SetStudentData(string[] data)
        {
            for (int i = 1; i < data.Length; i++)
            {
                string[] student = data[i].Split(';');
                RemoveSpace(ref student);
                if(student.Length == 6 && Validation.IsTime(student[0]) && 
                    Validation.IsTime(student[1]) && Validation.IsScore(student[2]) &&
                    Validation.IsPhoneNumber(student[3]) && Validation.IsFullName(student[4]) &&
                    Validation.IsDistanceLearning(student[5]))
                studentData.Add(i, new Student(student[0], student[1], student[2], student[3], student[4], student[5]));
            }

            if (studentData.Count >= 1) return true;
            else return false;
        }

        static void RemoveSpace(ref string[] input)
        {            
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsWhiteSpace(input[i], 0))
                {
                    input[i] = input[i].Remove(0, 1);                   
                }
            }
        }
    }
}

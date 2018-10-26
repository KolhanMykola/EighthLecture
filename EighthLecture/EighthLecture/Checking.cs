using System;
using System.IO;
using System.Threading;

namespace EighthLecture
{
    internal class Checking
    {
        static string pathForInput = Directory.GetCurrentDirectory() + "\\Input";
        static readonly string extension = ".csv";

        internal void Folder()
        {
            Console.WriteLine("Checking...");
            ScanFolder();
            Thread.Sleep(1000);
        }

        private void ScanFolder()
        {           
            string[] files = Directory.GetFiles(pathForInput);

            if (files.Length >= 1)
            {
                FileInfo fileInfo = null;
                foreach (string file in files)
                {
                    fileInfo = new FileInfo(file);
                    if(fileInfo.Extension == extension)
                    {
                        GetDataFromFile getDataFromFile = new GetDataFromFile();
                        getDataFromFile.ParseFile(fileInfo);                        
                    }
                }
            }
        }        
    }
}
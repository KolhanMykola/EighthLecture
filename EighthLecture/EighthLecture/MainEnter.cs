using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EighthLecture
{
    class MainEnter
    {
        static void Main(string[] args)
        {
            Checking check = new Checking();
            while (!(Console.KeyAvailable))
            {
                check.Folder();
            }

            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EighthLecture
{
    interface IStrategyStudentGroup
    {
        string Path { get; set; }
        void Create();        
    }
}

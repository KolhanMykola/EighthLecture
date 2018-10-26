using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EighthLecture
{
    class ContexFile
    {
        private IStrategyStudentGroup student;

        public ContexFile(IStrategyStudentGroup student)
        {
            this.student = student;
        }

        public void SetStrategyStudent(IStrategyStudentGroup student)
        {
            this.student = student;
        }

        public void ExecuteOperation()
        {
            student.Create();
        }
    }
}

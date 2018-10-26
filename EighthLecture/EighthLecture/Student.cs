using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EighthLecture
{
    class Student
    {
        private string startTime;
        private string endTime;
        private string score;
        private string phoneNumber;
        private string fullName;
        private string isDistanceLearning;

        public Student(string startTime, string endTime, string score, string phoneNumber, string fullName, string isDistanceLearning)
        {
            this.startTime = startTime;
            this.endTime = endTime;
            this.score = score;
            this.phoneNumber = phoneNumber;
            this.fullName = fullName;
            this.isDistanceLearning = isDistanceLearning;
        }

        public string StartTime { get => startTime; set => startTime = value; }
        public string EndTime { get => endTime; set => endTime = value; }
        public string Score { get => score; set => score = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string IsDistanceLearning { get => isDistanceLearning; set => isDistanceLearning = value; }
    }
}

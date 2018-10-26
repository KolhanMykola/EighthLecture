using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EighthLecture
{    
    public class Validation
    {
        public static bool IsTime(string input)
        {
            string pattern = @"^\d{2,2}.\d{2,2}.\d{4,4} \d{2,2}:\d{2,2}:\d{2,2}$";
            if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, pattern)) return true;
            else return false;
        }

        public static bool IsScore(string input)
        {
            string pattern = @"^(?:100|[1-9]?[0-9])$";
            if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, pattern)) return true;
            else return false;
        }

        public static bool IsPhoneNumber(string input)
        {
            string pattern = @"\d{12}";
            if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, pattern)) return true;
            else return false;
        }

        public static bool IsFullName(string input)
        {
            string pattern = @"^[A-Z][a-z]*(\s[A-Z][a-z]*)+$";
            if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, pattern)) return true;
            else return false;
        }

        public static bool IsDistanceLearning(string input)
        {            
            if (!string.IsNullOrEmpty(input) && (input.ToLower()=="no" || input.ToLower() == "yes")) return true;
            else return false;
        }
    }
}

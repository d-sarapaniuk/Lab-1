using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PL
{
    public static class Check
    {
        public static bool checkName(string str)
        {
            string temp = @"^\p{L}{1,32}$";
            Regex regex = new Regex(temp);
            if (regex.Match(str).Success) { return true; }
            return false;
        }
        public static bool checkStudentID(string str)
        {
            string temp = @"^\d{9}$";
            Regex regex = new Regex(temp);
            if (regex.Match(str).Success) { return true; }
            return false;
        }
        public static bool checkCourse(string str)
        {
            string temp = @"^[1-6]$";
            Regex regex = new Regex(temp);
            if (regex.Match(str).Success) { return true; }
            return false;
        }

    }
}

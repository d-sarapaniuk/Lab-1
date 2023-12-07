using Business_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Student : Person
    {
        public int Course { get; set; }
        public string Student_card { get; set; }
        public bool Dormitory { get; set; }
        public string Place_of_residence { get; set; }
        public Student()
        {
            studyBehaviour = new StudyAtUniversity();
            writePoemsBehaviour = new WriteFunnyPoem();
        }
        public Student(string first_Name, string last_Name, string gender, int course, string student_card, bool dormitory, string place_of_residence)
            : base (first_Name, last_Name, gender)
        {
            this.Course = course;
            this.Student_card = student_card;
            this.Dormitory = dormitory;
            this.Place_of_residence = place_of_residence;
            studyBehaviour = new StudyAtUniversity();
            writePoemsBehaviour = new WriteFunnyPoem();
        }

        public override string ToString()
        {
            string inDorms = Dormitory? "lives in dormitory" : "DOESN'T live in dormitory";
            return String.Format($"Student {First_Name} {Last_Name}, {Gender}, year {Course}, {Student_card}, {inDorms}, {Place_of_residence}");
        }
        public string ToString(bool inTable = false)
        {
            if (!inTable) return ToString();
            return String.Format("{0,-15} {1,-15} {2,-10} {3,-10} {4,-15} {5,-10} {6,-20}", First_Name, Last_Name, Gender, Course, Student_card, Dormitory, Place_of_residence);
        }
        public override void performStudy()
        {
            Console.Write($"{First_Name} {Last_Name}");
            base.performStudy();
            Course++;
            Console.WriteLine($"{First_Name} {Last_Name} is now on {Course} course!");
        }

        public override void performWritePoem()
        {
            Console.Write($"{First_Name} {Last_Name}");
            base.performWritePoem();
        }
    }
}

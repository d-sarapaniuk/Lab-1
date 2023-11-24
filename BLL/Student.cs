using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Student : Person
    {
        public override string First_Name { get; set; }
        public override string Last_Name { get; set; }
        public override string Gender { get; set; }
        public int Course { get; set; }
        public int Student_card { get; set; }
        public bool Dormitory { get; set; }
        public string Place_of_residence { get; set; }
        public Student() { }
        public Student(string first_Name, string last_Name, string gender, int course = 0, int student_card = 0, bool dormitory = false, string place_of_residence = "none")
            : base (first_Name, last_Name, gender)
        {
            this.Course = course;
            this.Student_card = student_card;
            this.Dormitory = dormitory;
            this.Place_of_residence = place_of_residence;
        }

        /*public override string ToString()
        {
            return $"First name: {First_Name}, \n" +
                $"Last name: {Last_Name}, \n" +
                $"Gender: {Gender}, \n" +
                $"Course: {Course}, \n" +
                $"Student card: {Student_card}, \n" +
                $"Dormitory: {Dormitory}, \n" +
                $"Place of residence: {Place_of_residence}.";
        }*/

        
    }
}

using DAL;
using BLL;
using PL;


namespace MainAPP

{
    internal class Program
    {
        static void Main(string[] args)
        {
            //database file path is specified in the DAL.DB class
            // DB.clean();

            /*BLL.Student student = new Student("Vasya","Pupkin", "male", 1, 123, true, "dvl");
            DB.write( student, student.Last_Name);*/


            Console.WriteLine("{0,-15} {1,-15} {2,-10} {3,-10} {4,-15} {5,-10} {6,-20}", "First name", "Last name", "Gender", "Course", "Student Card", "Dormitory", "Place of Residence");
            Console.WriteLine("{0,-15} {1,-15} {2,-10} {3,-10} {4,-15} {5,-10} {6,-20}", "John", "Smith", "male", "1", "XX12345678", "True", "11.205");
            Console.WriteLine("{0,-15} {1,-15} {2,-10} {3,-10} {4,-15} {5,-10} {6,-20}", "Emily", "Johnson", "female", "2", "XX87654321", "False", "12.345");
            Console.WriteLine("{0,-15} {1,-15} {2,-10} {3,-10} {4,-15} {5,-10} {6,-20}", "William", "Brown", "male", "3", "XX23456789", "True", "10.123");
            Console.WriteLine("{0,-15} {1,-15} {2,-10} {3,-10} {4,-15} {5,-10} {6,-20}", "Sarah", "Davis", "female", "4", "XX98765432", "False", "9.876");
            Console.WriteLine("{0,-15} {1,-15} {2,-10} {3,-10} {4,-15} {5,-10} {6,-20}", "Michael", "Wilson", "male", "5", "XX34567890", "True", "8.765");
            var v = DB_Agent.getEntities("Student Pupkin \n{\nFirst_Name: Vasya\nLast_Name: Pupkin\nGender: male\nCourse: 1\nStudent_card: 123\nDormitory: True\nPlace_of_residence: dvl\n}");



        }
    }
}
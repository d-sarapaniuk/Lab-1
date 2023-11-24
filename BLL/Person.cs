using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    //public enum genders {male, female}
    public abstract class Person
    {
        public abstract string First_Name { get; set; }
        public abstract string Last_Name { get; set; }
        public abstract string Gender { get; set; }
        public Person() { }
        public Person(string first_Name, string last_Name, string gender)
        {
            First_Name = first_Name;
            Last_Name = last_Name;
            Gender = gender;
        }



    }
}
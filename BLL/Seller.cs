using Business_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Seller : Person
    {
        public Seller() 
        {
            studyBehaviour = new SelfStudy();
            writePoemsBehaviour = new WriteSadPoem();
        }
        public Seller(string first_Name, string last_Name, string gender) : base(first_Name, last_Name, gender) 
        {
            studyBehaviour = new SelfStudy();
            writePoemsBehaviour = new WriteSadPoem();
        }

        public override string ToString()
        {
            return String.Format($"Seller {First_Name} {Last_Name}, {Gender}");
        }
        public string ToString(bool inTable)
        {
            if (!inTable) return ToString();
            return String.Format("{0,-15} {1,-15} {2,-10}", First_Name, Last_Name, Gender);
        }

        public override void performStudy()
        {
            Console.Write($"{First_Name} {Last_Name}");
            base.performStudy();
        }
        public override void performWritePoem()
        {
            Console.Write($"{First_Name} {Last_Name}");
            base.performWritePoem();
        }
    }
}
